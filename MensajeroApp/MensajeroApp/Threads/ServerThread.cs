using SocketUtils;
using SocketUtils.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MensajeroApp.Threads
{
    public class ServerThread
    {
        private int puerto;
        private ServerSocket server;
        public ServerThread(int puerto)
        {
            this.puerto = puerto;    
        }

        public void Ejecutar()
        {
            server = new ServerSocket(puerto);
            Console.WriteLine("Iniciando server de comunicaciones...");
            {
                if (server.Iniciar())
                {
                    Console.WriteLine("Iniciando en puerto {0}", puerto);
                    while (true)
                    {
                        Console.WriteLine("Esperando conexiones de clientes...");
                        ClienteSocket cliente = server.ObtenerCliente();

                        if(cliente != null)
                        {
                            Console.WriteLine("Conexion recibida desde Cliente");
                            //Aqui iniciar hilo del cliente
                            ClientThread hiloCliente = new ClientThread(cliente);
                            Thread t = new Thread(new ThreadStart(hiloCliente.Ejecutar));
                            t.IsBackground = true;
                            t.Start();
                        }


                    }
                }
            }
        }

    }
}
