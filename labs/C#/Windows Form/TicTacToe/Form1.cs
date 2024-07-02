using System.Runtime.InteropServices;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            Form form = new Board(txt_playerOneName.Text, txt_playerTwoName.Text);
            form.ShowDialog();
        }
    }
}
