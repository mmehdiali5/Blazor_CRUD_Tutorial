// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace CRUDinBlazor.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\_Imports.razor"
using CRUDinBlazor.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\_Imports.razor"
using CRUDinBlazor.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\Pages\UserDisplay.razor"
using CRUDinBlazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\Pages\UserDisplay.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/userDisplay")]
    public partial class UserDisplay : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 42 "C:\Users\ASUS\PUCIT Files\Web Engineering\CRUDinBlazor\CRUDinBlazor\Client\Pages\UserDisplay.razor"
       



    List<UserInfo> users = new List<UserInfo>();
    protected override async Task OnInitializedAsync()
    {
        users= await Http.GetFromJsonAsync<List<UserInfo>>("api/UserInfo");
    }

    UserInfo form = new UserInfo();

    async void submitRequest()
    {
        if (form.id < 1)
        {
            await Http.PostAsJsonAsync<UserInfo>("api/UserInfo", form);
        }
        else
        {
            await Http.PutAsJsonAsync<UserInfo>("api/UserInfo", form);
        }

        users = await Http.GetFromJsonAsync<List<UserInfo>>("api/UserInfo");
        await InvokeAsync(() => StateHasChanged());
        form.id = 0;
    }

    async void DeleteUser(string username)
    {
        await Http.DeleteAsync($"api/UserInfo/{username}");
        users = await Http.GetFromJsonAsync<List<UserInfo>>("api/UserInfo");
        await InvokeAsync(() => StateHasChanged());
    }

    void updateUser(UserInfo user)
    {
        form = user;
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
