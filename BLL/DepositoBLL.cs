using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class DepositoBLL {
        public deposito Create(deposito newdeposito) {
            deposito Result = null;
            using (var r = new Repository<deposito>()) {
                deposito tmp = r.Retrieve(
                    p => p.id_deposito == newdeposito.id_deposito);
                if (tmp == null) {
                    Result = r.Create(newdeposito);
                } else {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public bool Edit(deposito newdeposito) {
            bool Result = false;
            using (var r = new Repository<deposito>()) {
                deposito tmp = r.Retrieve(
                    p => p.num_convenio == newdeposito.num_convenio &&
                    p.id_deposito != newdeposito.id_deposito);
                if (tmp == null) {
                    Result = r.Update(newdeposito);
                } else {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public deposito Retrieve(int id) {
            deposito Result = null;
            using (var r = new Repository<deposito>()) {
                Result = r.Retrieve(p => p.id_deposito == id);
            }
            return Result;
        }

        public List<deposito> RetrieveAll() {
            List<deposito> Result = null;
            using (var r = new Repository<deposito>()) {
                Result = r.RetrieveAllOrder(p => p.banco);
            }
            return Result;
        }

        public bool Delete(int id) {
            bool Result = false;
            var cate = Retrieve(id);
            if (cate != null) {
                using (var r = new Repository<deposito>()) {
                    Result = r.Delete(cate);
                }
            } else {
                throw (new Exception("Error al eliminar la categoía"));
            }
            return Result;
        }
    }
}
