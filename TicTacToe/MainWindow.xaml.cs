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
using System.Windows.Forms;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean placeToken = false;
        private int turn;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
           GameTypeForm gameTypeForm = new GameTypeForm();

           DialogResult isSinglePlayer = gameTypeForm.ShowDialog();
           if(isSinglePlayer == System.Windows.Forms.DialogResult.Yes)
           {
               SinglePlayer();
           }
           else if(isSinglePlayer == System.Windows.Forms.DialogResult.No)
           {
               TwoPlayer();
           }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SinglePlayer()
        {
            int playerFirst = displayTurnInfo();

            
            placeToken = true;
            turn = 1;
        }

        private void TwoPlayer()
        {
            displayTurnInfo();

            placeToken = true;
            turn = 1;
        }

        private int displayTurnInfo()
        {
            Random rand = new Random();
            int player1 = rand.Next(1,3);

            if (player1 == 1)
            {
                Player1TextBox.Text = "Player 1 == X";
                Player1TextBox.Visibility = Visibility.Visible;
                Player2TextBox.Text = "Player 2 == Circle";
                Player2TextBox.Visibility = Visibility.Visible;
                PlayerTurnTextBox.Text = "Player 1's Turn";
                PlayerTurnTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                Player1TextBox.Text = "Player 1 == Circle";
                Player1TextBox.Visibility = Visibility.Visible;
                Player2TextBox.Text = "Player 2 == X";
                Player2TextBox.Visibility = Visibility.Visible;
                PlayerTurnTextBox.Text = "Player 2's Turn";
                PlayerTurnTextBox.Visibility = Visibility.Visible;
            }

            return player1;
        }

        private void Grid_Click(object sender, MouseButtonEventArgs e)
        {
            if(placeToken)
            {
                Point point = Mouse.GetPosition(gameGrid);
                if (turn % 2 == 0)
                    drawCircle(point);
                else
                    drawX(point);
                turn++;
                checkForWinner();
            }
            if (turn > 9)
                placeToken = false;

            
        }

        private void checkForWinner()
        {
            for(int row = 0; row < 3; row ++)
            {
                Shape shape1 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 0 && Grid.GetRow(e) == row);
                Shape shape2 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 1 && Grid.GetRow(e) == row);
                Shape shape3 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 2 && Grid.GetRow(e) == row);

                if (shape1 != null && shape2 != null && shape3 != null)
                {
                    if (shape1.GetType() == shape2.GetType() && shape1.GetType() == shape3.GetType())
                    {
                        System.Windows.Forms.MessageBox.Show("Winner!");
                        placeToken = false;
                    } 
                }
            }
        }

        private void drawX(Point point)
        {
            Line line1 = new Line();
            Line line2 = new Line();
            line1.Stroke = System.Windows.Media.Brushes.Blue;
            line2.Stroke = System.Windows.Media.Brushes.Blue;
            line1.StrokeThickness = 5;
            line2.StrokeThickness = 5;
            
            line1.X1 = 1;
            line1.Y1 = 1;
            line1.X2 = 100;
            line1.Y2 = 100;
            
            line2.X1 = 1;
            line2.Y1 = 100;
            line2.X2 = 100;
            line2.Y2 = 1;
            
            line1.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            line2.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            line1.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            line2.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            gameGrid.Children.Add(line1);
            gameGrid.Children.Add(line2);

            if (point.X < 128)
            {
                Grid.SetColumn(line1, 0);
                Grid.SetColumn(line2, 0);
            }
            else if (point.X > 128 && point.X < 256)
            {
                Grid.SetColumn(line1, 1);
                Grid.SetColumn(line2, 1);
            }
            else
            {
                Grid.SetColumn(line1, 2);
                Grid.SetColumn(line2, 2);
            }

            if (point.Y < 128)
            {
                Grid.SetRow(line1, 0);
                Grid.SetRow(line2, 0);
            }
            else if (point.Y > 128 && point.Y < 256)
            {
                Grid.SetRow(line1, 1);
                Grid.SetRow(line2, 1);
            }
            else
            {
                Grid.SetRow(line1, 2);
                Grid.SetRow(line2, 2);
            }
        }

        private void drawCircle(Point point)
        {
            Ellipse circle = new Ellipse();
            circle.Stroke = System.Windows.Media.Brushes.Red;
            circle.Height = 100;
            circle.Width = 100;
            circle.StrokeThickness = 2;

            circle.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            circle.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            gameGrid.Children.Add(circle);

            if (point.X < 128)
                Grid.SetColumn(circle, 0);
            else if (point.X > 128 && point.X < 256)
                Grid.SetColumn(circle, 1);
            else
                Grid.SetColumn(circle, 2);

            if (point.Y < 128)
                Grid.SetRow(circle, 0);
            else if (point.Y > 128 && point.Y < 256)
                Grid.SetRow(circle, 1);
            else
                Grid.SetRow(circle, 2);
        }

    }
}
