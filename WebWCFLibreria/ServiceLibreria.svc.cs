using DataBusinessLibreria;
using EntityLibreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebWCFLibreria
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceLibreria" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceLibreria.svc o ServiceLibreria.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceLibreria : IServiceLibreria
    {
        public EntRespuesta Obtener()
        {
            EntRespuesta er = new EntRespuesta();
            try
            {
                DBLibreria datos = new DBLibreria();
                List<EntLibreria> list = datos.Obtener();
                er.LibrosLista = list;
                return er;
            }
            catch (Exception ex)
            {
                er.Error = true;
                er.Msj = ex.Message;
                return er;
            }
        }
        public EntRespuesta ObtenerC() 
        {
            EntRespuesta er = new EntRespuesta();
            try
            {               
                DBCategoria datos = new DBCategoria();
                List<EntCategoria> ls = datos.ObtenerC();
                er.ListaCategoria = ls;
                return er;
            }
            catch (Exception ex)
            {
                er.Error = true;
                er.Msj = ex.Message;
                return er;
            }
        }
        public EntRespuesta IdObtener(int id) 
        {
            EntRespuesta er = new EntRespuesta();
            try
            {
                DBLibreria datos = new DBLibreria();
                EntLibreria l = datos.IdObtener(id);
                er.EntLibre = l;
                return er;
            }
            catch (Exception ex)
            {
                er.Error = true;
                er.Msj = ex.Message;
                return er;
            }
        }
        public EntRespuesta Actualizar(EntLibreria l) 
        {
            EntRespuesta er = new EntRespuesta();
            try
            {
                DBLibreria datos = new DBLibreria();
                datos.Editar(l);
                return er;
            }
            catch (Exception ex)
            {
                er.Error = true;
                er.Msj = ex.Message;
                return er;
            }
        }
        public EntRespuesta Agregar(EntLibreria l) 
        {
            EntRespuesta er = new EntRespuesta();
            try
            {
                DBLibreria datos = new DBLibreria();
                datos.Agregar(l);
                return er;
            }
            catch (Exception ex)
            {
                er.Error = true;
                er.Msj = ex.Message;
                return er;
            }
        }
        public EntRespuesta Eliminar(int id) 
        {
            EntRespuesta er = new EntRespuesta();
            try
            {
                DBLibreria datos = new DBLibreria();
                datos.Eliminar(id);
                return er;
            }
            catch (Exception ex)
            {
                er.Error = true;
                er.Msj = ex.Message;
                return er;
            }
        }
        public EntRespuesta Buscar(string Valor) 
        {
            EntRespuesta er = new EntRespuesta();
            try
            {
                DBLibreria datos = new DBLibreria();
                List<EntLibreria> l = datos.Buscar(Valor);
                er.LibrosLista = l;
                return er;
            }
            catch (Exception ex)
            {
                er.Error = true;
                er.Msj = ex.Message;
                return er;
            }
        }
        public EntRespuesta ValidarRepetido(EntLibreria l) 
        {
            EntRespuesta er = new EntRespuesta();
            try
            {
                DBLibreria datos = new DBLibreria();
                datos.ValidarRepetido(l);
                return er;
            }
            catch (Exception ex)
            {
                er.Error = true;
                er.Msj = ex.Message;
                return er;
            }
        }

    }
}
