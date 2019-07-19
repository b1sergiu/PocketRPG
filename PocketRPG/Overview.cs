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
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
            label2.Text = "Name: " + GameSettings.name;
            label3.Text = "Class: " + GameSettings.gameClass;
        }

        private void label2_ParentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Battle battle = new Battle();
            battle.Show();
            this.Close();
        }
    }
}