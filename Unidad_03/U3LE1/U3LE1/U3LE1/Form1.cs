using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace U3LE1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs paintEvnt)
        {
            // Get the graphics object 
            Graphics gfx = paintEvnt.Graphics;
            int x1 = 0;
            int y1 = 0;

            // Loop trough the 255 values red can have 
            for (int i = 0; i <= 255; i++)
            {
                // Create new brush with a defined color 
                Color brushColor = Color.FromArgb(i, 0, 0);
                // The brush is solid because we want a solid rectangle 
                SolidBrush myBrush = new SolidBrush(brushColor);
                // Actually draw the rectangle 
                gfx.FillRectangle(myBrush, x1, y1, 10, 10);
                // The next rectangle should be near the last one 
                x1 = x1 + 10;
                // If the row is complete start another one 
                if ((x1 % 290) == 0)
                {
                    y1 = y1 + 10;
                    x1 = 0;
                }
            }

            for (int i = 0; i <= 255; i++)
            {
                Color brushColor = Color.FromArgb(0, i, 0);
                SolidBrush myBrush = new SolidBrush(brushColor);
                gfx.FillRectangle(myBrush, x1, y1, 10, 10);
                x1 = x1 + 10;
                if ((x1 % 290) == 0)
                {
                    y1 = y1 + 10;
                    x1 = 0;
                }
            }

            for (int i = 0; i <= 255; i++)
            {
                Color brushColor = Color.FromArgb(0, 0, i);
                SolidBrush myBrush = new SolidBrush(brushColor);
                gfx.FillRectangle(myBrush, x1, y1, 10, 10);
                x1 = x1 + 10;
                if ((x1 % 290) == 0)
                {
                    y1 = y1 + 10;
                    x1 = 0;
                }
            }
        }



    }
}
