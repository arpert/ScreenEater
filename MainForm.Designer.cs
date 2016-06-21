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
      	this.components = new System.ComponentModel.Container();
      	this.btGo = new System.Windows.Forms.Button();
      	this.pictureBox1 = new System.Windows.Forms.PictureBox();
      	this.btClear = new System.Windows.Forms.Button();
      	this.btExit = new System.Windows.Forms.Button();
      	this.timer1 = new System.Windows.Forms.Timer(this.components);
      	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      	this.SuspendLayout();
      	// 
      	// btGo
      	// 
      	this.btGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      	this.btGo.Location = new System.Drawing.Point(199, 213);
      	this.btGo.Name = "btGo";
      	this.btGo.Size = new System.Drawing.Size(75, 23);
      	this.btGo.TabIndex = 0;
      	this.btGo.Text = "Go!";
      	this.btGo.UseVisualStyleBackColor = true;
      	this.btGo.Click += new System.EventHandler(this.BtGoClick);
      	// 
      	// pictureBox1
      	// 
      	this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      	this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      	this.pictureBox1.Name = "pictureBox1";
      	this.pictureBox1.Size = new System.Drawing.Size(286, 248);
      	this.pictureBox1.TabIndex = 1;
      	this.pictureBox1.TabStop = false;
      	this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseMove);
      	// 
      	// btClear
      	// 
      	this.btClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      	this.btClear.Location = new System.Drawing.Point(118, 213);
      	this.btClear.Name = "btClear";
      	this.btClear.Size = new System.Drawing.Size(75, 23);
      	this.btClear.TabIndex = 2;
      	this.btClear.Text = "Clear";
      	this.btClear.UseVisualStyleBackColor = true;
      	this.btClear.Click += new System.EventHandler(this.BtClearClick);
      	// 
      	// btExit
      	// 
      	this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      	this.btExit.DialogResult = System.Windows.Forms.DialogResult.OK;
      	this.btExit.Location = new System.Drawing.Point(37, 213);
      	this.btExit.Name = "btExit";
      	this.btExit.Size = new System.Drawing.Size(75, 23);
      	this.btExit.TabIndex = 3;
      	this.btExit.Text = "Exit";
      	this.btExit.UseVisualStyleBackColor = true;
      	this.btExit.Click += new System.EventHandler(this.BtExitClick);
      	// 
      	// timer1
      	// 
      	this.timer1.Enabled = true;
      	this.timer1.Interval = 20;
      	this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
      	// 
      	// MainForm
      	// 
      	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      	this.AutoSize = true;
      	this.ClientSize = new System.Drawing.Size(286, 248);
      	this.ControlBox = false;
      	this.Controls.Add(this.btExit);
      	this.Controls.Add(this.btClear);
      	this.Controls.Add(this.btGo);
      	this.Controls.Add(this.pictureBox1);
      	this.DoubleBuffered = true;
      	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      	this.KeyPreview = true;
      	this.Name = "MainForm";
      	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      	this.Text = "ScreenEater";
      	this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      	this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyUp);
      	this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainFormMouseMove);
      	this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainFormPreviewKeyDown);
      	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      	this.ResumeLayout(false);
      }
      private System.Windows.Forms.Timer timer1;
      private System.Windows.Forms.Button btExit;
      private System.Windows.Forms.Button btClear;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Button btGo;
      
   }
}
