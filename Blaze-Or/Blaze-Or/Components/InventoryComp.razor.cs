using Blaze_Or.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Blaze_Or.Components
{
    public partial class InventoryComp
    {
        public Item CurrentDragItem { get; set; }

        [Parameter]
        public List<Item> Items { get; set; }

        public ObservableCollection<InventoryAction> Actions { get; set; }

        /// <summary>
        /// Gets or sets the java script runtime.
        /// </summary>
        [Inject]
        internal IJSRuntime JavaScriptRuntime { get; set; }

        public InventoryComp()
        {
            Actions = new ObservableCollection<InventoryAction>();
            Actions.CollectionChanged += OnActionsCollectionChanged;
        }

        private void OnActionsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            JavaScriptRuntime.InvokeVoidAsync("Crafting.AddActions", e.NewItems);
        }
    }
}
