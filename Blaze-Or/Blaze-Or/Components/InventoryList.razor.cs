using Blaze_Or.Models;
using Blaze_Or.Services;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Blaze_Or.Components
{
    public partial class InventoryList
    {
        private List<Item> items;

        private int totalItem;

        [Inject]
        public IDataService DataService { get; set; }

        [Inject]
        public IWebHostEnvironment WebHostEnvironment { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [CascadingParameter]
        public IModalService Modal { get; set; }

        [Inject]
        public IStringLocalizer<InventoryList> Localizer { get; set; }

        [CascadingParameter]
        public InventoryComp Parent { get; set; }


        public void OnDragStart()
        {

        }


        public void OnDrop()
        {
            Parent.CurrentDragItem = null;
            return;
        }
        internal void OnDragEnter()
        {
            Parent.Actions.Add(new InventoryAction { Action = "Drag Enter", Item = this.items[0], Index = this.items[0].Id });
        }

        internal void OnDragLeave()
        {
            Parent.Actions.Add(new InventoryAction { Action = "Drag Leave", Item = this.items[0], Index = this.items[0].Id });
        }
        
        protected override async Task OnInitializedAsync()
        {
            items = await DataService.GetAllItems();
            totalItem = await DataService.Count();
            await base.OnInitializedAsync();
        }
        
    }

}
