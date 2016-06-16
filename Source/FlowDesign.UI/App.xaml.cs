using FlowDesign.Model;
using FlowDesign.Service.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FlowDesign.UI
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ApplicationService.ConfigFilepath = System.AppDomain.CurrentDomain.BaseDirectory;
            ApplicationService.LoadConfig();
            ApplicationService.SaveConfig();
        }
    }
}
