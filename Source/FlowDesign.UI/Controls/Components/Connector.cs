using FlowDesign.Model.Components.Common;
using FlowDesign.UI.Helper;
using FlowDesign.UI.ViewModels.ComponentViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FlowDesign.UI.Controls.Components
{
    /// <summary>
    /// Die Argumente die von Drag Start zum Drop übergeben werden sollen.
    /// </summary>
    public class ConnectionDragArgs
    {
        public ComponentContainerControl SourceContainer;
        public Connector SourceConnector;
        public Point Position;

        public ConnectionDragArgs(ComponentContainerControl sourceContainer, Point position, Connector sourceConnector)
        {
            SourceContainer = sourceContainer;
            Position = position;
            SourceConnector = sourceConnector;
        }
    }

    /// <summary>
    /// Ein Verbinder, der an einer Komponente hängt.
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Control" />
    public class Connector : Control
    {
        /// <summary>
        /// Intern werden alle Connections gespeichert, damit bei einem Layout Update die Positionen der Connectoren auf die Linien übertragen werden können.
        /// </summary>
        public static List<ConnectionViewModel> AllConnections = new List<ConnectionViewModel>();

        /// <summary>
        /// Die aktuelle Position des Connectors.
        /// </summary>
        public Point Position
        {
            get
            {
                ItemsControl itemsControl = GetParentItemsControl(this);

                if(itemsControl != null)
                {
                    return this.TransformToAncestor(itemsControl).Transform(new Point(15.0 * 0.5, 15.0 * 0.5));
                }

                return new Point(0, 0);
            }
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        public Connector()
        {
            MouseMove += Connector_MouseMove;
            Drop += Connector_Drop;
            Initialized += Connector_Initialized;
            Loaded += Connector_Loaded;

            base.LayoutUpdated += Connector_LayoutUpdated;
        }

        /// <summary>
        /// Event das ausgelöst wird, wenn das Element vollständig initialisiert ist.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void Connector_Initialized(object sender, EventArgs e)
        {
            ComponentViewModel viewModel = GetComponentViewModelFromControl(this as Control);
            viewModel.Connections.OnItemAdded += Connections_OnItemAdded;
        }

        /// <summary>
        /// Event das ausgelöst wird, wenn das Element vollständig geladen ist.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void Connector_Loaded(object sender, RoutedEventArgs e)
        {
            ComponentViewModel viewModel = GetComponentViewModelFromControl(this as Control);
            foreach (ConnectionComponent component in viewModel.Connections)
            {
                CreateConnection(component);
            }
        }

        /// <summary>
        /// Event das ausgelöst wird, wenn einem ComponentViewModel eine Connection hinzugefügt wird.
        /// </summary>
        /// <param name="component">Die Verbindung die hinzugefügt wurde.</param>
        private void Connections_OnItemAdded(ConnectionComponent component)
        {
            CreateConnection(component);
        }

        /// <summary>
        /// Fügt diesem Connector eine Connection hinzu.
        /// </summary>
        /// <param name="component">Die Verbindungskomponente.</param>
        private void CreateConnection(ConnectionComponent component)
        {
            /* ----- INFO -----
           * Die ViewModels enthalten zwar die ConnectionComponent mit SourceComponent und TargetComponent, aber
           * es fehlen die Connector UI Elemente, damit sich das Layout anpasst.
           */

            ComponentViewModel viewModel = GetComponentViewModelFromControl(this as Control);

            // Source hinzufügen.
            if (viewModel.Component.ID == component.SourceComponentID)
            {
                if (GetDirection(this) == component.SourceDirection)
                {
                    // Überprüfen ob schon ein ViewModel existiert um doppelungen zu verhinden.
                    if (ExistsConnection(component))
                    {
                        // Wenn schon ein ViewModel mit der ConnectionComponent existiert, den Connector setzten, damit die Position für die Verbindung berechnet werden können.
                        // Der Connector MUSS dem ViewModel hinzugefügt werden, sonst werden die Verbindungen nicht verschoben, wenn sich das Layout updated.
                        ConnectionViewModel sourceViewModel = GetExistingConnection(component);
                        sourceViewModel.SourceConnector = this;
                        sourceViewModel.UpdatePath();
                    }
                    else
                    {
                        // Wenn kein ViewModel mit der ConnectionComponent existiert, ein neues anlegen.
                        ConnectionViewModel createdVM = new ConnectionViewModel(component, viewModel.ParentViewModel);
                        createdVM.SourceConnector = this;

                        AllConnections.Add(createdVM);
                        viewModel.ParentViewModel.CurrentComponents.Add(createdVM);

                    }
                }
            }

            // Target hinzufügen.
            if (viewModel.Component.ID == component.TargetComponentID)
            {
                if (GetDirection(this) == component.TargetDirection)
                {
                    // Überprüfen ob schon ein ViewModel existiert um doppelungen zu verhinden.
                    if (ExistsConnection(component))
                    {
                        // Wenn schon ein ViewModel mit der ConnectionComponent existiert, den Connector setzten, damit die Position für die Verbindung berechnet werden können.
                        // Der Connector MUSS dem ViewModel hinzugefügt werden, sonst werden die Verbindungen nicht verschoben, wenn sich das Layout updated.
                        ConnectionViewModel targetViewModel = GetExistingConnection(component);
                        targetViewModel.TargetConnector = this;
                        targetViewModel.UpdatePath();
                    }
                    else
                    {
                        // Wenn kein ViewModel mit der ConnectionComponent existiert, ein neues anlegen.
                        ConnectionViewModel createdVM = new ConnectionViewModel(component, viewModel.ParentViewModel);
                        createdVM.TargetConnector = this;

                        AllConnections.Add(createdVM);
                        viewModel.ParentViewModel.CurrentComponents.Add(createdVM);
                    }
                }
            }
        }

        /// <summary>
        /// Überprüft ob es schon ein ViewModel mit der ConnectionComponent gibt.
        /// </summary>
        /// <param name="component">Die Komponente.</param>
        /// <returns>True falls es schon ein ViewModel gibt.s</returns>
        private bool ExistsConnection(ConnectionComponent component)
        {
            return AllConnections.Any(e =>
            {
                ConnectionComponent comp = (ConnectionComponent)e.Component;

                if (comp.TargetComponentID == component.TargetComponentID && comp.SourceComponentID == component.SourceComponentID)
                    return true;

                return false;
            });
        }

        /// <summary>
        /// Holt aus dem Connector die Seite auf der er sitzt.
        /// </summary>
        /// <param name="connector">Der Connector.</param>
        /// <returns>Die Richtung auf der der Connector sitzt.</returns>
        private ConnectionDirection GetDirection(Connector connector)
        {
            switch (connector.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    return ConnectionDirection.Left;
                case HorizontalAlignment.Right:
                    return ConnectionDirection.Right;
            }

            switch (connector.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    return ConnectionDirection.Top;
                case VerticalAlignment.Bottom:
                    return ConnectionDirection.Bottom;
            }

            return ConnectionDirection.Undefined;
        }

        /// <summary>
        /// Holt das ViewModel, dass eine bestimmte ConnectionComponent besitzt.
        /// </summary>
        /// <param name="component">Die Komponente, für das ViewModel geholt werden soll.</param>
        /// <returns>Das ConnectionViewModel</returns>
        private ConnectionViewModel GetExistingConnection(ConnectionComponent component)
        {
            ConnectionViewModel result = AllConnections.Where(e =>
            {
                ConnectionComponent comp = (ConnectionComponent)e.Component;

                if (comp.TargetComponentID == component.TargetComponentID && comp.SourceComponentID == component.SourceComponentID)
                    return true;

                return false;
            }).ToList().FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Holt aus einem Control das ComponentViewModel.
        /// </summary>
        /// <param name="control">Das Control</param>
        /// <returns>Das ComponentViewModel, das aus dem Control geholt wurde.</returns>
        private ComponentViewModel GetComponentViewModelFromControl(Control control)
        {
            return (ComponentViewModel)((ComponentContainerControl)(control.DataContext)).DataContext;
        }

        /// <summary>
        /// Holt das ItemsControl indem sich der Connector befindet.
        /// </summary>
        /// <param name="element">Das Element.</param>
        /// <returns>Das ItemsControl</returns>
        private ItemsControl GetParentItemsControl(DependencyObject element)
        {
            while (element != null && !(element is ItemsControl))
                element = VisualTreeHelper.GetParent(element);

            return element as ItemsControl;
        }

        /// <summary>
        /// Event das ausgelöst wird, wenn sich ein am Layout irengwas ändert.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void Connector_LayoutUpdated(object sender, EventArgs e)
        {
            foreach (var c in AllConnections)
            {
                c.UpdatePath();
            }
        }

        /// <summary>
        /// Event das ausgelöst wird, wenn ein Connection auf dem Connector gedroppt wird.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void Connector_Drop(object sender, DragEventArgs e)
        {
            base.OnDrop(e);

            //RemovePreview();

            ConnectionDragArgs args = (ConnectionDragArgs)e.Data.GetData(typeof(ConnectionDragArgs));

            ComponentViewModel targetViewModel = GetComponentViewModelFromControl(this as Control);
            ComponentViewModel sourceViewModel = (ComponentViewModel)args.SourceContainer.DataContext;

            ConnectionComponent connectionComponent = new ConnectionComponent();
            connectionComponent.SourceComponentID = sourceViewModel.Component.ID;
            connectionComponent.TargetComponentID = targetViewModel.Component.ID;
            connectionComponent.SourceDirection = GetDirection(args.SourceConnector);
            connectionComponent.TargetDirection = GetDirection(this);

            ConnectionViewModel connectionViewModel = new ConnectionViewModel(connectionComponent, targetViewModel.ParentViewModel);
            connectionViewModel.SourceConnector = args.SourceConnector;
            connectionViewModel.TargetConnector = sender as Connector;
            connectionViewModel.UpdatePath();

            // TOOD (JS): Einkommentieren, wenn normales drag'n drop wieder aktiviert werden soll.
            AllConnections.Add(connectionViewModel);

            targetViewModel.ParentViewModel.AddConnection(connectionViewModel);

            DrawAreaHelper.HideConnector(GetParentItemsControl(this));
        }

        /// <summary>
        /// Event das ausgelöst wird, wenn sich ein UI Element, das einen Connector hat bewegt.
        /// </summary>
        /// <param name="sender">Quelle des Events.</param>
        /// <param name="e">Die <see cref="RoutedEventArgs"/> Eventdaten.</param>
        private void Connector_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                ComponentContainerControl container = (ComponentContainerControl)((Control)sender).DataContext;

                // Preview starten.
                //RemovePreview();
                //AddPreview();

                // Daten für den Drag erstellen.
                ConnectionDragArgs args = new ConnectionDragArgs(container, Position, this);

                DrawAreaHelper.ShowConnector(GetParentItemsControl(this));

                // Drag starten.
                DragDrop.DoDragDrop(this, args, DragDropEffects.Copy | DragDropEffects.Move);

            }
        }
     
    }
}
