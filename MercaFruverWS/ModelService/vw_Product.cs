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
    
    public partial class vw_Product
    {
        public int productId { get; set; }
        public Nullable<int> Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<decimal> Cost { get; set; }
    }
}