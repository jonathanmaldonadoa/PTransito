using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransitoModel.ModelAux
{
    [NotMapped]
    public class ModVehiculo
    {
        public string PLACA { get; set; }
        public decimal VEHICULO_ID { get; set; }
        [Required(ErrorMessage = "El Campo {0} es necesario ")]
        public PROPIETARIO PROPIETARIO_LIST { get; set; }
        public IEnumerable<PROPIETARIO> PROPIETARIO { get; set; }

    }
}
