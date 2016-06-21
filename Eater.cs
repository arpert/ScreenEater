/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2011-09-20
 * Time: 12:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace ScreenEater
{
   using System;
	using System.Drawing;
	using System.Drawing.Imaging;

	/// <summary>
	/// Description of Eater.
	/// </summary>
    class Eater
      {
         public int x {get; set; }
         public int y {get; set; }
         /// <summary>
         /// e like Energy
         /// </summary>
         public int e {get; set; }
//         int dx = 1, dy = 0;
//         float dp = 0f;
         enum dirTo :int {X = 0, L = 1, U = 2, R = 3, D = 4, LU = 5, RU = 6, RD = 7, LD = 8 };
         const int Ndirs = 9;
         dirTo dir = dirTo.R;
         char []dirArr = new char[Ndirs];
         Color []clrArr = new Color[Ndirs];
         float []difArr = new float[Ndirs];
         static int []dxArr = new int[9] {0, -1,  0, 1,  0, -1,  1, 1, -1};
         static int []dyArr = new int[9] {0,  0, -1, 0,  1, -1, -1, 1,  1};

         public Color myColor { get; set; }
         public Color lastEatenColor {get; set; } 
         
         public Eater(int x0, int y0)
         {
            x = x0;
            y = y0;
            e = 16;
//            refClr;
         }
         
         public void Move(ref Bitmap bmp)
         {
         	if (ScreenEaterConfig.instance.MoveMethod == 1)
         	{
               Go(ref bmp);
         	} else
         	{
               Go2(ref bmp);
         	}
         }
         
         public int getDif(int r, int g, int b)
         {
            int ret = r + g + b;
            if (r == 0 && g == 0) ret *=2;
            if (g == 0 && b == 0) ret *=2;
            if (b == 0 && r == 0) ret *=2;

            if (r == 0 && g == b) ret *=3;
            if (g == 0 && b == r) ret *=3;
            if (b == 0 && r == g) ret *=3;

            return ret;
         }

         public int getDif(Color clr)
         {
            int ret = (int)(256*clr.GetBrightness());
//            if (clr.R == 0 && clr.G == 0) ret *=2;
//            if (clr.G == 0 && clr.B == 0) ret *=2;
//            if (clr.B == 0 && clr.R == 0) ret *=2;
//
//            if (clr.R == 0 && clr.G == clr.B) ret *=3;
//            if (clr.G == 0 && clr.B == clr.R) ret *=3;
//            if (clr.B == 0 && clr.R == clr.G) ret *=3;
//
            return ret;
         }

         private void Go2(ref Bitmap bmp)
         {
            if (myColor == null) 
            {
               myColor = bmp.GetPixel(x, y);
               lastEatenColor = myColor;
               e = (int)myColor.GetBrightness();
            } 

            int i;
            for(i = 0; i < Ndirs; i++)     { dirArr[i] = '+'; }

            /// no backward
            //dirArr[(((int)dir + 1) % 4) + 1] = '-';
            
            /// don't cross borders
            if ((x - 1) < 0)           { dirArr[(int)dirTo.L] = '-'; dirArr[(int)dirTo.LU] = '-'; dirArr[(int)dirTo.LD] = '-'; }
            if ((y - 1) < 0)           { dirArr[(int)dirTo.U] = '-'; dirArr[(int)dirTo.LU] = '-'; dirArr[(int)dirTo.RU] = '-'; }
            if ((x + 1) >= bmp.Width)  { dirArr[(int)dirTo.R] = '-'; dirArr[(int)dirTo.RU] = '-'; dirArr[(int)dirTo.RD] = '-'; }
            if ((y + 1) >= bmp.Height) { dirArr[(int)dirTo.D] = '-'; dirArr[(int)dirTo.LD] = '-'; dirArr[(int)dirTo.RD] = '-'; }

            if (x >= 1279)
            { // place for breakpoint
               int a = 9;
               a += 9;
            }
                  
            float dMax = float.MinValue;

            dirTo bestDir = dirTo.X; // don't move
            dirTo maxDir = dirTo.X;

            for(i = 0; i < Ndirs; i++)
            { 
               if (dirArr[i] == '+')
               {
                  //if (bestDir == dirTo.X) bestDir = (dirTo)i; // any dir is good
                  //if (maxDir  == dirTo.X) maxDir  = (dirTo)i; // any dir is good
                     
                  clrArr[i] = bmp.GetPixel(x + dxArr[i], y + dyArr[i]);
                  difArr[i] = getDif(clrArr[i]);

                  if (dMax < difArr[i]) { dMax = difArr[i]; maxDir = (dirTo)i; }

               } else
               {
                  clrArr[i] = Color.Empty;
                  difArr[i] = 0;
               }               
            }

            //float dif = -1000;
            //int n = 0;

            bestDir = maxDir;

            //if ((dMax <= difArr[(int)dir]) && (dirArr[(int)dir] == '+'))
            //{
            //    bestDir = dir;
            //    n = 1;
            //} else
            {
                int i0 = MainForm.rnd.Next(Ndirs);
                for(int ii = i0; ii < i0 + Ndirs; ii++)
                {
                    i = (ii % Ndirs);
                    if (dirArr[i] == '+')
                    {
                        if (dMax == difArr[i])
                        {
                                bestDir = (dirTo)i;
                                //n = 1;
                                break;
                        }
                    }
                }
            }
            
            if (dMax == 0)
            {
                Graphics gr = Graphics.FromImage(bmp);
                int xf = 240;
                Brush brs = new SolidBrush(Color.FromArgb(256 - xf + MainForm.rnd.Next(xf), 
                                                          256 - xf + MainForm.rnd.Next(xf), 
                                                          256 - xf + MainForm.rnd.Next(xf)));
                int d = ScreenEaterConfig.instance.HeadDiameter;
                int rad = d / 2;
                gr.FillEllipse(brs, x - rad, y - rad, d, d);
               x = MainForm.rnd.Next(bmp.Width - 2) + 1;
               y = MainForm.rnd.Next(bmp.Height - 2) + 1;
               myColor = bmp.GetPixel(x, y);
               lastEatenColor = myColor;
            }

//          dim my color
            int r = myColor.R - ScreenEaterConfig.instance.dimFactor;
            int g = myColor.G - ScreenEaterConfig.instance.dimFactor;
            int b = myColor.B - ScreenEaterConfig.instance.dimFactor;
            
//          not too much
            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;

            int p;
            switch (ScreenEaterConfig.instance.ColorShift)
            {
               case 1: /* gbr */ p = r; r = g; g = b; b = p; break;
               case 2: /* brg */ p = r; r = b; b = g; g = p; break;
               case 3: /* rbg */ p = b; b = g; g = p; break;
               case 4: /* bgr */ p = r; r = b; b = p; break;
               case 5: /* grb */ p = r; r = g; g = p; break;
             
               default: /* 0 rgb */
                  ; break;
            }
//          leave trail
            bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
            
//          new position
            x = x + dxArr[(int)bestDir];
            y = y + dyArr[(int)bestDir];

            lastEatenColor = bmp.GetPixel(x, y);

            double div = ScreenEaterConfig.instance.DiffSuppression;
            
//          You are what you eat
            r = (int)(Math.Round((lastEatenColor.R + div * myColor.R) / (div+1)));
            g = (int)(Math.Round((lastEatenColor.G + div * myColor.G) / (div+1)));
            b = (int)(Math.Round((lastEatenColor.B + div * myColor.B) / (div+1)));
            if (r == myColor.R) r -= ScreenEaterConfig.instance.dimFactor;
            if (g == myColor.G) g -= ScreenEaterConfig.instance.dimFactor;
            if (b == myColor.B) b -= ScreenEaterConfig.instance.dimFactor;

            int argb = lastEatenColor.ToArgb();
            if ((lastEatenColor.ToArgb() & 0xFFFFFF) == 0)
            {
               lastEatenColor = Color.White;
            }
            
            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;
            if (r <   0) r  =   0;
            if (g <   0) g  =   0;
            if (b <   0) b  =   0;

            dir = bestDir;
            myColor = Color.FromArgb(r, g, b);
         }

// ############################################################################################
// ############################################################################################

         private void Go(ref Bitmap bmp)
         {
            if (myColor == null) 
            {
               myColor = bmp.GetPixel(x, y);
               lastEatenColor = myColor;
            }

            int i;
            for(i = 0; i < 5; i++)     { dirArr[i] = '+'; }

            /// no backward
            dirArr[(((int)dir + 1) % 4) + 1] = '-';
            
            /// don't cross borders
            if ((x - 1) < 0)           { dirArr[(int)dirTo.L] = '-'; }
            if ((y - 1) < 0)           { dirArr[(int)dirTo.U] = '-'; }
            if ((x + 1) >= bmp.Width)  { dirArr[(int)dirTo.R] = '-'; }
            if ((y + 1) >= bmp.Height) { dirArr[(int)dirTo.D] = '-'; }
            
            float dMax = float.MinValue;
            float dMin = float.MaxValue;

            for(i = 0; i < 5; i++)
            { 
               if (dirArr[i] == '+')
               {
                  clrArr[i] = bmp.GetPixel(x + dxArr[i], y + dyArr[i]);
                  difArr[i] = (int)((Math.Abs(clrArr[i].GetHue() - lastEatenColor.GetHue())) / 1);
                  if (dMax < difArr[i]) dMax = difArr[i];
                  if (dMin > difArr[i]) dMin = difArr[i];
               } else
               {
                  clrArr[i] = Color.Empty;
                  difArr[i] = 0;
               }               
            }

            dirTo newDir = dir;

            bool dirChange = true;
            
            while (dirChange)
            {
               dirChange = false;
               for(i = 1; i < 5; i++)
               {
                  if (lastEatenColor.Equals(clrArr) && (newDir == (dirTo)i))
                  {
                     newDir = (dirTo)i;
                     dirChange = false; 
                     break;
                  }
                  else
                  if ((difArr[i] >= dMax) && (dirArr[i] == '+'))
                  { 
                     dirArr[i] = '-';
                     newDir = (dirTo)i;
                     dirChange = true; 
                  }
               }
            }

            int n = 0;
            for(i = 1; i < 5; i++)
            {
               if (dirArr[i] == '+') 
               {
                  ++n;
                  if (i == (int)dir)
                  {
                     n = -1;
                     break;
                  }
               }
            }

            if (n > 0)
            {
               int l = MainForm.rnd.Next(n);
               for(i = 1; i < 5; i++)
               {
                  if (dirArr[i] == '+')
                  {
                     if (l-- == 0)
                     {
                        newDir = (dirTo)i;
                        break;
                     }
                  }
               }
            } else
            {
               if (n != -1)
               {
               newDir = (dirTo)MainForm.rnd.Next(5);
               if (   (x + dxArr[(int)newDir] < 0)
                   || (y + dyArr[(int)newDir] < 0)
                   || (x + dxArr[(int)newDir] >= bmp.Width)
                   || (y + dyArr[(int)newDir] >= bmp.Height))
                  newDir = dirTo.X;
               }
            }
            
            int r = myColor.R -1;
            int g = myColor.G -1;
            int b = myColor.B -1;
            if (r < 0) r = 0;
            if (g < 0) g = 0;
            if (b < 0) b = 0;
            int p;
            switch (ScreenEaterConfig.instance.ColorShift)
            {
               case 1: /* gbr */ p = r; r = g; g = b; b = p; break;
               case 2: /* brg */ p = r; r = b; b = g; g = p; break;
               case 3: /* rbg */ p = b; b = g; g = p; break;
               case 4: /* bgr */ p = r; r = b; b = p; break;
               case 5: /* grb */ p = r; r = g; g = p; break;
             
               default: /* 0 rgb */
                  ; break;
            }
            bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
            
            x = x + dxArr[(int)newDir];
            y = y + dyArr[(int)newDir];
            lastEatenColor = bmp.GetPixel(x, y);

            double div = ScreenEaterConfig.instance.DiffSuppression;
            r = myColor.R + (int)(Math.Sign((lastEatenColor.R + 0 - myColor.R) / div));
            g = myColor.G + (int)(Math.Sign((lastEatenColor.G + 0 - myColor.G) / div));
            b = myColor.B + (int)(Math.Sign((lastEatenColor.B + 0 - myColor.B) / div));
//            r = (2* refClr.R + c.R) / 3;
//            g = (2* refClr.G + c.G) / 3;
//            b = (2* refClr.B + c.B) / 3;

            if (r > 255) r %= 255;
            if (g > 255) g %= 255;
            if (b > 255) b %= 255;
//            if (r > 31) r -= 1;
//            if (g > 31) g -= 1;
//            if (b > 31) b -= 1;
            dir = newDir;
            myColor = Color.FromArgb(r, g, b);
         }
      }
}
