namespace betStat
{
    partial class result
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
            this.components = new System.ComponentModel.Container();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.betCalDataSet = new betStat.betCalDataSet();
            this.fixtureOddResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fixtureOddResultTableAdapter = new betStat.betCalDataSetTableAdapters.fixtureOddResultTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fixtureIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fixtureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultBDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.betCalDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixtureOddResultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(201, 59);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(362, 23);
            this.comboBox2.TabIndex = 13;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.selectChangeDataFill);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(31, 59);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(152, 22);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.datePick);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(659, 55);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(45, 22);
            this.textBox4.TabIndex = 36;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(629, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = " Vs";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(580, 57);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(45, 22);
            this.textBox5.TabIndex = 34;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(616, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "Result";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button2.ForeColor = System.Drawing.Color.Honeydew;
            this.button2.Location = new System.Drawing.Point(725, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 53);
            this.button2.TabIndex = 32;
            this.button2.Text = "SAVE";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.button1.ForeColor = System.Drawing.Color.Honeydew;
            this.button1.Location = new System.Drawing.Point(835, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 53);
            this.button1.TabIndex = 37;
            this.button1.Text = "DELETE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // betCalDataSet
            // 
            this.betCalDataSet.DataSetName = "betCalDataSet";
            this.betCalDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fixtureOddResultBindingSource
            // 
            this.fixtureOddResultBindingSource.DataMember = "fixtureOddResult";
            this.fixtureOddResultBindingSource.DataSource = this.betCalDataSet;
            // 
            // fixtureOddResultTableAdapter
            // 
            this.fixtureOddResultTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fixtureIdDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.fixtureDataGridViewTextBoxColumn,
            this.resultADataGridViewTextBoxColumn,
            this.resultBDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fixtureOddResultBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(31, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(642, 438);
            this.dataGridView1.TabIndex = 38;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.cellClick);
            // 
            // fixtureIdDataGridViewTextBoxColumn
            // 
            this.fixtureIdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fixtureIdDataGridViewTextBoxColumn.DataPropertyName = "fixtureId";
            this.fixtureIdDataGridViewTextBoxColumn.HeaderText = "No";
            this.fixtureIdDataGridViewTextBoxColumn.Name = "fixtureIdDataGridViewTextBoxColumn";
            this.fixtureIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.fixtureIdDataGridViewTextBoxColumn.Width = 49;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 59;
            // 
            // fixtureDataGridViewTextBoxColumn
            // 
            this.fixtureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fixtureDataGridViewTextBoxColumn.DataPropertyName = "fixture";
            this.fixtureDataGridViewTextBoxColumn.HeaderText = "fixture";
            this.fixtureDataGridViewTextBoxColumn.Name = "fixtureDataGridViewTextBoxColumn";
            this.fixtureDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // resultADataGridViewTextBoxColumn
            // 
            this.resultADataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.resultADataGridViewTextBoxColumn.DataPropertyName = "resultA";
            this.resultADataGridViewTextBoxColumn.HeaderText = "resultA";
            this.resultADataGridViewTextBoxColumn.Name = "resultADataGridViewTextBoxColumn";
            this.resultADataGridViewTextBoxColumn.ReadOnly = true;
            this.resultADataGridViewTextBoxColumn.Width = 73;
            // 
            // resultBDataGridViewTextBoxColumn
            // 
            this.resultBDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.resultBDataGridViewTextBoxColumn.DataPropertyName = "resultB";
            this.resultBDataGridViewTextBoxColumn.HeaderText = "resultB";
            this.resultBDataGridViewTextBoxColumn.Name = "resultBDataGridViewTextBoxColumn";
            this.resultBDataGridViewTextBoxColumn.ReadOnly = true;
            this.resultBDataGridViewTextBoxColumn.Width = 71;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.MistyRose;
            this.button3.Location = new System.Drawing.Point(31, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 32);
            this.button3.TabIndex = 39;
            this.button3.Text = "BACK";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(962, 567);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.dateTimePicker1);
            this.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "result";
            this.Text = "result";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClose);
            this.Load += new System.EventHandler(this.result_Load);
            ((System.ComponentModel.ISupportInitialize)(this.betCalDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fixtureOddResultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private betCalDataSet betCalDataSet;
        private System.Windows.Forms.BindingSource fixtureOddResultBindingSource;
        private betCalDataSetTableAdapters.fixtureOddResultTableAdapter fixtureOddResultTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fixtureIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fixtureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultBDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button3;
    }
}