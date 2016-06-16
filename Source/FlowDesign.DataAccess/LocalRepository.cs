using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowDesign.Model;
using System.Xml;
using System.IO;
using FlowDesign.DataAccess.Converter;
using FlowDesign.Model.Flow;

namespace FlowDesign.DataAccess
{
    /// <summary>
    /// Speichert ein <see cref="FlowDesign.Model.Project"/> oder <see cref="FlowDesign.Model.ApplicationConfig"/> auf der Festplatte
    /// </summary>
    internal class LocalRepository : IRepository
    {
        private IProjectConverter converter;
        public LocalRepository(IProjectConverter converter)
        {
            this.converter = converter;
        }

        public Project LoadProject(string projectInfoPath)
        {
            Project tmpProject = new Project();
            if (!File.Exists(projectInfoPath))
                return null;

            string[] files = GetPathOfFilesInFolder(GetFolderFromProjectInfoPath(projectInfoPath));

            try
            {
                foreach (string filePath in files)
                {
                    if (Path.GetExtension(filePath) == ".flow")
                        tmpProject.Info = converter.ConvertObjectBack<ProjectInfo>(File.ReadAllText(filePath));
                    else if (Path.GetExtension(filePath) == ".diag")
                        tmpProject.Diagrams.Add(converter.ConvertObjectBack<Diagram>(File.ReadAllText(filePath)));
                }

                return tmpProject;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public bool SaveProject(Project currentProject)
        {
            short checksum = 0;

            CreateProjectFolder(currentProject.Info.Filepath);
            checksum += SaveOnDisk(converter.ConvertObject(currentProject.Info), currentProject.Info.Filepath, CreateFilenameFromType(currentProject.Info));

            foreach (Diagram diagram in currentProject.Diagrams)
            {
                checksum += SaveOnDisk(converter.ConvertObject(diagram), currentProject.Info.Filepath, CreateFilenameFromType(diagram));
            }

            if (checksum == 0)
                return true;
            else
                return false;
        }

        public ApplicationConfig LoadConfig(string configPath)
        {
            ApplicationConfig tmpConfig = new ApplicationConfig();

            configPath += CreateFilenameFromType(tmpConfig);

            if (!File.Exists(configPath))
                return tmpConfig; //Wenn keine Config vohanden, wird neue leer zurückgegeben (für Validator)

            try
            {
                if (Path.GetExtension(configPath) == ".cfg")
                    tmpConfig = converter.ConvertObjectBack<ApplicationConfig>(File.ReadAllText(configPath));

                return tmpConfig;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public bool SaveConfig(ApplicationConfig config, string path)
        {
            short checksum = 0;
            checksum += SaveOnDisk(converter.ConvertObject(config), path, CreateFilenameFromType(config));

            if (checksum == 0)
                return true;
            else
                return false;
        }

        private string CreateFilenameFromType(object objectType)
        {
            string tmpName = objectType.GetType().ToString();
            tmpName = RemoveNamespacesFromName(tmpName);

            if (objectType.GetType() == typeof(ProjectInfo))
                return $"{tmpName}.flow";
            else if (objectType.GetType().BaseType.BaseType == typeof(Diagram))
                return $"{tmpName}-{((Diagram)objectType).Name}.diag";
            else if (objectType.GetType() == typeof(ApplicationConfig))
                return $"{tmpName}.cfg";
            else
                return $"{tmpName}";
        }

        private string RemoveNamespacesFromName(string name)
        {
            return name.Substring(name.LastIndexOf('.') + 1);
        }

        private void CreateProjectFolder(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Erstellen von {path}. \n({ex.ToString()})");
            }
        }

        private short SaveOnDisk(string data, string path, string fileName)
        {
            try
            {
                StreamWriter writer = new StreamWriter($"{path}/{fileName}");
                writer.Write(data);
                writer.Close();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Speichern von {fileName} unter {path} fehlgeschlagen. \n({ex.ToString()})");
                return -1;
            }

        }

        private string[] GetPathOfFilesInFolder(string folderPath)
        {
            return Directory.GetFiles(folderPath);
        }

        private string GetFolderFromProjectInfoPath(string path)
        {
            return Path.GetDirectoryName(path);
        }

        public void DeleteObject(object objectToDelete, string projectPath)
        {
            string filename = CreateFilenameFromType(objectToDelete);
            if (File.Exists($"{projectPath}/{filename}"))
            {
                File.Delete($"{projectPath}/{filename}");
            }
        }
    }
}
