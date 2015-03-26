using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MPCgui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MPCOut.Items.Add("MPC> Waiting... ");
        }

        private void btnCompile_Click(object sender, RoutedEventArgs e)
        {
            MPCOut.Items.Add("MPC> Compiling...");
            MPCOut.Items.Add("MPC>> DONE");
        }

        private void btnPublish_Click(object sender, RoutedEventArgs e)
        {
            MPCOut.Items.Add("MPC> Publishing...");
            MPCOut.Items.Add("MPC>> DONE");
        }

        //Clears output screen of Data
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            MPCOut.Items.Clear();
            MPCOut.Items.Add("MPC> Waiting...");
        }



    }
}
