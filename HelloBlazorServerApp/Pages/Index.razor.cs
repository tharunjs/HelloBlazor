﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
//using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HelloBlazorServerApp.Pages
{
    public partial class Index
    {
        private string _myValue = string.Empty;

        //[Inject]
        //private ProtectedSessionStorage ProtectedSessionStore { get; set; }

        [Inject]
        private IMemoryCache MemoryCache { get; set; }

        [Inject]
        private IConfiguration Configuration { get; set; }

        protected override Task OnInitializedAsync()
        {
            _myValue = Configuration.GetValue<string>("MyKey");

            return base.OnInitializedAsync();
        }

        //private async Task AddToStorage()
        //{
        //    await ProtectedSessionStore.SetAsync("key", "its a value");
        //}

        private void AddToStorage()
        {
            MemoryCache.Set("key", "its a value", new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1) });
        }
    }
}
