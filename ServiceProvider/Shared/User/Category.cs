﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class.User.CategoryModel
{

    public class CategoryModel
    {

        [Key]
        public int CategoryID { get; set; }

  
        public string Name { get; set; }
     
        public string Description { get; set; }
    }

}
