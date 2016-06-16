using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowDesign.Model.Components
{
    public class ComponentUIProperties
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Width { get; set; } = 100;
        public double Height { get; set; } = 100;
        public int ZIndex { get; set; } = 50;
    }
}
