using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;
       
        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);

            //kp = new KeyPressEventHandler(key_Press);
            //this.KeyPress += kp; 
           // kd = new KeyEventHandler(key_Down);
            this.KeyDown += new KeyEventHandler(key_Down); // this works only when the control(form) has focus
            // you can also use anonymous EventHandler like this...
            // this.KeyPress += new KeyPressEventHandler(yourMethod);
        }

        //private KeyPressEventHandler kp;
        //private KeyEventHandler kd;

        private void key_Press(object sender, KeyPressEventArgs e)
        {
            // todo : check if arrow key up is pressed then call something to perform up
        }
        private void key_Down(object sender, KeyEventArgs e)
        {
            // todo : check if arrow key xx is down then call something to perform xx
            if(e.KeyData == Keys.Right || e.KeyData == Keys.D)
            {
                controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                //btnRight.Focus(); 
            }
            else if (e.KeyData == Keys.Left || e.KeyData == Keys.A)
            {
                controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                //btnLeft.Focus();
            }
            else if (e.KeyData == Keys.Up || e.KeyData == Keys.W)
            {
                controller.ActionPerformed(TwoZeroFourEightController.UP);
                //btnUp.Focus();
            }
            else if (e.KeyData == Keys.Down || e.KeyData == Keys.S)
            {
                controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                //btnDown.Focus();
            }

            //switch(e.KeyData)
            //{
            //    case Keys.Right:
            //    case Keys.D:
            //        controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
            //        btnRight.Focus();
            //        break;
            //}
        }

        public void Notify(Model m)
        {
            UpdateBoard(((TwoZeroFourEightModel) m).GetBoard());
            UpdateScore(((TwoZeroFourEightModel)m).GetScore());
            UpdateGameStatus(((TwoZeroFourEightModel) m).GameOver());
        }

        private void UpdateGameStatus(bool i)
        {
           if(i == true){lblScore.Text = "GameOver.";}
        }

        private void UpdateScore(int i)
        {
            lblScore.Text = i.ToString();
        }

        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            } else {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.Gray;
                    break;
                case 2:
                    l.BackColor = Color.DarkGray;
                    break;
                case 4:
                    l.BackColor = Color.Orange;
                    break;
                case 8:
                    l.BackColor = Color.Red;
                    break;
                default:
                    l.BackColor = Color.Green;
                    break;
            }
        }
        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00,board[0, 0]);
            UpdateTile(lbl01,board[0, 1]);
            UpdateTile(lbl02,board[0, 2]);
            UpdateTile(lbl03,board[0, 3]);
            UpdateTile(lbl10,board[1, 0]);
            UpdateTile(lbl11,board[1, 1]);
            UpdateTile(lbl12,board[1, 2]);
            UpdateTile(lbl13,board[1, 3]);
            UpdateTile(lbl20,board[2, 0]);
            UpdateTile(lbl21,board[2, 1]);
            UpdateTile(lbl22,board[2, 2]);
            UpdateTile(lbl23,board[2, 3]);
            UpdateTile(lbl30,board[3, 0]);
            UpdateTile(lbl31,board[3, 1]);
            UpdateTile(lbl32,board[3, 2]);
            UpdateTile(lbl33,board[3, 3]);
        }

     

        private void btnLeft_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.DOWN);
        }

    }
}
