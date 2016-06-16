using FlowDesign.DataAccess;
using FlowDesign.Model;
using System;

namespace FlowDesign.Service.Application
{
    /// <summary>
    /// Verwaltet alles was allgemein mit der Anwendung zu tun hat.
    /// </summary>
    public static class ApplicationService
    {
        /// <summary>
        /// Die Config.
        /// </summary>
        private static ApplicationConfig config = null;

        /// <summary>
        /// Pfad unter dem die Config gespeichert werden soll.
        /// </summary>
        public static string ConfigFilepath { get; set; } = string.Empty;

        /// <summary>
        /// Lädt die Config.
        /// </summary>
        /// <returns>Die Config.</returns>
        public static ApplicationConfig LoadConfig()
        {
            config = DataAccessProvider.GetRepository(DataAccessType.Local).LoadConfig(ConfigFilepath);

            return config;
        }

        /// <summary>
        /// Speichert die Config, unter dem im ApplicationService angegeben ConfigFilePath.
        /// </summary>
        public static void SaveConfig()
        {
            DataAccessProvider.GetRepository(DataAccessType.Local).SaveConfig(config, ConfigFilepath);
        }

        /// <summary>
        /// Gibt die Config zurück, ohne sie neu zu laden.
        /// </summary>
        /// <returns>Die Config.</returns>
        /// <exception cref="System.ArgumentNullException">Config wurde noch nicht geladen</exception>
        public static ApplicationConfig GetConfig()
        {
            if(config == null)
            {
                throw new ArgumentNullException("Config wurde noch nicht geladen");
            }

            return config;
        }

        /// <summary>
        /// Fügt der Config ein kürzlich geöffnetes Projekt hinzu.
        /// </summary>
        /// <param name="project">Das Projekt, das kürzlich geöffnet wurde.</param>
        public static void AddRecentlyUsed(RecentlyUsedProject project)
        {
            if (!config.RecentlyUsedProjects.Contains(project))
            {
                config.RecentlyUsedProjects.Add(project);
            }
        }
    }
}
