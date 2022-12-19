using Blaze_Or.Models;
using Microsoft.AspNetCore.Components;

namespace Blaze_Or.Components
{
    public partial class InventoryListImage
    {

        [Parameter]
        public Item Item { get; set; }

        [CascadingParameter]
        public Crafting Parent { get; set; }

        internal void OnDragEnter()
        {
        }

        internal void OnDragLeave()
        {
        }

        internal void OnDrop()
        {

        }

        private void OnDragStart()
        {
        }
    }

}
