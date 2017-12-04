using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class UsuariosBLL {
        public Usuario Create(Usuario newUsuario) {
            Usuario Result = null;
            using (var r = new Repository<Usuario>()) {
                Usuario tmp = r.Retrieve(
                    p => p.email == newUsuario.email);
                if (tmp == null) {
                    Result = r.Create(newUsuario);
                } else {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public bool Edit(Usuario newUsuario) {
            bool Result = false;
            using (var r = new Repository<Usuario>()) {
                Usuario tmp = r.Retrieve(
                    p => p.email == newUsuario.email &&
                    p.UsuarioId != newUsuario.UsuarioId);
                if (tmp == null) {
                    Result = r.Update(newUsuario);
                } else {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public Usuario Retrieve(string id) {
            Usuario Result = null;
            using (var r = new Repository<Usuario>()) {
                Result = r.Retrieve(p => p.UsuarioId == id);
            }
            return Result;
        }

        public Usuario Sesion(string email, string password) {
            Usuario Result = null;

            using (var r = new Repository<Usuario>()) {
                Result = r.Retrieve(p => p.email == email && p.password == password);
            }
            return Result;
        }

        public List<Usuario> RetrieveAll() {
            List<Usuario> Result = null;
            using (var r = new Repository<Usuario>()) {
                Result = r.RetrieveAllOrder(p => p.nombre);
            }
            return Result;
        }

        public bool Delete(string id) {
            bool Result = false;
            var usuario = Retrieve(id);
            if (usuario != null) {
                using (var r = new Repository<Usuario>()) {
                    Result = r.Delete(usuario);
                }
            } else {
                throw (new Exception());
            }
            return Result;
        }
    }
}
