namespace NewInterpolation
{
    partial class BaseValues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseValues));
            this.label2 = new System.Windows.Forms.Label();
            this.box2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.form2_buttonOk = new System.Windows.Forms.Button();
            this.box1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Частота:";
            // 
            // box2
            // 
            this.box2.Location = new System.Drawing.Point(139, 69);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(110, 20);
            this.box2.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Амплітуда:";
            // 
            // form2_buttonOk
            // 
            this.form2_buttonOk.Location = new System.Drawing.Point(110, 119);
            this.form2_buttonOk.Name = "form2_buttonOk";
            this.form2_buttonOk.Size = new System.Drawing.Size(75, 23);
            this.form2_buttonOk.TabIndex = 13;
            this.form2_buttonOk.Text = "ОК";
            this.form2_buttonOk.UseVisualStyleBackColor = true;
            this.form2_buttonOk.Click += new System.EventHandler(this.form2_buttonOk_Click);
            // 
            // box1
            // 
            this.box1.Location = new System.Drawing.Point(139, 30);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(110, 20);
            this.box1.TabIndex = 12;
            // 
            // BaseValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 154);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.form2_buttonOk);
            this.Controls.Add(this.box1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseValues";
            this.Text = "Введіть значення";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox box2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button form2_buttonOk;
        private System.Windows.Forms.TextBox box1;
    }
}