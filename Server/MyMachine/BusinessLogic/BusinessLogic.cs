using DataAccessLayer;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class MaschineBl
    {

        AuthorizationModel _am;
        public MaschineBl(AuthorizationModel am)
        {
            _am = am;
        }


        public ResponseObject<IEnumerable<MaschineDto>> GetAll()
        {
            if (_am.Role != "Administrator")
            {

                return new ResponseObject<IEnumerable<MaschineDto>>
                {
                    ErrorNumber = 991,
                    ErrorMessage = " Unzureichende Bnutzerrechte"
                };
            }
            return new MaschineDal().GetAll();


        }

      
        public ResponseObject<MaschineDto> Get(string id)

        {
            Guid g = Guid.Empty;
            Guid.TryParse(id, out g);

            if (g == Guid.Empty)
            {
                return new ResponseObject<MaschineDto>
                {
                    ErrorNumber = 10,
                    ErrorMessage = " Keine Maschine mit dieser Id gefunden."

                };

            }
            return new MaschineDal().Get(g);
        }




        public ResponseObject<MaschineDto> Save(MaschineDto dto)
        {
            var r = new ResponseObject<MaschineDto>();
            if (string.IsNullOrEmpty(dto.Bezeichnung))
            {
                r.ErrorNumber = 2;
                r.ErrorMessage = "Die Bezeichnung darf nicht leer sein";
            }

            if (string.IsNullOrEmpty(dto.Bild))
            { dto.Bild = string.Empty; }

            if (string.IsNullOrEmpty(dto.BeschreibungPdf))
            { dto.Bild = string.Empty; }

            if (r.ErrorNumber>0)
            {
                return r;
            }
            return new MaschineDal().Save(dto);

        }
        public ResponseObject<bool> Delete(Guid id)
        {
            return new MaschineDal().Delete(id);
        }
    }




    public class TemperaturBl
    {
        public ResponseObject<IEnumerable<TemperaturDto>> GetAll(string id)
        {
            Guid g = Guid.Empty;
            Guid.TryParse(id, out g);

            if (g == Guid.Empty)
            {
                if (g == Guid.Empty)
                {
                    return new ResponseObject<IEnumerable < TemperaturDto >>
                    {
                        ErrorNumber = 10,
                        ErrorMessage = " Keine Temperatur für Maschine mit dieser Id gefunden."

                    };

                }

            }

            return new TemperaturDal().GetAll(g);
        }


        public ResponseObject<TemperaturDto> Get(string id)

        {
            Guid g = Guid.Empty;
            Guid.TryParse(id, out g);

            if (g == Guid.Empty)
            {
                return new ResponseObject<TemperaturDto>
                {
                    ErrorNumber = 10,
                    ErrorMessage = " Keine Temperatur für Maschine mit dieser Id gefunden."

                };

            }
            return new TemperaturDal().Get(g);
        }




        public ResponseObject<TemperaturDto> Save(TemperaturDto dto)
        {
            var r = new ResponseObject<TemperaturDto>();
            if (string.IsNullOrEmpty(dto.Information))
            {
                r.ErrorNumber = 2;
                r.ErrorMessage = "Die Information darf nicht leer sein";
            }


            if (r.ErrorNumber > 0)
            {
                return r;
            }
            return new TemperaturDal().Save(dto);

        }
        public ResponseObject<bool> Delete(Guid id)
        {
            return new TemperaturDal().Delete(id);
        }
    }

}
