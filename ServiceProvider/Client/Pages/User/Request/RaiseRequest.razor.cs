using Class.User.UserModel;
using Microsoft.AspNetCore.Components;
using ServiceProvider.Shared.Requests;
using System.Net.Http.Json;

namespace ServiceProvider.Client.Pages.Request
{
    public  class RaiseRequest_new : ComponentBase
    {
        RequestClass request = new RequestClass();
        UserModel publicuserModel = new UserModel();
        protected override async Task OnInitializedAsync()
        {


           // publicuserModel = await _localstorage.GetItemAsync<UserModel>("currentusercurrentuser");


        }

        public async  void AddRequest()
        {
            request.RequestID = Guid.NewGuid();
            request.UserID = publicuserModel.ID;
            request.CreateDate = DateTime.Now;
            request.IsCanceled = false;
            request.IsCanceledBy = null;
            request.IsCanceledByID = null;
            request.CancelReason = null;
            request.CancelResonDate = null;

            //var response = await Http.PostAsJsonAsync("api/Request/PostRequest", request);
            //if (response.IsSuccessStatusCode)
            //{
            //    Snackbar.Add("Request Added");
            //}
        }
    }
}
