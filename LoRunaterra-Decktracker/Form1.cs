using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoRDeckCodes;
using static LoRDeckCodes.LoRDeckEncoder;



namespace LoRunaterra_Decktracker
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            List<CardCodeAndCount> aux = new List<CardCodeAndCount>();
            aux = GetDeckFromCode("CEBAIAIFB4WDANQIAEAQGDAUDAQSIJZUAIAQCBIFAEAQCBAA");
            foreach (var x in aux)
            {
                Console.WriteLine(x.CardCode);
                Console.WriteLine(x.Count);
            }

            //Inicializamos el formulario de status
            IniciarStatus();
        }
        private void AbrirFormularios(object formHijo)
        {
            //panelContenedor es el panel que se encargara de contener el nuevo formulario
            if (panel_contendor.Controls.Count > 0)
            {
                //Si hay algun otro form cargado en el panel se borra
                panel_contendor.Controls.RemoveAt(0);
            }
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            panel_contendor.Controls.Add(fh);
            panel_contendor.Tag = fh;
            fh.Show();
        }

        private void btn_inicio_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new InicioForm());
        }

        private void btn_historial_Click(object sender, EventArgs e)
        {
            AbrirFormularios(new Historial());
        }

        private void IniciarStatus()
        {
            //Puesto a fuego por ahora, cambiar en un futuro
            label_status.Text = "Buscando partida";
            label_status.Refresh();
        }
    }

}
