//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIGE.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class aditionalInformation
    {
        public int id { get; set; }
        public string profesion { get; set; }
        public byte[] empleo { get; set; }
        public Nullable<int> usuario { get; set; }
    
        public virtual information information { get; set; }
    }
}
