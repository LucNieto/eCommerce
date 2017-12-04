using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class ProveedoresBLL {
        public proveedor Create(proveedor newProveedor) {
            using (var r = new Repository<proveedor>()) {
                newProveedor = r.Create(newProveedor);
            }

            return newProveedor;
        }

        public bool Update(proveedor newProveedor) {
            bool Result = false;
            using (var r = new Repository<proveedor>()) {
                proveedor tmp = r.Retrieve(
                    p => p.empresa == newProveedor.empresa &&
                    p.id_proveedor != newProveedor.id_proveedor);
                if (tmp == null) {
                    Result = r.Update(newProveedor);
                } else {
                    throw (new Exception("El proveedor ya existe"));
                }
            }
            return Result;
        }

        public proveedor Retrieve(int id) {
            proveedor Result = null;
            using (var r = new Repository<proveedor>()) {
                Result = r.Retrieve(p => p.id_proveedor == id);
            }
            return Result;
        }

        public List<proveedor> RetrieveAll() {
            List<proveedor> Result = null;
            using (var r = new Repository<proveedor>()) {
                Result = r.RetrieveAllOrder(p => p.empresa);
            }
            return Result;
        }

        public bool Delete(int id) {
            bool Result = false;
            var proveedor = Retrieve(id);
            if (proveedor != null) {
                using (var r = new Repository<proveedor>()) {
                    Result = r.Delete(proveedor);
                }
            } else {
                throw (new Exception("Error al eliminar la categoía"));
            }
            return Result;
        }


    }
}