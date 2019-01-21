using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HATEOAS.ViewModes
{
    public class VehicleViewModel : LinkedResourceBaseViewModel
    {
        public string Model { get; set; }
        public string Owner { get; set; }
    }
}
