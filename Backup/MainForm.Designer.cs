/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: admin
 * Data: 2011-09-13
 * Godzina: 14:36
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
namespace ScreenEater
{
   partial class MainForm
   {
      /// <summary>
      /// Designer variable used to keep track of non-visual components.
      /// </summary>
      private System.ComponentModel.IContainer components = null;
      
      /// <summary>
      /// Disposes resources used by the form.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing) {
            if (components != null) {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }
      
      /// <summary>
      /// This method is required for Windows Forms designer support.
      /// Do not change the method contents inside the source code editor. The Forms designer might
      /// not be able to load this method if it was changed manually.
      /// </summary>
      private void InitializeComponent()
      {
      	this.btGo = new System.Windows.Forms.Button();
      	this.SuspendLayout();
      	// 
      	// btGo
      	// 
      	this.btGo.Location = new System.Drawing.Point(12, 238);
      	this.btGo.Name = "btGo";
      	this.btGo.Size = new System.Drawing.Size(75, 23);
      	this.btGo.TabIndex = 0;
      	this.btGo.Text = "Go!";
      	this.btGo.UseVisualStyleBackColor = true;
      	this.btGo.Click += new System.EventHandler(this.BtGoClick);
      	// 
      	// MainForm
      	// 
      	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      	this.ClientSize = new System.Drawing.Size(292, 273);
      	this.Controls.Add(this.btGo);
      	this.Name = "MainForm";
      	this.Text = "ScreenEater";
      	this.ResumeLayout(false);
      }
      private System.Windows.Forms.Button btGo;
   }
}
