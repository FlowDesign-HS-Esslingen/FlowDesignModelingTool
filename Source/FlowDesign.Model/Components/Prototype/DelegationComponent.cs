using FlowDesign.Model.Components.Common;
using System;

namespace FlowDesign.Model.Components.Prototype
{
    /// <summary>
    /// Komponente für eine Delegation.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Prototype.PrototypeComponent" />
    public class DelegationComponent : PrototypeComponent
    {
        /// <summary>
        /// Die Linien Komponente, die zum zeichnen der Delegation dient.
        /// </summary>
        public LineComponent Line { get; set; }

        /// <summary>
        /// ID des FlowViewDiagramms, die mit dieser Delegation verbunden ist.
        /// </summary>
        public Guid FlowViewID { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public DelegationComponent()
        {
            PrototypeComponentType = PrototypeComponentTypes.Delegation;
        }
    }
}
