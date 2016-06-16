using FlowDesign.Model.Components.Prototype;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für ein Mockup eines Maskenprototyps.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class MockupComponentViewModel : ComponentViewModel
    {
        /// <summary>
        /// Wrapper Property für den Bildpfad der Mockup Komponente.
        /// </summary>
        public string ImagePath
        {
            get { return ((MockupComponent)Component).ImagePath; }
            set
            {
                ((MockupComponent)Component).ImagePath = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die Mockup Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public MockupComponentViewModel(MockupComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
            PropertyDescriptions.Add(new SinglePropertyDescription("ImagePath","Pfad"));
        }
    }
}
