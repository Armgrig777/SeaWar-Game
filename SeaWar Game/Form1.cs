using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaWar_Game
{
    public partial class Form1 : Form
    {
        Field myField = new Field();
        int buttonSize = 30;
        int currentShipSize = 4;
        bool[,] gameboard;

        List<Ship.Coordinate> coordinates = new List<Ship.Coordinate>();

        public Form1()
        {

            InitializeComponent();
            this.Load += Form1_Load;
            gameboard = FillRandomShips();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.panelMyField.Size = new Size(10 * buttonSize, 10 * buttonSize);
            this.panelAIField.Size = new Size(10 * buttonSize, 10 * buttonSize);
            DrawField(myField);
            DrawAIField();


           
        }

        private void DrawField(Field field)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.FlatStyle = FlatStyle.Flat;

                    btn.Location = new Point(buttonSize * j, buttonSize * i);

                    btn.Size = new Size(buttonSize, buttonSize);
                    btn.Text = " ";
                    btn.Name = "0";

                    char letter = (char)(j + (int)'A');

                    btn.Tag = new Ship.Coordinate(letter, i + 1);

                    btn.Click += new EventHandler(btn_Click);
                    this.panelMyField.Controls.Add(btn);


                }
            }
        }
        private void DrawAIField()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    btn.FlatStyle = FlatStyle.Flat;

                    btn.Location = new Point(buttonSize * j, buttonSize * i);

                    btn.Size = new Size(buttonSize, buttonSize);
                    btn.Text = " ";


                    if (gameboard[i, j])
                    {
                        btn.Name = "1";

                    }
                    else
                    {
                        btn.Name = "0";
                    }
                    btn.Click += new EventHandler(btn_Click1);
                    this.panelAIField.Controls.Add(btn);

                }
            }
        }



        private void btn_Click1(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int x = btn.Location.X / 30;
            int y = btn.Location.Y / 30;
            if (btn.Name == "1")
            {
                btn.BackColor = Color.Red;
                btn.Text = "X";
                gameboard[x, y] = false;


            }
            else
            {
                btn.BackColor = Color.Gray;
                btn.Text = "*";
            }

            GameOver();
        }


        private void btn_Click(object sender, EventArgs e)
        {
            

            coordinates.Add((sender as Button)?.Tag as Ship.Coordinate);

            ((Button)sender).BackColor = Color.Blue;
            ((Button)sender).Name = "1";



            if (coordinates.Count == currentShipSize)
            {
                switch (currentShipSize)
                {
                    case 4:
                        myField.AddShip4(coordinates.ToArray());
                        currentShipSize--;
                        break;

                    case 3:
                        myField.AddShip3(coordinates.ToArray());
                        if (this.myField.GetShipCount(currentShipSize) == 2)
                            currentShipSize--;
                        break;


                    case 2:
                        myField.AddShip2(coordinates.ToArray());
                        if (this.myField.GetShipCount(currentShipSize) == 3)
                            currentShipSize--;
                        break;


                    case 1:
                        myField.AddShip1(coordinates.ToArray());
                        if (this.myField.GetShipCount(currentShipSize) == 4)
                            currentShipSize--;
                        break;
                }

                coordinates.Clear();
            }
            GameOver();

        }
        public void GameOver()
        {
            foreach (Button btn in panelMyField.Controls)
            {
                if (btn.Name != "0")
                    break;
                MessageBox.Show("AI Wins");
                RestartGame();
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (gameboard[i, j])
                        break;
                    if (!gameboard[9, 9])
                        MessageBox.Show("Player Wins");
                    RestartGame();

                }
            }

        }

        private void RestartGame()
        {
            gameboard = FillRandomShips();
            foreach (Button btn in panelMyField.Controls)
            {
                btn.BackColor = Color.White;
                btn.Name = "0";
            }
            foreach (Button btn in panelAIField.Controls)
            {
                btn.BackColor = Color.White;
                btn.Name = "0";
                btn.Text = " ";
            }


        }
        public bool[,] FillRandomShips()
        {
            bool[,] gameBoard = new bool[10, 10];
            // Define the lengths of each type of ship
            int[] shipLengths = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            // Loop through each ship length
            foreach (int shipLength in shipLengths)
            {
                bool shipPlaced = false;

                // Keep trying to place the ship until a valid position is found
                while (!shipPlaced)
                {
                    // Choose a random direction (0 = horizontal, 1 = vertical)
                    int direction = new Random().Next(2);

                    // Choose a random starting position that will allow the ship to fit on the board
                    int maxRow = gameBoard.GetLength(0) - (direction == 0 ? 1 : shipLength);
                    int maxCol = gameBoard.GetLength(1) - (direction == 1 ? 1 : shipLength);
                    int startRow = new Random().Next(maxRow + 1);
                    int startCol = new Random().Next(maxCol + 1);

                    // Check if the chosen position is valid
                    bool validPosition = true;
                    for (int row = Math.Max(0, startRow - 1); row <= Math.Min(gameBoard.GetLength(0) - 1, startRow + shipLength); row++)
                    {
                        for (int col = Math.Max(0, startCol - 1); col <= Math.Min(gameBoard.GetLength(1) - 1, startCol + shipLength); col++)
                        {
                            if (gameBoard[row, col])
                            {
                                validPosition = false;
                                break;
                            }
                        }
                        if (!validPosition)
                        {
                            break;
                        }
                    }

                    // Place the ship on the board if the position is valid
                    if (validPosition)
                    {
                        for (int i = 0; i < shipLength; i++)
                        {
                            if (direction == 0)
                            {
                                gameBoard[startRow, startCol + i] = true; // "true" represents a ship
                                if (startRow > 0) gameBoard[startRow - 1, startCol + i] = false; // "false" represents a buffer cell
                                if (startRow + 1 < gameBoard.GetLength(0)) gameBoard[startRow + 1, startCol + i] = false;
                            }
                            else
                            {
                                gameBoard[startRow + i, startCol] = true;
                                if (startCol > 0) gameBoard[startRow + i, startCol - 1] = false;
                                if (startCol + 1 < gameBoard.GetLength(1)) gameBoard[startRow + i, startCol + 1] = false;
                            }
                            if (startRow > 0 && startCol > 0) gameBoard[startRow - 1, startCol - 1] = false;
                            if (startRow > 0 && startCol + shipLength < gameBoard.GetLength(1)) gameBoard[startRow - 1, startCol + shipLength] = false;
                            if (startRow + 1 < gameBoard.GetLength(0) && startCol > 0) gameBoard[startRow + 1, startCol - 1] = false;
                            if (startRow + 1 < gameBoard.GetLength(0) && startCol + shipLength < gameBoard.GetLength(1)) gameBoard[startRow + 1, startCol + shipLength] = false;
                        }
                        shipPlaced = true;
                    }
                }
            }
            return gameBoard;
        }
    }
}
