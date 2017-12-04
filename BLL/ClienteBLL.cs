using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class ClienteBLL {
        public cliente Create(cliente newcliente) {
            cliente Result = null;
            using (var r = new Repository<cliente>()) {
                cliente tmp = r.Retrieve(
                    p => p.id_cliente == newcliente.id_cliente);
                if (tmp == null) {
                    Result = r.Create(newcliente);
                } else {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public bool Edit(cliente newcliente) {
            bool Result = false;
            using (var r = new Repository<cliente>()) {
                cliente tmp = r.Retrieve(
                    p => p.id_cliente == newcliente.id_cliente);
                if (tmp == null) {
                    Result = r.Update(newcliente);
                } else {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public cliente Retrieve(int id) {
            cliente Result = null;
            using (var r = new Repository<cliente>()) {
                Result = r.Retrieve(p => p.id_cliente == id);
            }
            return Result;
        }

        public List<cliente> RetrieveAll() {
            List<cliente> Result = null;
            using (var r = new Repository<cliente>()) {
                Result = r.RetrieveAllOrder(p => p.nombre_completo);
            }
            return Result;
        }

        public bool Delete(int id) {
            bool Result = false;
            var cate = Retrieve(id);
            if (cate != null) {
                using (var r = new Repository<cliente>()) {
                    Result = r.Delete(cate);
                }
            } else {
                throw (new Exception("Error al eliminar la categoía"));
            }
            return Result;
        }
    }
}
