namespace FlowDesign.Model.Components.SystemEnvironment
{
    /// <summary>
    /// System Komponennte.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.SystemEnvironment.SystemEnvironmentComponent" />
    public class SystemComponent : SystemEnvironmentComponent
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public SystemComponent()
        {
            this.SystemEnvType = SystemEnvComponentType.System;
            Name = "System";
        }
    }
}
