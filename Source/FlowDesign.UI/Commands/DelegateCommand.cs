using System;
using System.Windows.Input;

namespace FlowDesign.UI.Commands
{
    /// <summary>
    /// Ein allgemeins Kommando für WPF.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// Tritt ein, wenn Änderungen auftreten, die sich auf die Ausführung des Befehls auswirken.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Tritt ein, wenn das Kommando ausgeführt wird.
        /// </summary>
        public event EventHandler OnExecute;

        /// <summary>
        /// Predicate, das festlegt, ob das Kommando ausgeführt werden kann.
        /// </summary>
        private Predicate<object> canExecute;

        /// <summary>
        /// Action, die die aufgerufen wird, wenn das Kommando ausgeführt wird.
        /// </summary>
        private Action<object> execute;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="canExecute">Predicate, das festlegt, ob das Kommando ausgeführt werden kann.</param>
        /// <param name="execute">Action, die die aufgerufen wird, wenn das Kommando ausgeführt wird.</param>
        public DelegateCommand(Predicate<object> canExecute, Action<object> execute)
        {
            this.canExecute = canExecute;
            this.execute = execute;
        }

        /// <summary>
        /// Definiert die Methode, die bestimmt, ob der Befehl im aktuellen Zustand ausgeführt werden kann.
        /// </summary>
        /// <param name="parameter">Vom Befehl verwendete Daten. Wenn der Befehl keine Datenübergabe erfordert, kann das Objekt auf null festgelegt werden.</param>
        /// <returns>
        /// true, wenn der Befehl ausgeführt werden kann, andernfalls false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;

            return canExecute(parameter);
        }

        /// <summary>
        /// Definiert die Methode, die aufgerufen wird, wenn der Befehl aufgerufen wird.
        /// </summary>
        /// <param name="parameter">Vom Befehl verwendete Daten.Wenn der Befehl keine Datenübergabe erfordert, kann das Objekt auf null festgelegt werden.</param>
        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
            OnExecute?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Zeigt an, dass sich der ausführbarkeits Status des Kommandos geändert hat.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
