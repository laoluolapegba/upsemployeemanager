namespace UPS.EmployeeManager.UI.WinForms
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel3 = new Panel();
            btnRemove = new Button();
            btnAdd = new Button();
            panel4 = new Panel();
            pnlLeft = new Panel();
            dgMain = new DataGridView();
            pnlRight = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            label5 = new Label();
            cboGender = new ComboBox();
            chkStatus = new CheckBox();
            label4 = new Label();
            txtEmailAddress = new TextBox();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgMain).BeginInit();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(100, 65, 23);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1325, 71);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(5, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(104, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(250, 184, 10);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(1325, 31);
            panel2.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnSearch);
            panel3.Controls.Add(txtSearch);
            panel3.Controls.Add(btnRemove);
            panel3.Controls.Add(btnAdd);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 102);
            panel3.Name = "panel3";
            panel3.Size = new Size(1325, 59);
            panel3.TabIndex = 3;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(163, 6);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(129, 42);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remove Employee";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(23, 6);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(129, 42);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add Employee";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // panel4
            // 
            panel4.Location = new Point(3, 106);
            panel4.Name = "panel4";
            panel4.Size = new Size(705, 400);
            panel4.TabIndex = 4;
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(dgMain);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 161);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(903, 700);
            pnlLeft.TabIndex = 4;
            // 
            // dgMain
            // 
            dgMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMain.Dock = DockStyle.Fill;
            dgMain.Location = new Point(0, 0);
            dgMain.Name = "dgMain";
            dgMain.RowTemplate.Height = 25;
            dgMain.Size = new Size(903, 700);
            dgMain.TabIndex = 0;
            dgMain.CellClick += dgMain_CellClick;
            dgMain.SelectionChanged += dgMain_SelectionChanged;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(btnCancel);
            pnlRight.Controls.Add(btnSave);
            pnlRight.Controls.Add(label5);
            pnlRight.Controls.Add(cboGender);
            pnlRight.Controls.Add(chkStatus);
            pnlRight.Controls.Add(label4);
            pnlRight.Controls.Add(txtEmailAddress);
            pnlRight.Controls.Add(label3);
            pnlRight.Controls.Add(txtName);
            pnlRight.Controls.Add(label2);
            pnlRight.Controls.Add(txtId);
            pnlRight.Controls.Add(label1);
            pnlRight.Dock = DockStyle.Right;
            pnlRight.Location = new Point(912, 161);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(413, 700);
            pnlRight.TabIndex = 5;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(227, 192);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(129, 42);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(92, 192);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(129, 42);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 148);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 10;
            label5.Text = "Status:";
            // 
            // cboGender
            // 
            cboGender.FormattingEnabled = true;
            cboGender.Location = new Point(92, 115);
            cboGender.Name = "cboGender";
            cboGender.Size = new Size(121, 23);
            cboGender.TabIndex = 5;
            // 
            // chkStatus
            // 
            chkStatus.AutoSize = true;
            chkStatus.Location = new Point(92, 144);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(59, 19);
            chkStatus.TabIndex = 6;
            chkStatus.Text = "Active";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 123);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 6;
            label4.Text = "Gender:";
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.Location = new Point(92, 83);
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.Size = new Size(272, 23);
            txtEmailAddress.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 91);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 4;
            label3.Text = "Email:";
            // 
            // txtName
            // 
            txtName.Location = new Point(92, 56);
            txtName.Name = "txtName";
            txtName.Size = new Size(226, 23);
            txtName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 64);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Name:";
            // 
            // txtId
            // 
            txtId.Location = new Point(92, 23);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(63, 23);
            txtId.TabIndex = 1;
            txtId.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 31);
            label1.Name = "label1";
            label1.Size = new Size(20, 15);
            label1.TabIndex = 0;
            label1.Text = "Id:";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(994, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(139, 23);
            txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1139, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(129, 42);
            btnSearch.TabIndex = 11;
            btnSearch.Text = "Search Employee";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 861);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "frmMain";
            Text = "Employee Manager ";
            Load += frmMain_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgMain).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Button btnRemove;
        private Button btnAdd;
        private Panel pnlLeft;
        private Panel pnlRight;
        private Label label4;
        private TextBox txtEmailAddress;
        private Label label3;
        private TextBox txtName;
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private CheckBox chkStatus;
        private Label label5;
        private ComboBox cboGender;
        private Button btnCancel;
        private Button btnSave;
        private DataGridView dgMain;
        private PictureBox pictureBox1;
        private TextBox txtSearch;
        private Button btnSearch;
    }
}