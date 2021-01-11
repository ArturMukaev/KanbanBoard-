namespace Kanban_Board
{
    partial class KanbanBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьЗадачуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьФонToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьВсеЗадачиИзФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактироватьЗадачуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(1225, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Новые задачи";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(547, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 45);
            this.label2.TabIndex = 3;
            this.label2.Text = "Выполнение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(306, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 45);
            this.label3.TabIndex = 4;
            this.label3.Text = "В очереди";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1098, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 45);
            this.label4.TabIndex = 5;
            this.label4.Text = "Выполнено";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(804, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 45);
            this.label5.TabIndex = 6;
            this.label5.Text = "Тестирование";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(11, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(90, 35);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьЗадачуToolStripMenuItem1,
            this.изменитьФонToolStripMenuItem1,
            this.удалитьВсеЗадачиИзФайлToolStripMenuItem,
            this.редактироватьЗадачуToolStripMenuItem});
            this.менюToolStripMenuItem.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(82, 31);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // добавитьЗадачуToolStripMenuItem1
            // 
            this.добавитьЗадачуToolStripMenuItem1.Name = "добавитьЗадачуToolStripMenuItem1";
            this.добавитьЗадачуToolStripMenuItem1.Size = new System.Drawing.Size(381, 32);
            this.добавитьЗадачуToolStripMenuItem1.Text = "Добавить задачу";
            this.добавитьЗадачуToolStripMenuItem1.Click += new System.EventHandler(this.добавитьЗадачуToolStripMenuItem1_Click);
            // 
            // изменитьФонToolStripMenuItem1
            // 
            this.изменитьФонToolStripMenuItem1.Name = "изменитьФонToolStripMenuItem1";
            this.изменитьФонToolStripMenuItem1.Size = new System.Drawing.Size(381, 32);
            this.изменитьФонToolStripMenuItem1.Text = "Изменить фон";
            this.изменитьФонToolStripMenuItem1.Click += new System.EventHandler(this.изменитьФонToolStripMenuItem1_Click);
            // 
            // удалитьВсеЗадачиИзФайлToolStripMenuItem
            // 
            this.удалитьВсеЗадачиИзФайлToolStripMenuItem.Name = "удалитьВсеЗадачиИзФайлToolStripMenuItem";
            this.удалитьВсеЗадачиИзФайлToolStripMenuItem.Size = new System.Drawing.Size(381, 32);
            this.удалитьВсеЗадачиИзФайлToolStripMenuItem.Text = "Удалить все задачи из файла";
            this.удалитьВсеЗадачиИзФайлToolStripMenuItem.Click += new System.EventHandler(this.удалитьВсеЗадачиИзФайлToolStripMenuItem_Click);
            // 
            // редактироватьЗадачуToolStripMenuItem
            // 
            this.редактироватьЗадачуToolStripMenuItem.Name = "редактироватьЗадачуToolStripMenuItem";
            this.редактироватьЗадачуToolStripMenuItem.Size = new System.Drawing.Size(381, 32);
            this.редактироватьЗадачуToolStripMenuItem.Text = "Редактировать задачу";
            this.редактироватьЗадачуToolStripMenuItem.Click += new System.EventHandler(this.редактироватьЗадачуToolStripMenuItem_Click);
            // 
            // KanbanBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kanban_Board.Properties.Resources.рабочий_стол;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1341, 649);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "KanbanBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KanbanBoard";
            this.Load += new System.EventHandler(this.KanbanBoard_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KanbanBoard_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.KanbanBoard_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьЗадачуToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem изменитьФонToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьВсеЗадачиИзФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактироватьЗадачуToolStripMenuItem;
    }
}