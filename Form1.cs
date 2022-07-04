using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabalho2
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Label firstClicked = null;

        
        Label secondClicked = null;


        List<string> icons = new List<string>()
    {
        "d", "d", "e", "e", "Y", "Y", "~", "~",
        "b", "b", "e", "e", "h", "h", "A", "A"
    };
        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }
        private void AssignIconsToSquares()
        {
            
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    icons.RemoveAt(randomNumber);

                    iconLabel.ForeColor = iconLabel.BackColor;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // The timer is only on after two non-matching 
            // icons have been shown to the player, 
            // so ignore any clicks if the timer is running
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
              
                if (clickedLabel.ForeColor == Color.Black)
                    return;

            
                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }

               
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                CheckForWinner();

                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            
            firstClicked = null;
            secondClicked = null;
            
            

          
          
        }
        private void CheckForWinner()
        {
            
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("Parabens Voce Ganhou!", "Vencedor");
            Close();
        }
    }
}
