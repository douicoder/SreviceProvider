﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider.Shared.User
{
    public class ServiceProviderProfile
    {

        public Guid?  ServiceproviderProfileID { get; set; }//auto


        public Guid? UserID { get; set; }

        public string ShopName { get; set; }

        public string PinCode{ get; set; }

        



    }
}
