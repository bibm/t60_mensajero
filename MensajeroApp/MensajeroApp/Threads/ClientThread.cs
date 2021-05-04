using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MensajeModel.DAL;
using MensajeModel.DTO;
using SocketUtils;

namespace MensajeroApp.Threads
{
    public class ClientThread
    {
        private ClienteSocket cliente;
        private IMensajesDAL dal = MensajesDALFactory.CreateDAL();
        public ClientThread(ClienteSocket cliente)
        {
            this.cliente = cliente;
        }

        public void Ejecutar()
        {
            string nombre, detalle;
            do
            {
                cliente.Escribir("Ingrese nombre");
                nombre = cliente.Leer();

            } while (nombre == string.Empty);

            do
            {
                cliente.Escribir("Ingrese detalle");
                detalle = cliente.Leer();

            } while (detalle == string.Empty);
            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Detalle = detalle,
                Tipo = "TCP"
            };
            lock (dal)
            {
                dal.Save(m);
            }
            cliente.CerrarConexion();
        }
    }



}
