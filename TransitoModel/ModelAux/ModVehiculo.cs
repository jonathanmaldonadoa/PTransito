using System.Collections.Generic;

namespace TransitoModel.ModelAux
{
    public class ModVehiculo
    {
        public string PLACA { get; set; }
        public IEnumerable<PROPIETARIO> PROPIETARIO { get; set; }

    }
}
