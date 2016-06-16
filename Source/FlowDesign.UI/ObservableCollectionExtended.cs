using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign.UI
{
    /// <summary>
    /// Bietet zustäzliche Methoden und Events für eine ObservalbeCollection.
    /// </summary>
    /// <typeparam name="T">Typ des Items das hinzugefügt werden soll.</typeparam>
    /// <seealso cref="System.Collections.ObjectModel.ObservableCollection{T}" />
    public class ObservableCollectionExtended<T> : ObservableCollection<T>
    {
        public delegate void ItemsModifiedEventHandler(T item);

        /// <summary>
        /// Wird aufgerufen, wenn ein Item der Collection hinzugefügt wird. Wird nicht bei AddRange aufgerufen.
        /// </summary>
        public event ItemsModifiedEventHandler OnItemAdded;

        /// <summary>
        /// Wird aufgerufen, wenn ein Item aus der Collection entfernt wird.
        /// </summary>
        public event ItemsModifiedEventHandler OnItemRemoved;

        /// <summary>
        /// Fügt am Ende der <see cref="System.Collections.ObjectModel.ObservableCollection{T}" /> ein Objekt hinzu.
        /// </summary>
        /// <param name="item">Das Objekt, das am Ende der <see cref="T:System.Collections.ObjectModel.Collection`1" /> hinzugefügt werden soll. Der Wert kann für Verweistypen null sein.</param>
        public new void Add(T item)
        {
            base.Add(item);

            OnItemAdded?.Invoke(item);
        }

        /// <summary>
        /// Fügt der Collection eine Liste von Items hinzu.
        /// </summary>
        /// <param name="items">Die Items, die hinzugefügt werden sollen.</param>
        public void AddRange(List<T> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Add(items[i]);
            }
        }

        /// <summary>
        /// Entfernt das Item aus der Collection.
        /// </summary>
        /// <param name="item">Das Item, das entfernt werden soll.</param>
        public new void Remove(T item)
        {
            base.Remove(item);

            OnItemRemoved?.Invoke(item);
        }
       
    }
}
