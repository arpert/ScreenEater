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
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace ScreenEater
{
   /// <summary>
   /// Description of MainForm.
   /// </summary>
   public partial class MainForm : Form
   {
      public MainForm()
      {
         //
         // The InitializeComponent() call is required for Windows Forms designer support.
         //
         InitializeComponent();
         
         //
         // TODO: Add constructor code after the InitializeComponent() call.
         //
      }

//      public static void Main(string [] argl)
//      {
//         ScreenCapture sc = new ScreenCapture();
//         // capture entire screen, and save it to a file
//         Image img = sc.CaptureScreen();
//         // display image in a Picture control named imageDisplay
//         //imageDisplay.Image = img;
//         // capture this window, and save it
//         IntPtr handle = User32.GetDesktopWindow();
//         sc.CaptureWindowToFile(handle, "Capture_" + handle.ToString() + ".gif", ImageFormat.png);
//      }
      
      
      
      void BtGoClick(object sender, EventArgs e)
      {
         ScreenCapture sc = new ScreenCapture();
         // capture entire screen, and save it to a file
         Image img = sc.CaptureScreen();
         // display image in a Picture control named imageDisplay
         //imageDisplay.Image = img;
         // capture this window, and save it
         IntPtr handle = User32.GetDesktopWindow();
         sc.CaptureWindowToFile(handle, "Capture_" + handle.ToString() + ".gif", ImageFormat.Png);
      }
   
      /// <summary>
      /// Helper class containing User32 API functions
      /// </summary>
      private class User32
      {
         [StructLayout(LayoutKind.Sequential)]
         public struct RECT
         {
             public int left;
             public int top;
             public int right;
             public int bottom;
         }
         [DllImport("user32.dll")]
         public static extern IntPtr GetDesktopWindow();
         [DllImport("user32.dll")]
         public static extern IntPtr GetWindowDC(IntPtr hWnd);
         [DllImport("user32.dll")]
         public static extern IntPtr ReleaseDC(IntPtr hWnd,IntPtr hDC);
         [DllImport("user32.dll")]
         public static extern IntPtr GetWindowRect(IntPtr hWnd,ref RECT rect);
      }

   }
}
