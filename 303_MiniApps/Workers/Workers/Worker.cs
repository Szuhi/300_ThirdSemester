using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class Worker
    {
        public string Name { get; set; }
        public bool Sick { get; set; }
        public bool Vacation { get; set; }

        public override string ToString()
        {
            return (Sick) ? Name + " (vacation)" : Name;
        }
    }
}
