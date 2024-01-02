using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChaosGame
{
    public partial class MainWindow : Window
    {
        ChaosSquareShape window = new ChaosSquareShape();
        private const int Width = 300;
        private const int Height = 300;
        private const int maxIterations = 10000;
        private int iterations;
        private List<Point> vertices = new List<Point>();
        private Random random = new Random();
        private Point currentPoint;

        // Initialize the timer.
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            // Define the vertices of the polygon (triangle in this case)
            vertices.Add(new Point(Width / 2, 0));
            vertices.Add(new Point(Width, Height));
            vertices.Add(new Point(0, Height));

            // Start with a random point within the triangle
            currentPoint = GetRandomPoint();

            timer.Interval = TimeSpan.FromMilliseconds(0.50); // set timespan of .50 milli seconds.     
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Choose a random vertex
            Point targetVertex = vertices[random.Next(vertices.Count)];

            // Calculate the midpoint between the current point and the target vertex
            currentPoint.X = (currentPoint.X + targetVertex.X) / 2;
            currentPoint.Y = (currentPoint.Y + targetVertex.Y) / 2;

            // Draw a point at the calculated position
            Ellipse point = new Ellipse
            {
                Width = 4,
                Height = 4,

                Fill = new SolidColorBrush(Color.FromRgb((byte)random.Next(10, 255), (byte)random.Next(10, 255), (byte)random.Next(10, 255))),
                Margin = new Thickness(currentPoint.X, currentPoint.Y, 0, 0)
            };

            canvas.Children.Add(point);

            iterations++;
            if (iterations >= maxIterations)
            {
                timer.Stop(); // Stop the timer when you reach the desired number of iterations
                return;
            }
        }
        private Point GetRandomPoint()
        {
            return new Point(random.Next(Width), random.Next(Height));
        }

        //To open a new window to show square shape
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChaosSquareShape window = new ChaosSquareShape();
            window.Show();
        }
    }
}





