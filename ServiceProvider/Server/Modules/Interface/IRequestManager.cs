

using ServiceProvider.Shared.Requests;

namespace ServiceProvider.Server.Modules.Interface
{
    public interface IRequestManager
    {
        public bool AddRequest(RequestClass requestclass);//
        public bool AcceptRequest(RequestDetailClass requestDetailClass);//
        public List<RequestClass> GetRequests();//
        public List<RequestClass> GetShopAcceptedRequests();//
        public List<GetRequestInfoModel> GetRequestInfo(Guid AcceptedByID);//
        public List<GetRequestInfoModel> GetRequestInfoUsers(Guid UserID);//
        public bool UpdateRequest(RequestClass requestclass);       
       public bool DeleteRequest(RequestClass requestclass);

    }
}
