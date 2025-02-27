﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketUtils
{
    public class ClienteSocket
    {

        private Socket comCliente;
        private StreamWriter writer;
        private StreamReader reader;

        public ClienteSocket(Socket comCliente)
        {
            this.comCliente = comCliente;

            Stream stream = new NetworkStream(this.comCliente);
            this.writer = new StreamWriter(stream);
            this.reader = new StreamReader(stream);
        }

        public bool Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
        }

        public string Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void CerrarConexion()
        {
            this.comCliente.Close();
        }

    }
}
