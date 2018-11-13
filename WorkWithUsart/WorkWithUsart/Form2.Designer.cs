namespace WorkWithUsart
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxw1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxw2 = new System.Windows.Forms.TextBox();
            this.textBoxb2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxb1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Set work period";
            // 
            // textBoxw1
            // 
            this.textBoxw1.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxw1.Location = new System.Drawing.Point(45, 65);
            this.textBoxw1.Name = "textBoxw1";
            this.textBoxw1.Size = new System.Drawing.Size(38, 26);
            this.textBoxw1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(89, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = ":";
            // 
            // textBoxw2
            // 
            this.textBoxw2.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxw2.Location = new System.Drawing.Point(115, 65);
            this.textBoxw2.Name = "textBoxw2";
            this.textBoxw2.Size = new System.Drawing.Size(38, 26);
            this.textBoxw2.TabIndex = 3;
            // 
            // textBoxb2
            // 
            this.textBoxb2.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxb2.Location = new System.Drawing.Point(115, 166);
            this.textBoxb2.Name = "textBoxb2";
            this.textBoxb2.Size = new System.Drawing.Size(38, 26);
            this.textBoxb2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = ":";
            // 
            // textBoxb1
            // 
            this.textBoxb1.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxb1.Location = new System.Drawing.Point(45, 166);
            this.textBoxb1.Name = "textBoxb1";
            this.textBoxb1.Size = new System.Drawing.Size(38, 26);
            this.textBoxb1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Set blink period";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightBlue;
            this.button1.Location = new System.Drawing.Point(41, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 302);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxb2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxb1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxw2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxw1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(221, 341);
            this.MinimumSize = new System.Drawing.Size(221, 341);
            this.Name = "Form2";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxw1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxw2;
        private System.Windows.Forms.TextBox textBoxb2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxb1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}