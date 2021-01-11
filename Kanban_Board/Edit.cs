using System.Drawing;
using System.Windows.Forms;

namespace Kanban_Board
{
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
            Workerr = person1.Text;
            Taskk = task1.Text;
            Timee = time1.Text;
        }
        public static string Workerr;
        public static string Taskk;
        public static string Timee;




        Point lastPoint;
        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Exit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void person1_TextChanged(object sender, System.EventArgs e)
        {
            Workerr = person1.Text;
            
        }

        private void task1_TextChanged(object sender, System.EventArgs e)
        {
Taskk = task1.Text;
            
        }

        private void time1_TextChanged(object sender, System.EventArgs e)
        {
Timee = time1.Text;
        }
    }
}
