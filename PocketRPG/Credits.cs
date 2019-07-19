using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PocketRPG
{
    public partial class Credits : Form
    {
        public Credits()
        {
            InitializeComponent();
        }

        private void label3_ParentChanged(object sender, EventArgs e)
        {

        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}