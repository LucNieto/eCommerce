using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL {
    public class PlasticoBLL {
        
        
         public plastico Create(plastico tarjeta)
        {
            plastico Result = null;
            using (var r = new Repository<plastico>())
            {
                plastico tmp = r.Retrieve(
                    p => p.numero_tarjeta == tarjeta.numero_tarjeta);
                if (tmp == null)
                {
                    Result = r.Create(tarjeta);
                }
                else
                {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public bool Edit(plastico tarjeta)
        {
            bool Result = false;
            using (var r = new Repository<plastico>())
            {
                plastico tmp = r.Retrieve(
                    p => p.numero_tarjeta == tarjeta.numero_tarjeta &&
                    p.id_tarjeta != tarjeta.id_tarjeta);
                if (tmp == null)
                {
                    Result = r.Update(tarjeta);
                }
                else
                {
                    throw (new Exception());
                }
            }
            return Result;
        }

        public plastico Retrieve(int id)
        {
            plastico Result = null;
            using (var r = new Repository<plastico>())
            {
                Result = r.Retrieve(p => p.id_tarjeta == id);
            }
            return Result;
        }

        public List<plastico> RetrieveAll()
        {
            List<plastico> Result = null;
            using (var r = new Repository<plastico>())
            {
                Result = r.RetrieveAllOrder(p => p.nombre_titular);
            }
            return Result;
        }

        public bool Delete(int id)
        {
            bool Result = false;
            var tarjeta = Retrieve(id);
            if (tarjeta != null)
            {
                using (var r = new Repository<plastico>())
                {
                    Result = r.Delete(tarjeta);
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
