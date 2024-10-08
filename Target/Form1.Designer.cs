﻿using System.Windows.Forms;

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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.eNDKEYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muteAudioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgoundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passTextBOX = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setPassMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.keyIMPPNTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortcutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripSeparator2,
            this.eNDKEYToolStripMenuItem,
            this.muteAudioToolStripMenuItem,
            this.backgoundToolStripMenuItem,
            this.passwordMenuItem,
            this.toolStripSeparator3,
            this.keyIMPPNTToolStripMenuItem,
            this.shortcutToolStripMenuItem,
            this.toolStripSeparator4,
            this.salirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(138, 198);
            // 
            // targetV10ToolStripMenuItem
            // 
            this.targetV10ToolStripMenuItem.Enabled = false;
            this.targetV10ToolStripMenuItem.Name = "targetV10ToolStripMenuItem";
            this.targetV10ToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.targetV10ToolStripMenuItem.Text = "Target - v8";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
            // 
            // eNDKEYToolStripMenuItem
            // 
            this.eNDKEYToolStripMenuItem.Enabled = false;
            this.eNDKEYToolStripMenuItem.Name = "eNDKEYToolStripMenuItem";
            this.eNDKEYToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.eNDKEYToolStripMenuItem.Text = "Key :: END";
            // 
            // muteAudioToolStripMenuItem
            // 
            this.muteAudioToolStripMenuItem.Checked = true;
            this.muteAudioToolStripMenuItem.CheckOnClick = true;
            this.muteAudioToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.muteAudioToolStripMenuItem.Name = "muteAudioToolStripMenuItem";
            this.muteAudioToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.muteAudioToolStripMenuItem.Text = "Mute Audio";
            this.muteAudioToolStripMenuItem.Click += new System.EventHandler(this.muteAudioToolStripMenuItem_Click);
            // 
            // backgoundToolStripMenuItem
            // 
            this.backgoundToolStripMenuItem.Checked = true;
            this.backgoundToolStripMenuItem.CheckOnClick = true;
            this.backgoundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backgoundToolStripMenuItem.Name = "backgoundToolStripMenuItem";
            this.backgoundToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.backgoundToolStripMenuItem.Text = "Clock";
            this.backgoundToolStripMenuItem.Click += new System.EventHandler(this.backgoundToolStripMenuItem_Click);
            // 
            // passwordMenuItem
            // 
            this.passwordMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.passTextBOX,
            this.toolStripSeparator1,
            this.setPassMenuItem});
            this.passwordMenuItem.Name = "passwordMenuItem";
            this.passwordMenuItem.Size = new System.Drawing.Size(137, 22);
            this.passwordMenuItem.Text = "Password";
            // 
            // passTextBOX
            // 
            this.passTextBOX.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.passTextBOX.MaxLength = 100;
            this.passTextBOX.Name = "passTextBOX";
            this.passTextBOX.Size = new System.Drawing.Size(100, 23);
            this.passTextBOX.ToolTipText = "Write Here";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // setPassMenuItem
            // 
            this.setPassMenuItem.Name = "setPassMenuItem";
            this.setPassMenuItem.Size = new System.Drawing.Size(180, 22);
            this.setPassMenuItem.Text = "Set Password";
            this.setPassMenuItem.Click += new System.EventHandler(this.setPassMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(134, 6);
            // 
            // keyIMPPNTToolStripMenuItem
            // 
            this.keyIMPPNTToolStripMenuItem.Enabled = false;
            this.keyIMPPNTToolStripMenuItem.Name = "keyIMPPNTToolStripMenuItem";
            this.keyIMPPNTToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.keyIMPPNTToolStripMenuItem.Text = "Key :: Insert";
            // 
            // shortcutToolStripMenuItem
            // 
            this.shortcutToolStripMenuItem.Checked = true;
            this.shortcutToolStripMenuItem.CheckOnClick = true;
            this.shortcutToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shortcutToolStripMenuItem.Name = "shortcutToolStripMenuItem";
            this.shortcutToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.shortcutToolStripMenuItem.Text = "Shortcut";
            this.shortcutToolStripMenuItem.Click += new System.EventHandler(this.shortcutToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(134, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.salirToolStripMenuItem.Text = "Exit";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // horatxt
            // 
            this.horatxt.AutoSize = true;
            this.horatxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 109.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horatxt.ForeColor = System.Drawing.SystemColors.Control;
            this.horatxt.Location = new System.Drawing.Point(9, 93);
            this.horatxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.horatxt.Name = "horatxt";
            this.horatxt.Size = new System.Drawing.Size(747, 166);
            this.horatxt.TabIndex = 1;
            this.horatxt.Text = "h:mm:ss tt";
            this.horatxt.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(355, 292);
            this.ControlBox = false;
            this.Controls.Add(this.horatxt);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Target";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
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
        private ToolStripMenuItem muteAudioToolStripMenuItem;
        private ToolStripMenuItem keyIMPPNTToolStripMenuItem;
        private ToolStripMenuItem shortcutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem passwordMenuItem;
        private ToolStripTextBox passTextBOX;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem setPassMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
    }
}