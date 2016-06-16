namespace FlowDesign.Model.Components.SystemEnvironment
{
    /// <summary>
    /// Komponente für eine Resource.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.SystemEnvironment.SystemEnvironmentComponent" />
    public class ResourceComponent : SystemEnvironmentComponent
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ResourceComponent()
        {
            this.SystemEnvType = SystemEnvComponentType.Resources;
        }
    }
}
