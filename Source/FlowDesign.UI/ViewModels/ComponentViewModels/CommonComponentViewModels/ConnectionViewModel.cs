using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows;
using FlowDesign.UI.Controls.Components;
using FlowDesign.Model.Flow;
using FlowDesign.Model.Components.Common;
using FlowDesign.Model.Components.SystemEnvironment;
using System;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für eine Verbindung.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class ConnectionViewModel : ComponentViewModel
    {
        /// <summary>
        /// Die Geometry für die Verbindungs-Linie.
        /// </summary>
        private PathGeometry geometry;
        
        /// <summary>
        /// Die Geometry für die Verbindungs-Linie.
        /// </summary>
        public PathGeometry Geometry
        {
            get { return geometry; }
            private set { geometry = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Der Connector, der als Source dient.
        /// </summary>
        private Connector sourceConnector = null;
       
        /// <summary>
        /// Der Connector, der als Source dient.
        /// </summary>
        public Connector SourceConnector
        {
            get { return sourceConnector; }
            set { sourceConnector = value; }
        }

        /// <summary>
        /// Der Connector, der als Target dient.
        /// </summary>
        private Connector targetConnector = null;
      
        /// <summary>
        /// Der Connector, der als Target dient.
        /// </summary>
        public Connector TargetConnector
        {
            get { return targetConnector; }
            set { targetConnector = value; }
        }

        /// <summary>
        /// Die Geometry für das Ende die Verbindungs-Linie.
        /// </summary>
        private Geometry geometryEnd;
      
        /// <summary>
        /// Die Geometry für das Ende die Verbindungs-Linie.
        /// </summary>
        public Geometry GeometryEnd
        {
            get { return geometryEnd; }
            private set { geometryEnd = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die Verbindungs Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public ConnectionViewModel(ConnectionComponent component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
            component.UIProperties.Width = 1920;
            component.UIProperties.Height = 1080;
        }

        /// <summary>
        /// Aktuallisiert die Geometry der Verbindungs-Linie.
        /// </summary>
        public void UpdatePath()
        {
            if (SourceConnector == null || TargetConnector == null)
                return;

            PathGeometry geometry = new PathGeometry();
            List<Point> linePoints = new List<Point>()
            {
                TargetConnector.Position
             };

            PathFigure figure = new PathFigure();
            figure.StartPoint = SourceConnector.Position;

            figure.Segments.Add(new PolyLineSegment(linePoints, true));
            geometry.Figures.Add(figure);

            Geometry = geometry;

            if (ParentViewModel.CurrentDiagram is SystemEnvDiagram && UseConnectorEndSystem())
            {
                GeometryEnd = new EllipseGeometry(TargetConnector.Position, 10, 10);
            }
            else if(ParentViewModel.CurrentDiagram is FlowViewDiagram)
            {
                GeometryEnd = new EllipseGeometry(TargetConnector.Position, 10, 10);
            }

        }

        /// <summary>
        /// Überprüft ob der Connector in einem System-Umwelt Diagramm ein spezielles Ende hat.
        /// </summary>
        private bool UseConnectorEndSystem()
        {
            ConnectionComponent connection = (ConnectionComponent)Component;

            Model.Components.Component source = ParentViewModel.CurrentComponents.Where(e => e.Component.ID == connection.SourceComponentID).Select(e => e.Component).FirstOrDefault();
            Model.Components.Component target = ParentViewModel.CurrentComponents.Where(e => e.Component.ID == connection.TargetComponentID).Select(e => e.Component).FirstOrDefault();

            if(source is ActorComponent || source is AdapterComponent || source is ResourceComponent || source is SystemComponent)
            {
                if (target is ActorComponent || target is AdapterComponent || target is ResourceComponent || target is SystemComponent)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
