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
using System.Windows.Threading;

namespace GameProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameAreaForm : Window
    {
        private Model _model;
        private ObjectType[,] map;
        private Ellipse[,] coins;
        private Rectangle pacMan;
        //private System.Windows.Threading.DispatcherTimer gameTickTimer = new System.Windows.Threading.DispatcherTimer();

        private int _pacManXCoordinates;
        private int _pacManYCoordinates;

        private int _score;

        public GameAreaForm()
        {
            _model = new Model();
            InitializeComponent();
            DataContext = _model;
            //gameTickTimer.Tick += GameTickTimer_Tick;
            // build the grid map with 19 rows and 19 columns
            map = new ObjectType[Model.RowCount, Model.ColCount];
            // create a new ellipse object of type array to implement coins in each white space
            coins = new Ellipse[Model.RowCount, Model.ColCount];


            //Call Fill gameCanvas to create the walls and borders for the game
            FillMap();
            CreateMap();

        }

        private void FillMap()
        {
            // [column, row]

            map[1, 1] = ObjectType.Packman;
            map[1, 9] = ObjectType.Obstacle;

            map[2, 2] = ObjectType.Obstacle;
            map[2, 3] = ObjectType.Obstacle;
            map[2, 5] = ObjectType.Obstacle;
            map[2, 6] = ObjectType.Obstacle;
            map[2, 7] = ObjectType.Obstacle;
            map[2, 9] = ObjectType.Obstacle;
            map[2, 11] = ObjectType.Obstacle;
            map[2, 12] = ObjectType.Obstacle;
            map[2, 13] = ObjectType.Obstacle;
            map[2, 15] = ObjectType.Obstacle;
            map[2, 16] = ObjectType.Obstacle;

            map[3, 2] = ObjectType.Obstacle;
            map[3, 3] = ObjectType.Obstacle;
            map[3, 5] = ObjectType.Obstacle;
            map[3, 6] = ObjectType.Obstacle;
            map[3, 7] = ObjectType.Obstacle;
            map[3, 9] = ObjectType.Obstacle;
            map[3, 11] = ObjectType.Obstacle;
            map[3, 12] = ObjectType.Obstacle;
            map[3, 13] = ObjectType.Obstacle;
            map[3, 15] = ObjectType.Obstacle;
            map[3, 16] = ObjectType.Obstacle;

            map[5, 2] = ObjectType.Obstacle;
            map[5, 3] = ObjectType.Obstacle;
            map[5, 5] = ObjectType.Obstacle;
            map[5, 7] = ObjectType.Obstacle;
            map[5, 8] = ObjectType.Obstacle;
            map[5, 9] = ObjectType.Obstacle;
            map[5, 10] = ObjectType.Obstacle;
            map[5, 11] = ObjectType.Obstacle;
            map[5, 13] = ObjectType.Obstacle;
            map[5, 15] = ObjectType.Obstacle;
            map[5, 16] = ObjectType.Obstacle;

            map[6, 5] = ObjectType.Obstacle;
            map[6, 9] = ObjectType.Obstacle;
            map[6, 13] = ObjectType.Obstacle;

            map[7, 1] = ObjectType.Obstacle;
            map[7, 2] = ObjectType.Obstacle;
            map[7, 3] = ObjectType.Obstacle;
            map[7, 5] = ObjectType.Obstacle;
            map[7, 6] = ObjectType.Obstacle;
            map[7, 7] = ObjectType.Obstacle;
            map[7, 9] = ObjectType.Obstacle;
            map[7, 11] = ObjectType.Obstacle;
            map[7, 12] = ObjectType.Obstacle;
            map[7, 13] = ObjectType.Obstacle;
            map[7, 15] = ObjectType.Obstacle;
            map[7, 16] = ObjectType.Obstacle;
            map[7, 17] = ObjectType.Obstacle;

            map[8, 3] = ObjectType.Obstacle;
            map[8, 5] = ObjectType.Obstacle;
            map[8, 13] = ObjectType.Obstacle;
            map[8, 15] = ObjectType.Obstacle;

            map[9, 3] = ObjectType.Obstacle;
            map[9, 5] = ObjectType.Obstacle;
            map[9, 8] = ObjectType.Obstacle;
            map[9, 10] = ObjectType.Obstacle;
            map[9, 13] = ObjectType.Obstacle;
            map[9, 15] = ObjectType.Obstacle;

            map[10, 3] = ObjectType.Obstacle;
            map[10, 5] = ObjectType.Obstacle;
            map[10, 13] = ObjectType.Obstacle;
            map[10, 15] = ObjectType.Obstacle;

            map[11, 1] = ObjectType.Obstacle;
            map[11, 2] = ObjectType.Obstacle;
            map[11, 3] = ObjectType.Obstacle;
            map[11, 5] = ObjectType.Obstacle;
            map[11, 6] = ObjectType.Obstacle;
            map[11, 7] = ObjectType.Obstacle;
            map[11, 9] = ObjectType.Obstacle;
            map[11, 11] = ObjectType.Obstacle;
            map[11, 12] = ObjectType.Obstacle;
            map[11, 13] = ObjectType.Obstacle;
            map[11, 15] = ObjectType.Obstacle;
            map[11, 16] = ObjectType.Obstacle;
            map[11, 17] = ObjectType.Obstacle;

            map[12, 5] = ObjectType.Obstacle;
            map[12, 9] = ObjectType.Obstacle;
            map[12, 13] = ObjectType.Obstacle;

            map[13, 2] = ObjectType.Obstacle;
            map[13, 3] = ObjectType.Obstacle;
            map[13, 5] = ObjectType.Obstacle;
            map[13, 7] = ObjectType.Obstacle;
            map[13, 8] = ObjectType.Obstacle;
            map[13, 9] = ObjectType.Obstacle;
            map[13, 10] = ObjectType.Obstacle;
            map[13, 11] = ObjectType.Obstacle;
            map[13, 13] = ObjectType.Obstacle;
            map[13, 15] = ObjectType.Obstacle;
            map[13, 16] = ObjectType.Obstacle;

            map[15, 2] = ObjectType.Obstacle;
            map[15, 3] = ObjectType.Obstacle;
            map[15, 5] = ObjectType.Obstacle;
            map[15, 6] = ObjectType.Obstacle;
            map[15, 7] = ObjectType.Obstacle;
            map[15, 9] = ObjectType.Obstacle;
            map[15, 11] = ObjectType.Obstacle;
            map[15, 12] = ObjectType.Obstacle;
            map[15, 13] = ObjectType.Obstacle;
            map[15, 15] = ObjectType.Obstacle;
            map[15, 16] = ObjectType.Obstacle;

            map[16, 2] = ObjectType.Obstacle;
            map[16, 3] = ObjectType.Obstacle;
            map[16, 5] = ObjectType.Obstacle;
            map[16, 6] = ObjectType.Obstacle;
            map[16, 7] = ObjectType.Obstacle;
            map[16, 9] = ObjectType.Obstacle;
            map[16, 11] = ObjectType.Obstacle;
            map[16, 12] = ObjectType.Obstacle;
            map[16, 13] = ObjectType.Obstacle;
            map[16, 15] = ObjectType.Obstacle;
            map[16, 16] = ObjectType.Obstacle;

            map[17, 9] = ObjectType.Obstacle;

            #region ENEMIES
            map[4, 4] = ObjectType.Monster;
            #endregion
            //Call the FillBorderLines method to fill the borders of the game
            FillBorderLines(map, "x", 0);
            FillBorderLines(map, "x", Model.RowCount-1);
            FillBorderLines(map, "y", 0);
            FillBorderLines(map, "y", Model.ColCount-1);
        }
        private void FillBorderLines(ObjectType[,] mapBord, string direction, int startPoint)
        {
            var count = 0;
            switch (direction)
            {
                case "x":
                    count = Model.RowCount;
                    break;
                case "y":
                    count = Model.ColCount;
                    break;
            }

            for (int i = 0; i < count; i++)
            {
                switch (direction)
                {
                    case "x":
                        mapBord[startPoint, i] = ObjectType.Obstacle;
                        break;
                    case "y":
                        mapBord[i, startPoint] = ObjectType.Obstacle;
                        break;
                }
            }
        }

        private void CreateMap()
        {
            for (int y = 0; y < Model.RowCount; y++)
            {
                for (int x = 0; x < Model.ColCount; x++)
                {
                    //var obj = map[y, x];

                    if (map[y, x] == ObjectType.Coin)
                    {
                        //populate white spaces with coins
                        var coin = GetCoin();
                        // Set x, y pos
                        var xCoord = (Model.FixedDimension - coin.Width) / 2;
                        var yCoord = (Model.FixedDimension - coin.Height) / 2;
                        Canvas.SetTop(coin, (x * _model.dimension) + xCoord);
                        Canvas.SetLeft(coin, (y * _model.dimension) + yCoord);

                        gameCanvas.Children.Add(coin);

                        coins[y, x] = coin; // keep track of the coins
                        //continue; // TODO: Test
                    }

                    var shape = GetObject(map[y,x]);

                    if (map[y,x] == ObjectType.Packman)
                    {
                        shape.Name = "pacMan";
                        Canvas.SetTop(shape, (x * _model.dimension));
                        Canvas.SetLeft(shape, (y * _model.dimension));

                        pacMan = shape; // save pacman obj 
                        Canvas.SetZIndex(pacMan, (int)999); 
                        _pacManXCoordinates = x;
                        _pacManYCoordinates = y;

                        gameCanvas.Children.Add(shape);
                    }

                    if (map[y, x] == ObjectType.Obstacle)
                    {
                        shape.Name = "Obstacle";
                        Canvas.SetTop(shape, (x * _model.dimension));
                        Canvas.SetLeft(shape, (y * _model.dimension));

                        gameCanvas.Children.Add(shape);
                    }

                    if (map[y, x] == ObjectType.Monster)
                    {
                        Canvas.SetTop(shape, (x * _model.dimension));
                        Canvas.SetLeft(shape, (y * _model.dimension));

                        gameCanvas.Children.Add(shape);
                    }
                }
            }
        }

        private Ellipse GetCoin()
        {
            return new Ellipse()
            {
                Width = 8,
                Height = 8,
                Fill = Brushes.Yellow
            };
        }

        private Rectangle GetObject(ObjectType type)
        {
            var brush = Brushes.AliceBlue;

            switch (type)
            {
                case ObjectType.Packman:
                    brush = Brushes.Green;
                    break;
                case ObjectType.Obstacle:
                    brush = Brushes.Blue;
                    break;
                case ObjectType.Monster:
                    brush = Brushes.Red;
                    break;
                default:
                    break;
            }

            return new Rectangle()
            {
                Width = _model.dimension,
                Height = _model.dimension,
                Fill = brush
            };
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    if (!IsHitObstacle(e.Key))
                    {
                        Canvas.SetLeft(pacMan, Canvas.GetLeft(pacMan) - _model.dimension);
                        _pacManXCoordinates--;
                        IsHitToCoin();
                        IsHitToMonster();
                    }
                    break;
                case Key.Right:
                    if (!IsHitObstacle(e.Key))
                    {
                        Canvas.SetLeft(pacMan, Canvas.GetLeft(pacMan) + _model.dimension);
                        _pacManXCoordinates++;
                        IsHitToCoin();
                        IsHitToMonster();
                    }
                    break;
                case Key.Up:
                    if (!IsHitObstacle(e.Key))
                    {
                        Canvas.SetTop(pacMan, Canvas.GetTop(pacMan) - _model.dimension);
                        _pacManYCoordinates--;
                        IsHitToCoin();
                        IsHitToMonster();
                    }
                    break;
                case Key.Down:
                    if (!IsHitObstacle(e.Key))
                    {                        
                        Canvas.SetTop(pacMan, Canvas.GetTop(pacMan) + _model.dimension);
                        _pacManYCoordinates++;
                        IsHitToCoin();
                        IsHitToMonster();
                    }
                    break;
            }

           // map[_pacManYCoordinates, _pacManXCoordinates] = ObjectType.Packman;
        }

        private bool IsHitObstacle(Key key)
        {
            //ObjectType obj = ObjectType.Coin;
            ObjectType obj = ObjectType.None;

            switch (key)
            {
                case Key.Left:
                    obj = map[_pacManXCoordinates - 1, _pacManYCoordinates];
                    break;
                case Key.Right:
                    obj = map[_pacManXCoordinates + 1, _pacManYCoordinates];
                    break;
                case Key.Up:
                    obj = map[_pacManXCoordinates, _pacManYCoordinates - 1];
                    break;
                case Key.Down:
                    obj = map[_pacManXCoordinates, _pacManYCoordinates + 1];
                    break;
            }
            if (obj == ObjectType.Obstacle)
                return true;
            else return false;
        }
        private bool IsHitToMonster()
        {
            var obj = map[_pacManXCoordinates, _pacManYCoordinates];

            if (obj == ObjectType.Monster)
            {
                MessageBox.Show("YOU HIT A MONSTER");
                //this.Close();
                return true;
            }

            return false;
        }
        private void IsHitToCoin()
        {
            var obj = map[_pacManXCoordinates, _pacManYCoordinates];

            if (obj == ObjectType.Coin)
            {
                _score++;
                tbScore.Text = _score.ToString("000");
                // Get coin render type (Ellipse) to be removed from canvas
                var coin = coins[_pacManXCoordinates, _pacManYCoordinates];
                // Get location of coin in map layout and reset type
                map[_pacManXCoordinates, _pacManYCoordinates] = ObjectType.Space;
                // Remove coin from canvas
                gameCanvas.Children.Remove(coin);
            }
        }

        private void EnemyAIMove()
        {
            for (int col = 0; col < _model.dimension; col++)
            {
                for (int row = 0; row < _model.dimension; row++)
                {
                    var obj = map[col, row];

                    if (obj == ObjectType.Monster)
                    {
                        var xpos = col;
                        var ypos = row;
                        // LEFT
                        if(map[xpos - 1, ypos] == ObjectType.Space)
                        {

                        }
                    }
                    //switch (key)
                    //{
                    //    case Key.Left:
                    //        obj = map[_pacManXCoordinates - 1, _pacManYCoordinates];
                    //        break;
                    //    case Key.Right:
                    //        obj = map[_pacManXCoordinates + 1, _pacManYCoordinates];
                    //        break;
                    //    case Key.Up:
                    //        obj = map[_pacManXCoordinates, _pacManYCoordinates - 1];
                    //        break;
                    //    case Key.Down:
                    //        obj = map[_pacManXCoordinates, _pacManYCoordinates + 1];
                    //        break;
                    //}
                    //if (obj == ObjectType.Obstacle)
                    //    return true;
                    //else return false;
                }
            }
        }

    }
}
