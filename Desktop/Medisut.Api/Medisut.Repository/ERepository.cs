using Medisut.DomainClass;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medisut.Repository
{
    public class ERepository
    {
        Database db;
        public ERepository(string strConnection)
        {
            db = new SqlDatabase(strConnection);
        }

        public DataTable Get()
        {
            DataSet ds = db.ExecuteDataSet("spConsultaProductos");
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        public DataTable Get(int id)
        {
            DataSet ds = db.ExecuteDataSet("spBuscarProducto", id);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        public string Post(Producto pr)
        {
            object[] param = new object[3];
            param[0] = pr.Descripcion;
            param[1] = pr.CodigoProducto;
            param[2] = pr.Precio;
            int result = db.ExecuteNonQuery("spInsertarProducto", param);
            if (result != 0)
                return "Success";
            return "No Success";
        }

        public string Put(Producto pr)
        {
            object[] param = new object[4];
            param[0] = pr.Id;
            param[1] = pr.Descripcion;
            param[2] = pr.CodigoProducto;
            param[3] = pr.Precio;
            int result = db.ExecuteNonQuery("spEditarProducto", param);
            if (result != 0)
                return "Success";
            return "No Success";
        }

        public string Delete(int id)
        {
            int result = db.ExecuteNonQuery("spEliminarProducto", id);
            if (result != 0)
                return "Success";
            return "No Success";
        }
    }
}
