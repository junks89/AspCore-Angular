namespace SqlBackendEf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Temperatur")]
    public partial class Temperatur
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }


        [Column(Order = 1)]
        public string Maschine { get; set; }


        [Column(Order = 2)]
        public Guid MaschineId { get; set; }


        [Column(Order = 3)]
        public DateTime? Zeitstempel { get; set; }


        [Column(Order = 4)]
        public decimal Wert { get; set; }


        [Column(Order = 5)]
        public string Information { get; set; }
        [Column(Order = 6)]
        public bool Geloescht { get; set; }


        
    }
}
