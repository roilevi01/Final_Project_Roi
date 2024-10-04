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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Final_Project_Roi
{
    public partial class Battle_Shooter_Game : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        bool moveLeft, moveRight;
        List<Rectangle> itemRemover = new List<Rectangle>();
        Random rand = new Random();

        int enemySpriteCounter = 0;
        int enemyCounter = 100;
        int playerSpeed = 10;
        int limit = 50;
        int score = 0;
        int damage = 0;
        int enemySpeed = 5;

        Rect playerHitBox;

        public Battle_Shooter_Game()
        {
            InitializeComponent();
            StartGame();
        }

        private void StartGame()
        {
            gameTimer.Interval = TimeSpan.FromMilliseconds(4);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            MyCanvas.Focus();

          
            ImageBrush bg = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("C:\\Users\\Owner\\source\\repos\\project c#\\Final_Project_Roi\\Image_Of_Project\\Iamge_Of_Battle_Shoter\\purple.png")),
                TileMode = TileMode.Tile,
                Viewport = new Rect(0, 0, 0.15, 0.15),
                ViewportUnits = BrushMappingMode.RelativeToBoundingBox
            };
            MyCanvas.Background = bg;

          
            ImageBrush playerImage = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("C:\\Users\\Owner\\source\\repos\\project c#\\Final_Project_Roi\\Image_Of_Project\\Iamge_Of_Battle_Shoter\\player.png"))
            };
            Player.Fill = playerImage;

           
            score = 0;
            damage = 0;
            enemySpeed = 5;
            limit = 50;
            enemyCounter = 100;
            UpdateScoreAndDamageText();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            playerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Height, Player.Width);
            enemyCounter -= 1;
            UpdateScoreAndDamageText();

            if (enemyCounter < 0)
            {
                MakeEnemies();
                enemyCounter = limit;
            }
            MovePlayer();
            HandleBulletsAndEnemies();

           
            foreach (Rectangle i in itemRemover)
            {
                MyCanvas.Children.Remove(i);
            }

         
            if (score > 5)
            {
                limit = 20;
                enemySpeed = 7;
            }

           
            if (damage > 99)
            {
               
                EndGame();
            }
        }

        private void UpdateScoreAndDamageText()
        {
            scoreText.Content = "Score: " + score;
            damageText.Content = "Damage: " + damage;
        }

        private void MovePlayer()
        {
            if (moveLeft && Canvas.GetLeft(Player) > 0)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - playerSpeed);
            }
            if (moveRight && Canvas.GetLeft(Player) + 90 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + playerSpeed);
            }
        }

        private void HandleBulletsAndEnemies()
        {
            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                if (x is Rectangle && (string)x.Tag == "bullet")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) - 20);
                    Rect bulletHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if (Canvas.GetTop(x) < 10)
                    {
                        itemRemover.Add(x);
                    }

                    foreach (var y in MyCanvas.Children.OfType<Rectangle>())
                    {
                        if (y is Rectangle && (string)y.Tag == "enemy")
                        {
                            Rect enemyHit = new Rect(Canvas.GetLeft(y), Canvas.GetTop(y), y.Width, y.Height);
                            if (bulletHitBox.IntersectsWith(enemyHit))
                            {
                                itemRemover.Add(x);
                                itemRemover.Add(y);
                                score++;
                            }
                        }
                    }
                }

                if (x is Rectangle && (string)x.Tag == "enemy")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + enemySpeed);
                    if (Canvas.GetTop(x) > 750)
                    {
                        itemRemover.Add(x);
                        damage += 10;
                    }
                    Rect enemyHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    if (playerHitBox.IntersectsWith(enemyHitBox))
                    {
                        itemRemover.Add(x);
                        damage += 5;
                    }
                }
            }
        }

        private void EndGame()
        {
            gameTimer.Stop();
            damageText.Content = "Damage: 100";
            damageText.Foreground = Brushes.Red;

           
            MessageBoxResult result = MessageBox.Show(
                $"Captain, you have destroyed {score} alien ships.\nPress OK to play again or Cancel to go back to the Game Center.",
                "Game Over",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Information
            );

            if (result == MessageBoxResult.OK)
            {
                StartGame(); 
            }
            else
            {
              
                NavigateToGameCenter();
            }
        }

        private void NavigateToGameCenter()
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) moveLeft = false;
            if (e.Key == Key.Right) moveRight = false;
            if (e.Key == Key.Space) FireBullet();
        }

        private void FireBullet()
        {
            Rectangle newBullet = new Rectangle
            {
                Tag = "bullet",
                Height = 20,
                Width = 5,
                Fill = Brushes.White,
                Stroke = Brushes.Blue,
            };

            Canvas.SetLeft(newBullet, Canvas.GetLeft(Player) + Player.Width / 2);
            Canvas.SetTop(newBullet, Canvas.GetTop(Player) - newBullet.Height);
            MyCanvas.Children.Add(newBullet);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left) moveLeft = true;
            if (e.Key == Key.Right) moveRight = true;
        }

        private void MakeEnemies()
        {
            ImageBrush enemySprite = new ImageBrush();
            enemySpriteCounter = rand.Next(1, 6);
            switch (enemySpriteCounter)
            {
                case 1:
                    enemySprite.ImageSource = new BitmapImage(new Uri("C:\\Users\\Owner\\source\\repos\\project c#\\Final_Project_Roi\\Image_Of_Project\\Iamge_Of_Battle_Shoter\\1.png"));
                    break;
                case 2:
                    enemySprite.ImageSource = new BitmapImage(new Uri("C:\\Users\\Owner\\source\\repos\\project c#\\Final_Project_Roi\\Image_Of_Project\\Iamge_Of_Battle_Shoter\\2.png"));
                    break;
                case 3:
                    enemySprite.ImageSource = new BitmapImage(new Uri("C:\\Users\\Owner\\source\\repos\\project c#\\Final_Project_Roi\\Image_Of_Project\\Iamge_Of_Battle_Shoter\\3.png"));
                    break;
                case 4:
                    enemySprite.ImageSource = new BitmapImage(new Uri("C:\\Users\\Owner\\source\\repos\\project c#\\Final_Project_Roi\\Image_Of_Project\\Iamge_Of_Battle_Shoter\\4.png"));
                    break;
                case 5:
                    enemySprite.ImageSource = new BitmapImage(new Uri("C:\\Users\\Owner\\source\\repos\\project c#\\Final_Project_Roi\\Image_Of_Project\\Iamge_Of_Battle_Shoter\\5.png"));
                    break;
            }
            Rectangle newEnemy = new Rectangle
            {
                Tag = "enemy",
                Height = 50,
                Width = 56,
                Fill = enemySprite
            };
            Canvas.SetTop(newEnemy, -100);
            Canvas.SetLeft(newEnemy, rand.Next(30, 430));
            MyCanvas.Children.Add(newEnemy);
        }
    }
}
