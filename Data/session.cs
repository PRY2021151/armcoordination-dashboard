using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Data
{
    public class session
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int score { get; set; }
        public int maximum_response { get; set; }
        public int minimum_response { get; set; }
        public float average_response { get; set; }
        public int hits_left_arm { get; set; }
        public int hits_right_arm { get; set; }
        public float accuracy_percentage { get; set; }
        public int failures_right_arm { get; set; }
        public int failures_left_arm { get; set; }
        public int child_id { get; set; }
    }
}
