using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Web;

namespace ParcialPractica2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ListaClientes lstClientes = new ListaClientes();

        private void Form1_Load(object sender, EventArgs e)
        {
            string miArchivo = "Clientes.dat";

            if (File.Exists(miArchivo))
            {
                try
                {
                    FileStream fileStream = new FileStream(miArchivo, FileMode.Open, FileAccess.Read);
                    BinaryFormatter bf = new BinaryFormatter();
                    lstClientes = (ListaClientes)bf.Deserialize(fileStream);
                    fileStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al deserializar: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("El archivo no existe.");
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string miArchivo = "Clientes.dat";
            if (File.Exists(miArchivo))
                File.Delete(miArchivo);

            FileStream archivo = new FileStream(miArchivo, FileMode.CreateNew, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(archivo, lstClientes);

            archivo.Close();
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de texto (*.txt) | *.txt";
            string archivo;
            if(openFileDialog1.ShowDialog() == DialogResult.OK )
            {
                archivo = openFileDialog1.FileName;
                FileStream fs = new FileStream(archivo,FileMode.Open,FileAccess.Read);
                StreamReader sr = new StreamReader(fs);

                string renglon;
                string[] datos;

                try
                {
                    while (!sr.EndOfStream)
                    {
                        renglon = sr.ReadLine();
                        datos = renglon.Split(';');

                        Cliente cliente = lstClientes.VerCliente(Convert.ToInt32(datos[0]));
                        if (cliente == null)
                        {
                            cliente = new Cliente("No definido", Convert.ToInt32(datos[0]), 100);
                        }
                        if (datos[1] == "C")
                        {
                            cliente.AgregarCompra(Convert.ToDouble(datos[2]));
                        }
                        else if (datos[1] == "P")
                        {
                            cliente.AgregarPago(Convert.ToDouble(datos[2]));
                        }
                    }
                }
                catch (Exception ex)
                { 
                    MessageBox.Show(ex.Message);
                }
                finally 
                { 
                    sr.Dispose();
                    fs.Close();
                }

            }
        }

        private void btnResumen_Click(object sender, EventArgs e)
        {
            string archivo = "Resumen.txt";
            saveFileDialog1.FileName = archivo;
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(archivo))
                    File.Delete(archivo);

                FileStream  fs = new FileStream(archivo, FileMode.CreateNew,FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                foreach(Cliente cliente in lstClientes.ListaCompleta())
                {
                    string linea = cliente.Codigo + ";" + cliente.LeerSaldo();
                    sw.WriteLine(linea);
                    lbClientes.Items.Add(linea);
                }

                sw.Close();
                fs.Close();
            }

        }
    }
}
