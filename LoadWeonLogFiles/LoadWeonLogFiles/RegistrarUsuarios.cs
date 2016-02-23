using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace LoadWeonLogFiles
{
    class RegistrarUsuarios
    {
        string ruta;
        public RegistrarUsuarios(String ruta)
        {
            this.ruta = ruta;
        }
        public void Registrar()
        {
            foreach (string file in Directory.GetFiles(ruta, "*.Registro.txt"))
            {
                Console.WriteLine(file);
                StreamReader sr = File.OpenText(file);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    registraUsuario(line);
                    Console.WriteLine(line);
                }
                sr.Close();
                File.Delete(file);
            }
        }
        public void registraUsuario(string line)
        {
            //MAC|Sexo|Fecha
            AccessConeccion ac = new AccessConeccion();
            string[] aux = new string[] { "|" };
            string[] Parametros;
            Parametros = line.Split(aux, StringSplitOptions.RemoveEmptyEntries);
            try
            {
            string cmd = "INSERT INTO [usr].[Usuarios] " +
                                    "([Mac],[Sexo],[Fecha Nac]) " +
                         "VALUES " +
                                    "('" + Parametros[0].Replace(":","!") + "'," + Parametros[1] + ",'" + Parametros[2] + "')";

            
                ac.ExecutaEscalar(cmd);
            }
            catch (Exception) { }
        }
    }
}
