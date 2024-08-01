namespace StudentsApp
{
    partial class StudentsForm
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
            Save = new Button();
            CreateStudentName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            CreateStudentAge = new TextBox();
            label3 = new Label();
            CreateStudentMobile = new TextBox();
            Clear = new Button();
            Result = new Label();
            Error = new Label();
            ReadAllStudents = new Button();
            tabControl1 = new TabControl();
            CreatePage = new TabPage();
            UpdatePage = new TabPage();
            UpdateStudentAge = new TextBox();
            label4 = new Label();
            label5 = new Label();
            UpdateReadAllStudents = new Button();
            Update = new Button();
            UpdateStudentName = new TextBox();
            label6 = new Label();
            UpdateClear = new Button();
            label7 = new Label();
            label8 = new Label();
            UpdateStudentMobile = new TextBox();
            DeletePage = new TabPage();
            DeleteStudentAge = new TextBox();
            label9 = new Label();
            label10 = new Label();
            DeleteReadAllStudents = new Button();
            Delete = new Button();
            DeleteStudentName = new TextBox();
            label11 = new Label();
            DeleteClear = new Button();
            label12 = new Label();
            label13 = new Label();
            DeleteStudentMobile = new TextBox();
            GetIdPage = new TabPage();
            GetStudentName = new Label();
            GetStudentMobile = new Label();
            label22 = new Label();
            GetStudentAge = new Label();
            label20 = new Label();
            label18 = new Label();
            label17 = new Label();
            label14 = new Label();
            label15 = new Label();
            button7 = new Button();
            GetID = new Button();
            StudentID = new TextBox();
            label16 = new Label();
            GetClear = new Button();
            tabControl1.SuspendLayout();
            CreatePage.SuspendLayout();
            UpdatePage.SuspendLayout();
            DeletePage.SuspendLayout();
            GetIdPage.SuspendLayout();
            SuspendLayout();
            // 
            // Save
            // 
            Save.Location = new Point(85, 144);
            Save.Margin = new Padding(3, 2, 3, 2);
            Save.Name = "Save";
            Save.Size = new Size(82, 22);
            Save.TabIndex = 0;
            Save.Text = "Save";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // CreateStudentName
            // 
            CreateStudentName.Location = new Point(85, 23);
            CreateStudentName.Margin = new Padding(3, 2, 3, 2);
            CreateStudentName.Name = "CreateStudentName";
            CreateStudentName.Size = new Size(220, 23);
            CreateStudentName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 26);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 2;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 64);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 4;
            label2.Text = "Age";
            // 
            // CreateStudentAge
            // 
            CreateStudentAge.Location = new Point(85, 62);
            CreateStudentAge.Margin = new Padding(3, 2, 3, 2);
            CreateStudentAge.Name = "CreateStudentAge";
            CreateStudentAge.Size = new Size(220, 23);
            CreateStudentAge.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 100);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 6;
            label3.Text = "Mobile";
            // 
            // CreateStudentMobile
            // 
            CreateStudentMobile.Location = new Point(85, 98);
            CreateStudentMobile.Margin = new Padding(3, 2, 3, 2);
            CreateStudentMobile.Name = "CreateStudentMobile";
            CreateStudentMobile.Size = new Size(220, 23);
            CreateStudentMobile.TabIndex = 5;
            // 
            // Clear
            // 
            Clear.Location = new Point(222, 144);
            Clear.Margin = new Padding(3, 2, 3, 2);
            Clear.Name = "Clear";
            Clear.Size = new Size(82, 22);
            Clear.TabIndex = 7;
            Clear.Text = "Clear";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // Result
            // 
            Result.AutoSize = true;
            Result.ForeColor = Color.FromArgb(28, 194, 14);
            Result.Location = new Point(41, 283);
            Result.Name = "Result";
            Result.Size = new Size(0, 15);
            Result.TabIndex = 8;
            // 
            // Error
            // 
            Error.AutoSize = true;
            Error.ForeColor = Color.FromArgb(236, 49, 49);
            Error.Location = new Point(238, 283);
            Error.Name = "Error";
            Error.Size = new Size(0, 15);
            Error.TabIndex = 9;
            // 
            // ReadAllStudents
            // 
            ReadAllStudents.Location = new Point(84, 184);
            ReadAllStudents.Margin = new Padding(3, 2, 3, 2);
            ReadAllStudents.Name = "ReadAllStudents";
            ReadAllStudents.Size = new Size(220, 22);
            ReadAllStudents.TabIndex = 10;
            ReadAllStudents.Text = "Read All Students";
            ReadAllStudents.UseVisualStyleBackColor = true;
            ReadAllStudents.Click += ReadAllStudents_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(CreatePage);
            tabControl1.Controls.Add(UpdatePage);
            tabControl1.Controls.Add(DeletePage);
            tabControl1.Controls.Add(GetIdPage);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(382, 259);
            tabControl1.TabIndex = 11;
            // 
            // CreatePage
            // 
            CreatePage.BackColor = Color.FromArgb(233, 232, 175);
            CreatePage.Controls.Add(CreateStudentAge);
            CreatePage.Controls.Add(ReadAllStudents);
            CreatePage.Controls.Add(Save);
            CreatePage.Controls.Add(CreateStudentName);
            CreatePage.Controls.Add(label1);
            CreatePage.Controls.Add(Clear);
            CreatePage.Controls.Add(label2);
            CreatePage.Controls.Add(label3);
            CreatePage.Controls.Add(CreateStudentMobile);
            CreatePage.Location = new Point(4, 24);
            CreatePage.Name = "CreatePage";
            CreatePage.Padding = new Padding(3);
            CreatePage.Size = new Size(374, 231);
            CreatePage.TabIndex = 0;
            CreatePage.Text = "Create";
            // 
            // UpdatePage
            // 
            UpdatePage.BackColor = Color.FromArgb(233, 232, 175);
            UpdatePage.Controls.Add(UpdateStudentAge);
            UpdatePage.Controls.Add(label4);
            UpdatePage.Controls.Add(label5);
            UpdatePage.Controls.Add(UpdateReadAllStudents);
            UpdatePage.Controls.Add(Update);
            UpdatePage.Controls.Add(UpdateStudentName);
            UpdatePage.Controls.Add(label6);
            UpdatePage.Controls.Add(UpdateClear);
            UpdatePage.Controls.Add(label7);
            UpdatePage.Controls.Add(label8);
            UpdatePage.Controls.Add(UpdateStudentMobile);
            UpdatePage.Location = new Point(4, 24);
            UpdatePage.Name = "UpdatePage";
            UpdatePage.Padding = new Padding(3);
            UpdatePage.Size = new Size(374, 231);
            UpdatePage.TabIndex = 1;
            UpdatePage.Text = "Update";
            // 
            // UpdateStudentAge
            // 
            UpdateStudentAge.Location = new Point(88, 61);
            UpdateStudentAge.Margin = new Padding(3, 2, 3, 2);
            UpdateStudentAge.Name = "UpdateStudentAge";
            UpdateStudentAge.Size = new Size(220, 23);
            UpdateStudentAge.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 235);
            label4.Name = "label4";
            label4.Size = new Size(0, 15);
            label4.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 258);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 19;
            // 
            // UpdateReadAllStudents
            // 
            UpdateReadAllStudents.Location = new Point(87, 183);
            UpdateReadAllStudents.Margin = new Padding(3, 2, 3, 2);
            UpdateReadAllStudents.Name = "UpdateReadAllStudents";
            UpdateReadAllStudents.Size = new Size(220, 22);
            UpdateReadAllStudents.TabIndex = 21;
            UpdateReadAllStudents.Text = "Read All Students";
            UpdateReadAllStudents.UseVisualStyleBackColor = true;
            UpdateReadAllStudents.Click += UpdateReadAllStudents_Click;
            // 
            // Update
            // 
            Update.Location = new Point(88, 143);
            Update.Margin = new Padding(3, 2, 3, 2);
            Update.Name = "Update";
            Update.Size = new Size(82, 22);
            Update.TabIndex = 11;
            Update.Text = "Update";
            Update.UseVisualStyleBackColor = true;
            Update.Click += Update_Click;
            // 
            // UpdateStudentName
            // 
            UpdateStudentName.Location = new Point(88, 22);
            UpdateStudentName.Margin = new Padding(3, 2, 3, 2);
            UpdateStudentName.Name = "UpdateStudentName";
            UpdateStudentName.Size = new Size(220, 23);
            UpdateStudentName.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(28, 25);
            label6.Name = "label6";
            label6.Size = new Size(39, 15);
            label6.TabIndex = 13;
            label6.Text = "Name";
            // 
            // UpdateClear
            // 
            UpdateClear.Location = new Point(225, 143);
            UpdateClear.Margin = new Padding(3, 2, 3, 2);
            UpdateClear.Name = "UpdateClear";
            UpdateClear.Size = new Size(82, 22);
            UpdateClear.TabIndex = 18;
            UpdateClear.Text = "Clear";
            UpdateClear.UseVisualStyleBackColor = true;
            UpdateClear.Click += UpdateClear_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 63);
            label7.Name = "label7";
            label7.Size = new Size(28, 15);
            label7.TabIndex = 15;
            label7.Text = "Age";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(28, 99);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 17;
            label8.Text = "Mobile";
            // 
            // UpdateStudentMobile
            // 
            UpdateStudentMobile.Location = new Point(88, 97);
            UpdateStudentMobile.Margin = new Padding(3, 2, 3, 2);
            UpdateStudentMobile.Name = "UpdateStudentMobile";
            UpdateStudentMobile.Size = new Size(220, 23);
            UpdateStudentMobile.TabIndex = 16;
            // 
            // DeletePage
            // 
            DeletePage.BackColor = Color.FromArgb(233, 232, 175);
            DeletePage.Controls.Add(DeleteStudentAge);
            DeletePage.Controls.Add(label9);
            DeletePage.Controls.Add(label10);
            DeletePage.Controls.Add(DeleteReadAllStudents);
            DeletePage.Controls.Add(Delete);
            DeletePage.Controls.Add(DeleteStudentName);
            DeletePage.Controls.Add(label11);
            DeletePage.Controls.Add(DeleteClear);
            DeletePage.Controls.Add(label12);
            DeletePage.Controls.Add(label13);
            DeletePage.Controls.Add(DeleteStudentMobile);
            DeletePage.Location = new Point(4, 24);
            DeletePage.Name = "DeletePage";
            DeletePage.Size = new Size(374, 231);
            DeletePage.TabIndex = 2;
            DeletePage.Text = "Delete";
            // 
            // DeleteStudentAge
            // 
            DeleteStudentAge.Location = new Point(92, 63);
            DeleteStudentAge.Margin = new Padding(3, 2, 3, 2);
            DeleteStudentAge.Name = "DeleteStudentAge";
            DeleteStudentAge.Size = new Size(220, 23);
            DeleteStudentAge.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(32, 241);
            label9.Name = "label9";
            label9.Size = new Size(0, 15);
            label9.TabIndex = 20;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(32, 264);
            label10.Name = "label10";
            label10.Size = new Size(0, 15);
            label10.TabIndex = 19;
            // 
            // DeleteReadAllStudents
            // 
            DeleteReadAllStudents.Location = new Point(91, 185);
            DeleteReadAllStudents.Margin = new Padding(3, 2, 3, 2);
            DeleteReadAllStudents.Name = "DeleteReadAllStudents";
            DeleteReadAllStudents.Size = new Size(220, 22);
            DeleteReadAllStudents.TabIndex = 21;
            DeleteReadAllStudents.Text = "Read All Students";
            DeleteReadAllStudents.UseVisualStyleBackColor = true;
            DeleteReadAllStudents.Click += DeleteReadAllStudents_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(92, 145);
            Delete.Margin = new Padding(3, 2, 3, 2);
            Delete.Name = "Delete";
            Delete.Size = new Size(82, 22);
            Delete.TabIndex = 11;
            Delete.Text = "Delete";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // DeleteStudentName
            // 
            DeleteStudentName.Location = new Point(92, 24);
            DeleteStudentName.Margin = new Padding(3, 2, 3, 2);
            DeleteStudentName.Name = "DeleteStudentName";
            DeleteStudentName.Size = new Size(220, 23);
            DeleteStudentName.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(32, 27);
            label11.Name = "label11";
            label11.Size = new Size(39, 15);
            label11.TabIndex = 13;
            label11.Text = "Name";
            // 
            // DeleteClear
            // 
            DeleteClear.Location = new Point(229, 145);
            DeleteClear.Margin = new Padding(3, 2, 3, 2);
            DeleteClear.Name = "DeleteClear";
            DeleteClear.Size = new Size(82, 22);
            DeleteClear.TabIndex = 18;
            DeleteClear.Text = "Clear";
            DeleteClear.UseVisualStyleBackColor = true;
            DeleteClear.Click += DeleteClear_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(32, 65);
            label12.Name = "label12";
            label12.Size = new Size(28, 15);
            label12.TabIndex = 15;
            label12.Text = "Age";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(32, 101);
            label13.Name = "label13";
            label13.Size = new Size(44, 15);
            label13.TabIndex = 17;
            label13.Text = "Mobile";
            // 
            // DeleteStudentMobile
            // 
            DeleteStudentMobile.Location = new Point(92, 99);
            DeleteStudentMobile.Margin = new Padding(3, 2, 3, 2);
            DeleteStudentMobile.Name = "DeleteStudentMobile";
            DeleteStudentMobile.Size = new Size(220, 23);
            DeleteStudentMobile.TabIndex = 16;
            // 
            // GetIdPage
            // 
            GetIdPage.BackColor = Color.FromArgb(233, 232, 175);
            GetIdPage.Controls.Add(GetStudentName);
            GetIdPage.Controls.Add(GetStudentMobile);
            GetIdPage.Controls.Add(label22);
            GetIdPage.Controls.Add(GetStudentAge);
            GetIdPage.Controls.Add(label20);
            GetIdPage.Controls.Add(label18);
            GetIdPage.Controls.Add(label17);
            GetIdPage.Controls.Add(label14);
            GetIdPage.Controls.Add(label15);
            GetIdPage.Controls.Add(button7);
            GetIdPage.Controls.Add(GetID);
            GetIdPage.Controls.Add(StudentID);
            GetIdPage.Controls.Add(label16);
            GetIdPage.Controls.Add(GetClear);
            GetIdPage.Location = new Point(4, 24);
            GetIdPage.Name = "GetIdPage";
            GetIdPage.Size = new Size(374, 231);
            GetIdPage.TabIndex = 3;
            GetIdPage.Text = "Get Id";
            // 
            // GetStudentName
            // 
            GetStudentName.AutoSize = true;
            GetStudentName.Location = new Point(144, 148);
            GetStudentName.Name = "GetStudentName";
            GetStudentName.Size = new Size(0, 15);
            GetStudentName.TabIndex = 28;
            // 
            // GetStudentMobile
            // 
            GetStudentMobile.AutoSize = true;
            GetStudentMobile.Location = new Point(144, 203);
            GetStudentMobile.Name = "GetStudentMobile";
            GetStudentMobile.Size = new Size(0, 15);
            GetStudentMobile.TabIndex = 27;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(82, 203);
            label22.Name = "label22";
            label22.Size = new Size(50, 15);
            label22.TabIndex = 26;
            label22.Text = "Mobile :";
            // 
            // GetStudentAge
            // 
            GetStudentAge.AutoSize = true;
            GetStudentAge.Location = new Point(144, 177);
            GetStudentAge.Name = "GetStudentAge";
            GetStudentAge.Size = new Size(0, 15);
            GetStudentAge.TabIndex = 25;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(83, 177);
            label20.Name = "label20";
            label20.Size = new Size(34, 15);
            label20.TabIndex = 24;
            label20.Text = "Age :";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(83, 148);
            label18.Name = "label18";
            label18.Size = new Size(45, 15);
            label18.TabIndex = 0;
            label18.Text = "Name :";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(29, 128);
            label17.Name = "label17";
            label17.Size = new Size(39, 15);
            label17.TabIndex = 22;
            label17.Text = "Result";
            label17.Click += label17_Click_1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(47, 235);
            label14.Name = "label14";
            label14.Size = new Size(0, 15);
            label14.TabIndex = 20;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(47, 258);
            label15.Name = "label15";
            label15.Size = new Size(0, 15);
            label15.TabIndex = 19;
            // 
            // button7
            // 
            button7.Location = new Point(83, 86);
            button7.Margin = new Padding(3, 2, 3, 2);
            button7.Name = "button7";
            button7.Size = new Size(220, 22);
            button7.TabIndex = 21;
            button7.Text = "Read All Students";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // GetID
            // 
            GetID.Location = new Point(82, 60);
            GetID.Margin = new Padding(3, 2, 3, 2);
            GetID.Name = "GetID";
            GetID.Size = new Size(82, 22);
            GetID.TabIndex = 11;
            GetID.Text = "Sent";
            GetID.UseVisualStyleBackColor = true;
            GetID.Click += GetID_Click;
            // 
            // StudentID
            // 
            StudentID.Location = new Point(83, 18);
            StudentID.Margin = new Padding(3, 2, 3, 2);
            StudentID.Name = "StudentID";
            StudentID.Size = new Size(220, 23);
            StudentID.TabIndex = 12;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(29, 21);
            label16.Name = "label16";
            label16.Size = new Size(18, 15);
            label16.TabIndex = 13;
            label16.Text = "ID";
            label16.Click += label16_Click;
            // 
            // GetClear
            // 
            GetClear.Location = new Point(220, 60);
            GetClear.Margin = new Padding(3, 2, 3, 2);
            GetClear.Name = "GetClear";
            GetClear.Size = new Size(82, 22);
            GetClear.TabIndex = 18;
            GetClear.Text = "Clear";
            GetClear.UseVisualStyleBackColor = true;
            GetClear.Click += button9_Click;
            // 
            // StudentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(233, 232, 175);
            ClientSize = new Size(406, 310);
            Controls.Add(tabControl1);
            Controls.Add(Error);
            Controls.Add(Result);
            Margin = new Padding(3, 2, 3, 2);
            Name = "StudentsForm";
            Text = "Students";
            Load += StudentsForm_Load;
            tabControl1.ResumeLayout(false);
            CreatePage.ResumeLayout(false);
            CreatePage.PerformLayout();
            UpdatePage.ResumeLayout(false);
            UpdatePage.PerformLayout();
            DeletePage.ResumeLayout(false);
            DeletePage.PerformLayout();
            GetIdPage.ResumeLayout(false);
            GetIdPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Save;
        private TextBox CreateStudentName;
        private Label label1;
        private Label label2;
        private TextBox CreateStudentAge;
        private Label label3;
        private TextBox CreateStudentMobile;
        private Button Clear;
        private Label Result;
        private Label Error;
        private Button ReadAllStudents;
        private TabControl tabControl1;
        private TabPage CreatePage;
        private TabPage UpdatePage;
        private TabPage DeletePage;
        private TextBox UpdateStudentAge;
        private Label label4;
        private Label label5;
        private Button UpdateReadAllStudents;
        private Button Update;
        private TextBox UpdateStudentName;
        private Label label6;
        private Button UpdateClear;
        private Label label7;
        private Label label8;
        private TextBox UpdateStudentMobile;
        private TextBox DeleteStudentAge;
        private Label label9;
        private Label label10;
        private Button DeleteReadAllStudents;
        private Button Delete;
        private TextBox DeleteStudentName;
        private Label label11;
        private Button DeleteClear;
        private Label label12;
        private Label label13;
        private TextBox DeleteStudentMobile;
        private TabPage GetIdPage;
        private Label label14;
        private Label label15;
        private Button button7;
        private Button GetID;
        private TextBox StudentID;
        private Label label16;
        private Button GetClear;
        private Label label17;
        private Label GetStudentMobile;
        private Label label22;
        private Label GetStudentAge;
        private Label label20;
        private Label label18;
        private Label GetStudentName;
    }
}
