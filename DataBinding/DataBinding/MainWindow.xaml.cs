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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Binding sliderValue_CanvasHeightConnector = new Binding();

            ////Source Object 
            //sliderValue_CanvasHeightConnector.Source = zoomCtrl;

            //// source properties { CLR Property Or DP } 
            //// Reflection

            //sliderValue_CanvasHeightConnector.Path = new PropertyPath("Value");
            ////Set Target Property 

            //canvasArea.SetBinding(Rectangle.HeightProperty, sliderValue_CanvasHeightConnector);

        }
    }
}
