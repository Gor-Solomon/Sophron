using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophron.Domain
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Customer Customer { get; set; }
        public Machine Machine { get; set; }
    }
}
