using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Draw
{
    public enum ShapeType { Line, Rectangle, FreeLine };
    [XmlRoot]
    [Serializable]
    public abstract class Shape
	{
        protected Color penColor;
        protected int penWidth;
        [XmlIgnore] 
        public Pen PenFinal
        {
            get { return new Pen(penColor, penWidth); }
            set
            {
                penColor = value.Color;
                penWidth = (int)value.Width;
            }
        }
        public static Pen penTemp;
		public abstract void Draw(Graphics g, Pen pen);
		public abstract void mouseMove(Graphics g, MouseEventArgs e);
        public abstract void writeBinary(BinaryWriter bw);
        public abstract void readBinary(String br);
        public abstract void writeText(StreamWriter sw);
        public abstract void readText(String sr);

        public Shape(Pen pen)
        {
            this.PenFinal = pen;
        }

        public Shape()
        {
			PenFinal = penTemp;
        }

        public static Shape CreateShape(ShapeType type, Point pt, Pen pen)
        {
            switch (type)
            {
                case ShapeType.Line:
                    return new Line(pt, pen);
                case ShapeType.Rectangle:
                    return new Rect(pt, pen);
                case ShapeType.FreeLine:
                    return new FreeLine(pt, pen);
                default:
                    return null;
            }
        }

        public static Shape CreateShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Line:
                    return new Line();
                case ShapeType.Rectangle:
                    return new Rect();
                case ShapeType.FreeLine:
                    return new FreeLine();
                default:
                    return null;
            }
        }

        public Point getPointBinary(BinaryReader br)
        {
            int x = br.ReadInt32();
            int y = br.ReadInt32();
            return new Point(x, y);
        }

        public Color getColorBinary(BinaryReader br)
        {
            int iColor = br.ReadInt32();
            return Color.FromArgb(iColor);
        }

        public Color getColorText(string hexString)
        {
            int iColor = int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
            return Color.FromArgb(iColor);
        }

	}  // End Shape class


    [XmlInclude(typeof(Line))]
    [SoapInclude(typeof(Line))]
    [Serializable]
    public class Line : Shape
	{
         
        protected Point pt1, pt2;

        public Point Pt1
        {
            get { return pt1; }
            set { pt1 = value; }
        }

        public Point Pt2
        {
            get { return pt2; }
            set { pt2 = value; }
        }
        
        public Line(Point p1, Point p2, Pen pen) : base(pen)
		{
			pt1 = p1;
			pt2 = p2;
		}

		public Line()
		{
			pt1 = Point.Empty;
			pt2 = Point.Empty;
			this.PenFinal = penTemp;
		}

		public Line(Point pt, Pen pen)
		{
            pt1 = pt2 = pt;
			this.PenFinal = pen;
		}

		public override void Draw(Graphics g, Pen pen)
		{
			g.DrawLine(pen, pt1, pt2);
		}

		public override void mouseMove(Graphics g, MouseEventArgs e)
		{
			pt2 = e.Location;
			Draw(g, penTemp);
		}

		public override string ToString()
		{
            string s = string.Format("Line {4} {5} ({0},{1}) ({2},{3});\n",
				pt1.X, pt1.Y, pt2.X, pt2.Y, (int)this.PenFinal.Width, this.PenFinal.Color.GetHashCode().ToString("X4"));
			return s;
		}

        public override void writeBinary(BinaryWriter bw)
        {
            bw.Write(this.ToString());
        }

        public override void readBinary(String br)
        {
        }

        public override void writeText(StreamWriter sw)
        {
          
           
            sw.Write(this.ToString());
        }

        public override void readText(String sr)
        {
            String[] items = sr.Split(new char[0]); //split on whitespace
           
            float width = float.Parse(items[1]);
            Color color = Color.FromArgb(Convert.ToInt32(items[2], 16));


            String[] points = items[3].Substring(1, items[3].Length - 2).Split(',');
            Point p1 = new Point(Int32.Parse(points[0]), Int32.Parse(points[1]));

            String[] points2 = items[4].Substring(1, items[4].Length - 3).Split(',');
            Point p2 = new Point(Int32.Parse(points2[0]), Int32.Parse(points2[1]));

            this.pt1 = p1;
            this.pt2 = p2;
            this.PenFinal = new Pen(color, width); ;
        }

    } // End line class

     [Serializable]
    public class Rect : Line
    {
        public Rect(Point p1, Point p2, Pen pen)
            : base(p1, p2, pen)
        { }

		public Rect()
			: base()
		{ }

		public Rect(Point pt, Pen pen)
			: base(pt, pen)
		{ }

        public override void Draw(Graphics g, Pen pen)
        {
			int x = Math.Min(pt1.X, pt2.X);
			int y = Math.Min(pt1.Y, pt2.Y);
            int width = Math.Abs(pt2.X - pt1.X);
            int height = Math.Abs(pt2.Y - pt1.Y);
            Rectangle rect = new Rectangle(x, y, width, height);
            g.DrawRectangle(pen, rect);
        }

		public override void mouseMove(Graphics g, MouseEventArgs e)
		{
			pt2 = e.Location;
			Draw(g, penTemp);
		}

		public override string ToString()
		{
            string s = string.Format("Rect {4} {5} ({0},{1}) ({2},{3});\n",
                        pt1.X, pt1.Y, pt2.X, pt2.Y, (int)this.PenFinal.Width, this.PenFinal.Color.GetHashCode().ToString("X4"));
			return s;

		}

        public override void writeBinary(BinaryWriter bw)
        {
            bw.Write(this.ToString());
        }

        public override void readBinary(String br)
        {
        }

        public override void writeText(StreamWriter sw)
        {
            sw.Write(this.ToString());
        }

        public override void readText(String sr)
        {
            String[] items = sr.Split(new char[0]); //split on whitespace

            float width = float.Parse(items[1]);
            Color color = Color.FromArgb(Convert.ToInt32(items[2], 16));


            String[] points = items[3].Substring(1, items[3].Length - 2).Split(',');
            Point p1 = new Point(Int32.Parse(points[0]), Int32.Parse(points[1]));

            String[] points2 = items[4].Substring(1, items[4].Length - 3).Split(',');
            Point p2 = new Point(Int32.Parse(points2[0]), Int32.Parse(points2[1]));

            this.pt1 = p1;
            this.pt2 = p2;
            this.PenFinal = new Pen(color, width); ;
        }

    } // End Rect class

     [Serializable]
    public class FreeLine : Shape
    {
        protected List<Point> freeList;

        public List<Point> FreeList
        {
            get { return freeList; }
            set { freeList = value; }
        }

        public FreeLine(Point pt, Pen pen)
            : base(pen)
        {
            freeList = new List<Point>();
            freeList.Add(pt);
        }

        public FreeLine(Pen pen)
            : base(pen)
        {
            freeList = new List<Point>();
        }

        public FreeLine()
			: base()
        {
            freeList = new List<Point>();
        }

        public override void Draw(Graphics g, Pen pen)
        {
            Point[] ptArray = freeList.ToArray();
            g.DrawLines(pen, ptArray);
        }

		public override void mouseMove(Graphics g, MouseEventArgs e)
		{
			freeList.Add(e.Location);
			Draw(g, penTemp);
        }

		public override string ToString()
		{
            string s = string.Format("FreeLine {0} {1} ", (int)this.PenFinal.Width, this.PenFinal.Color.GetHashCode().ToString("X4"));
			foreach(Point p in freeList)
				s += string.Format("({0},{1}) ", p.X, p.Y);

            s += ";\n";
			return s;
		}

        public override void writeBinary(BinaryWriter bw)
        {
            bw.Write(this.ToString());
        }

        public override void readBinary(String br)
        {
        }

        public override void writeText(StreamWriter sw)
        {     
            sw.Write(this.ToString());
        }

        public override void readText(String sr)
        {
            String[] items = sr.Split(new char[0]); //split on whitespace

            float width = float.Parse(items[1]);
            Color color = Color.FromArgb(Convert.ToInt32(items[2], 16));

            int i;
            for (i = 3; i < items.Length-1; i++)
            {
                if (items[i].Length < 2)
                    continue;
                String[] points = items[i].Substring(1, items[i].Length - 2).Split(',');
                Point p1 = new Point(Int32.Parse(points[0]), Int32.Parse(points[1]));
                
                this.freeList.Add(p1);
            }

            this.PenFinal = new Pen(color, width);
            

            
        }

    } // End FreeLine class
}
