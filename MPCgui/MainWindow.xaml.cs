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

using MPC.api;

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

            //Setup API to suuport message redirection
            MPC.api.MPC.MPCOut.OnAPIMessage += MPCOut_OnAPIMessage;
            MPC.api.MPC.init();

            MPCOut.Items.Add("MPC> Waiting... ");
        }

        //Handles output from API to the GUI
        void MPCOut_OnAPIMessage(string Message)
        {
            MPCOut.Items.Add(Message);
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
