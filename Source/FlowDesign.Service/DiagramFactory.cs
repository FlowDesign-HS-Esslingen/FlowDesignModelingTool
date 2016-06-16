using FlowDesign.Model;
using FlowDesign.Service.Diagrams;
using System;
using System.Collections.Generic;

namespace FlowDesign.Service
{
    /// <summary>
    /// Factory um Diagramm zu erstellen.
    /// </summary>
    public class DiagramFactory
    {
        /// <summary>
        /// Enthält alle Diagrammtypen mit iheren zugehörigen Factories.    
        /// </summary>
        private Dictionary<Type, IDiagramStrategy> DiagramDictionary = null;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public DiagramFactory()
        {
            DiagramDictionary = new Dictionary<Type, IDiagramStrategy>();
        }

        /// <summary>
        /// Registriert für einen Diagramm Typ eine Factory.
        /// </summary>
        /// <param name="DiagramType">Typ des Diagramms.</param>
        /// <param name="DiagramFactory">Factory die zum Typ des Diagramms passt.</param>
        /// <exception cref="System.ArgumentException">Wird ausgelöst, wenn für einen Typ bereits eine Factory existiert.</exception>
        public void Register(Type DiagramType, IDiagramStrategy DiagramFactory)
        {
            if (!DiagramDictionary.ContainsKey(DiagramType))
                DiagramDictionary.Add(DiagramType, DiagramFactory);
            else
                throw new ArgumentException("Diagramm Typ " + DiagramType + " ist bereits registriert.");
        }

        /// <summary>
        /// Erstellt ein Diagramm.
        /// </summary>
        /// <typeparam name="T">Der Typ des Diagramms.</typeparam>
        /// <param name="name">Der Name, der dem Diagramm zugewiesen werden soll.</param>
        /// <returns>Das erstellte Diagramm.</returns>
        /// <exception cref="System.ArgumentException">Wird ausgelöst, wenn für den Diagramm Typ keine Factory existiert.</exception>
        public Diagram CreateDiagram<T> (string name)
        {
            if (!DiagramDictionary.ContainsKey(typeof(T)))
                throw new ArgumentException("Diagramm Typ " + typeof(T) + " ist nicht registriert.");

            return DiagramDictionary[typeof(T)].CreateEmptyDiagram(name);
        }
    }
}
