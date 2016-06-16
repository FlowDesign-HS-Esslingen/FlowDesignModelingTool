using FlowDesign.Model.Components.Common;
using FlowDesign.Model.Components.FlowView;
using FlowDesign.Model.Components.Prototype;
using FlowDesign.Model.Components.SystemEnvironment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FlowDesign.Model.Components
{
    public enum ComponentType
    {
        Common,
        SystemEnvironment,
        Prototype,
        FlowView,
    }

    [XmlInclude(typeof(CommonComponent))]
    [XmlInclude(typeof(ConnectionComponent))]
    [XmlInclude(typeof(SystemEnvironmentComponent))]
    [XmlInclude(typeof(PrototypeComponent))]
    [XmlInclude(typeof(FlowViewComponent))]
    public abstract class Component
    {
        public Guid ID { get; set; }
        public Guid ParentDiagramID { get; set; }
        public string Name { get; set; }
        public ComponentType Type { get; set; }

        public ComponentUIProperties UIProperties { get; set; } = new ComponentUIProperties();

        public Component()
        {
            ID = Guid.NewGuid();
        }
    }
}
