using SammysAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SammysAuto.ViewModel
{
    public class CarAndServicesViewModel
    {
        public Car CarObj { get; set; }
        public Service NewServiceObj { get; set; }
        public IEnumerable<Service> PastServicesObj { get; set; }
        public List<ServiceType> ServiceTypesObj { get; set; }
    }
}
