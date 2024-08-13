using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.Chats
{
    public class ChatPropClass
    {
        //shopidtenp = _obj.AcceptedByID;
        //useridtemp = _obj.UserID;
        //username = _obj.UserName;
        //shopname = _obj.ShopName;
        //Messagefrom = _obj.UserName;

        //public static  Guid?  ShopID         { get; set; }
        //public static Guid  ?UserID         { get; set; }
        //public static string? UserName    { get; set; }
        //public static string ?ShopName    { get; set; }
        //public static string? MessageFrom{ get; set; }

        public  Guid? ShopID { get; set; }
        public  Guid? UserID { get; set; }
        public  string? UserName { get; set; }
        public  string? ShopName { get; set; }
        public string? MessageFrom { get; set; }
    }
}
