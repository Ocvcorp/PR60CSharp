using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfGame
{
    public class FButton : Button
    {
        public int X;
        public int Y;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _x;
        private int _y;

        private Dictionary<int, FButton> _buttons =
            new Dictionary<int, FButton>(16);

        public MainWindow()
        {
            InitializeComponent();

            gameItem.Click += (s, e) => Random();

            int i = 1;
            foreach (var obj in grid.Children)
                if (obj is FButton)
                {
                    var btn = (FButton)obj;
                    btn.X = Grid.GetRow(btn);
                    btn.Y = Grid.GetColumn(btn);
                    btn.Padding = new Thickness(10);
                    btn.Click += OnFButtonClick;
                    _buttons.Add(i++, btn);
                }

            _buttons.Add(0, null);

            Random();
        }

        protected void OnFButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (FButton)sender;
            int x = Grid.GetRow(button);
            int y = Grid.GetColumn(button);

            // При нажатии на левый Ctrl можно и по диагонали!
            var down = Keyboard.IsKeyDown(Key.LeftCtrl);

            if ((down && (Math.Abs(_x - x) == 1
                 || Math.Abs(_y - y) == 1)) ||
                ((Math.Abs(_x - x) == 1 && _y == y)
                 || (Math.Abs(_y - y) == 1 && _x == x)))
            {
                Grid.SetRow(button, _x);
                Grid.SetColumn(button, _y);
                _x = x; _y = y;
            }
            else return;

            if (!_new) return;

            bool ok = _buttons.Values
                .Where(b => b != null)
                .All(b => b.X == Grid.GetRow(b)
                       && b.Y == Grid.GetColumn(b));

            if (!ok) return;

            MessageBox.Show("Игра закончена!");

            _new = false;
        }

        private bool _new;

        private void Random()
        {
            _new = true;

            var r = new Random();
            var a = new List<int>(16);
            var v = new List<int>(_buttons.Keys);

            int k = 0, n = 0;
            for (var x = 0; x < 4; x++)
                for (var y = 0; y < 4; y++)
                {
                    do
                    {
                        k = r.Next(0, v.Count);
                    }
                    while (a.Any(o => o == v[k]));

                    a.Add(v[k]); v.RemoveAt(k);

                    var button = _buttons[a[n]];

                    if (button == null)
                    {
                        _x = x; _y = y;
                    }
                    else
                    {
                        Grid.SetRow(button, x);
                        Grid.SetColumn(button, y);
                    }
                    n++;
                }
        }
    }
}
