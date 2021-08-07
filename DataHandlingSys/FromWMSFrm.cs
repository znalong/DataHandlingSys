using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataHandlingSys
{
    public partial class FromWMSFrm : Form
    {
        public FromWMSFrm()
        {
            InitializeComponent();
        }

        private void FromWMSFrm_Load(object sender, EventArgs e)
        {
            sendPic.Left = 50;
            sendPic.Top = 20;
            sendPic.Width = splitContainer1.Panel2.Height - 300;
            sendPic.Height = sendPic.Width;

            labData.Top = sendPic.Height + sendPic.Top + 10;
            labData.Left = sendPic.Left;
            txtSendData.Top = labData.Top + 30;
            txtSendData.Width = sendPic.Width;
            txtSendData.Left = sendPic.Left;

            labList.Left = splitContainer1.Panel2.Width-sendPic.Width;
            labList.Top = sendPic.Top;
            listViewOrder.Left = labList.Left;
            listViewOrder.Top = labList.Top + 30;
            listViewOrder.Width = sendPic.Width-50;
            listViewOrder.Height = splitContainer1.Panel2.Height / 3;

            ReturnPic.Left = labList.Left;
            ReturnPic.Top = listViewOrder.Top + listViewOrder.Height+30;
            ReturnPic.Height = listViewOrder.Height+100;
            ReturnPic.Width = ReturnPic.Height;
        }        

        private void btnBedin_Click(object sender, EventArgs e)
        {
            Bitmap bmp = Encoder.code(txtSendData.Text, 1, 7, 200, 1, true);
            sendPic.Image = bmp;

            Bitmap rebmp = Encoder.code("131231312312312", 1, 7, 200, 1, true);
            ReturnPic.Image = rebmp;

        }
    }
}
