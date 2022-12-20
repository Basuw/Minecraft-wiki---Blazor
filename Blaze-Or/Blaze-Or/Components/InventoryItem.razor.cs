using Blaze_Or.Models;
using Blazored.LocalStorage;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace Blaze_Or.Components
{
    public partial class InventoryItem
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }

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

        internal async void OnDrop()
        {
            if (NoDrop)
            {
                return;
            }

            this.Item = Parent.CurrentDragItem;
            await LocalStorage.SetItemAsync<Item>("data" + this.Index, this.Item);
            Parent.Actions.Add(new InventoryAction { Action = "Drop", Item = this.Item, Index = this.Index });

        }

        private async void OnDragStart()
        {
            Parent.CurrentDragItem = this.Item;
            this.Item = null;
            await LocalStorage.SetItemAsync<Item>("data" + this.Index, null);
            
            Parent.Actions.Add(new InventoryAction { Action = "Drag Start", Item = this.Item, Index = this.Index });
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRenderAsync(firstRender);

            if (!firstRender)
            {
                return;
            }
            Item = await LocalStorage.GetItemAsync<Item>("data" + this.Index);

            StateHasChanged();
        }

    }
}
