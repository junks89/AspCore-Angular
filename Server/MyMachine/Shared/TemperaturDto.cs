using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class TemperaturDto
    {

        public Guid Id { get; set; }


   
        public string Maschine { get; set; }


       
        public Guid MaschineId { get; set; }


      
        public DateTime? Zeitstempel { get; set; }


     
        public decimal Wert { get; set; }


      
        public string Information { get; set; }
      
        public bool Geloescht { get; set; }
    }
}
