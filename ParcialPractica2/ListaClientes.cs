using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPractica2
{
    [Serializable]
    public class ListaClientes
    {
        private List<Cliente> listado;
        public int UltimoCodigo
        {
            get { return UltimoCodigo; }
            set { UltimoCodigo = value; }
        }
        public int TotalDeClientes
        {
            get { return TotalDeClientes; }
            set { TotalDeClientes++; }
        }
        public bool AgregarCliente(Cliente nuevoCliente)
        {
            bool ret = false;
            listado.Sort();
            if (listado.BinarySearch(nuevoCliente) < 0)
            {
                listado.Add(nuevoCliente);
                ret = true;
            }
            return ret;
        }
        public bool BorrarCliente(int codigo)
        {
            bool ret = false;
            Cliente cliente = new Cliente("", codigo, 0);
            listado.Sort();
            int pos = listado.BinarySearch(cliente);
            if (pos > -1)
            {
                listado.RemoveAt(pos);
                ret = true;
            }
            return ret;
        }
        public Cliente VerCliente(int codigo)
        {
            Cliente cliente = new Cliente("", codigo, 0);
            Cliente ret = null;
            listado.Sort();
            int pos = listado.BinarySearch(cliente);
            if (pos > -1)
            {
                ret = listado[pos];
            }
            return ret;
        }
        public Cliente[] ListaCompleta()
        {
            Cliente[] ret = null;
            for(int i = 0; i < listado.Count; i++)
            {
                ret[i] = listado[i];
            }
            return ret;
        }
    }
}
