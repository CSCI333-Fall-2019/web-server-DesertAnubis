/* # # # # # # # # # # # Documentation # # # # # # # # # # # */
// Author:  Des
// Date:    10/3/2019
// Purpose: To design the window to open
/* # # # # # # # # # # # # # # # # # # # # # # # # # # # # # */

/* # # # # # # # # # # # # Libraries # # # # # # # # # # # # */
namespace WebServer
{
   partial class Form1
   {
      private System.ComponentModel.IContainer components = null;

      // Clears out useless components
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      // Sets up the form window
      private void InitializeComponent()
      {
         // Creates the objects on the form
         this.startBtn = new System.Windows.Forms.Button();
         this.stopBtn = new System.Windows.Forms.Button();
         this.SuspendLayout();

         // Start Button
         this.startBtn.Location = new System.Drawing.Point(154, 47);
         this.startBtn.Name = "startBtn";
         this.startBtn.Size = new System.Drawing.Size(448, 100);
         this.startBtn.TabIndex = 0;
         this.startBtn.Text = "Start Button";
         this.startBtn.UseVisualStyleBackColor = true;
         this.startBtn.Click += new System.EventHandler(this.startBtn_Click);

         // Stop Button
         this.stopBtn.Location = new System.Drawing.Point(154, 207);
         this.stopBtn.Name = "stopBtn";
         this.stopBtn.Size = new System.Drawing.Size(448, 122);
         this.stopBtn.TabIndex = 1;
         this.stopBtn.Text = "Stop Button";
         this.stopBtn.UseVisualStyleBackColor = true;
         this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);

         // Form1
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(800, 450);
         this.Controls.Add(this.startBtn);
         this.Controls.Add(this.stopBtn);
         this.Name = "Form1";
         this.Text = "Web Server";
         this.ResumeLayout(false);
      }

      private System.Windows.Forms.Button startBtn;
      private System.Windows.Forms.Button stopBtn;
   }
}

