/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2011-09-20
 * Time: 12:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ScreenEater
{
	using System;
    using System.Drawing;
	using System.Runtime.InteropServices;

      /// <summary>
      /// Helper class containing User32 API functions
      /// </summary>
      class User32
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
         
		#region Preview API's
		
		[DllImport("user32.dll")]
		public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
		
		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
		
		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
		
		[DllImport("user32.dll")]
		public static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);
		
		#endregion         
      }
}
