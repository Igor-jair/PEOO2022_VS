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

namespace AbastecimentoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Abastecimento obj = new Abastecimento();
            obj.SetValorKmRodados(double.Parse(txt1.Text));
            obj.SetValorPago(double.Parse(txt2.Text));
            obj.SetValorLitro(double.Parse(txt3.Text));
            txt4.Text = obj.MediakmLitro().ToString("0.00");
            txt5.Text = obj.MediaReaisKm().ToString("0.00");
        }

    }
}
