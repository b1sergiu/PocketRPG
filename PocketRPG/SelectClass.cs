using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace PocketRPG
{
    public partial class SelectClass : Form
    {
        public SelectClass()
        {
            InitializeComponent();
        }

        private void label2_ParentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                GameSettings.gameClass = "Warrior";
            }
            else if (radioButton2.Checked == true)
            {
                GameSettings.gameClass = "Archer";
            }
            else if (radioButton3.Checked == true)
            {
                GameSettings.gameClass = "Mage";
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No class selected!");
                Application.Exit();
            }
            Overview overview = new Overview();
            overview.Show();
            this.Close();
        }
    }
}