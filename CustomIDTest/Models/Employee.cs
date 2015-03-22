using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomIDTest.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        //is unique needs not to exceeds 900
        [MaxLength(450)]
        [Index(IsUnique = true)]
        public string Reference { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

   
        
        //{
        //    get 
        //    {
        //        return Reference ;
        //    }
        //    set
        //    {
        //        if (this.EmployeeID == 0)
        //        {
        //            this.EmployeeID = 1 ;
        //            Reference = addRef(this.EmployeeID);
        //        }
        //        else 
        //        {
        //            Reference = addRef(this.EmployeeID);
        //        }
        //    }
        //}

       

    }
}