//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Concept_Sale
    {
        public int conceptId { get; set; }
        public int conceptProductId { get; set; }
        public int conceptSaleId { get; set; }
        public int conceptQuantity { get; set; }
        public Nullable<decimal> conceptUnitPrice { get; set; }
        public int conceptStateId { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual cstate cstate { get; set; }
    }
}
