namespace QlyDiem
{
    partial class fDiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDiem));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbTimKiemTheoMa = new System.Windows.Forms.TextBox();
            this.btnTatCa = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.cbbHK = new System.Windows.Forms.ComboBox();
            this.tbDTX = new System.Windows.Forms.TextBox();
            this.tbDT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTenMon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMaMon = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbHoTen = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnSua = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnThem = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMaSV = new System.Windows.Forms.TextBox();
            this.dgvDiem = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.btnRefresh.SuspendLayout();
            this.btnXoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.btnSua.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.btnThem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(491, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 46);
            this.label1.TabIndex = 19;
            this.label1.Text = "Quản lý Điểm\r\n";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbTimKiemTheoMa);
            this.panel1.Controls.Add(this.btnTatCa);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Location = new System.Drawing.Point(54, 59);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1146, 71);
            this.panel1.TabIndex = 20;
            // 
            // tbTimKiemTheoMa
            // 
            this.tbTimKiemTheoMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimKiemTheoMa.ForeColor = System.Drawing.SystemColors.GrayText;
            this.tbTimKiemTheoMa.Location = new System.Drawing.Point(52, 21);
            this.tbTimKiemTheoMa.Margin = new System.Windows.Forms.Padding(4);
            this.tbTimKiemTheoMa.Name = "tbTimKiemTheoMa";
            this.tbTimKiemTheoMa.Size = new System.Drawing.Size(540, 26);
            this.tbTimKiemTheoMa.TabIndex = 19;
            this.tbTimKiemTheoMa.Text = "Nhập mã sinh viên";
            this.tbTimKiemTheoMa.Click += new System.EventHandler(this.tbTimKiemTheoMa_Click);
            // 
            // btnTatCa
            // 
            this.btnTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTatCa.ForeColor = System.Drawing.SystemColors.Info;
            this.btnTatCa.Location = new System.Drawing.Point(741, 13);
            this.btnTatCa.Margin = new System.Windows.Forms.Padding(4);
            this.btnTatCa.Name = "btnTatCa";
            this.btnTatCa.Size = new System.Drawing.Size(100, 43);
            this.btnTatCa.TabIndex = 6;
            this.btnTatCa.Text = "Tất Cả";
            this.btnTatCa.UseVisualStyleBackColor = false;
            this.btnTatCa.Click += new System.EventHandler(this.btnTatCa_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.DarkCyan;
            this.btnTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnTimKiem.Location = new System.Drawing.Point(633, 13);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 43);
            this.btnTimKiem.TabIndex = 5;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cbbHK);
            this.panel2.Controls.Add(this.tbDTX);
            this.panel2.Controls.Add(this.tbDT);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbTenMon);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbMaMon);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.tbHoTen);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.btnXoa);
            this.panel2.Controls.Add(this.btnSua);
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tbMaSV);
            this.panel2.Location = new System.Drawing.Point(54, 138);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1146, 176);
            this.panel2.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(498, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "Học kỳ:";
            // 
            // cbbHK
            // 
            this.cbbHK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbHK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbHK.FormattingEnabled = true;
            this.cbbHK.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cbbHK.Location = new System.Drawing.Point(585, 95);
            this.cbbHK.Name = "cbbHK";
            this.cbbHK.Size = new System.Drawing.Size(96, 28);
            this.cbbHK.TabIndex = 42;
            // 
            // tbDTX
            // 
            this.tbDTX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDTX.Location = new System.Drawing.Point(195, 132);
            this.tbDTX.Name = "tbDTX";
            this.tbDTX.Size = new System.Drawing.Size(264, 27);
            this.tbDTX.TabIndex = 41;
            // 
            // tbDT
            // 
            this.tbDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDT.Location = new System.Drawing.Point(195, 95);
            this.tbDT.Name = "tbDT";
            this.tbDT.Size = new System.Drawing.Size(264, 27);
            this.tbDT.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "Điểm thường xuyên:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "Điểm thi:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(498, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Tên môn:";
            // 
            // tbTenMon
            // 
            this.tbTenMon.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbTenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTenMon.Location = new System.Drawing.Point(586, 59);
            this.tbTenMon.Margin = new System.Windows.Forms.Padding(4);
            this.tbTenMon.Name = "tbTenMon";
            this.tbTenMon.ReadOnly = true;
            this.tbTenMon.Size = new System.Drawing.Size(263, 26);
            this.tbTenMon.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "Mã môn:";
            // 
            // tbMaMon
            // 
            this.tbMaMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaMon.Location = new System.Drawing.Point(195, 59);
            this.tbMaMon.Margin = new System.Windows.Forms.Padding(4);
            this.tbMaMon.Name = "tbMaMon";
            this.tbMaMon.Size = new System.Drawing.Size(264, 26);
            this.tbMaMon.TabIndex = 35;
            this.tbMaMon.TextChanged += new System.EventHandler(this.tbMaMon_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(498, 26);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 32;
            this.label9.Text = "Họ tên:";
            // 
            // tbHoTen
            // 
            this.tbHoTen.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHoTen.Location = new System.Drawing.Point(586, 23);
            this.tbHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.tbHoTen.Name = "tbHoTen";
            this.tbHoTen.ReadOnly = true;
            this.tbHoTen.Size = new System.Drawing.Size(264, 26);
            this.tbHoTen.TabIndex = 33;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(109)))), ((int)(((byte)(226)))));
            this.btnRefresh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnRefresh.Controls.Add(this.label20);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.ForeColor = System.Drawing.Color.MistyRose;
            this.btnRefresh.Location = new System.Drawing.Point(873, 26);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(114, 45);
            this.btnRefresh.TabIndex = 31;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(7, 10);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(86, 25);
            this.label20.TabIndex = 23;
            this.label20.Text = "Làm mới";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(33)))), ((int)(((byte)(48)))));
            this.btnXoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnXoa.Controls.Add(this.label19);
            this.btnXoa.Controls.Add(this.pictureBox3);
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.ForeColor = System.Drawing.Color.MistyRose;
            this.btnXoa.Location = new System.Drawing.Point(1009, 92);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(114, 45);
            this.btnXoa.TabIndex = 29;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(41, 10);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(48, 25);
            this.label19.TabIndex = 23;
            this.label19.Text = "Xóa";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(5, 5);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 36);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(158)))), ((int)(((byte)(0)))));
            this.btnSua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSua.Controls.Add(this.label18);
            this.btnSua.Controls.Add(this.pictureBox2);
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.ForeColor = System.Drawing.Color.MistyRose;
            this.btnSua.Location = new System.Drawing.Point(873, 92);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(114, 45);
            this.btnSua.TabIndex = 28;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(45, 10);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(48, 25);
            this.label18.TabIndex = 23;
            this.label18.Text = "Sửa";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(5, 5);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 36);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(71)))));
            this.btnThem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnThem.Controls.Add(this.label15);
            this.btnThem.Controls.Add(this.pictureBox1);
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.ForeColor = System.Drawing.Color.MistyRose;
            this.btnThem.Location = new System.Drawing.Point(1009, 25);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(114, 45);
            this.btnThem.TabIndex = 27;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(45, 10);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 25);
            this.label15.TabIndex = 23;
            this.label15.Text = "Thêm";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 36);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mã sinh viên:";
            // 
            // tbMaSV
            // 
            this.tbMaSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaSV.Location = new System.Drawing.Point(195, 23);
            this.tbMaSV.Margin = new System.Windows.Forms.Padding(4);
            this.tbMaSV.Name = "tbMaSV";
            this.tbMaSV.Size = new System.Drawing.Size(264, 26);
            this.tbMaSV.TabIndex = 3;
            this.tbMaSV.TextChanged += new System.EventHandler(this.tbMaSV_TextChanged);
            // 
            // dgvDiem
            // 
            this.dgvDiem.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiem.Location = new System.Drawing.Point(54, 338);
            this.dgvDiem.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDiem.Name = "dgvDiem";
            this.dgvDiem.RowHeadersWidth = 51;
            this.dgvDiem.Size = new System.Drawing.Size(1146, 395);
            this.dgvDiem.TabIndex = 22;
            this.dgvDiem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDiem_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 26);
            this.label4.TabIndex = 23;
            this.label4.Text = "Tìm kiếm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(73, 120);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 26);
            this.label10.TabIndex = 24;
            this.label10.Text = "Thông tin chi tiết";
            // 
            // fDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 746);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDiem);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fDiem";
            this.Text = "fDiem";
            this.Activated += new System.EventHandler(this.fDiem_Activated);
            this.Load += new System.EventHandler(this.fDiem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.btnRefresh.ResumeLayout(false);
            this.btnRefresh.PerformLayout();
            this.btnXoa.ResumeLayout(false);
            this.btnXoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.btnSua.ResumeLayout(false);
            this.btnSua.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.btnThem.ResumeLayout(false);
            this.btnThem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbTimKiemTheoMa;
        private System.Windows.Forms.Button btnTatCa;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel btnRefresh;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel btnXoa;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel btnSua;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel btnThem;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMaSV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMaMon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTenMon;
        private System.Windows.Forms.DataGridView dgvDiem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbbHK;
        private System.Windows.Forms.TextBox tbDTX;
        private System.Windows.Forms.TextBox tbDT;
        private System.Windows.Forms.Label label10;
    }
}