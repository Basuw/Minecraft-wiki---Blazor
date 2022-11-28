using Microsoft.AspNetCore.Components;

namespace Blaze_Or.UIInterfaces
{
    using Microsoft.AspNetCore.Components;

    namespace BlazorSample.UIInterfaces
    {
        public interface ITab
        {
            RenderFragment ChildContent { get; }
        }
    }
}
