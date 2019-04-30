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
            
            
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            btnStart.Visibility = Visibility.Collapsed;
            Game();

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
                button.Foreground = Brushes.Gray;

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
        }
    }
}
