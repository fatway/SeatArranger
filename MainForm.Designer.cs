namespace SeatArranger
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRandomArrang = new System.Windows.Forms.Button();
            this.btnMoveLeft = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveRight = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblShowMove = new System.Windows.Forms.Label();
            this.classRoom1 = new SeatArranger.ClassRoom();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPrintProject = new System.Windows.Forms.Button();
            this.btnSaveProject = new System.Windows.Forms.Button();
            this.btnReadNewProject = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStudentDel = new System.Windows.Forms.Button();
            this.btnStudentAdd = new System.Windows.Forms.Button();
            this.btnPaintStudent = new System.Windows.Forms.Button();
            this.btnSaveStudentList = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSex = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeskRow = new System.Windows.Forms.TextBox();
            this.btnPaintDesk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeskCol = new System.Windows.Forms.TextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.classRoom1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1027, 603);
            this.splitContainer1.SplitterDistance = 731;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnRandomArrang);
            this.panel2.Controls.Add(this.btnMoveLeft);
            this.panel2.Controls.Add(this.btnMoveUp);
            this.panel2.Controls.Add(this.btnMoveRight);
            this.panel2.Controls.Add(this.btnMoveDown);
            this.panel2.Location = new System.Drawing.Point(523, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 35);
            this.panel2.TabIndex = 6;
            // 
            // btnRandomArrang
            // 
            this.btnRandomArrang.Location = new System.Drawing.Point(6, 6);
            this.btnRandomArrang.Name = "btnRandomArrang";
            this.btnRandomArrang.Size = new System.Drawing.Size(44, 23);
            this.btnRandomArrang.TabIndex = 7;
            this.btnRandomArrang.Text = "随机";
            this.btnRandomArrang.UseVisualStyleBackColor = true;
            this.btnRandomArrang.Click += new System.EventHandler(this.BtnRandomArrangClick);
            // 
            // btnMoveLeft
            // 
            this.btnMoveLeft.Location = new System.Drawing.Point(62, 6);
            this.btnMoveLeft.Name = "btnMoveLeft";
            this.btnMoveLeft.Size = new System.Drawing.Size(25, 23);
            this.btnMoveLeft.TabIndex = 2;
            this.btnMoveLeft.Text = "←";
            this.btnMoveLeft.UseVisualStyleBackColor = true;
            this.btnMoveLeft.Click += new System.EventHandler(this.ButtonMoveLeftClick);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Location = new System.Drawing.Point(92, 6);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(25, 23);
            this.btnMoveUp.TabIndex = 1;
            this.btnMoveUp.Text = "↑";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.ButtonMoveUpClick);
            // 
            // btnMoveRight
            // 
            this.btnMoveRight.Location = new System.Drawing.Point(152, 6);
            this.btnMoveRight.Name = "btnMoveRight";
            this.btnMoveRight.Size = new System.Drawing.Size(25, 23);
            this.btnMoveRight.TabIndex = 4;
            this.btnMoveRight.Text = "→";
            this.btnMoveRight.UseVisualStyleBackColor = true;
            this.btnMoveRight.Click += new System.EventHandler(this.ButtonMoveRightClick);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Location = new System.Drawing.Point(122, 6);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(25, 23);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.Text = "↓";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.ButtonMoveDownClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblShowMove);
            this.panel1.Location = new System.Drawing.Point(708, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(23, 35);
            this.panel1.TabIndex = 5;
            // 
            // lblShowMove
            // 
            this.lblShowMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowMove.Location = new System.Drawing.Point(2, 11);
            this.lblShowMove.Name = "lblShowMove";
            this.lblShowMove.Size = new System.Drawing.Size(19, 16);
            this.lblShowMove.TabIndex = 0;
            this.lblShowMove.Text = "<<";
            this.lblShowMove.Click += new System.EventHandler(this.LblShowMoveClick);
            // 
            // classRoom1
            // 
            this.classRoom1.AutoScroll = true;
            this.classRoom1.AutoScrollMinSize = new System.Drawing.Size(731, 603);
            this.classRoom1.BackColor = System.Drawing.Color.Gray;
            this.classRoom1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classRoom1.Location = new System.Drawing.Point(0, 0);
            this.classRoom1.Name = "classRoom1";
            this.classRoom1.Size = new System.Drawing.Size(731, 603);
            this.classRoom1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnPrintProject);
            this.groupBox3.Controls.Add(this.btnSaveProject);
            this.groupBox3.Controls.Add(this.btnReadNewProject);
            this.groupBox3.Location = new System.Drawing.Point(14, 535);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 56);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "方案";
            // 
            // btnPrintProject
            // 
            this.btnPrintProject.Location = new System.Drawing.Point(183, 20);
            this.btnPrintProject.Name = "btnPrintProject";
            this.btnPrintProject.Size = new System.Drawing.Size(76, 23);
            this.btnPrintProject.TabIndex = 2;
            this.btnPrintProject.Text = "打印方案";
            this.btnPrintProject.UseVisualStyleBackColor = true;
            this.btnPrintProject.Click += new System.EventHandler(this.BtnPrintProjectClick);
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.Location = new System.Drawing.Point(95, 20);
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(76, 23);
            this.btnSaveProject.TabIndex = 1;
            this.btnSaveProject.Text = "保存方案";
            this.btnSaveProject.UseVisualStyleBackColor = true;
            this.btnSaveProject.Click += new System.EventHandler(this.BtnSaveProjectClick);
            // 
            // btnReadNewProject
            // 
            this.btnReadNewProject.Location = new System.Drawing.Point(7, 20);
            this.btnReadNewProject.Name = "btnReadNewProject";
            this.btnReadNewProject.Size = new System.Drawing.Size(76, 23);
            this.btnReadNewProject.TabIndex = 0;
            this.btnReadNewProject.Text = "加载方案";
            this.btnReadNewProject.UseVisualStyleBackColor = true;
            this.btnReadNewProject.Click += new System.EventHandler(this.BtnReadNewProjectClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnStudentDel);
            this.groupBox2.Controls.Add(this.btnStudentAdd);
            this.groupBox2.Controls.Add(this.btnPaintStudent);
            this.groupBox2.Controls.Add(this.btnSaveStudentList);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(14, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 435);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "学生名单";
            // 
            // btnStudentDel
            // 
            this.btnStudentDel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStudentDel.Location = new System.Drawing.Point(73, 391);
            this.btnStudentDel.Name = "btnStudentDel";
            this.btnStudentDel.Size = new System.Drawing.Size(53, 23);
            this.btnStudentDel.TabIndex = 4;
            this.btnStudentDel.Text = "删除";
            this.btnStudentDel.UseVisualStyleBackColor = true;
            this.btnStudentDel.Click += new System.EventHandler(this.BtnStudentDelClick);
            // 
            // btnStudentAdd
            // 
            this.btnStudentAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStudentAdd.Location = new System.Drawing.Point(7, 391);
            this.btnStudentAdd.Name = "btnStudentAdd";
            this.btnStudentAdd.Size = new System.Drawing.Size(53, 23);
            this.btnStudentAdd.TabIndex = 3;
            this.btnStudentAdd.Text = "添加";
            this.btnStudentAdd.UseVisualStyleBackColor = true;
            this.btnStudentAdd.Click += new System.EventHandler(this.BtnStudentAddClick);
            // 
            // btnPaintStudent
            // 
            this.btnPaintStudent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaintStudent.Location = new System.Drawing.Point(205, 391);
            this.btnPaintStudent.Name = "btnPaintStudent";
            this.btnPaintStudent.Size = new System.Drawing.Size(53, 23);
            this.btnPaintStudent.TabIndex = 2;
            this.btnPaintStudent.Text = "进屋";
            this.btnPaintStudent.UseVisualStyleBackColor = true;
            this.btnPaintStudent.Click += new System.EventHandler(this.BtnPaintStudentClick);
            // 
            // btnSaveStudentList
            // 
            this.btnSaveStudentList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveStudentList.Location = new System.Drawing.Point(139, 391);
            this.btnSaveStudentList.Name = "btnSaveStudentList";
            this.btnSaveStudentList.Size = new System.Drawing.Size(53, 23);
            this.btnSaveStudentList.TabIndex = 1;
            this.btnSaveStudentList.Text = "保存";
            this.btnSaveStudentList.UseVisualStyleBackColor = true;
            this.btnSaveStudentList.Click += new System.EventHandler(this.BtnSaveStudentListClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColOrder,
            this.ColName,
            this.ColSex});
            this.dataGridView1.Location = new System.Drawing.Point(7, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(253, 364);
            this.dataGridView1.TabIndex = 0;
            // 
            // ColOrder
            // 
            this.ColOrder.HeaderText = "学号";
            this.ColOrder.Name = "ColOrder";
            this.ColOrder.Width = 40;
            // 
            // ColName
            // 
            this.ColName.HeaderText = "姓名";
            this.ColName.Name = "ColName";
            // 
            // ColSex
            // 
            this.ColSex.HeaderText = "性别";
            this.ColSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.ColSex.Name = "ColSex";
            this.ColSex.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDeskRow);
            this.groupBox1.Controls.Add(this.btnPaintDesk);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDeskCol);
            this.groupBox1.Location = new System.Drawing.Point(14, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(266, 76);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "课桌设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "横排";
            // 
            // txtDeskRow
            // 
            this.txtDeskRow.Location = new System.Drawing.Point(37, 35);
            this.txtDeskRow.Name = "txtDeskRow";
            this.txtDeskRow.Size = new System.Drawing.Size(30, 21);
            this.txtDeskRow.TabIndex = 1;
            this.txtDeskRow.Text = "6";
            // 
            // btnPaintDesk
            // 
            this.btnPaintDesk.Location = new System.Drawing.Point(205, 33);
            this.btnPaintDesk.Name = "btnPaintDesk";
            this.btnPaintDesk.Size = new System.Drawing.Size(55, 23);
            this.btnPaintDesk.TabIndex = 0;
            this.btnPaintDesk.Text = "摆放";
            this.btnPaintDesk.UseVisualStyleBackColor = true;
            this.btnPaintDesk.Click += new System.EventHandler(this.BtnPaintDeskClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "竖排分组";
            // 
            // txtDeskCol
            // 
            this.txtDeskCol.Location = new System.Drawing.Point(130, 35);
            this.txtDeskCol.Name = "txtDeskCol";
            this.txtDeskCol.Size = new System.Drawing.Size(63, 21);
            this.txtDeskCol.TabIndex = 2;
            this.txtDeskCol.Text = "2/2/2/2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 603);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeatArranger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btnRandomArrang;
        private System.Windows.Forms.Label lblShowMove;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveLeft;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveRight;
        private System.Windows.Forms.Button btnSaveProject;
        private System.Windows.Forms.Button btnPrintProject;
        private System.Windows.Forms.Button btnStudentAdd;
        private System.Windows.Forms.Button btnStudentDel;
        private System.Windows.Forms.Button btnPaintStudent;
        private System.Windows.Forms.Button btnSaveStudentList;
        private System.Windows.Forms.Button btnReadNewProject;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewComboBoxColumn ColSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColOrder;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ClassRoom classRoom1;
        private System.Windows.Forms.Button btnPaintDesk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeskCol;
        private System.Windows.Forms.TextBox txtDeskRow;
    }
}
