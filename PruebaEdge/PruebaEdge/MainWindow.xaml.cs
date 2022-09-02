using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PruebaEdge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBApi dBApi = new DBApi();
        List<string> listaPersonajes = new List<string>();
        public MainWindow()
        {
           InitializeComponent();

            //Lista de personajes 
            listaPersonajes.Add("Luke Skywalker");
            listaPersonajes.Add("C-3PO");
            listaPersonajes.Add("R2-D2");
            listaPersonajes.Add("Darth Vader");
            listaPersonajes.Add("Leia Organa");
            listaPersonajes.Add("Owen Lars");
            listaPersonajes.Add("Beru Whitesun lars");
            listaPersonajes.Add("R5-D4");
            listaPersonajes.Add("Biggs Darklighte");
            listaPersonajes.Add("Obi-Wan Kenobi");


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Carga de personajes en el ComboBox
            cboPersonajes.ItemsSource = listaPersonajes;
            
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {   
            //Asocie el puntero del Array con el ID del personaje para buscar los datos especificos asociados a ese ID del personaje
            int id;
            if (cboPersonajes.SelectedItem != null)
            {
                id= cboPersonajes.SelectedIndex+1;
                dynamic respuesta = dBApi.Get("https://swapi.dev/api/people/" + id);
                lblAlturaResult.Content = respuesta.height;
                lblMasaResult.Content = respuesta.mass;
                lblColorPeloResult.Content = respuesta.hair_color;
                lblColorOjosResult.Content = respuesta.eye_color;
                lblGeneroResult.Content = respuesta.gender;
            }











            }
        }

    }
    

