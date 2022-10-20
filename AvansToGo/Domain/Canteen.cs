using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Canteen
    {
        public EnumCity City { get; set; }
        public string Location { get; set; }
        public bool ServesHotMeals { get; set; }

        public Canteen()
        {
   
        }
    }
}
