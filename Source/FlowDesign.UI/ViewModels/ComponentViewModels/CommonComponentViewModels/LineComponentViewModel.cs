using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows;
using FlowDesign.Model.Components;

namespace FlowDesign.UI.ViewModels.ComponentViewModels
{
    /// <summary>
    /// ViewModel für eine Linie.
    /// </summary>
    /// <seealso cref="FlowDesign.UI.ViewModels.ComponentViewModels.ComponentViewModel" />
    public class LineComponentViewModel : ComponentViewModel
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
        /// Die Geometry für das Element, das die Richtung anzeigt.
        /// </summary>
        private Geometry directionGeometry;

        /// <summary>
        /// Die Geometry für das Element, das die Richtung anzeigt.
        /// </summary>
        public Geometry DirectionGeometry
        {
            get { return directionGeometry; }
            private set { directionGeometry = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// Farbe der Linie.
        /// </summary>
        private Brush strokeColor = Brushes.Red;

        /// <summary>
        /// Farbe der Linie.
        /// </summary>
        public Brush StrokeColor
        {
            get { return strokeColor; }
            set { strokeColor = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// ViewModel des Anfassers für den Start der Linie.
        /// Wird für die berechnung der Linie gebraucht.
        /// </summary>
        private LinePartComponentViewModel linePartStartViewModel;

        /// <summary>
        /// ViewModel des Anfassers für den Start der Linie.
        /// Wird für die berechnung der Linie gebraucht.
        /// </summary>
        public LinePartComponentViewModel LinePartStartViewModel
        {
            get { return linePartStartViewModel; }
            set {linePartStartViewModel = AssignLinePartViewModel(linePartStartViewModel, value);}
        }

        /// <summary>
        /// ViewModel des Anfassers für das Ende der Linie.
        /// Wird für die berechnung der Linie gebraucht.
        /// </summary>
        private LinePartComponentViewModel linePartEndViewModel;

        /// <summary>
        /// ViewModel des Anfassers für das Ende der Linie.
        /// Wird für die berechnung der Linie gebraucht.
        /// </summary>
        public LinePartComponentViewModel LinePartEndViewModel
        {
            get { return linePartEndViewModel; }
            set
            {
                linePartEndViewModel = AssignLinePartViewModel(linePartEndViewModel, value);
            }
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="component">Die Komponente, die dem ViewModel zugeordnet werden soll.</param>
        /// <param name="parentViewModel">Das ViewModel der Hauptseite, darf nicht null sein.</param>
        public LineComponentViewModel(Component component, MainPageViewModel parentViewModel) : base(component, parentViewModel)
        {
            component.UIProperties.Width = 1920;
            component.UIProperties.Height = 1080;
        }

        /// <summary>
        /// Tritt ein, wenn sich die Position eines Anfassers der Linie ändert.
        /// </summary>
        /// <param name="sender">Die Quelle des Events.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/>Event Daten</param>
        private void LinePartPosition_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Position"))
            {
                UpdateLine();
            }
        }

        /// <summary>
        /// Aktualisiert die Geometry der Linie.
        /// </summary>
        private void UpdateLine()
        {
            if (LinePartStartViewModel == null || LinePartEndViewModel == null)
            {
                return;
            }

            ZIndex = Math.Max(LinePartStartViewModel.ZIndex, LinePartEndViewModel.ZIndex) - 1;

            PathGeometry geometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            figure.StartPoint = LinePartStartViewModel.Position;

            figure.Segments.Add(new PolyLineSegment(new List<Point> { LinePartEndViewModel.Position }, true));

            geometry.Figures.Add(figure);

            Geometry = geometry;

            DirectionGeometry = new EllipseGeometry(LinePartEndViewModel.Position, 10, 10);
        }

        /// <summary>
        /// Wenn ein LinePartViewModel gesetzt werden soll, muss diese Methode verwendet werden.
        /// Diese Methode fügt bei Bedarf einen EventListener für das PropertyChanged Event der Positions Property der LineParts.
        /// Daruch wird eine doppel registrierung der EventListener verhindert.
        /// </summary>
        /// <param name="oldValue">Der alte Wert des LinePartViewModels.</param>
        /// <param name="newValue">Der neue Wert des LinePartViewModels.</param>
        /// <returns>Ein LinePartComponentViewModel mit richtig zugewiesenen EventListener.</returns>
        private LinePartComponentViewModel AssignLinePartViewModel(LinePartComponentViewModel oldValue, LinePartComponentViewModel newValue)
        {
            // Nur zuweisen, wenn tatsächlich ein neuer Wert zugewiesen wird.
            if (oldValue != newValue)
            {
                // Wenn linePart schon existiert, den EventHandler löschen, damit nicht endlos viele registriert sind.
                if (oldValue != null)
                {
                    oldValue.PropertyChanged -= LinePartPosition_PropertyChanged;
                }

                oldValue = newValue;

                if (newValue != null)
                {
                    oldValue.PropertyChanged += LinePartPosition_PropertyChanged;
                }
            }

            return oldValue;
        }
    }
}
