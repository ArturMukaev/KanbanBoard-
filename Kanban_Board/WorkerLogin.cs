using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Kanban_Board
{
    public partial class WorkerLogin : Form
    {
        public WorkerLogin()
        {
            InitializeComponent();

        }
        public static int Work;
        Point lastPoint;
        private KanbanBoard f1;
        private void Enter_Click(object sender, EventArgs e)
        {
            string loginWorker = textBox1.Text;
            string passWorker = textBox2.Text;
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `workers` WHERE `login` = @WL AND `password` = @WP", db.getConnection());// заглушки
            command.Parameters.Add("@WL", MySqlDbType.VarChar).Value = loginWorker;
            command.Parameters.Add("@WP", MySqlDbType.VarChar).Value = passWorker;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                if (passWorker == "ivan1")
                {
                    Work = 1;
                }
                if (passWorker == "Petr1")
                {
                    Work = 2;
                }
                if (passWorker == "Orel1")
                {
                    Work = 3;
                }
                this.Close();
                this.f1 = new KanbanBoard();
                this.f1.Show();

            }
            else
            {
                MessageBox.Show("Такого пользователя нет в системе!");
            }
        }
        private void Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
        private LoginForm f2;
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.f2 = new LoginForm();
            this.f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
