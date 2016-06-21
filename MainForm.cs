/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: admin
 * Data: 2011-09-13
 * Godzina: 14:36
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Linq;

namespace ScreenEater
{
   /// <summary>
   /// Description of MainForm.
   /// </summary>
   public partial class MainForm : Form
   {
      public static Random rnd = new Random();
      Bitmap bmp;
      Eater[] eater;
      int scrnNumber;
      bool eating = false;

      IntPtr parentHandle = new IntPtr(0);
      
      public MainForm(int scrnNr)
      {
         scrnNumber = scrnNr;
         Bounds = Screen.AllScreens[scrnNumber].Bounds;
         //
         // The InitializeComponent() call is required for Windows Forms designer support.
         //
         InitializeComponent();
         
         //
         // TODO: Add constructor code after the InitializeComponent() call.
         //
         ShowButtons(ScreenEaterConfig.instance.ShowButtons);
         Go();
      }

      public void setParentHandle(IntPtr parentHWnd)
      {
      	parentHandle = parentHWnd;
      }
	     		 
      void Go()
      {
         Hide();
         eater = new Eater[ScreenEaterConfig.instance.EatersCount];
         System.Threading.Thread.Sleep(200);
         ScreenCapture sc = new ScreenCapture();
         // capture entire screen, and save it to a file
         Image img = sc.CaptureScreen();
         // display image in a Picture control 
         pictureBox1.Image = img;
         bmp = new Bitmap(img);
         
         Screen scr = Screen.AllScreens[scrnNumber];
         
         Point pointOrigin = new Point(scr.Bounds.Left, scr.Bounds.Top);
         
         Size size = new Size(bmp.Width, bmp.Height);
         using (Graphics graphics = Graphics.FromImage(bmp))
         {
              graphics.CopyFromScreen(pointOrigin, new Point(0, 0), size);
         }
         
         Color clr = Color.Black;
         for (int i = 0; i < eater.Length; i++) 
         {
            eater[i] = new Eater(rnd.Next(bmp.Width), rnd.Next(bmp.Height));
            eater[i].myColor = bmp.GetPixel(eater[i].x, eater[i].y);
         }
         // capture this window, and save it
//         IntPtr handle = User32.GetDesktopWindow();
//         sc.CaptureWindowToFile(handle, "Screen_" + String.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + ".png", ImageFormat.Png);
         Show();
      }
      
      void Clear()
      {
         pictureBox1.Image = null;
      }
      
      void BtGoClick(object sender, EventArgs e)
      {
         Go();
      }

      void BtClearClick(object sender, System.EventArgs e)
      {
         Clear();
      }

      void BtExitClick(object sender, EventArgs e)
      {
         Close();
      }
      
      public void Eat()
      {
         Graphics gr = pictureBox1.CreateGraphics();
         if (pictureBox1.Image != null) {
            for ( int j = 0; j < Math.Max(1, (int)(2000 / eater.Length)); j++) {
               for (int i = 0; i < eater.Length; i++) 
               {
                  if (eater[i] != null)
                     eater[i].Move(ref bmp);
               }
            }
            gr.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
            if (ScreenEaterConfig.instance.ShowHeads)
            {
                Pen pn = new Pen(ScreenEaterConfig.instance.HeadColor, 1);
                Brush br = new SolidBrush(ScreenEaterConfig.instance.HeadColor);
                int d = ScreenEaterConfig.instance.HeadDiameter;
                int r = d / 2;
               for (int i = 0; i < eater.Length; i++) 
               {
                  if (eater[i] != null)
                     if (ScreenEaterConfig.instance.FillHeads)
                        gr.FillEllipse(br, eater[i].x - r, eater[i].y - r, d, d);
                     else
                        gr.DrawEllipse(pn, eater[i].x - r, eater[i].y - r, d, d);
               }
            }
            int e = 0;
            for ( int j = 0; j < eater.Length - 1; j++)
            {
               if (eater[j].e > 0) ++e;
               else
               {
                  eater[j].x = rnd.Next(bmp.Width);
                  eater[j].y = rnd.Next(bmp.Height);
               }
               
               for (int i = j + 1; i < eater.Length; i++)
               {
                  if ((eater[i].x == eater[j].x) && 
                      (eater[i].y == eater[j].y))
                  {
                     eater[j].x = rnd.Next(bmp.Width);
                     eater[j].y = rnd.Next(bmp.Height);
                  }
               }
            }
         }
      }
      
      void Timer1Tick(object sender, EventArgs e)
      {
         if (!eating)
         {
            eating = true;
            Eat();
            eating = false;
         }
      }
      
      void MainFormPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
//         MessageBox.Show(e.KeyValue.ToString());
          if (e.KeyValue == 27)
          {
              Close();
              Application.Exit();
          }
      }
      
      void ShowButtons(bool show)
      {
         if (show) 
         {
            btClear.Show();
            btGo.Show();
            btExit.Show();
         } else
         {
            btClear.Hide();
            btGo.Hide();
            btExit.Hide();
         }
      }
      
      void MainFormKeyUp(object sender, KeyEventArgs e)
      {
         if (e.KeyValue == 27)
         {
            Close();
            Application.Exit();
         }
         else
         {
            if (e.Alt)
            {
               if (e.KeyCode == Keys.F2) 
               {
                  pictureBox1.Image.Save("Screen_" + String.Format("{0:yyyyMMddHHmmss}", DateTime.Now) + ".png", ImageFormat.Png);
               } else
               if (e.KeyCode == Keys.F3)
               {
                  ScreenEaterConfig.instance.ShowButtons = !ScreenEaterConfig.instance.ShowButtons;
                  ShowButtons(ScreenEaterConfig.instance.ShowButtons);
               } else
               if (e.KeyCode == Keys.F5) 
               {
                  Go();
               } else
               if (e.KeyCode == Keys.F8) 
               {
                   Clear();
               } else
               if (e.KeyCode == Keys.F9) 
               {
	               PropertyForm prpf = new PropertyForm();
		            prpf.con = ScreenEaterConfig.instance;
		            if (prpf.ShowDialog() == DialogResult.OK)
		            {
		               int n0 = eater.Length;
		               int n1 = ScreenEaterConfig.instance.EatersCount;
		               Array.Resize(ref eater, ScreenEaterConfig.instance.EatersCount);
		               if (n0 < n1)
		               {
		                  for(int i = n0; i < n1; i++)
		                  {
                           eater[i] = new Eater(rnd.Next(bmp.Width), rnd.Next(bmp.Height));
                           eater[i].myColor = bmp.GetPixel(eater[i].x, eater[i].y);
		                  }
		               }
		            }
               }
            }
         }
      }
      
      void MainFormMouseMove(object sender, MouseEventArgs e)
      {
      	if (ScreenEaterConfig.instance.scrRun)
      	{
      	   Close();
      	}
      }
      int moveCount = 0;
      void PictureBox1MouseMove(object sender, MouseEventArgs e)
      {
      	if (ScreenEaterConfig.instance.scrRun && (e.Button == MouseButtons.None))
      	{
            if (++moveCount > 18)
            {
                Close();
                Application.Exit();
            }
      	}
      }
   }
}
