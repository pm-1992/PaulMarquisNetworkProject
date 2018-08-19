using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    { 
        public nodeGraph G = new nodeGraph();
        public Form1()
        {
            InitializeComponent();
        }
        
        void drawUI()
        {
            //Set all image boxes to passive state for pre-emptive cleanup
            n0.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n1.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n2.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n3.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n4.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n5.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n6.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n7.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n8.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n9.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n10.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            n11.Image = WindowsFormsApp1.Properties.Resources.Node_Passive;
            l12.Image = WindowsFormsApp1.Properties.Resources.link_Passive;
            l13.Image = WindowsFormsApp1.Properties.Resources.link_Passive;
            l14.Image = WindowsFormsApp1.Properties.Resources.link_Passive;
            l15.Image = WindowsFormsApp1.Properties.Resources.Link_vpassive;
            l16.Image = WindowsFormsApp1.Properties.Resources.Link_vpassive;
            l17.Image = WindowsFormsApp1.Properties.Resources.Link_vpassive;
            l18.Image = WindowsFormsApp1.Properties.Resources.link_Passive;
            l19.Image = WindowsFormsApp1.Properties.Resources.link_Passive;
            l20.Image = WindowsFormsApp1.Properties.Resources.link_Passive;
            l21.Image = WindowsFormsApp1.Properties.Resources.Link_vpassive;
            l22.Image = WindowsFormsApp1.Properties.Resources.Link_vpassive;
            l23.Image = WindowsFormsApp1.Properties.Resources.Link_vpassive;
            l24.Image = WindowsFormsApp1.Properties.Resources.Link_vpassive;
            l25.Image = WindowsFormsApp1.Properties.Resources.link_Passive;
            l26.Image = WindowsFormsApp1.Properties.Resources.link_Passive;

            //Check if a solution was possible, update the UI.
            sanityLabel.Visible = !G.solFound;
            Console.WriteLine("SolFound is {0}", G.solFound);

            //Change solution path to green
            foreach (int z in G.solution)
            {

                switch (z)
                {
                    case 0:
                        n0.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 1:
                        n1.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 2:
                        n2.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 3:
                        n3.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 4:
                        n4.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 5:
                        n5.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 6:
                        n6.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 7:
                        n7.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 8:
                        n8.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 9:
                        n9.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 10:
                        n10.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 11:
                        n11.Image = WindowsFormsApp1.Properties.Resources.Node_active;
                        break;
                    case 12:
                        l12.Image = WindowsFormsApp1.Properties.Resources.Link_active;
                        break;
                    case 13:
                        l13.Image = WindowsFormsApp1.Properties.Resources.Link_active;
                        break;
                    case 14:
                        l14.Image = WindowsFormsApp1.Properties.Resources.Link_active;
                        break;
                    case 15:
                        l15.Image = WindowsFormsApp1.Properties.Resources.Link_vactive;
                        break;
                    case 16:
                        l16.Image = WindowsFormsApp1.Properties.Resources.Link_vactive;
                        break;
                    case 17:
                        l17.Image = WindowsFormsApp1.Properties.Resources.Link_vactive;
                        break;
                    case 18:
                        l18.Image = WindowsFormsApp1.Properties.Resources.Link_active;
                        break;
                    case 19:
                        l19.Image = WindowsFormsApp1.Properties.Resources.Link_active;
                        break;
                    case 20:
                        l20.Image = WindowsFormsApp1.Properties.Resources.Link_active;
                        break;
                    case 21:
                        l21.Image = WindowsFormsApp1.Properties.Resources.Link_vactive;
                        break;
                    case 22:
                        l22.Image = WindowsFormsApp1.Properties.Resources.Link_vactive;
                        break;
                    case 23:
                        l23.Image = WindowsFormsApp1.Properties.Resources.Link_vactive;
                        break;
                    case 24:
                        l24.Image = WindowsFormsApp1.Properties.Resources.Link_vactive;
                        break;
                    case 25:
                        l25.Image = WindowsFormsApp1.Properties.Resources.Link_active;
                        break;
                    case 26:
                        l26.Image = WindowsFormsApp1.Properties.Resources.Link_active;
                        break;
                }
            }
            
            //Highlight failed nodes in red
            foreach (int z in G.badNodes)
            {
                switch (z)
                {
                    case 0:
                        n0.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 1:
                        n1.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 2:
                        n2.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 3:
                        n3.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 4:
                        n4.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 5:
                        n5.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 6:
                        n6.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 7:
                        n7.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 8:
                        n8.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 9:
                        n9.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 10:
                        n10.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 11:
                        n11.Image = WindowsFormsApp1.Properties.Resources.Node_Break;
                        break;
                    case 12:
                        l12.Image = WindowsFormsApp1.Properties.Resources.Link_Break;
                        break;
                    case 13:
                        l13.Image = WindowsFormsApp1.Properties.Resources.Link_Break;
                        break;
                    case 14:
                        l14.Image = WindowsFormsApp1.Properties.Resources.Link_Break;
                        break;
                    case 15:
                        l15.Image = WindowsFormsApp1.Properties.Resources.Link_vBreak;
                        break;
                    case 16:
                        l16.Image = WindowsFormsApp1.Properties.Resources.Link_vBreak;
                        break;
                    case 17:
                        l17.Image = WindowsFormsApp1.Properties.Resources.Link_vBreak;
                        break;
                    case 18:
                        l18.Image = WindowsFormsApp1.Properties.Resources.Link_Break;
                        break;
                    case 19:
                        l19.Image = WindowsFormsApp1.Properties.Resources.Link_Break;
                        break;
                    case 20:
                        l20.Image = WindowsFormsApp1.Properties.Resources.Link_Break;
                        break;
                    case 21:
                        l21.Image = WindowsFormsApp1.Properties.Resources.Link_vBreak;
                        break;
                    case 22:
                        l22.Image = WindowsFormsApp1.Properties.Resources.Link_vBreak;
                        break;
                    case 23:
                        l23.Image = WindowsFormsApp1.Properties.Resources.Link_vBreak;
                        break;
                    case 24:
                        l24.Image = WindowsFormsApp1.Properties.Resources.Link_vBreak;
                        break;
                    case 25:
                        l25.Image = WindowsFormsApp1.Properties.Resources.Link_Break;
                        break;
                    case 26:
                        l26.Image = WindowsFormsApp1.Properties.Resources.Link_Break;
                        break;
                }
            }


        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
               //Assign default test values to combo boxes
            comboFailed.Text = "0";
            comboSource.Text = "0";
            comboDestination.Text = "3";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void node_1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void run_Click(object sender, EventArgs e)
        {
           G.solve();
        }

        private void stop_Click(object sender, EventArgs e)
        {

        }

        private void pickNewStart_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void sanityLabel_Click(object sender, EventArgs e)
        {

        }

        private void comboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            G.source = Convert.ToInt32(comboSource.Text);
        }

        private void comboDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            G.dest = Convert.ToInt32(comboDestination.Text);
        }

        private void comboFailed_SelectedIndexChanged(object sender, EventArgs e)
        {
            G.rz = Convert.ToInt32(comboFailed.Text);
        }





        /* Sets control variables in the graph object to user selected values.
         * Calls the solve function, updates the UI, then clears container variables for next attempt.
         **/
        private void solveButton_Click(object sender, EventArgs e)
        {
            G.source = Convert.ToInt32(comboSource.Text);
            G.dest = Convert.ToInt32(comboDestination.Text); 
            G.rz = Convert.ToInt32(comboFailed.Text);
            G.solve();
            drawUI();
            G.reset();
        }
    }
}
