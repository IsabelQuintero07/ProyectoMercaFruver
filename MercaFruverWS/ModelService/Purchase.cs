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
    
    public partial class Purchase
    {
        public int purchaseId { get; set; }
        public int purchaseSupplierId { get; set; }
        public int purchaseProductId { get; set; }
        public int purchaseQuantity { get; set; }
        public decimal purchaseUnitCost { get; set; }
        public System.DateTime purchaseDate { get; set; }
        public int purchaseStateId { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual cstate cstate { get; set; }
    }
}
