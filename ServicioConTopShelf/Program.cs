using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ServicioConTopShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(configuracionDelServicio=> {
                configuracionDelServicio.Service<ServicioConvertidorDeArchivos>
                (
                    instanciaDelServicio =>
                    {
                        instanciaDelServicio.ConstructUsing(() => new ServicioConvertidorDeArchivos());
                        instanciaDelServicio.WhenStarted(servicioEnEjecucion => servicioEnEjecucion.Comenzar());
                        instanciaDelServicio.WhenStopped(servicioEnEjecucion => servicioEnEjecucion.Detenerce());
                    }
                );
                configuracionDelServicio.StartAutomatically();
                configuracionDelServicio.SetDisplayName("Conversor de Archivos");
                configuracionDelServicio.SetDescription("Convierte los archivos en la carpeta temporal a mayusculas");
                configuracionDelServicio.SetServiceName("ConversorDeArchivos");
            });
        }
    }
}
