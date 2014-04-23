using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using YAGCI_SHIPPING.Kls;
using System.Reflection;
using System.IO;

namespace YAGCI_SHIPPING
{
    static class Program
    {

        public static CultureInfo Cultur = null;

        public static string Versiyon
        {
            get
            {
                Assembly entryPoint = Assembly.GetEntryAssembly();

                // Get the name of the assembly.
                AssemblyName entryPointName = entryPoint.GetName();

                // Get the version.
                Version entryPointVersion = entryPointName.Version;

                return entryPointVersion.ToString();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //key:C79E-52F4-19E0-DE7F
            if (args != null && args.Length > 0 && args[0] != null && args[0].IndexOf("key") != -1)
            {
                string key = Lisans.CreateKey(args[0].Replace("key", "").Replace("-", "").Replace(":", "").Replace("=", "").ToUpper());
                Kls.Dlg.Bilgi(string.Format("Ürün anahtarı:{0}\nPanoya kopyalandı!", key));
                Clipboard.SetText(key, TextDataFormat.Text);
            }

            int snc =
                Process.GetProcesses().Where(x => x.ProcessName == Process.GetCurrentProcess().ProcessName)
                .Count();

            if (snc > 1)
            {
                MessageBox.Show("!...Dikkat...\nBu program zaten çalışıyor..\n..Dikkat..                 .....       ..              ..      .   ..  .                                                                  ....                                        ...");
                return;
            }


            Cultur = new CultureInfo("Tr-tr");

            Cultur.NumberFormat.CurrencyDecimalSeparator = ",";
            Cultur.NumberFormat.CurrencyGroupSeparator = ".";
            Cultur.NumberFormat.NumberDecimalSeparator = ",";
            Cultur.NumberFormat.NumberGroupSeparator = ".";

            Thread.CurrentThread.CurrentCulture = Cultur;

            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.Skins.SkinManager.EnableMdiFormSkins();
            DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
                        
            Application.Run(new Formlar.FormAnaEkran());
        }
    }
}
