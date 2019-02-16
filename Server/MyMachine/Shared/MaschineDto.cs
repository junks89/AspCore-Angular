using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class MaschineDto
    {

       
        public Guid Id { get; set; }

        
        public string Bezeichnung { get; set; }

       
        public decimal MinTemp { get; set; }

        public decimal MaxTemp { get; set; }

       
        public bool Aktiv { get; set; }

        public bool Geloescht { get; set; }

        public DateTime? LetzteAktivierung { get; set; }

       
        public string Information { get; set; }

       
        public string Bild { get; set; }

       
        public string BeschreibungPdf { get; set; }

    }
}
