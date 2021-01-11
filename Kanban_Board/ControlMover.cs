using System;
using System.Drawing;
using System.Windows.Forms;

namespace Kanban_Board
{
    public static class ControlMover
    {
     
        public static bool AllowMove { get; set; }
        public static bool BringToFront { get; set; }
        private static Point startMouse;
        private static Point startLocation;

        static Cursor oldCursor;

        static ControlMover()
        {
           
            AllowMove = true;
            BringToFront = true;
        }

        public static void Add(Control ctrl)
        {
            ctrl.MouseDown += ctrl_MouseDown;
            ctrl.MouseUp += ctrl_MouseUp;
            ctrl.MouseMove += ctrl_MouseMove;
            //int x = ctrl.Top;
            //int y = ctrl.Left;
            //ctrl.Location = new Point(x, y);
        }

        private static void ctrl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            var ctrl = (sender as Control);
            ctrl.Cursor = oldCursor;
        }

      

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
    }
}
