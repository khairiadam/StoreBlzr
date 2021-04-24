using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using StoreBlzr.Shared.Dto;
using StoreBlzr.Shared.Services.Auth;


namespace StoreBlzr.Client.Components
{
    public partial class RegisterForm
    {
        public IAuthDataService AuthService { get; set; }
        public UserModel User { get; set; }
        public EventCallback<bool> CloseEventCallback { get; set; }

        // public bool ShowDialog { get; set; }

        // public void Show()
        // {
        //     ResetDialog();
        //     ShowDialog = true;
        //     StateHasChanged();
        // }

        // public void Close()
        // {
        //     ShowDialog = false;
        //     StateHasChanged();
        // }

        // private void ResetDialog()
        // {
        //     user = new UserModel();
        // }
        protected async Task HandleValidSubmit()
        {
            await AuthService.RegisterAsync(User);

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }

    }
}