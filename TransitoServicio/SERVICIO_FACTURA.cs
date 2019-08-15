using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TransitoModel;
using TransitoModel.ModelAux;


namespace TransitoServicio
{
    public class SERVICIO_FACTURA
    {
        private PRUEBA1Entities db = new PRUEBA1Entities();

        public int Contar(ModFactura m)
        {
            var bus = db.PROPIETARIO_VEHICULO
                .Include(x => x.VEHICULO)
                .Include(x => x.PROPIETARIO)
                .Where(x => x.PROPIETARIO.NUMEROIDENTIFICACION == m.DOCUMENTO && x.VEHICULO.PLACA == m.PLACA).ToList();
            if (bus.Count() > 0)
            {
                return bus.Count();
            }
            return 0;
        }

        

        public async Task<bool> AgregarTramite(ModFactura m)
        {
            try
            {
                FACTURA_TRAMITE aux = new FACTURA_TRAMITE();
                aux.ID_TRAMITE = m.TRAMITE.ID;
                aux.CREA_FECHA = DateTime.Now;
                aux.ID_FACTURA = m.FACTURA.ID;
                db.FACTURA_TRAMITE.Add(aux);
                await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;

            }
        }
        public async Task<decimal> CrearFactura(ModFactura m)
        {
            try
            {
                    FACTURA_TRAMITE aux = new FACTURA_TRAMITE();
                    aux.ID_TRAMITE = m.TRAMITE.ID;
                    aux.CREA_FECHA = DateTime.Now;

                    FACTURA aux2 = new FACTURA();
                    aux2.FACTURA_TRAMITE.Add(aux);
                    aux2.FECHA = m.FACTURA.FECHA;
                    aux2.ID_VEHICULO = m.FACTURA.ID_VEHICULO;
                    aux2.NUMERO = m.FACTURA.NUMERO;
                    aux2.OBSERVACIONES = m.FACTURA.OBSERVACIONES;

                    db.FACTURA.Add(aux2);
                    await db.SaveChangesAsync();
                    decimal ID = aux2.ID;

                    return ID;
            }
            catch
            {
                return 0;

            }
        }

        public async Task<ModFactura> FacturaDetalle(decimal m)
        {
            FACTURA fACTURA = await db.FACTURA.FindAsync(m);
            ModFactura aux = new ModFactura();
            aux.FACTURA = fACTURA;
            aux.FACTURA_TRAMITE = fACTURA.FACTURA_TRAMITE;

            return aux;
        }
        public async Task<List<FACTURA>> FacturaListar()
        {
            var fACTURA = db.FACTURA.Include(f => f.VEHICULO);
            return await fACTURA.ToListAsync();
        }

    }
}
