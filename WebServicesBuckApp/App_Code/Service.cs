using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	public int GetData(String rol)
	{
        int i = 0;

        if(rol.Equals("admin"))
        {
            i = 1;
        }
        else if (rol.Equals("user"))
        {
            i = 2;
        }
        return i;
	}
}
