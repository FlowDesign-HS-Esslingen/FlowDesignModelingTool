namespace FlowDesign.Model.Components.SystemEnvironment
{
    /// <summary>
    /// Komponente für einen Actor.
    /// </summary>
    /// <seealso cref="FlowDesign.Model.Components.SystemEnvironment.SystemEnvironmentComponent" />
    public class ActorComponent : SystemEnvironmentComponent
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public ActorComponent()
        {
            this.SystemEnvType = SystemEnvComponentType.Actors;
        }
    }
}
