using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransitoModel;
using TransitoModel.ModelAux;

namespace TransitoServicio
{
    public class SERVICIOS_ASOCIAR
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();

        public async Task<ModVehiculo> RetornarLista(ModVehiculo m)
        {
            var pac = await db.PROPIETARIO_VEHICULO
                 .Include(p => p.VEHICULO)
                .Include(c => c.PROPIETARIO)
                .Where(c => c.VEHICULO.PLACA == m.PLACA)
                .ToListAsync();

            ModVehiculo mod = new ModVehiculo();
            mod.PROPIETARIO = Convert(pac);
            mod.VEHICULO_ID = ReturnID(pac);
            return mod;
        }
        private decimal ReturnID(List<PROPIETARIO_VEHICULO> pac)
        {
            foreach (var i in pac)
            {
                return i.VEHICULO.ID;
            }
            return 0;
        }

        private IEnumerable<PROPIETARIO> Convert(List<PROPIETARIO_VEHICULO> pac)
        {
            List<PROPIETARIO> aux = new List<PROPIETARIO>();

            foreach (var i in pac)
            {
                aux.Add(new PROPIETARIO
                {
                    NOMBRES = i.PROPIETARIO.NOMBRES,
                    APELLIDOS = i.PROPIETARIO.APELLIDOS,
                    CORREOELECTRONICO = i.PROPIETARIO.CORREOELECTRONICO,
                    DIRECCION = i.PROPIETARIO.DIRECCION,
                    NUMEROIDENTIFICACION = i.PROPIETARIO.NUMEROIDENTIFICACION,
                    PROPIETARIO_VEHICULO = i.PROPIETARIO.PROPIETARIO_VEHICULO,
                    TELEFONO = i.PROPIETARIO.TELEFONO
                });
            }
            return aux;
        }

        public IEnumerable GetPropietario()
        {
            var propietario = db.PROPIETARIO.AsEnumerable().Select(x => new
            {
                id = x.ID,
                FullName = string.Format("{0} - {1}  ", x.NUMEROIDENTIFICACION, x.NOMBRES)
            }).ToList();
            return propietario;
        }

        public async Task<bool> AddAsociar(ModVehiculo m)
        {
            try
            {
                PROPIETARIO_VEHICULO p_V = new PROPIETARIO_VEHICULO();
                p_V.ID_PROPIETARIO = m.PROPIETARIO_LIST.ID;
                p_V.ID_VEHICULO = m.VEHICULO_ID;
                p_V.CREA_FECHA = DateTime.Now;

                db.PROPIETARIO_VEHICULO.Add(p_V);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
