using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MouseMod
    {
        public int Id { get; set; }
        public Mouse Base { get; set; }
        public int Weight { get; set; }
        public string Comments { get; set; }
    }
}
