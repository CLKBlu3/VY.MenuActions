using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VY.MenuActions.Dtos
{
    public class MenuActionDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Action { get; set; }
        [JsonIgnore]
        public Guid? ReportsTo { get; set; }
        [JsonIgnore]
        public virtual MenuActionDto ReportsToNavigation { get; set; }
        [JsonPropertyName("Items")]
        public virtual List<MenuActionDto> InverseReportsToNavigation { get; set; }
    }
}
