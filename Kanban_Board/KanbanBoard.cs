using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Kanban_Board
{
    public partial class KanbanBoard : Form
    {

        static GroupBox[] cards = new GroupBox[20];



        public KanbanBoard()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;

            AllowMove = true;
            BringToFront = true;


        }
        [Serializable]
        static class Serialisation
        {
            public static byte[] Serialize(object[] obj)
            {
                MemoryStream ms = new MemoryStream();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                ms.Close();
                return ms.GetBuffer();
            }

            public static object[] Deserialize(byte[] bt)
            {
                object[] obj;
                MemoryStream ms = new MemoryStream(bt);
                BinaryFormatter bf = new BinaryFormatter();
                obj = (object[])bf.Deserialize(ms);
                ms.Close();
                return obj;
            }
        }

        private void удалитьВсеЗадачиИзФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.Delete("savedata");

            object[] obj = Serialisation.Deserialize(File.ReadAllBytes("k"));
            List<object> k = new List<object>();
            k.Add(obj[0]);
            k[0] = 0;
            File.WriteAllBytes("k", Serialisation.Serialize(k.ToArray()));
            for (int i = 0; i < 20; i++)
            {
                string h = i.ToString();
                if (File.Exists(h))
                {
                    File.Delete(h);
                }
            }
            MessageBox.Show("Перезапустите приложение!");

        }


        private void добавитьЗадачуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Addf();

        }

        static TextBox task;
        static TextBox time;
        static TextBox person;

        private void Addf()
        {
            object[] obj1 = Serialisation.Deserialize(File.ReadAllBytes("k"));
            List<object> k = new List<object>();
            k.Add(obj1[0]);
            File.WriteAllBytes("k", Serialisation.Serialize(k.ToArray()));

            task = new TextBox();
            time = new TextBox();
            cards[(int)k[0]] = new GroupBox();
            person = new TextBox();
            Button save = new Button();
            Button details = new Button();

            cards[(int)k[0]].Name = ((int)k[0] + 1).ToString();
            cards[(int)k[0]].Text = "";
            cards[(int)k[0]].Size = new Size(150, 140);
            cards[(int)k[0]].Location = new Point(20, 105);
            this.Controls.Add(cards[(int)k[0]]);

            cards[(int)k[0]].Controls.Add(task);
            cards[(int)k[0]].Controls.Add(time);
            cards[(int)k[0]].Controls.Add(person);
            cards[(int)k[0]].Controls.Add(save);
            cards[(int)k[0]].Controls.Add(details);

            details.Location = new Point(130, 0);
            details.Size = new Size(20, 20);
            details.Text = "?";
            details.Name = cards[(int)k[0]].Name;

            save.Name = cards[(int)k[0]].Name;
            save.Location = new Point(110, 115);
            save.Size = new Size(40, 20);
            save.Text = "Save";

            task.Location = new System.Drawing.Point(5, 42);
            task.Name = "task";
            task.Multiline = true;
            task.Size = new Size(140, 70);

            time.Location = new System.Drawing.Point(5, 120);
            time.Name = "time";
            time.Multiline = true;
            time.Size = new System.Drawing.Size(80, 19);

            person.Location = new System.Drawing.Point(0, 0);
            person.Name = "person";
            person.Multiline = true;
            person.Size = new System.Drawing.Size(120, 19);

            cards[(int)k[0]].MouseDoubleClick += DoubleClik;
            save.Click += Clik;
            details.Click += ShowInfo;
            //ControlMover.Add(cards[(int)k[0]]);
            cards[(int)k[0]].MouseDown += ctrl_MouseDown;
            cards[(int)k[0]].MouseUp += ctrl_MouseUp;
            cards[(int)k[0]].MouseMove += ctrl_MouseMove;
            cards[(int)k[0]].MouseUp += LockChanged;

            Safe(ref cards[(int)k[0]], ref task, ref time, ref person, ref save, ref details);
            k[0] = (int)k[0] + 1;
            File.WriteAllBytes("k", Serialisation.Serialize(k.ToArray()));

        }


        static void ShowInfo(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            string name = ctrl.Name;
            if (!File.Exists(name))
            {
                MessageBox.Show("Данная задача еще не перемещалась!");
            }
            else
            {
                object[] obj1 = Serialisation.Deserialize(File.ReadAllBytes(name));
                for (int i = 0; i < obj1.Length; i++)
                {
                    MessageBox.Show("Данная задача была перемещена " + (i + 1) + " раз в " + obj1[i]);
                }

            }
        }
        static void LockChanged(object sender, EventArgs e)
        {
            var ctrl = sender as Control;
            string name = ctrl.Name;
            if (!File.Exists(name))
            {
                List<object> info = new List<object>();
                File.WriteAllBytes(name, Serialisation.Serialize(info.ToArray()));
                info.Add(1);
                string curTimeShort = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
                info[0] = curTimeShort;
                File.WriteAllBytes(name, Serialisation.Serialize(info.ToArray()));
            }
            else
            {
                object[] obj1 = Serialisation.Deserialize(File.ReadAllBytes(name));
                List<object> info = new List<object>();
                for (int i = 0; i < obj1.Length; i++)
                {
                    info.Add(obj1[i]);
                }
                string curTimeShort = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
                info.Add(curTimeShort);
                File.WriteAllBytes(name, Serialisation.Serialize(info.ToArray()));
            }
        }
        static void Erorr(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Это не ваша задача!");
        }

        public static bool AllowMove { get; set; }
        public static bool BringToFront { get; set; }
        private static Point startMouse;
        private static Point startLocation;

        static Cursor oldCursor;

        static void ctrl_MouseMove(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;

            if (e.Button != MouseButtons.Left)
                return;

            var l = ctrl.PointToScreen(e.Location);
            var dx = l.X - startMouse.X;
            var dy = l.Y - startMouse.Y;

            if (Math.Max(Math.Abs(dx), Math.Abs(dy)) > 1)
            {
                if (AllowMove)
                {
                    Point newLoc = startLocation + new Size(dx, dy);
                    if (newLoc.X < 0) newLoc = new Point(0, newLoc.Y);
                    if (newLoc.Y < 0) newLoc = new Point(newLoc.X, 0);
                    ctrl.Location = newLoc;
                    ctrl.Cursor = Cursors.SizeAll;
                    if (BringToFront) ctrl.BringToFront();

                    object[] ob = Serialisation.Deserialize(File.ReadAllBytes("savedata"));
                    List<object> data = new List<object>();
                    for (int i = 0; i < ob.Length; i++)
                    {
                        data.Add(ob[i]);
                    }

                    for (int i = 4; i < ob.Length; i += 31)
                    {
                        if ((string)data[i] == ctrl.Name)
                        {
                            data[i - 4] = newLoc.X;
                            data[i - 3] = newLoc.Y;
                        }
                    }
                    File.WriteAllBytes("savedata", Serialisation.Serialize(data.ToArray()));

                }
            }
        }

        static void ctrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            var ctrl = sender as Control;
            startMouse = ctrl.PointToScreen(e.Location);
            startLocation = ctrl.Location;
            oldCursor = ctrl.Cursor;
        }
        private static void ctrl_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
                return;
            var ctrl = (sender as Control);
            ctrl.Cursor = oldCursor;

        }

        private void Safe(ref GroupBox temp, ref TextBox task, ref TextBox time, ref TextBox person, ref Button save, ref Button details)
        {
            object[] obj = Serialisation.Deserialize(File.ReadAllBytes("savedata"));
            List<object> data = new List<object>();
            for (int i = 0; i < obj.Length; i++)
            {
                data.Add(obj[i]);
            }
            data.AddRange(new object[] {
                        temp.Bounds.X,
                        temp.Bounds.Y,
                        temp.Bounds.Width,
                        temp.Bounds.Height,
                        temp.Name, temp.Text,task.Bounds.X,task.Bounds.Y,task.Bounds.Width,task.Bounds.Height,task.Text,
            time.Bounds.X,time.Bounds.Y,time.Bounds.Width,time.Bounds.Height,time.Text,person.Bounds.X,person.Bounds.Y,person.Bounds.Width,person.Bounds.Height,person.Text,save.Bounds.X,save.Bounds.Y,save.Bounds.Width,save.Bounds.Height,save.Text,details.Bounds.X,details.Bounds.Y,details.Bounds.Width,details.Bounds.Height,details.Text});
            File.WriteAllBytes("savedata", Serialisation.Serialize(data.ToArray()));

        }





        private void DoubleClik(object sender, System.EventArgs e)
        {
            var ctrl = (sender as Control);
            object[] obj = Serialisation.Deserialize(File.ReadAllBytes("savedata"));
            List<object> data = new List<object>();

            for (int i = 4; i < obj.Length; i += 31)
            {
                if ((string)obj[i] == (string)ctrl.Name)
                {
                    if (i == 4)
                    {
                        for (int j = 31; j < obj.Length - 31; j++)
                        {
                            data.Add(obj[j]);
                        }
                        this.Controls.Remove(ctrl);
                        File.Delete(ctrl.Name);
                    }
                    else
                    {
                        for (int j = 0; j < i - 4; j++)
                        {
                            data.Add(obj[j]);
                        }
                        for (int j = i + 27; j < obj.Length - 31; j++)
                        {
                            data.Add(obj[j]);
                        }
                        this.Controls.Remove(ctrl);
                        File.Delete(ctrl.Name);
                    }

                }
            }
            File.WriteAllBytes("savedata", Serialisation.Serialize(data.ToArray()));

        }
        private Edit f3;
        private void Clik(object sender, EventArgs e)
        {
            if (f3 == null || f3.Visible == false)
            {
                var ctrl = (sender as Control);
                object[] obj = Serialisation.Deserialize(File.ReadAllBytes("savedata"));
                List<object> data = new List<object>();
                for (int i = 0; i < obj.Length; i++)
                {
                    data.Add(obj[i]);
                }

                for (int i = 4; i < obj.Length; i += 31)
                {
                    if ((string)data[i] == ctrl.Name)
                    {
                        data[i + 6] = task.Text;
                        data[i + 11] = time.Text;
                        data[i + 16] = person.Text;
                    }
                }
                File.WriteAllBytes("savedata", Serialisation.Serialize(data.ToArray()));
            }
            else
            {
                var ctrl = (sender as Control);
                object[] obj = Serialisation.Deserialize(File.ReadAllBytes("savedata"));
                List<object> data = new List<object>();
                for (int i = 0; i < obj.Length; i++)
                {
                    data.Add(obj[i]);
                }

                for (int i = 4; i < obj.Length; i += 31)
                {
                    if ((string)data[i] == ctrl.Name)
                    {
                        data[i + 6] = Edit.Taskk;
                        data[i + 11] = Edit.Timee;
                        data[i + 16] = Edit.Workerr;
                        //task.Text = Edit.Taskk;
                        //time.Text = Edit.Timee;
                        //person.Text = Edit.Workerr;
                    }
                }
                File.WriteAllBytes("savedata", Serialisation.Serialize(data.ToArray()));
                this.f3.Close();
                MessageBox.Show("Перезапустите приложение!");

            }

        }




        Point lastPoint;
        private void KanbanBoard_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void KanbanBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void KanbanBoard_Load(object sender, EventArgs e)
        {

            if (WorkerLogin.Work == 1|| WorkerLogin.Work == 2 || WorkerLogin.Work == 3)
            {
                this.менюToolStripMenuItem.Visible = false;
                this.menuStrip1.Visible = false;
            }
            string rabotnik ="";
            if(WorkerLogin.Work == 1)
            {
                rabotnik = "Иванов";
            }
            if (WorkerLogin.Work == 2)
            {
                rabotnik = "Петров";
            }
            if (WorkerLogin.Work == 3)
            {
                rabotnik = "Орлов";
            }
            if (!File.Exists("savedata"))
            {
                List<object> data = new List<object>();
                File.WriteAllBytes("savedata", Serialisation.Serialize(data.ToArray()));
            }
            else
            {
                object[] obj = Serialisation.Deserialize(File.ReadAllBytes("savedata"));
                GroupBox[] gr = new GroupBox[(obj.Length + 1) / 31];
                TextBox[] tx = new TextBox[(obj.Length + 1) / 10];
                Button[] bt = new Button[obj.Length / 15];
                for (int j = 0; j < (obj.Length + 1) / 31; j++)
                {
                    gr[j] = new GroupBox();
                    if(rabotnik == "")
                    {
                        gr[j].MouseDoubleClick += DoubleClik;
                    }

                }
                for (int j = 0; j < (obj.Length + 1) / 10; j++)
                {
                    tx[j] = new TextBox();

                }
                for (int j = 0; j < obj.Length / 15; j++)
                {
                    bt[j] = new Button();

                }
                int k = 0;
                int b = 0;
                for (int i = 0; i < obj.Length; i += 31)
                {

                    gr[i / 31].SetBounds((int)obj[i], (int)obj[i + 1], (int)obj[i + 2], (int)obj[i + 3]);
                    gr[i / 31].Text = obj[4 + i].ToString();
                    gr[i / 31].Name = obj[4 + i].ToString();
                    this.Controls.Add(gr[i / 31]);


                    for (int h = k; h < k + 3; h++)
                    {
                        tx[h].SetBounds((int)obj[i + 6], (int)obj[i + 7], (int)obj[i + 8], (int)obj[i + 9]);
                        tx[h].Text = obj[10 + i].ToString();
                        gr[i / 31].Controls.Add(tx[h]);
                        tx[h].Multiline = true;
                        h++;
                        tx[h].SetBounds((int)obj[i + 11], (int)obj[i + 12], (int)obj[i + 13], (int)obj[i + 14]);
                        tx[h].Text = obj[15 + i].ToString();
                        gr[i / 31].Controls.Add(tx[h]);
                        h++;
                        tx[h].SetBounds((int)obj[i + 16], (int)obj[i + 17], (int)obj[i + 18], (int)obj[i + 19]);
                        tx[h].Text = obj[20 + i].ToString();
                        gr[i / 31].Controls.Add(tx[h]);
                        if (tx[h].Text == rabotnik || rabotnik == "")
                        {

                            gr[i / 31].MouseDown += ctrl_MouseDown;
                            gr[i / 31].MouseMove += ctrl_MouseMove;
                            gr[i / 31].MouseUp += ctrl_MouseUp;
                            gr[i / 31].MouseUp += LockChanged;
                        }
                        else
                        {
                            gr[i / 31].MouseDown += Erorr;
                            gr[i / 31].MouseUp += Erorr;
                        }
                    }
                    k = k + 3;

                    bt[b].SetBounds((int)obj[i + 21], (int)obj[i + 22], (int)obj[i + 23], (int)obj[i + 24]);
                    bt[b].Text = obj[25 + i].ToString();
                    gr[i / 31].Controls.Add(bt[b]);
                    bt[b].Name = gr[i / 31].Name;

                    bt[b].Click += Clik;

                    if (WorkerLogin.Work == 1 || WorkerLogin.Work == 2 || WorkerLogin.Work == 3)
                    {
                        bt[b].Visible = false;
                    }
                    b++;
                    bt[b].SetBounds((int)obj[i + 26], (int)obj[i + 27], (int)obj[i + 28], (int)obj[i + 29]);
                    bt[b].Text = obj[30 + i].ToString();
                    gr[i / 31].Controls.Add(bt[b]);
                    bt[b].Name = gr[i / 31].Name;
                    bt[b].Click += ShowInfo;
                    b++;

                    
                }

            }
        }


        private void изменитьФонToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int r = rnd.Next(1, 4);
            if (r == 1)
            {
                this.BackgroundImage = Properties.Resources.table1;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
            }
            else
            {
                if (r == 2)
                {
                    this.BackgroundImage = Properties.Resources.рабочий_стол;
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                    label3.ForeColor = Color.Black;
                    label4.ForeColor = Color.Black;
                    label5.ForeColor = Color.Black;
                }
                else
                {
                    this.BackgroundImage = Properties.Resources.table2;
                    label1.ForeColor = Color.White;
                    label2.ForeColor = Color.White;
                    label3.ForeColor = Color.White;
                    label4.ForeColor = Color.White;
                    label5.ForeColor = Color.White;
                }
            }
        }

        private void редактироватьЗадачуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.f3 = new Edit();
            this.f3.Show();
        }
    }
}




