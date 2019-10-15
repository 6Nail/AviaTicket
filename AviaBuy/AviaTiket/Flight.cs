using System;
using System.Collections.Generic;
using System.Text;

namespace AviaTiket
{
    class Flight
    {
       public string ToFly { get; set; }
       public DateTime dateTime { get; set; }
       public DateTime Late { get; set; }
       public Guid IdTicket { get; set; }

    }
}
