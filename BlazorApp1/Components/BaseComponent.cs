using BlazorApp1.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Components
{
    public class BaseComponent : ComponentBase
    {
        [Inject] protected IAppState AppState { get; set; }
        [Inject] protected NavigationManager Navigation { get; set; }

        protected void Logout()
        {
            AppState.ClearUsername();
            Navigation.NavigateTo("/");
        }

        public void Authorize(int AppStateId,int id)
        {
            if (AppStateId != id)
            {

                Navigation.NavigateTo("/");
            }
        }
    }
}
