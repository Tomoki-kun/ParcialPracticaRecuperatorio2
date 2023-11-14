using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialPractica2
{
    public class Cliente:IComparable
    {
        private string razonSocial;
        private int codigo;
        private double saldo;
        private double tope;

        public Cliente(string nombre, int codigo, double tope)
        {
            this.razonSocial = nombre;
            this.codigo = codigo;
            this.tope = tope;
        }

        public void AgregarCompra(double monto)
        {
            if (saldo + monto <= tope)
                saldo += monto;
        }

        public void AgregarPago(double monto)
        {
            saldo -= monto;
        }

        public double LeerSaldo()
        {
            return saldo;
        }

        public int CompareTo(object obj)
        {
            return this.codigo.CompareTo(((Cliente)obj).codigo);
        }
    }
}
