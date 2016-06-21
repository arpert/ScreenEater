/*
 * Utworzone przez SharpDevelop.
 * Użytkownik: admin
 * Data: 2011-09-13
 * Godzina: 14:36
 * 
 * Do zmiany tego szablonu użyj Narzędzia | Opcje | Kodowanie | Edycja Nagłówków Standardowych.
 */
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace ScreenEater
{
   /// <summary>
   /// Class with program entry point.
   /// </summary>
   internal sealed class Program
   {
      enum Action { run, config, preview, none};
      public static ScreenEaterConfig _config = new ScreenEaterConfig();

      /// <summary>
      /// Program entry point.
      /// </summary>
      [STAThread]
      private static void Main(string[] args)
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);

         string cfgPath;
         cfgPath = Application.ExecutablePath;
         int n = cfgPath.LastIndexOf('\\');
         if (n >= 0) 
         {
            cfgPath = cfgPath.Substring(0, n + 1);
         }

         string cfgFileName  = "ScreenEater.cfg";

         try {
            Object obj = ScreenEaterConfig.instance; 
            loadCfg(cfgPath + cfgFileName, ref obj);
            ScreenEaterConfig.instance = (ScreenEaterConfig)obj;
            if (ScreenEaterConfig.instance.HeadColor == System.Drawing.Color.Empty)
                ScreenEaterConfig.instance.HeadColor = System.Drawing.Color.HotPink;
         } catch (Exception e) 
         {
            Console.WriteLine(e.Message);
         }

	     Action action = Action.none;	

	     if (args.Length > 0)
		 {
		         if (args[0].ToLower().Trim().Substring(0,2) == "/c") { action = Action.config; }
		    else if (args[0].ToLower() == "/s") { action = Action.run; } // load the screensaver
		    else if (args[0].ToLower() == "/p") { action = Action.preview; }// load the preview
         }         
         ScreenEaterConfig.instance.scrRun = false;
	     switch (action)
         {
            case Action.config: 
		         ScreenEaterConfig.instance.scrRun = true;
	            PropertyForm prpf = new PropertyForm();
               prpf.con = ScreenEaterConfig.instance;
		         prpf.ShowDialog();
		       break;
            case Action.preview: 
		         ScreenEaterConfig.instance.scrRun = true;
//	     		 MessageBox.Show("Preview not available", "Message"); 
	     		 IntPtr parentHWnd = new IntPtr(long.Parse(args[1]));
	     		 MainForm frm = new MainForm(Screen.AllScreens.GetLowerBound(0));
	     		 frm.setParentHandle(parentHWnd);
	     		 
//	     		 Application.Run(frm);
	     	   break;
            case Action.run: 
		         ScreenEaterConfig.instance.scrRun = true;
               for (int i = Screen.AllScreens.GetLowerBound(0); 
                    i <= Screen.AllScreens.GetUpperBound(0); i++)
		         {
	                MainForm screensaver = new MainForm(i);
	                screensaver.Show();
	            }   
               Application.Run();
	     		  break;
            default:
	     		 Application.Run(new MainForm(Screen.AllScreens.GetLowerBound(0))); 
	     	   break;
         }

         ScreenEaterConfig.instance.ArgCount = args.Length;
         ScreenEaterConfig.instance.ArgList = "";
	     for(int i = 0; i < args.Length; i++)
	     {  
             if (i != 0) ScreenEaterConfig.instance.ArgList += ", ";
             ScreenEaterConfig.instance.ArgList += args[i];
	     }
	     
	     try {
             saveCfg(cfgPath + cfgFileName, ScreenEaterConfig.instance);
         } catch (Exception e)
         {
	        Console.WriteLine(e.Message);
	        MessageBox.Show(e.Message, "Error");
         }
      }
          

      private static void saveCfg(string filename, Object dico)
      {
         // Create an instance of the XmlSerializer class;
         // specify the type of object to serialize.
         XmlSerializer serializer = new XmlSerializer(dico.GetType());
         TextWriter writer = new StreamWriter(filename);
          
         serializer.Serialize(writer, dico);
         writer.Close();
      }
    
      private static void loadCfg(string filename, ref Object dico)
      {
         // Create an instance of the XmlSerializer class;
         // specify the type of object to be deserialized.
         XmlSerializer serializer = new XmlSerializer(dico.GetType());
   
         /* If the XML document has been altered with unknown
         nodes or attributes, handle them with the 
         UnknownNode and UnknownAttribute events.*/
         serializer.UnknownNode += new 
         XmlNodeEventHandler(serializer_UnknownNode);
         serializer.UnknownAttribute += new 
         XmlAttributeEventHandler(serializer_UnknownAttribute);
      
         // A FileStream is needed to read the XML document.
         FileStream fs = new FileStream(filename, FileMode.Open);
         // Declare an object variable of the type to be deserialized.
   
         /* Use the Deserialize method to restore the object's state with
         data from the XML document. */
         dico = serializer.Deserialize(fs);
         fs.Close();
      }
   
      private static void serializer_UnknownNode
      (object sender, XmlNodeEventArgs e)
      {
         Console.WriteLine("Unknown Node:" +   e.Name + "\t" + e.Text);
      }
   
      private static void serializer_UnknownAttribute
      (object sender, XmlAttributeEventArgs e)
      {
         System.Xml.XmlAttribute attr = e.Attr;
         Console.WriteLine("Unknown attribute " + 
         attr.Name + "='" + attr.Value + "'");
      }


   }
}
