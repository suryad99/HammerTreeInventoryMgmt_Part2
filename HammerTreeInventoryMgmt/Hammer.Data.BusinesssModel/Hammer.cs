using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hammer.Data.BusinesssModel
{
    public class HammerDTO
    {
        public int HammerId { get; set; }
        public string HammerName { get; set; }
        public string HammerDescription { get; set; }
        public bool IsActive { get; set; }
        public string Category { get; set; }
        public CategoryDTO categoryDTO { get; set; }
    }
}
