using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
namespace CRUD
{
    public class Datos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["tecsup"].ConnectionString);
        //create proc for CRUD
        public void InsertData(int id, string name, string desc)
        {
            SqlCommand cmd = new SqlCommand("usp_insertar_cate", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //params
            cmd.Parameters.AddWithValue("@codigo", id);
            cmd.Parameters.AddWithValue("@nombre", name);
            cmd.Parameters.AddWithValue("@detalle", desc);
            //open a db conn
            cn.Open();
            //execute a command with a respective method
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void UpdateData(int id, string name, string desc)
        {
            SqlCommand cmd = new SqlCommand("usp_update_cate", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //params
            cmd.Parameters.AddWithValue("@codigo", id);
            cmd.Parameters.AddWithValue("@nombre", name);
            cmd.Parameters.AddWithValue("@detalle", desc);
            //open a db conn
            cn.Open();
            //execute a command with a respective method
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void DeleteData(int id)
        {
            SqlCommand cmd = new SqlCommand("usp_delete_cate", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //params
            cmd.Parameters.AddWithValue("@codigo", id);
            //open a db conn
            cn.Open();
            //execute a command with a respective method
            cmd.ExecuteNonQuery();
            cn.Close();
        }
        public DataTable ReadData()
        {
            //do read & destroy requirements
            using (SqlDataAdapter da = new SqlDataAdapter("usp_select_cate", cn))
            {
                //object read
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                using (DataTable dt = new DataTable())
                {
                    //fill dataTable
                    da.Fill(dt);
                    return dt;
                }

            }
        }
    }
}