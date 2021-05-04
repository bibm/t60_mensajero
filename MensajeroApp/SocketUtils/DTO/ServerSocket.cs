using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketUtils.DTO
{
    public class ServerSocket
    {
        private int puerto;
        private Socket servidor;
        

        public ServerSocket (int puerto)
        {
            this.puerto = puerto;
        }

        public bool Iniciar()
        {
            try
            {
                //Se crea una instancia de socket en servidor
                this.servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //Se especifica las ip's y puertos a utilizar. Se usa bind para tomar posesión del puerto.
                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                //Se especifica la cantidad maxima de clientes en espera que el server puede escuchar o recibir.
                this.servidor.Listen(10);
                return true;
            }catch(IOException ex)
            {
                return false;
            }
        }

        

        public ClienteSocket ObtenerCliente()
        {
            try
            {
                return new ClienteSocket(this.servidor.Accept());
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        

    }
}
