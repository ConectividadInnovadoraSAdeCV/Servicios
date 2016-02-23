using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data;
using System.Text;

namespace MovilRestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetDataUsingMethod(string value)
        {
            return value + "I am returned by Method Name";
        }
        public string GetCamionesCercanos(string value)
        {

            AccessConeccion ac = new AccessConeccion(); 
            string res = "";
            string [] aux=new string[]{"|"};
            string[] Parametros;
            Parametros = value.Split(aux, StringSplitOptions.RemoveEmptyEntries);
            string cmd = "SELECT Latitud,Longitud,Pasajeros,Rampa "+
                         "FROM [dbo].[GetCamiones] (" + Parametros[0] + "," + Parametros[1].Replace(",", ".") + "," + Parametros[2].Replace(",", ".") + ")";
            DataTable dt = ac.ObtieneTabla(cmd);
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    res += r["Latitud"] + "|" + r["Longitud"] + "|" + r["Pasajeros"] + "|" + r["Rampa"] + ";";
                }
            }
            return res;
        }

        public string AltaUsuario(string value)
        {
            //MAC|Sexo|Fecha
            AccessConeccion ac = new AccessConeccion();
            string res = "si";
            string[] aux = new string[] { "|" };
            string[] Parametros;
            Parametros = value.Split(aux, StringSplitOptions.RemoveEmptyEntries);

            string cmd = "INSERT INTO [usr].[Usuarios] "+
                                    "([Mac],[Sexo],[Fecha Nac]) "+
                         "VALUES "+
                                    "('" + Parametros[0] + "'," + Parametros[1] + ",'" + Parametros[2] + "')";

            if (ac.ExecutaEscalar(cmd) == null)
            {
                cmd = "UPDATE [usr].[Usuarios] "+
                            "SET [Sexo] = " + Parametros[1] + ",[Fecha Nac] = '" + Parametros[2] + "',[Fecha Registro] = GETDATE() " +
                      "WHERE [Mac]='" + Parametros[0] + "'";
                if (null == ac.ExecutaEscalar(cmd))
                {
                    res = "no";
                }
            }
            return res;
        }
        public string GetSpots(string value)
        {
            AccessConeccion ac = new AccessConeccion();
            string res = "";
            string[] aux = new string[] { "|" };
            string[] Parametros;
            Parametros = value.Split(aux, StringSplitOptions.RemoveEmptyEntries);
            string cmd = "SELECT ID, Intervalo, Pregunta, [Respuesta 1], [Respuesta 2], [Respuesta 3], Fondo, liga "+
                         "FROM dbo.GetSpots('"+value+"') AS GetSpots_1";
            DataTable dt = ac.ObtieneTabla(cmd);
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    res += r["ID"] + "|" + r["Intervalo"] + "|" + r["Pregunta"] + "|" + 
                            r["Respuesta 1"] + "|" + r["Respuesta 2"] + "|" + r["Respuesta 3"] +
                            "|" + r["Fondo"] + "|" + r["liga"] +";";
                }
            }
            return res;
        }
        public string SetAnswers(string value)
        {
            //ID|Respuesta
            AccessConeccion ac = new AccessConeccion();
            string res = "si";
            string[] aux = new string[] { "|" };
            string[] Parametros;
            Parametros = value.Split(aux, StringSplitOptions.RemoveEmptyEntries);

            string cmd = "UPDATE [spt].[EncuestasUsuarios] "+
                         "SET [Fecha Respuesta]=GETDATE(),[Respuesta] = " + Parametros[0] + " " +
                         "WHERE [ID]="+Parametros[1]+" ";

            if (ac.ExecutaEscalar(cmd) == null)
            {               
              res = "no";
            }
            return res;
        }


        public string GetGps(string value)
        {

            AccessConeccion ac = new AccessConeccion();
            string res = "";
            string[] aux = new string[] { "|" };
            string[] Parametros;
            Parametros = value.Split(aux, StringSplitOptions.RemoveEmptyEntries);
            string cmd = "SELECT [Latitud],[Longitud],[Fecha] "+
                         "FROM [GPS].[dbo].[CurrentLocation] WHERE [Pwd]='"+value+"'";
            DataTable dt = ac.ObtieneTabla(cmd);
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    res += r["Latitud"] + "|" + r["Longitud"] + "|" + r["Fecha"] + ";";
                }
            }
            return res;
        }
        public string SetGps(string value)
        {
            //[Pwd],[Latitud],[Longitud]
            AccessConeccion ac = new AccessConeccion();
            string res = "si";
            string[] aux = new string[] { "|" };
            string[] Parametros;
            Parametros = value.Split(aux, StringSplitOptions.RemoveEmptyEntries);

            string cmd = "INSERT INTO [GPS].[dbo].[GPS] "+
                            "([Pwd],[Latitud],[Longitud])  "+
                  "VALUES "+
                            "('" + Parametros[0] + "'," + Parametros[1] + "," + Parametros[2] + ")";

            if (ac.ExecutaEscalar(cmd) == null)
            {
                res = "no";
            }
            return res;
        }
    }
}
