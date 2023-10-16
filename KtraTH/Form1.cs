using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Entities;
using BUS;
namespace KtraTH
{
    public partial class Form1 : Form
    {
        private readonly LoaiSachService loaiSachService = new LoaiSachService();
        private readonly SachService sachService = new SachService();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                var listLoaisach = loaiSachService.GetAll();
                var listSach = sachService.GetAll();
                FillLoaisachCombobox(listLoaisach);
                BindGrid(listSach);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillLoaisachCombobox(List<LoaiSach> listLoaisach)
        {

            this.cmbTL.DataSource = listLoaisach;
            this.cmbTL.DisplayMember = "TenLoai";
            this.cmbTL.ValueMember = "MaLoai";
        }
        private void BindGrid(List<Sach> listSach)
        {
            dgvQLS.Rows.Clear();
            foreach (var item in listSach)
            {
                int index = dgvQLS.Rows.Add();
                dgvQLS.Rows[index].Cells[0].Value = item.MaSach;
                dgvQLS.Rows[index].Cells[1].Value = item.TenSach;
                dgvQLS.Rows[index].Cells[2].Value = item.NamXB;
                dgvQLS.Rows[index].Cells[3].Value = item.LoaiSach.TenLoai;
            }
        }

        private void dgvQLS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dgvQLS.Rows[e.RowIndex];

            txtMas.Text = row.Cells[0].Value.ToString();
            txtTens.Text = row.Cells[1].Value.ToString();
            txtNXB.Text = row.Cells[2].Value.ToString();
            cmbTL.Text = row.Cells[3].Value.ToString();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvQLS.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    dgvQLS.Rows.RemoveAt(dgvQLS.Rows[0].Index);
                    Sach s = new Sach();
                    string mas = txtMas.Text;
                    sachService.Delete(mas);
                }
                else
                {
                    MessageBox.Show("Sách cần xóa không tồn tại ", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (txtMas.Text == "" || txtTens.Text == "" || txtNXB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sách ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                dgvQLS.Rows.Add(txtMas.Text, txtTens.Text, int.Parse(txtNXB.Text),cmbTL.Text);
               
                Sach s = new Sach();
                s.MaSach = txtMas.Text;
                s.TenSach = txtTens.Text;
                s.NamXB = int.Parse(txtNXB.Text);
                s.MaLoai = int.Parse(cmbTL.SelectedValue.ToString());
                sachService.Add(s);
                MessageBox.Show("Thêm thành công!", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvQLS.SelectedRows.Count > 0)
            {
                string mas = txtMas.Text;

                string tens = txtTens.Text;
                int nxb = int.Parse(txtNXB.Text);
                int theloai = int.Parse(cmbTL.SelectedValue.ToString());

             
                

               
            }



        }
    }
}
