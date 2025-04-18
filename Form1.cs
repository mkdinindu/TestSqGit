using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSqGit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            addVersionNumber();
            CheckForUpdate();
        }

        private async Task CheckForUpdate()
        {
            using(var manager = new UpdateManager(@"C:\Temp\Releases"))
            {
                await manager.UpdateApp();
            }
        }
        private void addVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            this.Text += $" v.{fileVersionInfo.FileVersion}";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
