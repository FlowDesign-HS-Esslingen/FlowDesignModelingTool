using System;
namespace FlowDesign.Model.Components.FlowView
{
    /// <summary>
    /// Komponente für ein Modul.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.FlowView.FlowViewComponent" />
    public class ModulComponent : FlowViewComponent
    {
        /// <summary>
        /// ID des Parent Moduls.
        /// </summary>
        public Guid ParentID { get; set; }

        /// <summary>
        /// ID des Kind Moduls.
        /// </summary>
        public Guid ChildID { get; set; }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ModulComponent()
        {
            FlowViewType = FlowViewTypes.Modul;
        }
    }
}
