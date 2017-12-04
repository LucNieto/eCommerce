using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceWeb.Models {
    public class DepositoModel {
        public int id_deposito { get; set; }
        public double cantidad { get; set; }
        public string banco { get; set; }
        public int num_convenio { get; set; }
        public int referencia { get; set; }
    }
}