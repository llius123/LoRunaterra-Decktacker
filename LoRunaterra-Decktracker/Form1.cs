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
using System.Configuration;
using LoRunaterra_Decktracker.API;

namespace LoRunaterra_Decktracker
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //Inicializamos el formulario de status
            IniciarStatus();
            //Inicializamos la busqueda de partida
            IniciarBusqueda();


            //Pruebas que hay que eliminar en un futuro

            //Prueba de la libreria de decodificacion de deck
            //List<CardCodeAndCount> aux = new List<CardCodeAndCount>();
            //aux = GetDeckFromCode("CEBAIAIFB4WDANQIAEAQGDAUDAQSIJZUAIAQCBIFAEAQCBAA");
            //foreach (var x in aux)
            //{
            //    Console.WriteLine(x.CardCode);
            //    Console.WriteLine(x.Count);
            //}

            //Prueba del archivo de configuracion
            //Console.WriteLine(ConfigurationManager.AppSettings["api_runaterra"]);
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
            AbrirFormularios(new Mazos());
        }

        private void IniciarStatus()
        {
            //Puesto a fuego por ahora, cambiar en un futuro
            label_status.Text = "Buscando partida";
            label_status.Refresh();
        }
        private void IniciarBusqueda()
        {
            ApiRunaterraJuego juego = new ApiRunaterraJuego();

            juego.getStaticDecklist();
        }
    }

}
