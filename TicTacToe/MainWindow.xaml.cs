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
using System.Windows.Controls.Primitives;


namespace TicTacToe
{
    public enum Player {
        X,O
    }

    

    public partial class MainWindow : Window
    {
        public Player CurrentPlayer;

        public MainWindow()
        {
            InitializeComponent();
            CurrentPlayer = Player.X;

        }


        private void ButtonClick(object sender,RoutedEventArgs e) {
            var bt = (Button)sender;
            if (bt.Content == null) {

                if (CurrentPlayer == Player.X) {
                    bt.Content = "X";
                    
                }

                if (CurrentPlayer == Player.O)
                {
                    bt.Content = "O";
                }


               CheckVictory();
               ChangePlayer();
            }
        }
        public void ChangePlayer() {

            if (CurrentPlayer == Player.X)
            {
                CurrentPlayer = Player.O;
                ToggleO();

            }
            else {
                CurrentPlayer = Player.X;
                ToggleX();


            }

        }


        public void CheckVictory() { 


        }


        private void PlayerClick(object sender, RoutedEventArgs e) {
            var bt = (ToggleButton)sender;
            if (bt.Content.ToString() == "X") {
                CurrentPlayer = Player.X;
                ToggleX();
            }
            else
            {
                CurrentPlayer = Player.O;
                ToggleO();

            }

        }

        private void ToggleX() {
            playerX.IsChecked = true;
            playerO.IsChecked = false;
        }
        private void ToggleO()
        {
            playerX.IsChecked = false;
            playerO.IsChecked = true;
        }

        private void ReplayClick(object sender, RoutedEventArgs e)
        {
            

        }

    }
}
