using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioConTopShelf
{
    class ServicioConvertidorDeArchivos
    {
        private FileSystemWatcher _observadorDeArchivos;
        public bool Comenzar() {
            this._observadorDeArchivos = new FileSystemWatcher(@"C:\temp\archivosDeTexto", "*.txt");
            this._observadorDeArchivos.Created += this.convertirArchivo;
            this._observadorDeArchivos.IncludeSubdirectories = false;
            this._observadorDeArchivos.EnableRaisingEvents = true;
            return true;
        }

        private void convertirArchivo(object sender, FileSystemEventArgs e)
        {
            string contenidoDelArchivo = File.ReadAllText(e.FullPath);
            if (e.FullPath.Contains("convertido")) return;
            string contenideoDelArchivoEnMayuscula = contenidoDelArchivo.ToUpperInvariant();
            string ruteDelNuevoArchivo = this.enrutarArchivo(e);
            File.WriteAllText(ruteDelNuevoArchivo, contenideoDelArchivoEnMayuscula);

        }

        private string enrutarArchivo(FileSystemEventArgs e)
        {
            string directorio = Path.GetDirectoryName(e.FullPath);
            string nombreDelArchivo = Path.GetFileName(e.FullPath);
            string nombreDelNuevoArchivo = nombreDelArchivo.Replace(".txt","") + ".convertido.txt";
            return Path.Combine(directorio, nombreDelNuevoArchivo);
        }

        public bool Detenerce() {
            this._observadorDeArchivos.Dispose();
            return true;
        }

    }
}
