using System.Net;
using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class Main : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool AllocConsole();

        public Main()
        {
            InitializeComponent();
        }

        private void Host_btn_Click(object sender, EventArgs e)
        {
            MainMenu_p.Visible = false;
            Host_p.Visible = true;
        }

        private void Join_btn_Click(object sender, EventArgs e)
        {
            MainMenu_p.Visible = false;
            Join_p.Visible = true;
        }

        private void HostReturn_btn_Click(object sender, EventArgs e)
        {
            MainMenu_p.Visible = true;
            Host_p.Visible = false;
        }

        private void JoinReturn_btn_Click(object sender, EventArgs e)
        {
            MainMenu_p.Visible = true;
            Join_p.Visible = false;
        }

        private void Connect_btn_Click(object sender, EventArgs e)
        {
            CheckData(JoinIP_tb.Text, JoinPort_tb.Text);
        }

        private void Start_btn_Click(object sender, EventArgs e)
        {
            CheckData(HostIP_tb.Text, HostPort_tb.Text);
        }

        private void JoinIP_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void JoinPort_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void HostIP_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void HostPort_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CheckData(string ip, string port)
        {
            if (!IPAddress.TryParse(ip, out IPAddress iPAddress))
            {
                MessageBox.Show($"'{ip}' is not a valid ip adress!");
                return;
            }

            if (port is null or "")
            {
                MessageBox.Show($"You must enter a Port!");
                return;
            }

            AllocConsole();
            Console.WriteLine($"IP: {iPAddress}, Port: {port}");
        }
    }
}
