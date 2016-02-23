using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace LoadWeonLogFiles
{
    class Intereses
    {
        string ruta;
        public Intereses(String ruta)
        {
            this.ruta = ruta;
        }
        public void Registrar()
        {
            foreach (string file in Directory.GetFiles(ruta, "*.0"))
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
            string[] aux = new string[] { " " };
            string[] Parametros;
            Parametros = line.Split(aux, StringSplitOptions.RemoveEmptyEntries);
            try
            {
            string cmd = "INSERT INTO [usr].[Intereses] "+
                                "([Interes],[Usuario]) " +
                         "VALUES " +
                                    "('" + Parametros[0].Replace(":", "!")  + "','" + Parametros[1]+ "')";

            
                ac.ExecutaEscalar(cmd);
            }
            catch (Exception) { }
        }
    }
}
