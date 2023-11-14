using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPractica2
{
    public class ListaClientes
    {
        private List<Cliente> listado;
        public int UltimoCodigo
        {
            get { return UltimoCodigo; }
            set {  UltimoCodigo = value; }
        }
        public int TotalDeClientes
        {
            get { return TotalDeClientes; }
            set {  TotalDeClientes = value; }
        }
        public bool AgregarCliente(Cliente nuevoCliente)
        {
            listado.Add(nuevoCliente);
        }
        public bool BorrarCliente(int codigo)
        {

        }
        public Cliente VerCliente() 
        {
            
        }
        public Cliente[] ListaCompleta()
        {

        }
    }
}
