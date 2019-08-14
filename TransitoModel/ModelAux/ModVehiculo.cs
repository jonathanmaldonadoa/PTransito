using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransitoModel.ModelAux
{
    [NotMapped]
    public class ModVehiculo
    {
        public string PLACA { get; set; }
        public decimal VEHICULO_ID { get; set; }
        public PROPIETARIO PROPIETARIO_LIST { get; set; }
        public IEnumerable<PROPIETARIO> PROPIETARIO { get; set; }

    }
}
