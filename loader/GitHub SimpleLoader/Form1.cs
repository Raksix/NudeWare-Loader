//NudeWare Raksix Tarafından Düzenlenip SimpleLoader Sourcesi kullanılmıştır, https://github.com/WilsonPublic/SimpleLoader [Open Source Cheat Loader]
//This is very noob friendly and can easily be adapted, this has no form of protection against cracking so please come up with your own ideas on how to prevent cracking
//I recommend using Dot Net Reactor to protect your programs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManualMapInjection.Injection;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string HWID;

        private void Form1_Load(object sender, EventArgs e)
        {
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value; //Changing the variable "HWID (String)" to the WindowsIdentity Value, you can use any other forms of HWID, you can even use MAC/IP (Not recommended)
            textBox1.Text = HWID;
            textBox1.ReadOnly = true;
            checkonline();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkonline();
            WebClient wb = new WebClient();
            string HWIDLIST = wb.DownloadString("http://www.siteadınız.com/HWİD.txt"); //HWID linki yada LİSANS linki [Örnek: http://myurl.com/HWID.txt]
            if (HWIDLIST.Contains(textBox1.Text)) //You can add a "!" before the "HWIDLIST" and after the "if (" to make it into a blacklist HWID system instead of a whitelist HWID system
            {
                string mainpath = "C:\\Windows\\main.dll"; //Dll'Bilgisayara nereye kadeceği ve ismi NOT: değiştirmenize gerek yok
                wb.DownloadFile("http://www.siteadınız.com/cheat.dll", mainpath); //Dll'in nerede olduğunu buraya yazınız [Örnek: http://myurl.com/MYDLL.dll]
                var name = "csgo"; //csgo.exe yerine csgo tercih edilir [Örnek: For Team Fortress 2 you would replace it with "hl2"]
                var target = Process.GetProcessesByName(name).FirstOrDefault();
                var path = mainpath;
                var file = File.ReadAllBytes(path);

                //Dll bulunamadı yazısı
                if (!File.Exists(path))
                {
                    MessageBox.Show("DLL Bulunamadı!");
                    return;
                }
                
                //Injection, just leave this alone if you are a beginner
                var injector = new ManualMapInjector(target) { AsyncInjection = true };
                label2.Text = $"hmodule = 0x{injector.Inject(file).ToInt64():x8}";
                
                if (System.IO.File.Exists(mainpath)) //Checking if the DLL exists
                {
                    System.IO.File.Delete(mainpath); //Deleting the DLL
                }
            }
            else
            {
                MessageBox.Show("Lisansınız Yok");
            }
        }

        private void checkonline()
        {
            //Hilenin aktif yada kapalı yazısının bağlı olduğu site "https://google.com/"
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("https://google.com/"))
                    {
                        label1.ForeColor = Color.Green;
                        label1.Text = ("Aktif");
                    }
                }
            }
            catch
            {
                //If it does not get a response (This means the user is offline or google is down for some reason) it will Exit the application, you can stop this by removing "Application.Exit();"
                label1.ForeColor = Color.Red;
                label1.Text = ("Kapalı");
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(HWID);
            button2.Enabled = false;
            button2.Text = "Copied";
        }
    private void BunifuImageButton2_Click(object sender, EventArgs e)
        {

            this.Close();
            Application.Exit();

        }

        private void Button3_Click(object sender, EventArgs e)
        {



            checkonline();
            WebClient wb = new WebClient();
            
            
            {
                string mainpath = "C:\\Windows\\main.dll"; //You can change the path to wherever you want but just remember to use "\\" inst    ead of just one "\"
                wb.DownloadFile("", mainpath); //Ücretsiz hileniz varsa buraya ekleyebilrisiniz [Örnek: http://myurl.com/MYDLL.dll]
                var name = "csgo"; //Replace "csgo" with any exe you want [Example: For Team Fortress 2 you would replace it with "hl2"]
                var target = Process.GetProcessesByName(name).FirstOrDefault();
                var path = mainpath;
                var file = File.ReadAllBytes(path);

                //Checking if the DLL isn't found
                if (!File.Exists(path))
                {
                    MessageBox.Show("DLL Bulunamadı!");
                    return;
                }

                //Injection, just leave this alone if you are a beginner
                var injector = new ManualMapInjector(target) { AsyncInjection = true };
                label2.Text = $"hmodule = 0x{injector.Inject(file).ToInt64():x8}";

                if (System.IO.File.Exists(mainpath)) //Checking if the DLL exists
                {
                    System.IO.File.Delete(mainpath); //Deleting the DLL
                }
            }




        }
    }
}
