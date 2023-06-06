using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoBan_DateTimePicker_MonthCalendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*  Bắt đầu DateTimePicker  */
        private void Form1_Load(object sender, EventArgs e)
        {
            // Số điện thoại phải nhập 10 số
            txtSoDienThoai.MaxLength = 10;

            // Xử lý chức năng chỉ cho phép chọn thời gian đăng kí học lớn hơn thời gian hiện tại:
            int dayOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dateTimePickerThoiGian.MinDate = DateTime.Now;
            dateTimePickerThoiGian.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayOfMonth);
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar == ' ') || (e.KeyChar == (char)8)))
                e.Handled = true;
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if(txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập họ tên");
                txtHoTen.Clear();
                txtHoTen.Focus();
                return;
            }    
            if(txtSoDienThoai.Text.Trim().Length != 10)
            {
                MessageBox.Show("Bạn phải nhập số điện thoại bao gồm 10 số");
                txtSoDienThoai.Clear();
                txtSoDienThoai.Focus();
                return;
            }    
            if(txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập email");
                txtEmail.Clear();
                txtEmail.Focus();
                return;
            }

            DateTime ngayThang = dateTimePickerThoiGian.Value;
            MessageBox.Show("Chúc mừng bạn: " + txtHoTen.Text + "\nSố điện thoại: " + txtSoDienThoai.Text + "\nEmail:"
                + txtEmail.Text + "\nThời gian lựa chọn: " + ngayThang.ToString("dd/MM/yyyy"));
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            txtEmail.Clear();
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        /*  Kết thúc DateTimePicker  */
        

        /*  Bắt đầu Month Calendar  */
        
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            DateTime myDate = monthCalendar1.SelectionStart;
            txtSelectionStart.Text = myDate.ToString("dd/MM/yyyy");
            myDate = monthCalendar1.SelectionEnd;
            txtSelectionEnd.Text = myDate.ToString("dd/MM/yyyy");

            myDate = monthCalendar1.MinDate;
            txtMinDate.Text = myDate.ToString("dd/MM/yyyy");
            myDate = monthCalendar1.MaxDate;
            txtMaxDate.Text = myDate.ToString("dd/MM/yyyy");

            myDate = monthCalendar1.TodayDate;
            txtDayDate.Text = myDate.ToString("dd/MM/yyyy");
        }

        private void btnCountDay_Click(object sender, EventArgs e)
        {
            txtCountDay.Text = Convert.ToInt32((monthCalendar1.SelectionEnd - monthCalendar1.SelectionStart).TotalDays).ToString();
        }

        private void tbnCountHour_Click(object sender, EventArgs e)
        {
            txtCountHour.Text = Convert.ToInt32((monthCalendar1.SelectionEnd - monthCalendar1.SelectionStart).TotalHours).ToString();
        }
        /*  Kết thúc MonthCalendar  */
    }
}
