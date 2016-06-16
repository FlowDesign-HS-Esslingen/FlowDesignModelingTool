namespace FlowDesign.Model.Components.Prototype
{
    /// <summary>
    /// Komponente für ein Mockup.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.Prototype.PrototypeComponent" />
    public class MockupComponent : PrototypeComponent
    {
        /// <summary>
        /// Pfad für das Mockup Bild.
        /// </summary>
        public string ImagePath { get; set; } = "../Resources/Images/Test/TestMockup.png";

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public MockupComponent()
        {
            PrototypeComponentType = PrototypeComponentTypes.Mockup;
        }
    }
}
