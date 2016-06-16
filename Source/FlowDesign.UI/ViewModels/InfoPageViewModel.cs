using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign.UI.ViewModels
{
    /// <summary>
    /// ViewModel für das InfoPanel auf der rechten Seite der Startseite.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ViewModelBase" />
    public class InfoPageViewModel : ViewModelBase
    {
        private string einleitungsText;
        public string EinleitungsText
        {
            get { return einleitungsText; }
            set { einleitungsText = value; RaisePropertyChanged(); }
        }

        private string neuigkeitenText;
        public string NeuigkeitenText
        {
            get { return neuigkeitenText; }
            set { neuigkeitenText = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public InfoPageViewModel()
        {
            EinleitungsText = @"Ein intelligent entwickeltes Tool zur grafischen Erstellung von Flow Design Diagrammen.
Planen Sie ihr Projekt auf Basis der nächsten Generation von Clean Software durch Verringerung von Abhängigkeiten und Strukturierung klarer Datenflüsse.

„Expliziter Softwareentwurf hilft mithin nicht nur dem Code, sondern auch dem Team.“
(Ralf Westphal)";

            NeuigkeitenText = @"Version 0.1
    Projekt erstellen
    Projekt laden
    Zuletzt geöffnete Projekte laden

Version 0.2
    System-Umwelt-Diagramm

Version 0.3
    Maskenprototyp

Version 0.4
    FlowView-Diagramm";
        }
    }
}
