using NhatKy.Models;

namespace NhatKy
{
    public partial class frmAdd : Form
    {
        public frmAdd()
        {
            InitializeComponent();
        }

        Project_PRNContext context = new Project_PRNContext();
        private void frmAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //Tạo đối tượng sẽ Add
                Diary d = new Diary
                {
                    Mood = txtMood.Text,
                    Time = dtpTime.Value,
                    Note = txtNote.Text,
                };

                //Add vào Context và Save
                context.Diaries.Add(d);
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Đã thêm nhật ký mới!");
                    frmList f = new frmList();
                    f.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMood.Text = "";
            dtpTime.ResetText();
            txtNote.ResetText();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn muốn thoát à?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
                Environment.Exit(0);
            }
        }

        private void frmAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}