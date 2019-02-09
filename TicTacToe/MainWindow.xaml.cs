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
using System.Diagnostics;

namespace TicTacToe
{
    public enum Player {
        X,O
    }

    
        
    public partial class MainWindow : Window
    {
        public Player CurrentPlayer;
        //public static string[,] Table = new string[4, 4];

        public static int[,] Winners = new int[,]
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {0,4,8},
            {2,4,6}
        };

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

                //SetInTable();
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


        public void CheckVictory()
        {

            var tab = FindButtons<Button>(Root).ToArray();

            for (int i = 0; i < 8; i++)
            {


            }
        }

        /*private void SetInTable() {
            int i = 0;
            var tab = FindButtons<Button>(Root).ToArray();
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++) {
                    Table[x, y] = tab[i].ToString() ;
                    i++;
                }
            }
        }*/

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






        public static IEnumerable<T> FindButtons<T>(DependencyObject root) where T : DependencyObject
        {
            if (root != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
                    {
                    DependencyObject child = VisualTreeHelper.GetChild(root, i);
                    if (child != null && child is T )
                    {

                        yield return (T)child;
                    }
                    foreach (T childOfChild in FindButtons<T>(child))
                    {
                        yield return childOfChild;
                    }

                }
            }


        }



    }
}
