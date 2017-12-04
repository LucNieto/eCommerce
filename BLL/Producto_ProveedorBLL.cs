using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class Producto_ProveedorBLL {
        public producto_proveedor Create(producto_proveedor newProducto_proveedor) {
            producto_proveedor Result = null;
            using (var r = new Repository<producto_proveedor>()) {
                producto_proveedor tmp = r.Retrieve(
                    p => p.prod_prov == newProducto_proveedor.prod_prov);
                if (tmp == null) {
                    Result = r.Create(newProducto_proveedor);
                } else {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public bool Edit(producto_proveedor newProducto_proveedor) {
            bool Result = false;
            var r = new Repository<producto_proveedor>();
            //using (var r = new Repository<producto_proveedor>()) {
            //    producto_proveedor tmp = r.Retrieve(
            //        p => p. == newproducto_proveedor.nombre_producto_proveedor &&
            //        p.id_producto_proveedor != newproducto_proveedor.id_producto_proveedor);
            //    if (tmp == null) {
                    Result = r.Update(newProducto_proveedor);
                //} else {
                //    throw (new Exception());
                //}
            //}
            return Result;
        }

        public producto_proveedor Retrieve(int id) {
            producto_proveedor Result = null;
            using (var r = new Repository<producto_proveedor>()) {
                Result = r.Retrieve(p => p.prod_prov == id);
            }
            return Result;
        }

        public List<producto_proveedor> RetrieveAll() {
            List<producto_proveedor> Result = null;
            using (var r = new Repository<producto_proveedor>()) {
                Result = r.RetrieveAllOrder(p => p.precio_unitario.ToString());
            }
            return Result;
        }

        public bool Delete(int id) {
            bool Result = false;
            var prod_prov = Retrieve(id);
            if (prod_prov != null) {
                using (var r = new Repository<producto_proveedor>()) {
                    Result = r.Delete(prod_prov);
                }
            } else {
                throw (new Exception());
            }
            return Result;
        }
    }
}
