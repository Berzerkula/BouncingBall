// https://bytecrunchers.wordpress.com/2012/07/24/bouncing-ball-in-c/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace BouncingBall
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {

        const int radius = 20;
        const int velocity = 5;

        int xC, yC, xDelta = 10, yDelta = 10, xSize, ySize;  // class level variables

        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            this.ResizeRedraw = true;      // Tell form to redraw itself when resized
            timer1.Start();
            Form1_Resize(this, EventArgs.Empty);  // Force a Resize Event as pgm starts
                                                  //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 25;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Name = "Form1";
            this.Text = "Bouncing Ball";
            this.Resize += new System.EventHandler(this.Form1_Resize);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }



        private void Form1_Resize(object sender, System.EventArgs e)
        {
            xSize = this.ClientSize.Width;   // Set current window size
            ySize = this.ClientSize.Height;
            xC = xSize / 2;                    // Place ball in center of window 
            yC = ySize / 2;
            DrawBall();                       // Draw the ball in the window		
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            DrawBall();                       // Draw ball in next frame of animation		
        }

        private void DrawBall()
        {
            Graphics g = this.CreateGraphics();
            Brush b = new SolidBrush(this.BackColor);
            g.FillEllipse(b, xC - radius, yC - radius, 2 * radius, 2 * radius); //erase old ball
            xC += xDelta;                                                   //move ball
            yC += yDelta;
            if ((xC + radius >= ClientSize.Width) || (xC - radius <= 0)) //check for wall hits
                xDelta = -xDelta;
            if ((yC + radius >= ClientSize.Height) || (yC - radius <= 0))
                yDelta = -yDelta;
            b = new SolidBrush(Color.Red);                               // draw new ball
            g.FillEllipse(b, xC - radius, yC - radius, 2 * radius, 2 * radius);
            b.Dispose();
            g.Dispose();
        }

    }
}