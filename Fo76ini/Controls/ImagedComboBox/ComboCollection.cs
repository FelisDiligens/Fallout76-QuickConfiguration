/*
 * Author:  Bassam Alugili
 * Article: https://www.codeproject.com/Articles/106467/How-to-Display-Images-in-ComboBox-in-5-Minutes
 */

using System;
using System.Collections;
using System.Windows.Forms;

namespace ComboxExtended
{

    /// <summary>
    /// Collections of ComboBoxItem.
    /// </summary>
    /// <typeparam name="TComboBoxItem">ComboBoxItem.</typeparam>
    public class ComboCollection<TComboBoxItem> : CollectionBase
    {

        public EventHandler UpdateItems;
        public ComboBox.ObjectCollection  ItemsBase { get; set; }

        public ComboBoxItem this[int index]
        {
            get
            {
                return ((ComboBoxItem)ItemsBase[index]);
            }
            set
            {
                ItemsBase[index] = value;
            }
        }

        public int Add(ComboBoxItem value)
        {
            var  result =  ItemsBase.Add(value);
            UpdateItems.Invoke(this, null);
            return result;
        }

        public int IndexOf(ComboBoxItem value)
        {
            return (ItemsBase.IndexOf(value));
        }

        public void Insert(int index, ComboBoxItem value)
        {
            ItemsBase.Insert(index, value);
            UpdateItems.Invoke(this, null);
        }

        public void Remove(ComboBoxItem value)
        {
            ItemsBase.Remove(value);
            UpdateItems.Invoke(this, null);
        }

        public bool Contains(ComboBoxItem value)
        {
            return (ItemsBase.Contains(value));
        }

    }

}
