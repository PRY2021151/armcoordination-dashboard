using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Data
{
    public class children
    {
        public int id { get; set; }
        public string names { get; set; }
        public string last_name { get; set; }
        public DateTime date_of_birth { get; set; }
        public string gender { get; set; }
        public string relationship { get; set; }
        public bool is_deleted { get; set; }
        public string AspNetUsers_Id { get; set; }

    }
}
