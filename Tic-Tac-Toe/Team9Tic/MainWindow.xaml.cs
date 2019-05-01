//Team 9
//Martin Carrion
//Tristan Osborn

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
        Symbol[] Type  = new Symbol[9];
        bool Turns=false;
        bool End=false;

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
            MessageBox.Show("X Turn");
            Turns = true;
            for (int i = 0; i < Type.Length; i++)
            {
                Type[i] = Symbol.NoSpace;

            }
            End = false;
            RowsandColumns.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = "";

            });

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var column = Grid.GetColumn(button);//Helps Place buttons
            var row = Grid.GetRow(button);//Helps Place Buttons
            var both = column + (row * 3);//equation that helps solidify buttons
            if (End)
            {
                MessageBox.Show("Game has ended");
                Game();
                return;


            }
            if (Type[both] != Symbol.NoSpace)
            {
                return;
            }
            if (Turns)
            {
                
                Type[both] = Symbol.Cross;
                button.Content = "X";
                button.Foreground = Brushes.Purple;
                MessageBox.Show("O Turn");



            }
            else
            {
                Type[both] = Symbol.Circle;
                button.Content = "O";
                button.Foreground = Brushes.Red;
                MessageBox.Show("X Turn");
                

            }
            if (!Turns)
            {
                button.Foreground = Brushes.Yellow;
            }
           

            Turns ^= true;//switch players
            Check();//Goes to Check method

        }
        public void Check()
        {
            var Row0 = Type[0] & Type[1] & Type[2];
            var Row1 = Type[3] & Type[4] & Type[5];
            var Row2 = Type[6] & Type[7] & Type[8];
            var Col0 = Type[0] & Type[3] & Type[6];
            var Col1 = Type[1] & Type[4] & Type[7];
            var Col2 = Type[2] & Type[5] & Type[8];
            var Dag1 = Type[0] & Type[4] & Type[8];
            var Dag2 = Type[2] & Type[4] & Type[6];
            var Tie = !Type.Any(t => t == Symbol.NoSpace);
            if (Type[0] != Symbol.NoSpace && (Row0) == Type[0])//Select units in box. zig zag style
            {
                MessageBox.Show("Top Row !");
               
                End = true;
            }

            else if (Type[3] != Symbol.NoSpace && (Row1) == Type[3])
            {
                MessageBox.Show("Middle Row !");
                End = true;
            }

            else if (Type[6] != Symbol.NoSpace && (Row2) == Type[6])
            {
                MessageBox.Show("Last Row !");
                End = true;
            }

            else if (Type[0] != Symbol.NoSpace && (Col0) == Type[0])
            {
                MessageBox.Show("Left Column !");
                End = true;
            }

            else if (Type[1] != Symbol.NoSpace && (Col1) == Type[1])
            {
                MessageBox.Show("Middle Column !");
                End = true;
            }
            else if (Type[2] != Symbol.NoSpace && (Col2) == Type[2])
            {
                MessageBox.Show("RIght Column !");
                End = true;
            }
            else if (Type[0] != Symbol.NoSpace && (Dag1) == Type[0])
            {
                MessageBox.Show("Diagonal !");
                End = true;
            }
            else if (Type[2] != Symbol.NoSpace && (Dag2) == Type[2])
            {
                MessageBox.Show("Diagonal !");

                End = true;
            }
           else if (Tie)
            {
                End = true;
                MessageBox.Show("TIE");

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