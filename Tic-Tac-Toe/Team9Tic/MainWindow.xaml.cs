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

namespace Team9Tic
{

    public partial class MainWindow : Window
    {
        public Symbol[] Type;
        public bool Turns;
        public bool End;

        public MainWindow()
        {

            InitializeComponent();
            MessageBox.Show("Game of Tic-Tac-Toe");
            Game();



        }


        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {



        }
        public void Game()
        {
            Type = new Symbol[9];//Establishes array
            for (int i = 0; i < Type.Length; i++)
            {
                Type[i] = Symbol.NoSpace;

            }
            Turns = true;
            RowsandColumns.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = "";
                button.Background = Brushes.Black;
                button.Foreground = Brushes.OrangeRed;

            });
            End = false;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (End)
            {
                MessageBox.Show("Game has ended");
                Game();
                return;


            }
            var button = (Button)sender;
            var column = Grid.GetColumn(button);//Helps Place buttons
            var row = Grid.GetRow(button);//Helps Place Buttons
            var index = column + (row * 3);//equation that helps solidify buttons
            if (Type[index] != Symbol.NoSpace)
            {
                return;
            }
            Type[index] = Turns ? Symbol.Cross : Symbol.Circle;//PLayer 1 and Player 2
            button.Content = Turns ? "X" : "O";//sets symbols to players
            if (Turns)
            {
                button.Foreground = Brushes.Red;
            }
            if (!Turns)
            {
                button.Foreground = Brushes.Yellow;
            }
            if (Turns)
            {
                button.Foreground = Brushes.Purple;
            }









            Turns ^= true;//switch players
            Check();

        }
        public void Check()
        {

            if (Type[0] != Symbol.NoSpace && (Type[0] & Type[1] & Type[2]) == Type[0])
            {
                MessageBox.Show("Top Row")
                End = true;


            }

            if (Type[3] != Symbol.NoSpace && (Type[3] & Type[4] & Type[5]) == Type[3])
            {
                End = true;

            }

            if (Type[6] != Symbol.NoSpace && (Type[6] & Type[7] & Type[8]) == Type[6])
            {
                End = true;

            }

            if (Type[0] != Symbol.NoSpace && (Type[0] & Type[3] & Type[6]) == Type[0])
            {
                End = true;

            }

            if (Type[1] != Symbol.NoSpace && (Type[1] & Type[4] & Type[7]) == Type[1])
            {
                End = true;

            }
            if (Type[2] != Symbol.NoSpace && (Type[2] & Type[5] & Type[8]) == Type[2])
            {
                End = true;

            }

        }
        private void BtnStart_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}