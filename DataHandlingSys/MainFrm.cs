using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DataHandlingSys
{
    public partial class MainFrm : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;        

        public MainFrm()
        {
            InitializeComponent();
            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            panel1.Top = 65;
            panel1.Height = this.Height;
            panel1.Width = this.Width;
            //mTabSelector.Left = 0;
            //mTabSelector.Top = 60;
            //mTabSelector.Width = this.Width;
            //mTabSelector.Height = 30;
            //mTabControl.Width = mTabSelector.Width;
            mTabControl.Top = 65;
            //mTabControl.Width = panel1.Width;
            //mTabControl.TabPages[0].Width = mTabSelector.Width;
            InitialTabPage();
        }

        private void mTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ChangeTabPage();
        }
        private void InitialTabPage()
        {
            Form frmFW = new FromWMSFrm();
            frmFW.Width = this.Width;
            frmFW.Height = this.Height;
            AddFormToTabpages("FromWMS", frmFW);
            Form frmTW = new ToWMSFrm();
            frmTW.Width = this.Width;
            frmTW.Height = this.Height;
            AddFormToTabpages("ToWMS", frmTW);
            Form frmLog = new LogFrm();
            frmLog.Width = this.Width;
            frmLog.Height = this.Height;
            AddFormToTabpages("LogWMS", frmLog);
        }
        //子窗体切换激活
        private void ChangeTabPage()
        {
            switch(mTabControl.SelectedIndex)
            {
                case 0:
                    Form frmFW = new FromWMSFrm();
                    frmFW.MaximizeBox = true;
                    frmFW.Visible = true;
                    break;
                case 1:
                    Form frmTW = new ToWMSFrm();
                    frmTW.MaximizeBox = true;
                    frmTW.Visible = true;
                    break;
                case 2:
                    Form frmLog = new LogFrm();
                    frmLog.MaximizeBox = true;
                    frmLog.Visible = true;
                    break;
                default:
                    break;
            }

        }
        //增加TabPage，将对应的窗体激活
        private void mTabControl_ControlAdded(object sender, ControlEventArgs e)
        {

        }
        //关闭TabPage，将对应的窗体关闭
        private void mTabControl_ControlRemoved(object sender, ControlEventArgs e)
        {
            //if (this.tabControl.SelectedIndex == 0)
            //this.ChangeTabPage();
        }

        private void AddFormToTabpages(string str, Form myForm)
        {
            if (!this.tabControlCheckHave(this.mTabControl, str))
            {
                this.mTabControl.TabPages.Add(str);
                this.mTabControl.SelectTab((int)(this.mTabControl.TabPages.Count - 1));
                myForm.FormBorderStyle = FormBorderStyle.None;
                myForm.TopLevel = false;
                myForm.MaximizeBox = true;
                myForm.Show();
                myForm.Parent = this.mTabControl.SelectedTab;
            }

        }
        public bool tabControlCheckHave(TabControl tab, string tabName) //看tabpage中是否已有窗体
        {
            for (int i = 0; i < tab.TabCount; i++)
            {
                if (tab.TabPages[i].Text == tabName)
                {
                    tab.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }

        private void mTabSelector_Click(object sender, EventArgs e)
        {

        }
    }
}
