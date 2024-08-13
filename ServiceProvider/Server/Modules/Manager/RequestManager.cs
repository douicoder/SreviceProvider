using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Tls;
using ServiceProvider.Server.Modules.Interface;
using ServiceProvider.Shared.Requests;
using ServiceProvider.Shared.User;

namespace ServiceProvider.Server.Modules.Manager
{
    public class RequestManager : IRequestManager
    {
        DatabaseContext _database = new DatabaseContext();
        public RequestManager(DatabaseContext db)
        {
            _database = db;
        }

        public bool AcceptRequest(RequestDetailClass requestDetailClass)
        {
            _database.RequestDetailsDB.Add(requestDetailClass);
            _database.SaveChanges();
            return true;
        }

        public bool AddRequest(RequestClass requestclass)
        {
            _database.RequestsDB.Add(requestclass);
            _database.SaveChanges();
            return true;
        }

        public bool DeleteRequest(RequestClass requestclass)
        {
            _database.RequestsDB.Remove(requestclass);
            _database.SaveChanges();
            return true;
        }

        public List<GetRequestInfoModel> GetRequestInfo(Guid AcceptedByID)
        {
            try
            {
                var id = new Microsoft.Data.SqlClient.SqlParameter("@AcceptedByID", AcceptedByID);
                var result = _database.GetRequestInfoModelDB.FromSqlRaw("EXEC GetRequestInfo @AcceptedByID", id).ToList();
                return result;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<GetRequestInfoModel> GetRequestInfoUsers(Guid UserID)
        {
            {
                try
                {
                    var id = new Microsoft.Data.SqlClient.SqlParameter("@UserID", UserID);
                    var result = _database.GetRequestInfoModelDB.FromSqlRaw("EXEC GetRequestInfoForUser @UserID", id).ToList();
                    return result;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public List<RequestClass> GetRequests()
        {
            List<RequestClass> requestClasses = _database.RequestsDB.ToList();
            return requestClasses;
        }

        public List<RequestClass> GetShopAcceptedRequests()
        {
            List<RequestClass> requestClasses = _database.RequestsDB.ToList();
            return requestClasses;
        }

        public bool UpdateRequest(RequestClass requestclass)
        {
            try
            {
                var record=_database.RequestsDB.Where(x => x.RequestID==requestclass.RequestID).FirstOrDefault();
                if(record != null) 
                {

                    record.IsAccepted = requestclass.IsAccepted;
                    record.IsDeleated = requestclass.IsDeleated;


                }
                _database.SaveChanges();
                return true;
            }
            catch(Exception ex) 
            {
                throw ex;
                return false;
            }
        }
    }

}
