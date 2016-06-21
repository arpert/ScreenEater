/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: admin
 * Data: 2010-10-25
 * Godzina: 10:17
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */

namespace ScreenEater
{
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using System.Windows.Markup;

public class ScreenEaterConfig
   {
	  public static ScreenEaterConfig instance = new ScreenEaterConfig();
 	
	  [Category("Default"),
       DisplayName("Tryb wygaszacza"),
       Description("Jeśli TRUE - program został uruchomiony w trybie wygaszacza ekranu")]
       public bool scrRun { get; set; }

	  [Category("Default"),
       DisplayName("Ilość zjadaczy"),
       Description("Ilość zjadaczy w akcji")]
       public int EatersCount { get; set; }
      
      [Category("Default"),
       DisplayName("Wspólczynnik zmiany koloru"),
       Description("Współczynnik zmiany koloru")]
       public double DiffSuppression { get; set; }

       [Category("Default"),
       DisplayName("Wyświetlaj przyciski"),
       Description("Jeśli TRUE - to wyświetla przyciski")]
       public bool ShowButtons { get; set; }

      [Category("Default"),
       DisplayName("Średnica znacznika"),
       Description("Średnica znacznika")]
       public int HeadDiameter { get; set; }

      [Category("Default"),
       DisplayName("Wyświetlaj znaczniki"),
       Description("Jeśli TRUE - to wyświetla znaczniki pozycji")]
       public bool ShowHeads { get; set; }

      [Category("Default"),
       DisplayName("Kolor znaczników"),
       Description("Kolor znaczników")]
       public Color HeadColor { get; set; }
       
       [Category("Default"),
       DisplayName("Znaczniki pełne"),
       Description("Jeśli TRUE - to wyświetla znaczniki jako koła, jeśli FALSE - jako okręgi")]
       public bool FillHeads { get; set; }
       
      [Category("Default"),
       DisplayName("Współczynnik przyciemniania"),
       Description("Współczynnik przyciemniania")]
       public byte dimFactor { get; set; }

      [Category("Default"),
       DisplayName("Ilość argumentów"),
       Description("Do odczytu: ilość przekazanych argumentów")]
       public int ArgCount { get; set; }

      [Category("Default"),
       DisplayName("Sposób poruszania"),
       Description("Numer metody wyliczania kolejnego ruchu")]
       public int MoveMethod { get; set; }

      [Category("Default"),
       DisplayName("Rotacja kolorów"),
       Description("Metoda zamiany składowych koloru (0 - bez zmiany)")]
       public int ColorShift { get; set; }
       
      [Category("Default"),
       DisplayName("Lista argumentów"),
       Description("Do odczytu: lista przekazanych argumentów")]
       public string ArgList { get; set; }
       
       public ScreenEaterConfig()
       {
          this.scrRun = true;
          this.EatersCount = 20;
          this.DiffSuppression = .5;
          this.HeadDiameter = 7;
          this.ShowButtons = false;
          this.ArgCount = 0;
          this.ArgList = "";

          this.dimFactor = 3;
          this.ShowHeads = false;
          this.FillHeads = false;
          this.MoveMethod = 0;
          this.ColorShift = 0;
       }
   }
}
