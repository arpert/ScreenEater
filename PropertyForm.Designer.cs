/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: admin
 * Data: 2010-12-01
 * Godzina: 11:05
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
namespace ScreenEater
{
   partial class PropertyForm
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
         this.btOK = new System.Windows.Forms.Button();
         this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
         this.SuspendLayout();
         // 
         // btOK
         // 
         this.btOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
         this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btOK.Location = new System.Drawing.Point(128, 396);
         this.btOK.Name = "btOK";
         this.btOK.Size = new System.Drawing.Size(75, 23);
         this.btOK.TabIndex = 2;
         this.btOK.Text = "OK";
         this.btOK.UseVisualStyleBackColor = true;
         // 
         // propertyGrid1
         // 
         this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                           | System.Windows.Forms.AnchorStyles.Left) 
                           | System.Windows.Forms.AnchorStyles.Right)));
         this.propertyGrid1.Location = new System.Drawing.Point(2, 1);
         this.propertyGrid1.Name = "propertyGrid1";
         this.propertyGrid1.Size = new System.Drawing.Size(342, 389);
         this.propertyGrid1.TabIndex = 3;
         // 
         // PropertyForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(346, 423);
         this.Controls.Add(this.propertyGrid1);
         this.Controls.Add(this.btOK);
         this.Name = "PropertyForm";
         this.Text = "PropertyForm";
         this.Load += new System.EventHandler(this.PropertyFormLoad);
         this.ResumeLayout(false);
      }
      private System.Windows.Forms.PropertyGrid propertyGrid1;
      private System.Windows.Forms.Button btOK;
   }
}
