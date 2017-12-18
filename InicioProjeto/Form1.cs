using BL;
using System;
using System.Windows.Forms;

namespace InicioProjeto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mensageiro_Click(object sender, EventArgs e)
        {
            new RunMessenger().StartChangeXML();
        }
    }
}
