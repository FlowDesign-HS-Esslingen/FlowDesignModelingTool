using System.Collections.Generic;
using System.Linq;
using FlowDesign.Model.Components;
using FlowDesign.UI.ViewModels.ComponentViewModels;
using FlowDesign.Model.Components.Common;
using FlowDesign.Model;
using FlowDesign.UI.ViewModels;

namespace FlowDesign.UI
{
    /// <summary>
    /// Erstellt ViewModels für allgemeine Diagramm Komponenten.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.IViewModelFactory" />
    public class CommonComponentViewModelFactory : IViewModelFactory
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
            CommonComponent commonComponent = (CommonComponent)component;

            if(commonComponent.CommonComponentType == CommonComponentTypes.Comment )
            {
                return new List<ComponentViewModel> { new CommentComponentViewModel((CommentComponent)component, parentViewModel) };
            }

            if(commonComponent.CommonComponentType == CommonComponentTypes.Text)
            {
                return new List<ComponentViewModel> { new TextComponentViewModel((TextComponent)component, parentViewModel) };
            }


            if (commonComponent.CommonComponentType == CommonComponentTypes.Line)
            {
                LineComponent line = (LineComponent)component;
                LinePartComponent lineStart = (LinePartComponent)parentDiagram.DiagramComponents.Where(e => e is LinePartComponent && e.ID == line.LinePartStartId).FirstOrDefault();
                LinePartComponent lineEnd = (LinePartComponent)parentDiagram.DiagramComponents.Where(e => e is LinePartComponent && e.ID == line.LinePartEndId).FirstOrDefault();

                LinePartComponentViewModel lineStartViewModel = new LinePartComponentViewModel(lineStart, parentViewModel);
                LinePartComponentViewModel lineEndViewModel = new LinePartComponentViewModel(lineEnd, parentViewModel);

                LineComponentViewModel lineViewModel = new LineComponentViewModel(line, parentViewModel);
                lineViewModel.LinePartStartViewModel = lineStartViewModel;
                lineViewModel.LinePartEndViewModel = lineEndViewModel;

                return new List<ComponentViewModel> { lineStartViewModel, lineEndViewModel, lineViewModel };
            }

            return new List<ComponentViewModel>();
        }
    }
}
