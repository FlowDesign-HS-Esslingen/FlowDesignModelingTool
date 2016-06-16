using FlowDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign.DataAccess
{
    public interface IRepository
    {
        /// <summary>
        /// Speichert die Projektdaten und Diagramme in dem Filesystem
        /// </summary>
        /// <param name="currentProject"></param>
        /// <returns></returns>
        bool SaveProject(Project currentProject);

        /// <summary>
        /// Lädt die Projektdaten und Diagramme vom Filesystem in das Project Objekt
        /// </summary>
        /// <param name="projectInfoPath"></param>
        /// <returns></returns>
        Project LoadProject(string projectInfoPath);

        /// <summary>
        /// Speichert Config-Objekt in dem Filesystem
        /// </summary>
        /// <param name="config"></param>
        /// <param name="path">Pfad ohne Dateiname</param>
        /// <returns></returns>
        bool SaveConfig(ApplicationConfig appConfig, string path);

        /// <summary>
        /// Lädt die Config-Datei in ein Config-Objekt vom Filesystem
        /// </summary>
        /// <param name="configPath">Pfad inklusive Dateiname</param>
        /// <returns></returns>
        ApplicationConfig LoadConfig(string configPath);

        /// <summary>
        /// Löscht das angegebene Objekt aus dem Projektordner
        /// </summary>
        /// <param name="objectToDelete"></param>
        /// <param name="projectPath"></param>
        void DeleteObject(object objectToDelete, string projectPath);
    }
}
