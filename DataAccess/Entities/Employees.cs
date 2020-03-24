using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
        public class Employee
        {
        public int idPk { get; set; }
            public string idNumber { get; set; }
            public string name { get; set; }
            public string mail { get; set; }
            public DateTime birthday { get; set; }
        

        }
}
