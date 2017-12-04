using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceWeb.Models {
    public class ProveedoresModel {
        public int id_proveedor { get; set; }
        public string empresa { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}