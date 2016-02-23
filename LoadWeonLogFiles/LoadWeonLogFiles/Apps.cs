using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace LoadWeonLogFiles
{
    class Apps
    {
        string ruta;
        public Apps(String ruta)
        {
            this.ruta = ruta;
        }
        public void Registrar()
        {
            foreach (string file in Directory.GetFiles(ruta, "*.Apps"))
            {
                Console.WriteLine(file);
                StreamReader sr = File.OpenText(file);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    registraAPP(line);
                    Console.WriteLine(line);
                }
                sr.Close();
                File.Delete(file);
            }
        }
        public void registraAPP(string line)
        {
            //MAC|App!
            AccessConeccion ac = new AccessConeccion();
            string[] aux = new string[] { "|" };
            string[] Parametros;
            Parametros = line.Split(aux, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                string cmd = "INSERT INTO [usr].[UsersApps] " +
                                    "([Usuario],[App]) " +
                             "VALUES " +
                                        "('" + Parametros[0].Replace(":", "!") + "','" + Parametros[1].Replace("!", "") + "')";


                ac.ExecutaEscalar(cmd);
            }
            catch (Exception) { }
        }
    }
}
