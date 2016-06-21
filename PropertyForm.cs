/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: admin
 * Data: 2010-12-01
 * Godzina: 11:05
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenEater
{
   /// <summary>
   /// Description of PropertyForm.
   /// </summary>
   public partial class PropertyForm : Form
   {
      public Object con { get; set; }
      
      public PropertyForm()
      {
         //
         // The InitializeComponent() call is required for Windows Forms designer support.
         //
         InitializeComponent();
         
         //
         // TODO: Add constructor code after the InitializeComponent() call.
         //
      }
      
      void PropertyFormLoad(object sender, EventArgs e)
      {
         propertyGrid1.Name = "Właściwości";
//         propertyGrid1.PropertySort = PropertySort.NoSort;
         
         propertyGrid1.SelectedObject = con;
      }
   }
}
