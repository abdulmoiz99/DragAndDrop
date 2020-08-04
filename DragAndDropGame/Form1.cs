using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDropGame
{
    public partial class Form1 : Form
    {
        private Control activeControl;
        private Point previousPosition;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var label = new Label();
            label.AutoSize = true;
            label.Location = new Point(118, 182);
            label.Text = "Sample";
            label.MouseDown += new MouseEventHandler(Label_MouseDown);
            label.MouseUp += new MouseEventHandler(Label_MouseUp);
            label.MouseMove += new MouseEventHandler(Label_MouseMove);
            Controls.Add(label);
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {          
            if (activeControl == null || activeControl != sender)
            {
                return;
            }

            var location = activeControl.Location;
            location.Offset(e.Location.X - previousPosition.X, e.Location.Y - previousPosition.Y);
            activeControl.Location = location;
        }

        private void Label_MouseUp(object sender, MouseEventArgs e)
        {
            if (activeControl.Bounds.IntersectsWith(listBox1.Bounds))
            {
                activeControl.Location = radioButton1.Location;
            }
            else if (activeControl.Bounds.IntersectsWith(listBox2.Bounds))
            {
                activeControl.Location = radioButton2.Location;
            }
            else if (activeControl.Bounds.IntersectsWith(listBox3.Bounds))
            {
                activeControl.Location = radioButton3.Location;
            }
            else if (activeControl.Bounds.IntersectsWith(listBox4.Bounds))
            {
                activeControl.Location = radioButton4.Location;
            }
            else 
            {
                activeControl.Location = new Point(118, 182);
            }
            activeControl = null;
            Cursor = Cursors.Default;
        }

        private void Label_MouseDown(object sender, MouseEventArgs e)
        {
            activeControl = sender as Control;
            previousPosition = e.Location;
            Cursor = Cursors.Hand;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
