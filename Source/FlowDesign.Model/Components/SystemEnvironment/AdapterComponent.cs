namespace FlowDesign.Model.Components.SystemEnvironment
{
    /// <summary>
    /// Komponente für einen Adapter.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.SystemEnvironment.SystemEnvironmentComponent" />
    public class AdapterComponent : SystemEnvironmentComponent
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public AdapterComponent()
        {
            this.SystemEnvType = SystemEnvComponentType.Adapter;
        }
    }
}
