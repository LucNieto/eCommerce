using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriasBLL
    {
        public categoria Create(categoria newCategoria)
        {
            categoria Result = null;
            using (var r = new Repository<categoria>())
            {
                categoria tmp = r.Retrieve(
                    p => p.nombre_categoria == newCategoria.nombre_categoria);
                if (tmp == null)
                {
                    Result = r.Create(newCategoria);
                }
                else
                {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public bool Edit(categoria newCategoria)
        {
            bool Result = false;
            using (var r = new Repository<categoria>())
            {
                categoria tmp = r.Retrieve(
                    p => p.nombre_categoria == newCategoria.nombre_categoria &&
                    p.id_categoria != newCategoria.id_categoria);
                if (tmp == null)
                {
                    Result = r.Update(newCategoria);
                }
                else
                {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public categoria Retrieve(int id)
        {
            categoria Result = null;
            using (var r = new Repository<categoria>())
            {
                Result = r.Retrieve(p => p.id_categoria == id);
            }
            return Result;
        }

        public List<categoria> RetrieveAll()
        {
            List<categoria> Result = null;
            using (var r = new Repository<categoria>())
            {
                Result = r.RetrieveAllOrder(p => p.nombre_categoria);
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            var cate = Retrieve(id);
            if (cate != null)
            {
                using (var r = new Repository<categoria>())
                {
                    Result = r.Delete(cate);
                }
            }
            else
            {
                throw (new Exception("Error al eliminar la categoía"));
            }
            return Result;
        }
    }
}
