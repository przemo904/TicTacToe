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
        int count = 0;

        public static int[,] Winners = new int[,]
        {
            {0,1,2},
            {3,4,5},
            {6,7,8},
            {0,3,6},
            {1,4,7},
            {2,5,8},
            {2,4,6},
            {0,4,8}
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

                count++;
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
            
            var btab = FindButtons<Button>(Root).ToArray();


            List<Button> list = new List<Button>();
            for (int i = 1; i < 12; i++)
            {
                if (i % 4 == 0) continue;
                list.Add(btab[i - 1]);
            }

            Check(list);


            List<Button> list1 = new List<Button>();
            for (int i = 1; i < 12; i++)
            {
                if (i % 4 == 0) continue;
                list1.Add(btab[i]);
            }

            Check(list1);


            List<Button> list2 = new List<Button>();
            for (int i = 1; i < 12; i++)
            {
                if (i % 4 == 0) continue;
                list2.Add(btab[i+3]);
            }

            Check(list2);

            List<Button> list3 = new List<Button>();
            for (int i = 1; i < 12; i++)
            {
                if (i % 4 == 0) continue;
                list3.Add(btab[i+4]);
            }

            Check(list3);

        }


        public void Check(List<Button> list) {

           

            for (int i = 0; i < 8; i++)
            {
                int a = Winners[i, 0];
                int b = Winners[i, 1];
                int c = Winners[i, 2];

                Button b1 = list[a];
                Button b2 = list[b];
                Button b3 = list[c];

                if (b1.Content == null || b2.Content == null || b3.Content == null) continue;

                if (b1.Content == b2.Content && b2.Content == b3.Content)
                {

                    WinnersGrid.Visibility = Visibility.Visible;
                    WinText.Text = CurrentPlayer + " Wygrywa";
                    return;
                }
            }

            if (count == 16) {
                WinnersGrid.Visibility = Visibility.Visible;
                WinText.Text = " Remis ";
                return;

            }

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
            var tab = FindButtons<Button>(Root).ToArray();

            WinnersGrid.Visibility = Visibility.Collapsed;

            for (int i = 0; i < 16; i++) {
                tab[i].Content = null;

            }
            count = 0;
            CurrentPlayer = Player.O;

        }

        public static IEnumerable<T> FindButtons<T>(DependencyObject root) where T : DependencyObject {
            if (root != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++) {
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
