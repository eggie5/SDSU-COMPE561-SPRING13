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
            saveDialog();
        }

        private void saveDialog()
        {
            DialogResult result; // result of SaveFileDialog
            string fileName; // name of file containing data

            using (SaveFileDialog fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false; // let user create file
                fileChooser.Filter = "Text Files (*.txt) |*.txt| Binary Files (*.bin) |*.bin";
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
                        //// open file with write access
                        //FileStream output = new FileStream(fileName,
                        //   FileMode.Create, FileAccess.Write);

                        //// sets file to where data is written

                        //string ext = Path.GetExtension(fileName);
                        //if (ext.Equals(".bin"))
                        //{
                        //    BinaryWriter bw = new BinaryWriter(output);
                        //    persistShapesAsBin(bw);
                        //    bw.Close();
                        //}
                        //else //ext
                        //{
                        //    StreamWriter fileWriter = new StreamWriter(output);
                        //    persistShapesAsText(fileWriter);
                        //    fileWriter.Close();
                        //}

                        persistShapes();

                        
                        newFile = false;
                        // disable Save button and enable Enter button
                        //    saveButton.Enabled = false;
                        //   enterButton.Enabled = true;

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
            fileWriter.Close();
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
            if (!newFile) //file already exists, just save it
            {
                FileStream output = new FileStream(currentFile,
                           FileMode.Create, FileAccess.Write);

                // sets file to where data is written
                string ext = Path.GetExtension(currentFile);
                if (ext.Equals(".bin"))
                {
                    BinaryWriter bw = new BinaryWriter(output);
                    persistShapesAsBin(bw);
                    bw.Close();
                }
                else //ext
                {
                    StreamWriter fileWriter = new StreamWriter(output);
                    persistShapesAsText(fileWriter);
                    fileWriter.Close();
                }

     

                return;
            }

            saveDialog();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string fileName;

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                fileChooser.CheckFileExists = false; // let user create file
                fileChooser.Filter = "Text Files (*.txt) |*.txt| Binary Files (*.bin) |*.bin";
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

                        FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                        

                        //clear canvas
                        this.shapeList.Clear();
                        this.Invalidate();

                        string ext = Path.GetExtension(fileName);
                        if (ext.Equals(".bin"))
                        {
                            BinaryReader br = new BinaryReader(input);
                            readShapesFileAsBin(br);
                            br.Close();
                        }
                        else //ext
                        {
                            StreamReader reader = new StreamReader(input);
                            readShapesFileAsText(reader);
                            reader.Close();
                        }

                        input.Close();
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
			finally 
			{
				output.Close();
			}
		}
		
		private void persistShapes()
		{
			if (currentFile!=null)
			{
                string ext = Path.GetExtension(currentFile);
                FileStream output = new FileStream(currentFile, FileMode.Create, FileAccess.Write);
                if (ext.Equals(".bin"))
                {
                    persistShapesAsBin(output);
                }
				if(ext.Equals(".ser"))
				{
					persistShapesAsSeralizedBinary(output);
				}
                else //ext
                {
                    persistShapesAsText(output);
                }

            }
            else
            {
                throw new Exception("there is no current document");
            }
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