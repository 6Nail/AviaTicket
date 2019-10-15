using System;
using System.Collections.Generic;
using System.Text;

namespace AviaTiket
{
    public class Passenger
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ToFly { get; set; }

        public DateTime TimeExit { get; set; }
        public bool Registr { get; set; } 
    }
}
