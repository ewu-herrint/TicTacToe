﻿using System;
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

/*
 * Tyler Herrin
 * Graphics Assignment
 * CSCD 371
 */

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean placeToken = false;
        private Boolean isSinglePlayer;
        private int turn;

        public MainWindow()
        {
            InitializeComponent();
            PlayerTurnTextBox.Text = "Go to Game -> New Game to start a game!";
            PlayerTurnTextBox.Visibility = Visibility.Visible;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
           gameGrid.Children.Clear();
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
            isSinglePlayer = true;
            int playerFirst = displayTurnInfo();
            placeToken = true;
            if (playerFirst != 1)
                aiTurn();
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
                checkForWinner();
                swapTurnDisplayInfo();
            }
            if (isSinglePlayer && placeToken)
            {
                aiTurn();
                swapTurnDisplayInfo();
            }
            
            if (turn > 9 && placeToken)
            {
                placeToken = false;
                System.Windows.Forms.MessageBox.Show("Draw");
            }
            
        }

        private void swapTurnDisplayInfo()
        {
            if (PlayerTurnTextBox.Text == "Player 1's Turn")
                PlayerTurnTextBox.Text = "Player 2's Turn";
            else
                PlayerTurnTextBox.Text = "Player 1's Turn";
        }

        private void aiTurn()
        {
            Point point = aiPlace();  
            if (turn % 2 == 0)
                drawCircle(point);
            else
                drawX(point);    
            checkForWinner();
        }

        private Point aiPlace()
        {
            for (int col = 0; col < 3; col++)
            {
                for (int row = 0; row < 3; row++)
                {
                    if (gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == col && Grid.GetRow(e) == row) == null)
                    {
                        double x, y;
                        if (col == 0)
                            x = 125;
                        else if (col == 1)
                            x = 255;
                        else
                            x = 300;
                        if (row == 0)
                            y = 125;
                        else if (row == 1)
                            y = 255;
                        else
                            y = 300;

                        return new Point(x, y);
                    }
                }
            }
            throw new InvalidOperationException("No place to place AI token");
        }

        private void checkForWinner()
        {
            Shape shape1;
            Shape shape2;
            Shape shape3;

            // Check rows
            for(int row = 0; row < 3; row ++)
            {
                shape1 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 0 && Grid.GetRow(e) == row);
                shape2 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 1 && Grid.GetRow(e) == row);
                shape3 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 2 && Grid.GetRow(e) == row);
                
                if (shape1 != null && shape2 != null && shape3 != null)
                {
                    if (shape1.GetType() == shape2.GetType() && shape1.GetType() == shape3.GetType())
                    {
                        whoIsWinner(shape1);
                        placeToken = false;
                    } 
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                shape1 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == col && Grid.GetRow(e) == 0);
                shape2 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == col && Grid.GetRow(e) == 1);
                shape3 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == col && Grid.GetRow(e) == 2);

                if (shape1 != null && shape2 != null && shape3 != null)
                {
                    if (shape1.GetType() == shape2.GetType() && shape1.GetType() == shape3.GetType())
                    {
                        whoIsWinner(shape1);
                        placeToken = false;
                    }
                }
            }

            //Check Diagonals
            shape1 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 0 && Grid.GetRow(e) == 0);
            shape2 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 1 && Grid.GetRow(e) == 1);
            shape3 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 2 && Grid.GetRow(e) == 2);

            if (shape1 != null && shape2 != null && shape3 != null)
            {
                if (shape1.GetType() == shape2.GetType() && shape1.GetType() == shape3.GetType())
                {
                    whoIsWinner(shape1);
                    placeToken = false;
                }
            }
            shape1 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 2 && Grid.GetRow(e) == 0);
            shape2 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 1 && Grid.GetRow(e) == 1);
            shape3 = gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == 0 && Grid.GetRow(e) == 2);

            if (shape1 != null && shape2 != null && shape3 != null)
            {
                if (shape1.GetType() == shape2.GetType() && shape1.GetType() == shape3.GetType())
                {
                    whoIsWinner(shape1);
                    placeToken = false;
                }
            }

        }

        private void whoIsWinner(Shape shape)
        {
            if (shape.GetType() == new Line().GetType())
            {
                System.Windows.Forms.MessageBox.Show("X Wins!");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Circle Wins!");
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

            int row;
            int col;
            if (point.X < 128)
            {
                col = 0;
            }
            else if (point.X > 128 && point.X < 256)
            {
                col = 1;
            }
            else
            {
                col = 2;
            }

            if (point.Y < 128)
            {
                row = 0;
            }
            else if (point.Y > 128 && point.Y < 256)
            {
                row = 1;
            }
            else
            {
                row = 2;
            }

            if(gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == col && Grid.GetRow(e) == row) == null)
            {
                gameGrid.Children.Add(line1);
                gameGrid.Children.Add(line2);
                Grid.SetColumn(line1, col);
                Grid.SetColumn(line2, col);
                Grid.SetRow(line1, row);
                Grid.SetRow(line2, row);
                turn++;
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(" Tic Tac Toe \n Tyler Herrin \n 2015");
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

            int row;
            int col;
            if (point.X < 128)
            {
                col = 0;
            }
            else if (point.X > 128 && point.X < 256)
            {
                col = 1;
            }
            else
            {
                col = 2;
            }

            if (point.Y < 128)
            {
                row = 0;
            }
            else if (point.Y > 128 && point.Y < 256)
            {
                row = 1;
            }
            else
            {
                row = 2;
            }

            if (gameGrid.Children.Cast<Shape>().FirstOrDefault(e => Grid.GetColumn(e) == col && Grid.GetRow(e) == row) == null)
            {
                gameGrid.Children.Add(circle);
                Grid.SetColumn(circle, col);
                Grid.SetRow(circle, row);
                turn++;
            }
        }

    }
}
