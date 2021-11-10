
namespace StudyC1
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.label2 = new System.Windows.Forms.Label();
            this.c1TextBox1 = new C1.Win.C1Input.C1TextBox();
            this.c1Button2 = new C1.Win.C1Input.C1Button();
            this.c1Button1 = new C1.Win.C1Input.C1Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.c1TextBox2 = new C1.Win.C1Input.C1TextBox();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(59, 491);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "件数    ○○／○○";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c1TextBox1
            // 
            this.c1TextBox1.AutoSize = false;
            this.c1TextBox1.Location = new System.Drawing.Point(62, 60);
            this.c1TextBox1.Name = "c1TextBox1";
            this.c1TextBox1.Size = new System.Drawing.Size(130, 25);
            this.c1TextBox1.TabIndex = 16;
            this.c1TextBox1.Tag = null;
            this.c1TextBox1.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            // 
            // c1Button2
            // 
            this.c1Button2.Location = new System.Drawing.Point(427, 542);
            this.c1Button2.Name = "c1Button2";
            this.c1Button2.Size = new System.Drawing.Size(106, 41);
            this.c1Button2.TabIndex = 15;
            this.c1Button2.Text = "キャンセル";
            this.c1Button2.UseVisualStyleBackColor = false;
            this.c1Button2.Click += new System.EventHandler(this.c1Button2_Click);
            // 
            // c1Button1
            // 
            this.c1Button1.Location = new System.Drawing.Point(279, 542);
            this.c1Button1.Name = "c1Button1";
            this.c1Button1.Size = new System.Drawing.Size(106, 41);
            this.c1Button1.TabIndex = 14;
            this.c1Button1.Text = "OK";
            this.c1Button1.UseVisualStyleBackColor = false;
            this.c1Button1.Click += new System.EventHandler(this.c1Button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(62, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "区分";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(192, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 25);
            this.panel1.TabIndex = 12;
            // 
            // radioButton3
            // 
            this.radioButton3.BackColor = System.Drawing.SystemColors.Window;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(173, -1);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 25);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "両方";
            this.radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            this.radioButton2.BackColor = System.Drawing.SystemColors.Window;
            this.radioButton2.Location = new System.Drawing.Point(82, -1);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(85, 25);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "ホルスタイン";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.BackColor = System.Drawing.SystemColors.Window;
            this.radioButton1.Location = new System.Drawing.Point(15, 0);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 25);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "黒毛";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // c1TextBox2
            // 
            this.c1TextBox2.AutoSize = false;
            this.c1TextBox2.Location = new System.Drawing.Point(192, 60);
            this.c1TextBox2.Name = "c1TextBox2";
            this.c1TextBox2.ShowFocusRectangle = true;
            this.c1TextBox2.Size = new System.Drawing.Size(341, 25);
            this.c1TextBox2.TabIndex = 11;
            this.c1TextBox2.Tag = null;
            this.c1TextBox2.VerticalAlign = C1.Win.C1Input.VerticalAlignEnum.Middle;
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.c1FlexGrid1.AllowEditing = false;
            this.c1FlexGrid1.AllowNodeCellCheck = false;
            this.c1FlexGrid1.AreRowDetailsFrozen = false;
            this.c1FlexGrid1.AutoGenerateColumns = false;
            this.c1FlexGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle;
            this.c1FlexGrid1.CausesValidation = false;
            this.c1FlexGrid1.ColumnInfo = resources.GetString("c1FlexGrid1.ColumnInfo");
            this.c1FlexGrid1.Location = new System.Drawing.Point(62, 85);
            this.c1FlexGrid1.Margin = new System.Windows.Forms.Padding(2);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.Count = 16;
            this.c1FlexGrid1.Rows.MinSize = 25;
            this.c1FlexGrid1.Size = new System.Drawing.Size(471, 404);
            this.c1FlexGrid1.TabIndex = 10;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 612);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c1TextBox1);
            this.Controls.Add(this.c1Button2);
            this.Controls.Add(this.c1Button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.c1TextBox2);
            this.Controls.Add(this.c1FlexGrid1);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "種牛登録";
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Button1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1TextBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private C1.Win.C1Input.C1TextBox c1TextBox1;
        private C1.Win.C1Input.C1Button c1Button2;
        private C1.Win.C1Input.C1Button c1Button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private C1.Win.C1Input.C1TextBox c1TextBox2;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
    }
}