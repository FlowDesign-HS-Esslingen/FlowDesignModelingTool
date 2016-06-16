using System;

namespace FlowDesign.Model.Components.Prototype
{
    /// <summary>
    /// Komponente für eine Selbstdelegation.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Prototype.PrototypeComponent" />
    public class SelfDelegationComponent : PrototypeComponent
    {
        /// <summary>
        /// ID des FlowViewDiagramms, die mit dieser Delegation verbunden ist.
        /// </summary>
        public Guid FlowViewID { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SelfDelegationComponent()
        {
            PrototypeComponentType = PrototypeComponentTypes.SelfDelegation;
        }

    }
}
