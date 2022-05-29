using ECommerce.Selling.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ECommerce.Selling.DataAccess
{
    public class VentaModelDAO
    {
        #region singleton
        private static readonly VentaModelDAO _instancia = new VentaModelDAO();
        public static VentaModelDAO Instancia { get { return _instancia; } }
        #endregion singleton

        public List<VentaModel> Listar()
        {
            SqlCommand cmd = null;
            List<VentaModel> list = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarVentaModels", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                list = new List<VentaModel>();
                while (dr.Read())
                {
                    VentaModel VentaModel = new VentaModel();
                    VentaModel.Id = Convert.ToString(dr["Id"]);
                    VentaModel.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    VentaModel.MedioDePago = Convert.ToString(dr["MedioDePago"]);
                    VentaModel.PrecioTotal = Convert.ToDecimal(dr["PrecioTotal"]);
                    VentaModel.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    list.Add(VentaModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return list;
        }

        public VentaModel Devolver(string id)
        {
            SqlCommand cmd = null;
            VentaModel VentaModel = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spDevolverVentaModel", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    VentaModel = new VentaModel();
                    VentaModel.Id = Convert.ToString(dr["Id"]);
                    VentaModel.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    VentaModel.MedioDePago = Convert.ToString(dr["MedioDePago"]);
                    VentaModel.PrecioTotal = Convert.ToDecimal(dr["PrecioTotal"]);
                    VentaModel.Fecha = Convert.ToDateTime(dr["Fecha"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return VentaModel;
        }

        public bool Insertar(VentaModel VentaModel)
        {
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spInsertarVentaModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", VentaModel.Id);
                cmd.Parameters.AddWithValue("@IdUsuario", VentaModel.IdUsuario);
                cmd.Parameters.AddWithValue("@MedioDePago", VentaModel.MedioDePago);
                cmd.Parameters.AddWithValue("@PrecioTotal", VentaModel.PrecioTotal);
                //cmd.Parameters.AddWithValue("@Fecha", VentaModel.Fecha);

                cn.Open();

                int nro = cmd.ExecuteNonQuery();
                if (nro > 0) creado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return creado;
        }

        public bool Eliminar(string id)
        {
            SqlCommand cmd = null;
            bool eliminado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spEliminarVentaModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();

                int nro = cmd.ExecuteNonQuery();
                if (nro > 0) eliminado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return eliminado;
        }

        public bool Actualizar(VentaModel VentaModel)
        {
            SqlCommand cmd = null;
            bool editado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spActualizarVentaModel", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", VentaModel.Id);
                cmd.Parameters.AddWithValue("@IdUsuario", VentaModel.IdUsuario);
                cmd.Parameters.AddWithValue("@MedioDePago", VentaModel.MedioDePago);
                cmd.Parameters.AddWithValue("@PrecioTotal", VentaModel.PrecioTotal);
                //cmd.Parameters.AddWithValue("@Fecha", VentaModel.Fecha);

                cn.Open();

                int nro = cmd.ExecuteNonQuery();
                if (nro > 0) editado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return editado;
        }
    }
}
