namespace SqlBackendEf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Maschine")]
    public partial class Maschine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

       
        [Column(Order = 1)]
        public string Bezeichnung { get; set; }

       
        [Column(Order = 2)]
        public decimal MinTemp { get; set; }

      
        [Column(Order = 3)]
        public decimal MaxTemp { get; set; }

       
        [Column(Order = 4)]
        public bool Aktiv { get; set; }

     
        [Column(Order = 5)]
        public bool Geloescht { get; set; }

        public DateTime? LetzteAktivierung { get; set; }

       
        [Column(Order = 6)]
        public string Information { get; set; }

        
        [Column(Order = 7)]
        public string Bild { get; set; }

        
        [Column(Order = 8)]
        public string BeschreibungPdf { get; set; }
    }
}
