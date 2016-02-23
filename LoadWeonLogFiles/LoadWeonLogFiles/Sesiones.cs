using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace LoadWeonLogFiles
{
    class Sesiones
    {
        string ruta;
        public Sesiones(String ruta)
        {
            this.ruta = ruta;
        }
        public void Registrar()
        {
            foreach (string file in Directory.GetFiles(ruta, "*.InciosSesion.txt"))
            {
                Console.WriteLine(file);
                StreamReader sr = File.OpenText(file);
                string line;
                string Camion = Path.GetFileNameWithoutExtension(file).Substring(0, Path.GetFileNameWithoutExtension(file).IndexOf("."));
                while ((line = sr.ReadLine()) != null)
                {
                    registraUsuario(line,Camion);
                    Console.WriteLine(line);
                }
                sr.Close();
                File.Delete(file);
            }
        }
        public void registraUsuario(string line,string Camion)
        {
            //MAC|Sexo|Fecha
            AccessConeccion ac = new AccessConeccion();
            string[] aux = new string[] { "|" };
            string[] Parametros;
            Parametros = line.Split(aux, StringSplitOptions.RemoveEmptyEntries);
            try
            {
            string cmd = "INSERT INTO [usr].[Conexiones] "+
                                    "([Hora],[Usuario],[Camion]) " +
                         "VALUES " +
                                    "('" + Parametros[0] + "','" + Parametros[1].Replace(":", "!") + "'," + Camion + ")";

            
                ac.ExecutaEscalar(cmd);
            }
            catch (Exception) { }
        }
    }
}
