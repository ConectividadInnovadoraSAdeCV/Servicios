using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace LoadWeonLogFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            //*
            string ruta = @"C:\Dropbox\ArchivosBBB\Informacion";
            /*/
            string ruta = @"C:\Dropbox";
            //*/
            //comienzo con usuario registrados
            
            RegistrarUsuarios ru = new RegistrarUsuarios(ruta);
            ru.Registrar();
             
            Sesiones ss = new Sesiones(ruta);
            ss.Registrar();
            
            Intereses i = new Intereses(ruta);
            i.Registrar();

            Apps ap = new Apps(ruta);
            ap.Registrar();
        }       

    }
}
