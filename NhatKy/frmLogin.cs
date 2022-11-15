using NhatKy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhatKy
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += FrmLogin_KeyDown;
        }

        private void FrmLogin_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        Project_PRNContext context = new Project_PRNContext();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtAcc.Text.Trim()))
                {
                    MessageBox.Show("Chưa nhập Account!");
                    txtAcc.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(txtPass.Text.Trim()))
                {
                    MessageBox.Show("Chưa nhập Pass!");
                    txtPass.Focus();
                    return;
                }

                if (context.Users.Where(item => item.Account == txtAcc.Text && item.Password == txtPass.Text).Count() > 0)
                {
                    MessageBox.Show("Chào mừng " + txtAcc.Text + "!");
                    frmList f = new frmList(txtAcc.Text);
                    f.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
