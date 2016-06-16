using System;
using System.Collections.Generic;

namespace FlowDesign.Model
{
    /// <summary>
    /// Die Config der Anwendung.
    /// </summary>
    [Serializable]
    public class ApplicationConfig
    {
        public List<RecentlyUsedProject> RecentlyUsedProjects { get; set; } = new List<RecentlyUsedProject>();
    }
}
