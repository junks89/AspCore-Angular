using SqlBackendEf;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class TemperaturDal
    {

        public ResponseObject<IEnumerable<TemperaturDto>> GetAll(Guid id)
        {
            using (var data = new MyTemperaturModel()) // Damit die COnnection immer geschlossen wird
            {
                var list = data.Temperatur.Where(x => x.MaschineId == id).OrderBy(m => m.Zeitstempel).ToList();
                var result = new List<TemperaturDto>();
                foreach (var item in list)
                {
                    result.Add(Map(item));
                }
                return new ResponseObject<IEnumerable<TemperaturDto>> { Result = result };
            }

        }

        public ResponseObject<TemperaturDto> Get(Guid id)
        {

            using (var data = new MyTemperaturModel())
            {
                var m = data.Temperatur.Find(id);
                if (data != null)
                {
                    var result = Map(m);
                    return new ResponseObject<TemperaturDto> { Result = result };
                }
                return new ResponseObject<TemperaturDto>
                {
                    ErrorNumber = 1,
                    ErrorMessage = "Keine Temperatur für die Maschine mit dieser Id gefunden"
                };
            }


        }

        public ResponseObject<TemperaturDto> Save(TemperaturDto dto)
        {
            using (var data = new MyTemperaturModel())
            {
                var m = Map(dto);
                if (m.Id == Guid.Empty)
                {
                    data.Temperatur.Add(m);
                }
                else
                {
                    data.Entry(m).State = System.Data.Entity.EntityState.Modified;
                }
                data.SaveChanges();
                return new ResponseObject<TemperaturDto> { Result = Map(m) };
            }
        }

        public ResponseObject<bool> Delete(Guid id)
        {
            using (var data = new MyTemperaturModel())
            {
                var m = data.Temperatur.Find(id);
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

        private TemperaturDto Map(Temperatur m)
        {
            var td = new TemperaturDto
            {
                Id = m.Id,
                Maschine = m.Maschine,
                MaschineId = m.MaschineId,
                Zeitstempel = m.Zeitstempel,
                Wert = m.Wert,
                Information = m.Information,
                Geloescht = m.Geloescht

            };


            return td;
        }


        private Temperatur Map(TemperaturDto m)
        {
            var td = new Temperatur
            {
                Id = m.Id,
                Maschine = m.Maschine,
                MaschineId = m.MaschineId,
                Zeitstempel = m.Zeitstempel,
                Wert = m.Wert,
                Information = m.Information,
                Geloescht = m.Geloescht

            };


            return td;
        }

    }
}
