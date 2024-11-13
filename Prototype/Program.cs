using PrototypeFigure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IFigure figure = new Rectangle(10, 20);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();

            IFigure triangle = new Triangle(5, 8);
            IFigure clonedTriangle = triangle.Clone();
            triangle.GetInfo();

            Console.Read();
        }
    }

    interface IFigure
 {
 IFigure Clone();
    void GetInfo();
}

    class Triangle : IFigure
    {
        int baseLength;
        int height;

        public Triangle(int b, int h)
        {
            baseLength = b;
            height = h;
        }

        public IFigure Clone()
        {
            return new Triangle(this.baseLength, this.height);
        }

        public void GetInfo()
        {
            Console.WriteLine("Трикутник з основою {0} та висотою {1}", baseLength, height);
        }

    }

    class Rectangle : IFigure
{
    int width;
    int height;
    public Rectangle(int w, int h)
    {
        width = w;
        height = h;
    }
    public IFigure Clone()
    {
        return new Rectangle(this.width, this.height);
    }
    public void GetInfo()
    {
        Console.WriteLine("Прямокутник довжиною {0} и шириною {1} ", height, width);
    }
}
class Circle : IFigure
{
    int radius;
    public Circle(int r)
    {
        radius = r;
    }
    public IFigure Clone()
    {
        return new Circle(this.radius);
    }
    public void GetInfo()
    {
        Console.WriteLine("Круг радіусом {0}", radius);
    }
}
}