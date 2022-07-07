using EntityLibreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebWCFLibreria
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceLibreria" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceLibreria
    {
        [OperationContract]
        EntRespuesta Obtener();

        [OperationContract]
        EntRespuesta ObtenerC();    

        [OperationContract]
        EntRespuesta IdObtener(int id);

        [OperationContract]
        EntRespuesta Actualizar(EntLibreria l);

        [OperationContract]
        EntRespuesta Agregar(EntLibreria l);

        [OperationContract]
        EntRespuesta Buscar(string valor);

        [OperationContract]
        EntRespuesta Eliminar(int id);
        
        [OperationContract]
        EntRespuesta ValidarRepetido(EntLibreria l);
    }
}
