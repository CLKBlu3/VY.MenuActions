using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.MenuActions.XCutting.Contracts;

namespace VY.MenuActions.Business.Contracts.Domain
{
    public class ArgContext
    {
        public string Path { get; set; }
        public SerializerType Serializer { get; set; }
        public ActionType Action { get; set; }
    }
}
