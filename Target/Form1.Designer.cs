using System.Windows.Forms;

namespace Target
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.targetV10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eNDKEYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horatxt = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "Target";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Target";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.targetV10ToolStripMenuItem,
            this.eNDKEYToolStripMenuItem,
            this.backgoundToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 108);
            // 
            // targetV10ToolStripMenuItem
            // 
            this.targetV10ToolStripMenuItem.Enabled = false;
            this.targetV10ToolStripMenuItem.Name = "targetV10ToolStripMenuItem";
            this.targetV10ToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.targetV10ToolStripMenuItem.Text = "Target - v1.0";
            // 
            // eNDKEYToolStripMenuItem
            // 
            this.eNDKEYToolStripMenuItem.Enabled = false;
            this.eNDKEYToolStripMenuItem.Name = "eNDKEYToolStripMenuItem";
            this.eNDKEYToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.eNDKEYToolStripMenuItem.Text = "Key :: END";
            // 
            // backgoundToolStripMenuItem
            // 
            this.backgoundToolStripMenuItem.Checked = true;
            this.backgoundToolStripMenuItem.CheckOnClick = true;
            this.backgoundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backgoundToolStripMenuItem.Name = "backgoundToolStripMenuItem";
            this.backgoundToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.backgoundToolStripMenuItem.Text = "Clock";
            this.backgoundToolStripMenuItem.Click += new System.EventHandler(this.backgoundToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.salirToolStripMenuItem.Text = "Exit";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // horatxt
            // 
            this.horatxt.AutoSize = true;
            this.horatxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 109.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horatxt.ForeColor = System.Drawing.SystemColors.Control;
            this.horatxt.Location = new System.Drawing.Point(12, 115);
            this.horatxt.Name = "horatxt";
            this.horatxt.Size = new System.Drawing.Size(930, 206);
            this.horatxt.TabIndex = 1;
            this.horatxt.Text = "h:mm:ss tt";
            this.horatxt.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.ControlBox = false;
            this.Controls.Add(this.horatxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Target";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem targetV10ToolStripMenuItem;
        private ToolStripMenuItem eNDKEYToolStripMenuItem;
        private ToolStripMenuItem backgoundToolStripMenuItem;
        private Label horatxt;
    }
}