using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VY.MenuActions.Infraestructure.Contracts.Entities
{
    public class MenuAction
    {
        [XmlIgnore, JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        [XmlIgnore, JsonIgnore]
        public Guid? ReportsTo { get; set; }
        [XmlIgnore, JsonIgnore]
        public virtual MenuAction ReportsToNavigation { get; set; }
        [JsonProperty("Items")]
        public virtual List<MenuAction> InverseReportsToNavigation { get; set; }
    }
}
