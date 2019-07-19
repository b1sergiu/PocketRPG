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
    public partial class Battle : Form
    {
        public Battle()
        {
            InitializeComponent();
        }

        private void Battle_Load(object sender, EventArgs e)
        {
            Encounter("Wolf", 100);
        }

        public class EnemyAttributes
        {
            public static int h;
            public static int es;
            public static int s;
            public static string animalName;
        }

        public void Encounter(string animal, int health)
        {
            EnemyAttributes.h = health;
            EnemyAttributes.es = 0;
            EnemyAttributes.s = 0;
            EnemyAttributes.animalName = animal;
        Prompt:
            //if (EnemyAttributes.h <= 0) goto Defeat;

            label1.Text = EnemyAttributes.animalName;
            System.Windows.Forms.MessageBox.Show("A wild " + animal + " appeared!");

            if (GameSettings.gameClass == "Warrior")
            {
                button1.Text = "Slash";
                button2.Text = "Hammer";
                button3.Text = "Night Sky";
                int attack = 0;
            }
            else if (GameSettings.gameClass == "Archer")
            {
                button1.Text = "Arrow";
                button2.Text = "Multi Arrow";
                button3.Text = "Volley";
                int attack = 0;
            }
            else if (GameSettings.gameClass == "Mage")
            {
                button1.Text = "Fireball";
                button2.Text = "Tornado";
                button3.Text = "Meteor Rain";
                int attack = 0;
            }
            AttackReady();
        }

        private void AttackReady()
        {
            button1.Enabled = true;
            if (EnemyAttributes.s >= 2)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }

            if (EnemyAttributes.s == 3)
            //Probably meant >=
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GameSettings.gameClass == "Warrior")
            {
                label2.Text = GameSettings.name + " used " + button1.Text + "! " + EnemyAttributes.animalName + " took 14 damage!";
                label2.Update(); //This one is necesarry, otherwise the label won't update and I have no idea why
                HealthUpdate(14);
            }
            else if (GameSettings.gameClass == "Archer")
            {
                label2.Text = GameSettings.name + " used " + button1.Text + "! " + EnemyAttributes.animalName + " took 15 damage!";
                label2.Update();
                HealthUpdate(15);
            }
            else if (GameSettings.gameClass == "Mage")
            {
                label2.Text = GameSettings.name + " used " + button1.Text + "! " + EnemyAttributes.animalName + " took 5 damage!";
                label2.Update();
                HealthUpdate(5);
            }
            EnemyAttributes.s++;
            EnemyAttack();
        }

        private void EnemyAttack()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            Thread.Sleep(3000);
            if (EnemyAttributes.es < 3)
            {
                label2.Text = EnemyAttributes.animalName + " used Claw! " + GameSettings.name + " took 5 damage!";
            }
            else
            {
                label2.Text = EnemyAttributes.animalName + " used Cursed Howl! " + GameSettings.name + " took 50 damage!";
                //EnemyAttributes.es = 0; was probably meant to be used here
            }
            EnemyAttributes.es++;
            AttackReady();
        }

        public void Defeat()
        {
            System.Windows.Forms.MessageBox.Show("You deafeated the " + EnemyAttributes.animalName + "!");
            Credits credits = new Credits();
            credits.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GameSettings.gameClass == "Warrior")
            {
                label2.Text = GameSettings.name + " used " + button2.Text + "! " + EnemyAttributes.animalName + " took 50 damage!";
                label2.Update();
                HealthUpdate(50);
            }
            else if (GameSettings.gameClass == "Archer")
            {
                label2.Text = GameSettings.name + " used " + button2.Text + "! " + EnemyAttributes.animalName + " took 45 damage!";
                label2.Update();
                HealthUpdate(45);
            }
            else if (GameSettings.gameClass == "Mage")
            {
                label2.Text = GameSettings.name + " used " + button2.Text + "! " + EnemyAttributes.animalName + " took 60 damage!";
                label2.Update();
                HealthUpdate(60);
            }
            EnemyAttributes.s = 0;
            EnemyAttack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (GameSettings.gameClass == "Warrior")
            {
                label2.Text = GameSettings.name + " used " + button3.Text + "! " + EnemyAttributes.animalName + " took 100 damage!";
                label2.Update();
                HealthUpdate(100);
            }
            else if (GameSettings.gameClass == "Archer")
            {
                label2.Text = GameSettings.name + " used " + button3.Text + "! " + EnemyAttributes.animalName + " took 150 damage!";
                label2.Update();
                HealthUpdate(150);
            }
            else if (GameSettings.gameClass == "Mage")
            {
                label2.Text = GameSettings.name + " used " + button3.Text + "! " + EnemyAttributes.animalName + " took 200 damage!";
                label2.Update();
                HealthUpdate(200);
            }
            EnemyAttributes.s = 0;
            EnemyAttack();
        }

        public void HealthUpdate(int healthUpdate)
        {
            EnemyAttributes.h = EnemyAttributes.h - healthUpdate;
            if (EnemyAttributes.h >= 0)
            {
                progressBar1.Value = EnemyAttributes.h;
            }
            else
            {
                progressBar1.Value = 0;
                Defeat();
            }
        }
    }
}