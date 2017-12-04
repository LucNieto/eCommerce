using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceWeb.Models {
    public class ClienteModel {
        public int id_cliente { get; set; }
        public string nombre_completo { get; set; }
        public string ape_pat { get; set; }
        public string ape_mat { get; set; }
        public Nullable<int> num_int { get; set; }
        public Nullable<int> num_ext { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public int codigo_postal { get; set; }
    }
}