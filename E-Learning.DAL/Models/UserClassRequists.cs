using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.DAL
{
    public class UserClassRequists
    {
        [Key]
        public int id { get; set; }
          public string Userid { get; set; }
        public int? Classid { get; set; }
        public bool? Active { get; set; }
        public  virtual User? user { get; set; }  
        public virtual Class? Class { get; set; }




    }
}
