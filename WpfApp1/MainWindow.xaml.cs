using Chessuniverse.Library;
using ChessUniverse.Library;
using ChessUniverse.Library.Pieces;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        private bool _t;
        private int _imgDownX;
        private int _imgDownY;
        private int _imgUpX;
        private int _imgUpY;

        private System.Windows.Point _ptLast = new System.Windows.Point();
        private ChessBoard chessboard=new ChessBoard(); 
        public MainWindow()
        {
            InitializeComponent();
            chessboard.SetStartPosition();
        }
        public void MouseMove(object sender, MouseEventArgs e)
        {
            if (_t)
            {
                var img = (System.Windows.Controls.Image)sender;
                var ptNew = new System.Windows.Point();
                ptNew.X = img.Margin.Left;
                ptNew.Y = img.Margin.Top;

                img.Margin = new Thickness(ptNew.X + (e.GetPosition(img).X - _ptLast.X),
                ptNew.Y + (e.GetPosition(img).Y - _ptLast.Y), 0, 0);
            }
        }
        public void MouseDown(object sender, MouseButtonEventArgs e)
        {
            _t = true;
            var img = (System.Windows.Controls.Image)sender;

            _ptLast = e.GetPosition(img);

            Mouse.Capture(img);
            StackPanel.SetZIndex(img, 1);
            label1.Content = "X: " + img.Margin.Left.ToString();
            label2.Content = "Y: " + img.Margin.Top.ToString();

            _imgDownX = (int)(img.Margin.Left);
            _imgDownY = (int)(img.Margin.Top);
        }
        public void MouseUp(object sender, MouseButtonEventArgs e)
        {
            _t = false;

            var img = (Image)sender;

            int fromX = _imgDownX / 57;
            int fromY = _imgDownY / 57;

            int toX = (int)(img.Margin.Left + 28.5) / 57;
            int toY = (int)(img.Margin.Top + 28.5) / 57;

            Mouse.Capture(null);
            Panel.SetZIndex(img, 0);

            Coordinate start = new Coordinate((Letter)fromX, (Numbers)fromY);
            Coordinate end = new Coordinate((Letter)toX, (Numbers)toY);

            bool ok = TryMove(start, end);

            if (!ok)
            {
                img.Margin = new Thickness(_imgDownX, _imgDownY, 0, 0);
                return;
            }

            img.Margin = new Thickness(toX * 57, toY * 57, 0, 0);
        }
        private bool TryMove(Coordinate start, Coordinate end)
        {
            var piece = chessboard[(int)start.Number, (int)start.Letter];

            if (piece is IMovable movable)
            {
                bool ok = movable.Move(start, end, chessboard);

                if (!ok)
                    return false;

                chessboard[(int)end.Number, (int)end.Letter] = piece;

                chessboard[(int)start.Number, (int)start.Letter] = null;

                return true;
            }

            return false;
        }
    }
}