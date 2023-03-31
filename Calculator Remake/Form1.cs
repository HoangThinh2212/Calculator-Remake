namespace Calculator_Remake
{
    public partial class Calculator : Form
    {

        double resultValue = 0;
        double resultCanBacHai = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }
        // Hàm dành cho các số từ 0 -> 9 và dấu .
        private void button_Click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || (isOperationPerformed))
            {
                textBox_Result.Clear();
            }

            isOperationPerformed = false;

            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!textBox_Result.Text.Contains("."))
                {
                    textBox_Result.Text = textBox_Result.Text + button.Text;
                }
            }
            else
            {
                textBox_Result.Text = textBox_Result.Text + button.Text;
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                button6.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
                textBox_Result.Clear() ;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
                textBox_Result.Clear();
            }
        }

        // nút CE
        private void button16_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }
        // nút C
        private void button17_Click(object sender, EventArgs e)
        {
            labelCurrentOperation.Text = "";
            textBox_Result.Text = "0";
            resultValue = 0;
        }

        // Dấu =
        private void button6_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    if (resultCanBacHai != 0)
                    {
                        textBox_Result.Text = (resultValue + resultCanBacHai ).ToString();
                        resultCanBacHai = 0;
                    }
                    else
                    {
                        textBox_Result.Text = (resultValue + double.Parse(textBox_Result.Text)).ToString();
                    }
                    break;
                case "-":
                    textBox_Result.Text = (resultValue - double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "x":
                    textBox_Result.Text = (resultValue * double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "÷":
                    textBox_Result.Text = (resultValue / double.Parse(textBox_Result.Text)).ToString();
                    break;

                default:
                    break;
            }

            resultValue = double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
            operationPerformed = "";
        }
        // Nút %
        private void button15_Click(object sender, EventArgs e)
        {

        }
        // Nút căn bậc 2
        private void button20_Click(object sender, EventArgs e)
        {
            double bienLuuTamThoi = 0;
            bienLuuTamThoi = double.Parse(textBox_Result.Text);
            resultCanBacHai = Math.Sqrt(bienLuuTamThoi);
            labelCurrentOperation.Text = labelCurrentOperation.Text + resultCanBacHai;
        }
    }
}