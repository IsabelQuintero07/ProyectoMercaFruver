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
    
    public partial class vw_Purchase
    {
        public int purchaseId { get; set; }
        public string Supplier { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public System.DateTime PurchaseDate { get; set; }
    }
}
