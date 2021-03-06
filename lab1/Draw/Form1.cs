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
//using System.Runtime.Serialization.Formatters
using System.Xml.Serialization;
using System.Xml;

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
        String dialogFilterString = "Text Files (*.txt) |*.txt| Binary Files (*.bin) |*.bin| XML Ser (*.ser) |*.ser| XML (*.xml) |*.xml";

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
			if (e.Button == MouseButtons.Left && shape!=null)
			{
				Invalidate();
				Update();
                shape.mouseMove(g, e);
			}
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
            if (shape == null)
            {
                Console.WriteLine("null shape on mouse up");
                return;
            }

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
                shape.Draw(e.Graphics, shape.PenFinal);
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
            showSaveDialog();
        }

        private void showSaveDialog()
        {
            DialogResult result; // result of SaveFileDialog
            string fileName; // name of file containing data

            using (SaveFileDialog fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false; // let user create file
                fileChooser.Filter = dialogFilterString;
                fileChooser.DefaultExt = "txt";
                result = fileChooser.ShowDialog();
                fileName = currentFile = fileChooser.FileName; // name of file to save data
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
                        persistShapes();   
                        newFile = false;
                        this.Text = Path.GetFileName(currentFile);
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error opening file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void persistShapesAsBin(BinaryWriter writer)
        {
            foreach (Shape shape in shapeList)
            {
                shape.writeBinary(writer);

            }
        }

        private void persistShapesAsBin(FileStream output)
        {
            BinaryWriter bw = new BinaryWriter(output);
            persistShapesAsBin(bw);
            bw.Close();
        }

        private void persistShapesAsText(StreamWriter writer)
        {

            foreach (Shape shape in shapeList)
            {
                shape.writeText(writer);

            }
       
        }

        private void persistShapesAsText(FileStream output)
        {
            StreamWriter fileWriter = new StreamWriter(output);
            persistShapesAsText(fileWriter);
            output.Close();
           
          
            
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (newFile) //opne new file dialog
            {
                showSaveDialog();
            }
            else //file already exists, just save it
            {
                // sets file to where data is written
                persistShapes();
            }

            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                fileChooser.CheckFileExists = false; // let user create file
                fileChooser.Filter = dialogFilterString;
                fileChooser.DefaultExt = "txt";
                result = fileChooser.ShowDialog();
                fileName =currentFile = fileChooser.FileName; // name of file to save data
                newFile = false;
            }

            if (result == DialogResult.OK)
            {
                // show error if user specified invalid file
                if (String.IsNullOrEmpty(fileName))
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        //clear canvas
                        ClearCanvas();

                        using (var input = new FileStream(fileName, FileMode.Open))
                        {
                            string ext = Path.GetExtension(fileName);
                            if (ext.Equals(".bin"))
                            {
                                using (var br = new BinaryReader(input))
                                {
                                    readShapesFileAsBin(br);
                                }
                            }
                            else if (ext.Equals(".xml"))
                            {
                                deserializeXML(input);
                            }
                            else if (ext.Equals(".ser"))
                            {
                                deserializeBinaryXML(input);
                            }
                            else //ext
                            {
                                using (var reader = new StreamReader(input))
                                {
                                    readShapesFileAsText(reader);
                                }
                            }

                        }
                        this.Text = Path.GetFileName(currentFile);
                        Invalidate();
                       
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Error opening file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void deserializeXML(FileStream input)
        {
            Type[] types = new Type[] { typeof(Line), typeof(Rect), typeof(FreeLine) };
            XmlSerializer x = new XmlSerializer(typeof(List<Shape>), types);
            this.shapeList=(List<Shape>)x.Deserialize(input);
        }

        private void ClearCanvas()
        {
            this.shapeList.Clear();
            this.Invalidate();
            this.dataModified = false;
            this.newFile = true ;
        }

        private void deserializeBinaryXML(FileStream input)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                this.shapeList = (List<Shape>)formatter.Deserialize(input);
        
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
        }

        private void readShapesFileAsBin(BinaryReader br)
        {

            while (br.PeekChar() > -1)
            {
                String line = br.ReadString();

                string type = line.Split(new char[0])[0];
                
          
                switch (type)
                {
                    case "Line":
                        shape = new Line();
                        shape.readText(line);
                        break;
                    case "FreeLine":

                        shape = new FreeLine();
                        shape.readText(line);
                        break;
                    case "Rect":
                        shape = new Rect();
                        shape.readText(line);
                        break;

                }

                shapeList.Add(shape);

            }
        }

        private void readShapesFileAsText(StreamReader reader)
        {
           // String rawText = reader.ReadToEnd();
            //parse text
         
            while(reader.Peek()>0)
            {
             
                String line = reader.ReadLine();
                string type =line.Split(new char[0])[0];
                //Shape shape=null; 
                //using the global shape obj he added

                switch (type)
                {
                    case "Line":
                        shape = new Line();
                        shape.readText(line);
                        break;
                    case "FreeLine":

                        shape = new FreeLine();
                        shape.readText(line);
                        break;
                    case "Rect":
                        shape = new Rect();
                        shape.readText(line);
                        break;

                }

                shapeList.Add(shape);

            }


        } 

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataModified)
            {
                DialogResult dr = MessageBox.Show("Save unsaved changes?", "", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    persistShapes();
                }
            }

            shapeList.Clear();
            Invalidate();
            newFile = true;
            currentFile = null;
        }

		void persistShapesAsSeralizedBinary (FileStream output)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			try 
			{
				formatter.Serialize(output, this.shapeList);
                
			}
			catch (SerializationException e) 
			{
				Console.WriteLine("Failed to serialize. Reason: " + e.Message);
				throw;
			}

		}
		
		private void persistShapes()
		{
			if (currentFile!=null)
			{
                string ext = Path.GetExtension(currentFile);
                using (var output = new FileStream(currentFile, FileMode.Create, FileAccess.Write))
                {
                    switch (ext)
                    {
                        case ".bin":
                            persistShapesAsBin(output);
                            break;
                        case ".ser":
                            persistShapesAsSeralizedBinary(output);
                            break;
                        case ".xml":
                            persistShapesAsXML(output);
                            break;
                        case ".txt":
                            persistShapesAsText(output);
                            break;
                    }
                }
            }
            else
            {
                throw new Exception("there is no current document");
            }
        }

        private void persistShapesAsXML(FileStream output)
        {
            Type[] types = new Type[] { typeof(Line), typeof(Rect), typeof(FreeLine) };
            XmlSerializer x = new XmlSerializer(typeof(List<Shape>), types);
            x.Serialize(output, this.shapeList);

            output.Close();

        }

  

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataModified)
            {
                DialogResult dr = MessageBox.Show("You have unsaved changes. Save before quitting?", "", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    persistShapes();
                }
            }
            Application.Exit();
        } 

	}  // end class Form1   
            
}