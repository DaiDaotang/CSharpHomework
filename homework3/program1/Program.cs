using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace program1 
{
    public abstract class Shape
    {
        public abstract double Area
        {
            get;
        }
        public virtual void Draw()
        {
            Console.WriteLine(" ");
        }
    }
    public class Square:Shape 
    {
        private double myside;
        public Square (double side)
        {
            myside = side;
        }
        public override double Area
        {
            get
            {
                return myside * myside;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("边长是" + myside +"的正方形面积为"+ Area);
        }
    }
    public class Rectangle : Shape
    {
        private double myWidth;
        private double myHeight;
        public Rectangle(double width,double height)
        {
            myWidth = width;
            myHeight = height;
        }
        public override double Area
        {
            get
            {
                return myWidth * myHeight;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("宽是" + myWidth + "高是"+ myHeight+"的长方形面积为" + Area);
        }
    }
    public class Circle : Shape
    {
        private double myRadius;
        public Circle(double radius)
        {
            myRadius = radius;
        }
        public override double Area
        {
            get
            {
                return myRadius * myRadius * System.Math.PI;
            }
        }
        public override void Draw()
        {
            Console.WriteLine("半径是" + myRadius + "的圆面积为" + Area);
        }
    }
    public class Triangle : Shape
    {
        private double myside1;
        private double myside2;
        private double myside3;
        private double p;
        public Triangle(double side1, double side2, double side3)
        {
            myside1 = side1;
            myside2 = side2;
            myside3 = side3;
            p = (myside1 + myside2 + myside3)/2;
        }
        public override double Area
        {
            get
            {
                return Math.Sqrt(p * (p - myside1) * (p - myside2) * (p - myside3));
            }
        }
        public override void Draw()
        {
            Console.WriteLine("三边分别为"+myside1+","+myside2+","+myside3+"的三角面积为"+Area);
        }
    }
    class Factory
    {
        public static Shape getShape(string type, double a=0,double b=0,double c=0)
        {
            Shape shape = null;
            if(type .Equals("Square"))
            {
                shape = new Square(a);
            }
            else if(type.Equals("Rectangle"))
            {
                shape = new Rectangle(a,b);
            }
            else if (type.Equals("Circle"))
            {
                shape = new Circle(a);
            }
            else if (type.Equals("Triangle"))
            {
                shape = new Triangle(a,b,c);
            }
            return shape;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Shape square = Factory.getShape("Square", 1);
            square.Draw();
            Shape rectangle = Factory.getShape("Rectangle", 1,2);
            rectangle.Draw();
            Shape circle = Factory.getShape("Circle", 3);
            circle.Draw();
            Shape triangle = Factory.getShape("Triangle", 3,3,5);
            triangle.Draw();

            Console.ReadLine();
        }
    }
}
