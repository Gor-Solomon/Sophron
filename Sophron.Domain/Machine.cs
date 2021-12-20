using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophron.Domain
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string License { get; set; }
        public Customer Customer { get; set; }
        public Device Device { get; set; }
    }
}
