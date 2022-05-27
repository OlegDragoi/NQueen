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
using Core;
using Core.SolutionFinders;

namespace NQueenDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int n = 8;
        int curentIndex = 0;
        BitmapImage source = new BitmapImage(new Uri("/queen.png", UriKind.Relative));
        NQueenNode actualNode;
        List<NQueenNode> solution;
        public MainWindow()
        {
            InitializeComponent();
            actualNode = new NQueenNode(n);
            solution = actualNode.NodeStepByStep();
        }

        private void DrawChessBoard(NQueenNode node)
        {
            NQueenState state = node.State;
            ChessBoard.Children.Clear();
            int n = state.GridSize;
            double sideLength = Screen.ActualHeight;
            double indent = sideLength / (2*n);
            double step = (sideLength - indent) / n;

            //Drawing squares on the board
            for (int i = 0; i < n; i++)
            {
                double topMargin = indent + i * step;
                for (int j = 0; j < n; j++)
                {
                    double leftMargin = indent + j * step;
                    if ((i + j) % 2 == 0)
                    {
                        ChessBoard.Children.Add(
                            new Rectangle()
                            {
                                Fill = new SolidColorBrush(Colors.DarkGray),
                                Margin = new Thickness(leftMargin, topMargin, 0, 0),
                                Height = step,
                                Width = step
                            }
                        );
                    }
                }
            }

            double fontSize = indent / 1.75;
            //Numbering the rows and columns
            for (int i = 0; i < n; i++)
            {
                double distance = indent + i * step;
                //Adding a new number on top
                ChessBoard.Children.Add(
                    new Label()
                    {
                        Content = i,
                        FontSize = fontSize,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(distance, 0, 0, 0),
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = indent,
                        Width = step
                    }
                );
                //Adding a new number on left
                ChessBoard.Children.Add(
                    new Label()
                    {
                        Content = i,
                        FontSize = fontSize,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Margin = new Thickness(0, distance, 0, 0),
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Height = step,
                        Width = indent
                    }
                );
            }
            
            //Drawing board separator lines
            for (int i = 0; i < n+1; i++)
            {
                double distance = indent + i * step;
                //Adding new vertical line
                ChessBoard.Children.Add(
                    new Line()
                    {
                        Stroke = new SolidColorBrush(Colors.Black),
                        X1 = distance,
                        X2 = distance,
                        Y1 = sideLength
                    }
                );
                //Adding new horizontal line
                ChessBoard.Children.Add(
                    new Line()
                    {
                        Stroke = new SolidColorBrush(Colors.Black),
                        Y1 = distance,
                        Y2 = distance,
                        X1 = sideLength
                    }
                );
            }

            int margin = 5;
            double imageSize = step - 2 * margin;
            int[] queens = state.Displacemet;
            //Placing the queens
            for (int i = 0; i < n; i++)
            {
                double leftMargin = indent + i * step + margin;
                double topMargin = indent + queens[i] * step + margin;
                ChessBoard.Children.Add(
                    new Image()
                    {
                        Source = source,
                        Width = imageSize,
                        Height = imageSize,
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Margin = new Thickness(leftMargin,topMargin, 0, 0)
                    }
                );
            }
            LblIndex.Content = node.Depth;
        }

        private void Recalculate(ASolutionFinder finder)
        {
            actualNode = finder.FindSolution();
            DrawChessBoard(actualNode);
            solution = actualNode.NodeStepByStep();
            curentIndex = actualNode.Depth;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DrawChessBoard(actualNode);
        }

        private void TbSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            int result;
            if (int.TryParse(TbSize.Text, out result))
                n = result;
        }


        private void Rnd_Click(object sender, RoutedEventArgs e)
        {
            Recalculate(new RandomFinder(n));
        }

        private void BackTrack_Click(object sender, RoutedEventArgs e)
        {
            Recalculate(new BackTrackFinder(n));
        }

        private void BtnDecrease_Click(object sender, RoutedEventArgs e)
        {
            if (--curentIndex < 0) curentIndex = 0;
            DrawChessBoard(solution[curentIndex]);
        }

        private void BtnIncrease_Click(object sender, RoutedEventArgs e)
        {
            if (++curentIndex > solution.Count - 1) curentIndex = solution.Count - 1;
            DrawChessBoard(solution[curentIndex]);
        }
    }
}
