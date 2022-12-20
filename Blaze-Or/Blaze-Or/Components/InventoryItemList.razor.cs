using Blaze_Or.Models;
using Blazored.LocalStorage;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace Blaze_Or.Components
{
    public partial class InventoryItemList
    {


        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public Item Item { get; set; }

        [Parameter]
        public bool NoDrop { get; set; }

        [CascadingParameter]
        public InventoryComp Parent { get; set; }

        internal void OnDragEnter()
        {
            if (NoDrop)
            {
                return;
            }

            Parent.Actions.Add(new InventoryAction { Action = "Drag Enter", Item = this.Item, Index = this.Index });
        }

        internal void OnDragLeave()
        {
            if (NoDrop)
            {
                return;
            }

            Parent.Actions.Add(new InventoryAction { Action = "Drag Leave", Item = this.Item, Index = this.Index });
        }

        internal void OnDrop()
        {
            if (NoDrop)
            {
                return;
            }

            this.Item = Parent.CurrentDragItem;
            Parent.Actions.Add(new InventoryAction { Action = "Drop", Item = this.Item, Index = this.Index });

        }

        private async void OnDragStart()
        {
            Parent.CurrentDragItem = this.Item;
            Parent.Actions.Add(new InventoryAction { Action = "Drag Start", Item = this.Item, Index = this.Index });
        }
    }
}
