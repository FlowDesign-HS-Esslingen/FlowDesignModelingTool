using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace FlowDesign.UI.Helper
{
    /// <summary>
    /// Verwaltet Pages.
    /// </summary>
    public class PageManager
    {
        private Dictionary<string, Page> pages = new Dictionary<string, Page>();
        public Frame FrameControl { get; set; } = null;

        /// <summary>
        /// Registriert eine Page, damit auf sie später gewechselt werden kann.
        /// </summary>
        /// <param name="page">Die Page die hinzugefügt werden soll.</param>
        /// <param name="name">Der Name der später zum wechsel auf die Seite benutzt werden soll.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public void RegisterPage(Page page, string name)
        {
            if(pages.ContainsKey(name))
            {
                throw new ArgumentException($"{name} ist bereits im PageManager registriert.");
            }

            pages.Add(name, page);
        }

        /// <summary>
        /// Gibt eine Page anhand eines Namens zurück.
        /// </summary>
        /// <param name="name">Der Name der Page, mit sie registriert wurde..</param>
        /// <returns>Die Page</returns>
        /// <exception cref="System.ArgumentException">Wird ausgelöst, wenn keine Page mit dem Namen existiert.</exception>
        public Page GetPage(string name)
        {
            if (!pages.ContainsKey(name))
            {
                throw new ArgumentException($"{name} ist nicht im PageManager registriert.");
            }

            return pages[name];
        }

        /// <summary>
        /// Wechselt zu einer Page.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.ArgumentNullException">Dem PageManager wurde kein Frame hinzugefügt.</exception>
        public void SwitchPageByName(string name)
        {
            if (!pages.ContainsKey(name))
            {
                throw new ArgumentException($"{name} ist nicht im PageManager registriert.");
            }


            if(FrameControl == null)
            {
                throw new ArgumentNullException("Dem PageManager wurde kein Frame hinzugefügt.");
            }

            Page selectedPage = pages.First(e => e.Key == name).Value;
            FrameControl.NavigationService.Navigate(selectedPage);

        }
    }
}
