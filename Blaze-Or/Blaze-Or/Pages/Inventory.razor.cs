using Blaze_Or.Components;
using Blaze_Or.Modals;
using Blaze_Or.Models;
using Blaze_Or.Services;
using Blazored.Modal;
using Blazored.Modal.Services;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace Blaze_Or.Pages
{
    public partial class Inventory
    {
        [Inject]
        public IDataService DataService { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            base.OnAfterRenderAsync(firstRender);

            if (!firstRender)
            {
                return;
            }

            Items = await DataService.List(0, await DataService.Count());

            StateHasChanged();
        }
    }
}

