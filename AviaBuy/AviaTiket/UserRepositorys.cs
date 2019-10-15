using System;
using System.Collections.Generic;
using System.Text;

namespace AviaTiket
{
   public interface UserRepositorys
   {
       
        
            void Add(Passenger passenger);
            void Delete(Guid Idpassenger);
            void Update(Passenger passenger);
            ICollection<Passenger> GetAll();
        
   }
}
