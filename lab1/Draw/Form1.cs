using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Draw
{
	public partial class Form1 : Form
	{
		Point pt1;
        Color penColor = Color.FromArgb(255, 255, 0, 0);
        int penWidth = 10;
        List<Shape> shapeList = new List<Shape>();
        ShapeType currentShape = ShapeType.Line;
        Shape shape;
        bool dataModified = false;
        string currentFile;
        bool newFile = true;

		public Form1()
		{
			InitializeComponent();
			this.DoubleBuffered = true;
            Shape.penTemp = new Pen(Color.Black);
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			pt1 = e.Location;
			Pen pen = new Pen(penColor, penWidth);
            shape = Shape.CreateShape(currentShape, pt1, pen); 
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			Graphics g = this.CreateGraphics();
			if (e.Button == MouseButtons.Left)
			{
				Invalidate();
				Update();
                shape.mouseMove(g, e);
			}
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				return;	// Don't respond to right mouse button up

			Graphics g = this.CreateGraphics();
            shape.mouseMove(g, e);
            shapeList.Add(shape);
			Invalidate();
            dataModified = true;
        }

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
            foreach (Shape shape in shapeList)
                shape.Draw(e.Graphics, shape.penFinal);
        }

		private void penWidthMenuItem_Click(object sender, EventArgs e)
		{
			PenDialog dlg = new PenDialog();
            dlg.PenWidth = penWidth;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                penWidth = dlg.PenWidth;
            }
		}

        private void lineMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.Line;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.Rectangle;
        }

        private void freeLineMenuItem_Click(object sender, EventArgs e)
        {
            currentShape = ShapeType.FreeLine;
        }

        private void printShapesMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("\nAll Shapes");
            foreach (Shape shape in shapeList)
                Console.WriteLine(shape);
        }

        private void penColorMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = penColor;
            if (dlg.ShowDialog() == DialogResult.OK)
                penColor = dlg.Color;

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void dosaveaction(StreamWriter writer)
        {

            foreach (Shape shape in shapeList)
            {
                shape.writeText(writer);

            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result; // result of SaveFileDialog
            string fileName; // name of file containing data

            if (!newFile)
            {
                FileStream output = new FileStream(currentFile,
                           FileMode.OpenOrCreate, FileAccess.Write);

                // sets file to where data is written
                StreamWriter writer = new StreamWriter(output);

                dosaveaction(writer);

                writer.Close();

                return;
            }

            using (SaveFileDialog fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false; // let user create file
                result = fileChooser.ShowDialog();
                fileName= currentFile = fileChooser.FileName; // name of file to save data
            }

            if (result == DialogResult.OK)
            {
                // show error if user specified invalid file
                if (fileName == string.Empty)
                    MessageBox.Show("Invalid File Name", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        // open file with write access
                        FileStream output = new FileStream(fileName,
                           FileMode.OpenOrCreate, FileAccess.Write);

                        // sets file to where data is written
                        StreamWriter fileWriter = new StreamWriter(output);

                        dosaveaction(fileWriter);
                        fileWriter.Close();
                        newFile = false;
                        // disable Save button and enable Enter button
                        //    saveButton.Enabled = false;
                        //   enterButton.Enabled = true;
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error opening file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
        } 

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataModified)
            {
                // Offer to save drawing
            }
            Application.Exit();
        } 

	}  // end class Form1   
            
}