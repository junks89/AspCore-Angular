using SqlBackendEf;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
   public class MaschineDal
    {

        public ResponseObject<IEnumerable<MaschineDto>> GetAll()
        {
            using (var data = new MyMachineModel()) // Damit die COnnection immer geschlossen wird
            {
                var list = data.Maschine.OrderBy(m => m.Bezeichnung).ToList();
                var result = new List<MaschineDto>();
                foreach (var item in list)
                {
                    result.Add(Map(item));
                }
                return new ResponseObject<IEnumerable<MaschineDto>> { Result = result };
            }
            
        }

        public ResponseObject<MaschineDto> Get (Guid id)
        {
            
            using (var data = new MyMachineModel())
            {
                var m = data.Maschine.Find(id);
                if (data != null)
                {
                    var result = Map(m);
                    return new ResponseObject<MaschineDto> { Result = result };
                }
                return new ResponseObject<MaschineDto>
                {
                    ErrorNumber = 1,
                    ErrorMessage = "Keine Maschine mit dieser Id gefunden"
                };
            }


        }

        public ResponseObject<MaschineDto> Save(MaschineDto dto)
        {
            using (var data = new MyMachineModel())
            {
                var m = Map(dto);
                if (m.Id == Guid.Empty)
                {
                    data.Maschine.Add(m);
                }
                else
                {
                    data.Entry(m).State = System.Data.Entity.EntityState.Modified;
                }
                data.SaveChanges();
                return new ResponseObject<MaschineDto> { Result = Map(m) };
            }
        }

        public ResponseObject<bool> Delete(Guid id)
        {
            using (var data = new MyMachineModel())
            {
                var m = data.Maschine.Find(id);
                if (m != null)
                {
                    m.Geloescht = true;
                    data.Entry(m).State = System.Data.Entity.EntityState.Modified;
                    data.SaveChanges();
                    return new ResponseObject<bool> { Result = true };
                }
                return new ResponseObject<bool> { Result = false };
            }
        }

        private MaschineDto Map(Maschine m)
        {
            var md = new MaschineDto
            {
                Id = m.Id,
                Bezeichnung = m.Bezeichnung,
                MinTemp = m.MinTemp,
                MaxTemp = m.MaxTemp,
                Aktiv = m.Aktiv,
                Geloescht = m.Geloescht,
                LetzteAktivierung = m.LetzteAktivierung,
                Information = m.Information,
                Bild = m.Bild,
                BeschreibungPdf = m.BeschreibungPdf

            };


            return md;
        }


        private Maschine Map(MaschineDto m)
        {
            var md = new Maschine
            {
                Id = m.Id,
                Bezeichnung = m.Bezeichnung,
                MinTemp = m.MinTemp,
                MaxTemp = m.MaxTemp,
                Aktiv = m.Aktiv,
                Geloescht = m.Geloescht,
                LetzteAktivierung = m.LetzteAktivierung,
                Information = m.Information,
                Bild = m.Bild,
                BeschreibungPdf = m.BeschreibungPdf

            };


            return md;
        }

    }
}
