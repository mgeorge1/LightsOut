using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightsOut
{
    public partial class MainForm : Form
    {
        private const int GridOffset = 25;
        private const int GridLength = 200;
        private int NumCells;
        private int CellLength;

        LightsOutGame lightsOut = new LightsOutGame();

        public MainForm()
        {
            InitializeComponent();
            NumCells = lightsOut.GridSize;
            CellLength = GridLength / NumCells;
    
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lightsOut.NewGame();
            this.Invalidate();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for(int r = 0; r<NumCells; r++)
            {
                for(int c = 0; c<NumCells; c++)
                {
                    Brush brush;
                    Pen pen;

                    if (lightsOut.GetGridValue(r,c))
                    {
                        pen = Pens.Black;
                        brush = Brushes.White;
                    }
                    else
                    {
                        pen = Pens.White;
                        brush = Brushes.Black;
                    }

                    int x = c * CellLength + GridOffset;
                    int y = r * CellLength + GridOffset;

                    g.DrawRectangle(pen, x, y, CellLength, CellLength);
                    g.FillRectangle(brush, x + 1, y + 1, CellLength - 1, CellLength - 1);
                }
            }
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X < GridOffset || e.X > CellLength * NumCells + GridOffset ||
                e.Y < GridOffset || e.Y > CellLength * NumCells + GridOffset)
                return;
            int r = (e.Y - GridOffset) / CellLength;
            int c = (e.X - GridOffset) / CellLength;

            lightsOut.Move(r, c);

            this.Invalidate();

            if (lightsOut.IsGameOver())
            {
                MessageBox.Show(this, "Congratulations! You've Won!", "Lights Out!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private bool PlayerWon()
        {
            
            for (int i = 0; i < NumCells; i++)
            {
                for (int j = 0; j < NumCells; j++)
                {
                    if (lightsOut.GetGridValue(i, j) == true)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            lightsOut.NewGame();
            this.Invalidate();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutBox = new AboutForm();
            aboutBox.ShowDialog(this);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SizeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void X3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void X4ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
