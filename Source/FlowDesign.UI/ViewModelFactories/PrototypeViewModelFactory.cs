using System.Collections.Generic;
using System.Linq;
using FlowDesign.Model.Components;
using FlowDesign.UI.ViewModels.ComponentViewModels;
using FlowDesign.Model.Components.Prototype;
using FlowDesign.Model;
using FlowDesign.UI.ViewModels;
using FlowDesign.Model.Components.Common;

namespace FlowDesign.UI
{
    /// <summary>
    /// Erstellt ViewModels für einen Maskenprototyp.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.IViewModelFactory" />
    public class PrototypeViewModelFactory : IViewModelFactory
    {
        /// <summary>
        /// Erstellt ein ViewModel, das zu einer Komponente passt.
        /// </summary>
        /// <param name="component">Die Komponente, für die das ViewModel erstellt werden soll.</param>
        /// <param name="parentDiagram">Das Diagramm, zudem die Komponente gehört.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite.</param>
        /// <returns>
        /// Eine Liste von ViewModels. Für eine Komponenten können mehere ViewModels erstellen z.B. Line und LinePart
        /// </returns>
        public List<ComponentViewModel> CreateViewModelsFromComponent(Component component, Diagram parentDiagram, MainPageViewModel parentViewModel)
        {
            PrototypeComponent prototypeComponent = (PrototypeComponent)component;

            if(prototypeComponent.PrototypeComponentType == PrototypeComponentTypes.Mockup)
            {
                return new List<ComponentViewModel> { new MockupComponentViewModel((MockupComponent)component, parentViewModel) };
            }

            if (prototypeComponent.PrototypeComponentType == PrototypeComponentTypes.SelfDelegation)
            {
                return new List<ComponentViewModel> { new SelfDelegationComponentViewModel((SelfDelegationComponent)component, parentViewModel) };
            }

            if(prototypeComponent.PrototypeComponentType == PrototypeComponentTypes.Delegation)
            {
                DelegationComponent delegationComponent = (DelegationComponent)component;
                LineComponent line = delegationComponent.Line;
                LinePartComponent lineStart = (LinePartComponent)parentDiagram.DiagramComponents.Where(e => e is LinePartComponent && e.ID == line.LinePartStartId).FirstOrDefault();
                LinePartComponent lineEnd = (LinePartComponent)parentDiagram.DiagramComponents.Where(e => e is LinePartComponent && e.ID == line.LinePartEndId).FirstOrDefault();

                LinePartComponentViewModel lineStartViewModel = new LinePartComponentViewModel(lineStart, parentViewModel);
                LinePartComponentViewModel lineEndViewModel = new LinePartComponentViewModel(lineEnd, parentViewModel);

                DelegationComponentViewModel lineViewModel = new DelegationComponentViewModel(delegationComponent, parentViewModel);
                lineViewModel.LinePartStartViewModel = lineStartViewModel;
                lineViewModel.LinePartEndViewModel = lineEndViewModel;

                return new List<ComponentViewModel> {lineViewModel, lineStartViewModel, lineEndViewModel };
            }


            return new List<ComponentViewModel>();
        }
    }
}
