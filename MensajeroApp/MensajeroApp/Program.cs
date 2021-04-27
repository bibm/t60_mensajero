using MensajeModel.DAL;
using MensajeModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroApp
{
    class Program
    {
        static IMensajesDAL dal = MensajesDALFactory.CreateDAL();
        static void IngresarMensaje()
        {
            string nombre, detalle;
            do
            {
                Console.WriteLine("Ingrese nombre");
                nombre = Console.ReadLine().Trim();
                
            } while (nombre == string.Empty);

            do
            {
                Console.WriteLine("Ingrese detalle");
                detalle = Console.ReadLine().Trim();

            } while (detalle == string.Empty);
            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo = "Aplicacion"
            };
            dal.Save(m);

        }

        static void MostrarTodos()
        {
            List<Mensaje> lista = dal.GetAll();
            lista.ForEach(m =>
            {
                Console.WriteLine("N:{0} | D:{1} | T:{2}", m.Nombre, m.Detalle, m.Tipo);
            });
        }

        static bool Menu()
        {
            bool continuar = true;

            Console.WriteLine("1. Ingresar mensaje\n 2.Mostrar mensajes" + "0. Salir");
            string respuesta = Console.ReadLine().Trim();

            switch (respuesta)
            {
                case "1":
                    IngresarMensaje();
                    break;
                case "2":
                    MostrarTodos();
                    break;                    
                default:
                    Console.WriteLine("Ingrese opcion valida");
                    break;
            }

            return continuar;
        }

        static void Main(string[] args)
        {
            while (Menu()) ;
        }
    }
}
