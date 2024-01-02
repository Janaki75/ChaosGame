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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ChaosGame
{
    /// <summary>
    /// Interaction logic for ChaosSquareShape.xaml
    /// </summary>
    public partial class ChaosSquareShape : Window
    {
        private const int Width = 300;
        private const int Height = 300;
        private const int maxIterations = 10000;
        private int iterations;
        private int index;
        private int newIndex;
        private List<Point> vertices = new List<Point>();
        private Random random = new Random();
        private Point currentPoint;

        // Initialize the timer.
        DispatcherTimer timer = new DispatcherTimer();

        public ChaosSquareShape()
        {
            InitializeComponent();

            // Define the vertices of the polygon (Square in this case)
            vertices.Add(new Point(50, 50));
            vertices.Add(new Point(50, 350));
            vertices.Add(new Point(350, 50));
            vertices.Add(new Point(350, 350));

            // Start with a random point within the square.
            currentPoint = GetRandomPoint();

            //Choose a random index
            index = random.Next(vertices.Count);

            timer.Interval = TimeSpan.FromMilliseconds(0.20); // set timespan of 0.20 miili seconds.    
            timer.Start();            
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {           
            // Choose a random vertex
            Point targetVertex = vertices[index];

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
                      
            do {                            
                newIndex = random.Next(vertices.Count);
                
            } while (newIndex == index) ;
           
            index = newIndex;
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
    }   
}






