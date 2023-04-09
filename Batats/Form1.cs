using Batats.ExcelDb;

namespace Batats;

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

    private void Form1_Load(object sender, EventArgs e) { 
        FillGrid();

        var x = new AutoCompleteStringCollection();
        x.AddRange(DB.GetData("select [الفلاح] from [karta$]").Rows[0].ItemArray.Select(c=>c.ToString()).ToArray());
        txtFarmer.AutoCompleteCustomSource = x;

    }

    private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }

    private void button1_Click(object sender, EventArgs e)
    {
        DB.ExecuteCommand(
            $"INSERT INTO [karta$]  VALUES( '{txtFarmer.Text}','{comboBox1.Text}','{txtKarta.Value}','{txtTaqawy.Text}','{txtScale.Value}','{dateTimePicker1.Value.ToShortDateString()}','{txtDiscount.Value}','{txtNet.Value}')"
        );
        FillGrid();
        clear();
        MessageBox.Show("تمام");
    }

    void clear()
    {
        Action<Control.ControlCollection> func = null;

        func = (controls) =>
        {
            foreach (Control control in controls)
                if (control is TextBox)
                    (control as TextBox).Clear();
                else
                    func(control.Controls);
        };

        func(Controls);
    }
    void FillGrid()
    {

        dataGridView1.DataSource = DB.GetData("select * from [karta$]");
    }
}
