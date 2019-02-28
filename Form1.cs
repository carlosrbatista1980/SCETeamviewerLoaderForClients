using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace SCETeamviewerLoaderForClients
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.notifyIcon1.Visible = false;
            Application.DoEvents();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            if (IsRunning() == null)
            {
                TeamviewerSCE();
            }
            else
            {
                MessageBox.Show("O Aplicativo já está em execução, operação cancelada");
                Process proc = Process.GetCurrentProcess();
                Process[] process = Process.GetProcessesByName(proc.ProcessName);
                foreach (Process p in process)
                {
                    if (process.Length > 1)
                    {
                        p.Kill();
                        //this.notifyIcon1.Visible = false;
                    }
                    process.SetValue(1, 1);
                    Application.DoEvents();
                    
                }
                
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AoFinalizarAplicacao(object sender, FormClosingEventArgs e)
        {
            
            Process proc = Process.GetCurrentProcess();
            Process[] process = Process.GetProcessesByName(proc.ProcessName);
            foreach (Process p in process)
            {
                if (process.Length > 0)
                    p.Kill();
                Dispose(true);
                this.notifyIcon1.Visible = false;                
                Application.Exit();
                Application.DoEvents();
                this.Close();
            }
            
        }

        private static Process IsRunning()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.
                         Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            
            return null;
        }

        private void TeamviewerSCE()
        {
            string team = "TeamViewer";
            
            try
            {
                Process[] proc = Process.GetProcessesByName(team);
                foreach (Process p in proc)
                {
                   p.Kill();
                }                
                File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "TeamViewerSCE -idcnpfu757.exe", Properties.Resources.TeamviewerSCE);
                Thread.Sleep(1000);
                Application.DoEvents();
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "TeamViewerSCE -idcnpfu757.exe");
                // colocar aqui o loading
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "");
                if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "TeamViewerSCE -idcnpfu757.exe"))
                    File.Delete(AppDomain.CurrentDomain.BaseDirectory + "TeamViewerSCE -idcnpfu757.exe");
                Application.Exit();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = true;
            Application.Exit();
        }
        

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormClosing += new FormClosingEventHandler(AoFinalizarAplicacao);
            Application.Exit();
        }


    }
}
