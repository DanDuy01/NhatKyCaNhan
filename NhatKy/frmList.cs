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
    public partial class frmList : Form
    {
        public frmList()
        {
            InitializeComponent();
        }

        public frmList(string text)
        {
            InitializeComponent();
            Text = "Hello " + text;
        }

        Project_PRNContext context = new Project_PRNContext();
        private void frmList_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var data = context.Diaries.Select(item => new
            {
                Id = item.DiaryId,
                TamTrang = item.Mood,
                Ngay = item.Time,
                NhatKy = item.Note,
                YeuThich = item.Favourite,
            }).ToList();
            dtgDiary.DataSource = data;

            cboId.DataSource = data;
            cboId.DisplayMember = "DiaryId";
            cboId.ValueMember = "Id";

            //Binding dữ liệu lên Form
            cboId.DataSource = data;
            cboId.DataBindings.Clear();
            cboId.DataBindings.Add("Text", data, "Id");
            txtMood.DataBindings.Clear();
            txtMood.DataBindings.Add("Text", data, "TamTrang");
            dtpTime.DataBindings.Clear();
            dtpTime.DataBindings.Add("Text", data, "Ngay");
            txtNote.DataBindings.Clear();
            txtNote.DataBindings.Add("Text", data, "NhatKy");
            chbFav.DataBindings.Clear();
            chbFav.DataBindings.Add("Text", data, "YeuThich");

            chbFav.Click += ChbFav_Click;
            chbFav.Click += btnUpdate_Click;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAdd f = new frmAdd();
            f.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn muốn thoát à?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void frmList_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool fav = false;
            try
            {
                if (chbFav.Checked)
                {
                    fav = true;
                }

                //Tìm đối tượng sẽ Update
                Diary d = context.Diaries.FirstOrDefault(item => item.DiaryId == Int32.Parse(cboId.Text));
                if (d != null)
                {
                    d.Mood = txtMood.Text;
                    d.Time = DateTime.Now;
                    d.Note = txtNote.Text;
                    d.Favourite = fav;

                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Đã sửa nhật ký!");
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        private void ChbFav_Click(object? sender, EventArgs e)
        {
            if (!chbFav.Checked)
            {
                MessageBox.Show("Đã xóa khỏi Yêu thích!");
                return;
            }
            else
            {
                MessageBox.Show("Đã thêm vào mục Yêu thích!");
                return;
            }            
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //Tìm đối tượng sẽ Delete
                Diary d = context.Diaries.FirstOrDefault(item => item.DiaryId == Int32.Parse(cboId.Text));
                if (d != null)
                {
                    context.Diaries.Remove(d);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Xóa nhật ký thành công!");
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void btnFav_Click(object sender, EventArgs e)
        {
            var data = context.Diaries.Select(item => new
            {
                Id = item.DiaryId,
                TamTrang = item.Mood,
                Ngay = item.Time,
                NhatKy = item.Note,
                YeuThich = item.Favourite,
            }).Where(item => item.YeuThich.Value)
                .ToList();
            dtgDiary.DataSource = data;
        }

        private void dtgDiary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgDiary.Columns[e.ColumnIndex].Name == "Detail")
            {
                //var data = context.Diaries.Select(item => new
                //{
                //    Id = item.DiaryId,
                //    TamTrang = item.Mood,
                //    Ngay = item.Time,
                //    NhatKy = item.Note,
                //    YeuThich = item.Favourite,
                //}).ToList();
                //dtgDiary.DataSource = data;

                //cboId.DataSource = data;
                //cboId.DisplayMember = "DiaryId";
                //cboId.ValueMember = "Id";

                ////Binding dữ liệu lên Form
                //cboId.DataSource = data;
                //cboId.DataBindings.Clear();
                //cboId.DataBindings.Add("Text", data, "Id");
                //txtMood.DataBindings.Clear();
                //txtMood.DataBindings.Add("Text", data, "TamTrang");
                //dtpTime.DataBindings.Clear();
                //dtpTime.DataBindings.Add("Text", data, "Ngay");
                //txtNote.DataBindings.Clear();
                //txtNote.DataBindings.Add("Text", data, "NhatKy");
                //chbFav.DataBindings.Clear();
                //chbFav.DataBindings.Add("Text", data, "YeuThich");
            }
        }
    }
}
