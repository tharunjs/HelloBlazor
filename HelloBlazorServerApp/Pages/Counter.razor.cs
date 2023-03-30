using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HelloBlazorServerApp.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;

        private string _value;

        //[Inject]
        //private ProtectedSessionStorage ProtectedSessionStore { get; set; }

        [Inject]
        private IMemoryCache MemoryCache { get; set; }

        private void IncrementCount()
        {
            currentCount++;
        }

        //protected override async Task OnInitializedAsync()
        //{
        //    var x = await ProtectedSessionStore.GetAsync<string>("key");
        //    if (x.Success)
        //    {
        //        _value = x.Value;
        //    }
        //    await base.OnInitializedAsync();
        //}

        protected override Task OnInitializedAsync()
        {
            if (MemoryCache.TryGetValue<string>("key", out string val))
            {
                _value = val;
                //MemoryCache.Remove("key");
            }

            return base.OnInitializedAsync();
        }
    }
}
