using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class FacturaBLL {
        public factura Create(factura newFactura) {
            factura Result = null;
            using (var r = new Repository<factura>()) {
                factura tmp = r.Retrieve(
                    p => p.id_factura == newFactura.id_factura);
                if (tmp == null) {
                    Result = r.Create(newFactura);
                } else {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public bool Edit(factura newFactura) {
            bool Result = false;
            using (var r = new Repository<factura>()) {
                factura tmp = r.Retrieve(
                    p => p.RFC_cliente == newFactura.RFC_cliente &&
                    p.id_factura != newFactura.id_factura);
                if (tmp == null) {
                    Result = r.Update(newFactura);
                } else {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public factura Retrieve(int id) {
            factura Result = null;
            using (var r = new Repository<factura>()) {
                Result = r.Retrieve(p => p.id_factura == id);
            }
            return Result;
        }

        public List<factura> RetrieveAll() {
            List<factura> Result = null;
            using (var r = new Repository<factura>()) {
                Result = r.RetrieveAllOrder(p => p.RFC_cliente);
            }
            return Result;
        }

        public bool Delete(int id) {
            bool Result = false;
            var cate = Retrieve(id);
            if (cate != null) {
                using (var r = new Repository<factura>()) {
                    Result = r.Delete(cate);
                }
            } else {
                throw (new Exception("Error al eliminar la categoía"));
            }
            return Result;
        }
    }
}
