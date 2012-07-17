﻿namespace MySql.Notifier
{
  partial class MessageDialog
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageDialog));
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblOperationDetails = new System.Windows.Forms.Label();
      this.picLogo = new System.Windows.Forms.PictureBox();
      this.lblOperationSummary = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnOK = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.AutoSize = true;
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.lblOperationDetails);
      this.panel1.Controls.Add(this.picLogo);
      this.panel1.Controls.Add(this.lblOperationSummary);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(511, 123);
      this.panel1.TabIndex = 48;
      // 
      // lblOperationDetails
      // 
      this.lblOperationDetails.AutoSize = true;
      this.lblOperationDetails.Location = new System.Drawing.Point(111, 66);
      this.lblOperationDetails.Name = "lblOperationDetails";
      this.lblOperationDetails.Size = new System.Drawing.Size(108, 15);
      this.lblOperationDetails.TabIndex = 27;
      this.lblOperationDetails.Text = "lblOperationDetails";
      // 
      // picLogo
      // 
      this.picLogo.Location = new System.Drawing.Point(18, 23);
      this.picLogo.Name = "picLogo";
      this.picLogo.Size = new System.Drawing.Size(82, 69);
      this.picLogo.TabIndex = 26;
      this.picLogo.TabStop = false;
      // 
      // lblOperationSummary
      // 
      this.lblOperationSummary.AutoSize = true;
      this.lblOperationSummary.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblOperationSummary.ForeColor = System.Drawing.Color.Navy;
      this.lblOperationSummary.Location = new System.Drawing.Point(110, 37);
      this.lblOperationSummary.Name = "lblOperationSummary";
      this.lblOperationSummary.Size = new System.Drawing.Size(107, 20);
      this.lblOperationSummary.TabIndex = 25;
      this.lblOperationSummary.Text = "Error Summary";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.btnOK);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
      this.panel2.Location = new System.Drawing.Point(0, 123);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(511, 58);
      this.panel2.TabIndex = 47;
      // 
      // btnOK
      // 
      this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOK.Location = new System.Drawing.Point(412, 19);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(87, 27);
      this.btnOK.TabIndex = 13;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      // 
      // MessageDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(511, 181);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel2);
      this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MessageDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "MySQL Notifer";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblOperationSummary;
    private System.Windows.Forms.PictureBox picLogo;
    private System.Windows.Forms.Label lblOperationDetails;
  }
}