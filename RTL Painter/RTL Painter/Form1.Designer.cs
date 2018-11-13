namespace RTL_Painter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolLine = new System.Windows.Forms.ToolStripButton();
            this.toolCircle = new System.Windows.Forms.ToolStripButton();
            this.toolTriangle = new System.Windows.Forms.ToolStripButton();
            this.toolStar = new System.Windows.Forms.ToolStripButton();
            this.toolPenColor = new System.Windows.Forms.ToolStripButton();
            this.toolBackgroundColor = new System.Windows.Forms.ToolStripButton();
            this.toolStepBack = new System.Windows.Forms.ToolStripButton();
            this.toolClear = new System.Windows.Forms.ToolStripButton();
            this.toolOpen = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.textBoxLineWidth = new System.Windows.Forms.TextBox();
            this.labelLineWidth = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLine,
            this.toolCircle,
            this.toolTriangle,
            this.toolStar,
            this.toolPenColor,
            this.toolBackgroundColor,
            this.toolStepBack,
            this.toolClear,
            this.toolOpen,
            this.toolSave,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(937, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolLine
            // 
            this.toolLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolLine.Image = ((System.Drawing.Image)(resources.GetObject("toolLine.Image")));
            this.toolLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolLine.Name = "toolLine";
            this.toolLine.Size = new System.Drawing.Size(23, 22);
            this.toolLine.Text = "toolStripButton1";
            this.toolLine.Click += new System.EventHandler(this.toolLine_Click);
            // 
            // toolCircle
            // 
            this.toolCircle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolCircle.Image = ((System.Drawing.Image)(resources.GetObject("toolCircle.Image")));
            this.toolCircle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCircle.Name = "toolCircle";
            this.toolCircle.Size = new System.Drawing.Size(23, 22);
            this.toolCircle.Text = "toolStripButton2";
            this.toolCircle.Click += new System.EventHandler(this.toolCircle_Click);
            // 
            // toolTriangle
            // 
            this.toolTriangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolTriangle.Image = ((System.Drawing.Image)(resources.GetObject("toolTriangle.Image")));
            this.toolTriangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolTriangle.Name = "toolTriangle";
            this.toolTriangle.Size = new System.Drawing.Size(23, 22);
            this.toolTriangle.Text = "toolStripButton3";
            this.toolTriangle.Click += new System.EventHandler(this.toolTriangle_Click);
            // 
            // toolStar
            // 
            this.toolStar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStar.Image = ((System.Drawing.Image)(resources.GetObject("toolStar.Image")));
            this.toolStar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStar.Name = "toolStar";
            this.toolStar.Size = new System.Drawing.Size(23, 22);
            this.toolStar.Text = "toolStripButton1";
            this.toolStar.Click += new System.EventHandler(this.toolStar_Click);
            // 
            // toolPenColor
            // 
            this.toolPenColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPenColor.Image = ((System.Drawing.Image)(resources.GetObject("toolPenColor.Image")));
            this.toolPenColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPenColor.Name = "toolPenColor";
            this.toolPenColor.Size = new System.Drawing.Size(23, 22);
            this.toolPenColor.Text = "toolStripButton1";
            this.toolPenColor.Click += new System.EventHandler(this.toolPenColor_Click);
            // 
            // toolBackgroundColor
            // 
            this.toolBackgroundColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBackgroundColor.Image = ((System.Drawing.Image)(resources.GetObject("toolBackgroundColor.Image")));
            this.toolBackgroundColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBackgroundColor.Name = "toolBackgroundColor";
            this.toolBackgroundColor.Size = new System.Drawing.Size(23, 22);
            this.toolBackgroundColor.Text = "toolStripButton2";
            this.toolBackgroundColor.Click += new System.EventHandler(this.toolBackgroundColor_Click);
            // 
            // toolStepBack
            // 
            this.toolStepBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStepBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStepBack.Image")));
            this.toolStepBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStepBack.Name = "toolStepBack";
            this.toolStepBack.Size = new System.Drawing.Size(23, 22);
            this.toolStepBack.Text = "toolStripButton3";
            this.toolStepBack.Click += new System.EventHandler(this.toolStepBack_Click);
            // 
            // toolClear
            // 
            this.toolClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolClear.Image = ((System.Drawing.Image)(resources.GetObject("toolClear.Image")));
            this.toolClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClear.Name = "toolClear";
            this.toolClear.Size = new System.Drawing.Size(23, 22);
            this.toolClear.Text = "toolStripButton4";
            this.toolClear.Click += new System.EventHandler(this.toolClear_Click);
            // 
            // toolOpen
            // 
            this.toolOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolOpen.Image")));
            this.toolOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOpen.Name = "toolOpen";
            this.toolOpen.Size = new System.Drawing.Size(23, 22);
            this.toolOpen.Text = "toolStripButton1";
            this.toolOpen.Click += new System.EventHandler(this.toolOpen_Click);
            // 
            // toolSave
            // 
            this.toolSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(23, 22);
            this.toolSave.Text = "toolStripButton2";
            this.toolSave.Click += new System.EventHandler(this.toolSave_Click);
            // 
            // toolExit
            // 
            this.toolExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(23, 22);
            this.toolExit.Text = "toolStripButton1";
            this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
            // 
            // textBoxLineWidth
            // 
            this.textBoxLineWidth.Location = new System.Drawing.Point(404, 3);
            this.textBoxLineWidth.Name = "textBoxLineWidth";
            this.textBoxLineWidth.Size = new System.Drawing.Size(32, 20);
            this.textBoxLineWidth.TabIndex = 6;
            this.textBoxLineWidth.TextChanged += new System.EventHandler(this.textBoxLineWidth_TextChanged);
            // 
            // labelLineWidth
            // 
            this.labelLineWidth.AutoSize = true;
            this.labelLineWidth.BackColor = System.Drawing.Color.White;
            this.labelLineWidth.Location = new System.Drawing.Point(340, 6);
            this.labelLineWidth.Name = "labelLineWidth";
            this.labelLineWidth.Size = new System.Drawing.Size(58, 13);
            this.labelLineWidth.TabIndex = 5;
            this.labelLineWidth.Text = "Line width:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 435);
            this.Controls.Add(this.textBoxLineWidth);
            this.Controls.Add(this.labelLineWidth);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RTL Painter";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolLine;
        private System.Windows.Forms.ToolStripButton toolCircle;
        private System.Windows.Forms.ToolStripButton toolTriangle;
        private System.Windows.Forms.ToolStripButton toolStar;
        private System.Windows.Forms.ToolStripButton toolPenColor;
        private System.Windows.Forms.ToolStripButton toolBackgroundColor;
        private System.Windows.Forms.ToolStripButton toolStepBack;
        private System.Windows.Forms.ToolStripButton toolClear;
        private System.Windows.Forms.ToolStripButton toolOpen;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.TextBox textBoxLineWidth;
        private System.Windows.Forms.Label labelLineWidth;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

