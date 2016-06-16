using System;
using System.Collections.Generic;

namespace FlowDesign.Service
{
    /// <summary>
    /// Enthält Argumente, die einer Validierung zur Überprüfung übergeben werden können.
    /// </summary>
    public class ValidationParameters
    {
        /// <summary>
        /// Die Argumente die in der Validierung überprüft werden sollen. 
        /// </summary>
        public List<object> Arguments { get; } = new List<object>();

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="arguments">Die Argumente, die bei der Validierung überprüft werden sollen.</param>
        public ValidationParameters(params object[] arguments)
        {
            Arguments.AddRange(arguments);
        }
    }

    /// <summary>
    /// Klasse, die hilft gleiche Validierungen zu kapseln.
    /// </summary>
    public class Validation
    {
        private Func<bool> validation;
        private Func<ValidationParameters, bool> validationWithInput;

        /// <summary>
        /// Die Nachrichten, die während der Validierung ausgeben wurden.
        /// </summary>
        public List<string> ValidationMessages { get; set; } = new List<string>();

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="validationExpression">Action, die die Validierung enthält.</param>
        public Validation(Func<bool> validationExpression)
        {
            validation = validationExpression;
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="validationExpression">Funktion, die die Validierung enthält und ValidationParameters als Übergabeparameter erhält.</param>
        public Validation(Func<ValidationParameters, bool> validationExpression)
        {
            validationWithInput = validationExpression;
        }

        /// <summary>
        /// Führt die Validierung aus.
        /// </summary>
        public bool Validate(ValidationParameters parameters = null)
        {
            ValidationMessages.Clear();

            if(validation != null)
            {
                return validation.Invoke();
            }

            if(validationWithInput != null && parameters != null)
            {
                return validationWithInput.Invoke(parameters);
            }

            return validation.Invoke();
        }
    }
}
