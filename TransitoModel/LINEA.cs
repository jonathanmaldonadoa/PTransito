//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TransitoModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class LINEA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LINEA()
        {
            this.VEHICULO = new HashSet<VEHICULO>();
        }
    
        public decimal ID { get; set; }
        public string DESCRIPCION { get; set; }
        public Nullable<decimal> ID_MARCA { get; set; }
    
        public virtual MARCA MARCA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VEHICULO> VEHICULO { get; set; }
    }
}
