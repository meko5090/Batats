using Batats.ExcelDb;

namespace Batats
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtScale_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var scal = float.Parse(txtScale.Text);
                var percent = float.Parse(txtDiscount.Text);
                txtNet.Text = (scal - ((percent / 100) * scal)).ToString();
            }
            catch (Exception)
            {

                txtNet.Text = "0";
            }
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var scal = float.Parse(txtScale.Text);
                var percent = float.Parse(txtDiscount.Text);
                txtNet.Text = (scal - ((percent / 100) * scal)).ToString();
            }
            catch (Exception)
            {

                txtNet.Text = string.Empty;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB.ExecuteCommand($"INSERT INTO [Sheet1$] ([id],[farmer])  VALUES({0}, '{txtFarmer.Text}')");
            MessageBox.Show("تمام");
        }
    }
}