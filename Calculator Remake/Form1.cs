namespace Calculator_Remake
{
    public partial class Calculator : Form
    {
        // Khai báo các biến 
        double resultValue = 0;
        double resultCanBacHai = 0;
        double resultBinhPhuong = 0;
        double resultThapPhan = 0;
        double resultMuMuoi = 0;
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

        // Hàm dành cho các nút phép toán
        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                button6.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed + " ";
                isOperationPerformed = true;
                textBox_Result.Clear();
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed + " ";
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
            switch (operationPerformed) // khác "" switch ( biến cần xét ) 
                                        // case .... :
                                        //        break;
            {
                case "+":
                    if ((resultCanBacHai != 0) || (resultBinhPhuong != 0) || (resultThapPhan != 0) || (resultMuMuoi != 0))
                    {
                        textBox_Result.Text = (resultValue + resultCanBacHai + resultBinhPhuong + resultThapPhan + resultMuMuoi).ToString();
                        resultCanBacHai = 0;
                        resultBinhPhuong = 0;
                        resultThapPhan = 0;
                    }
                    else
                    {
                        textBox_Result.Text = (resultValue + double.Parse(textBox_Result.Text)).ToString();
                    }
                    break;
                case "-":
                    if (resultCanBacHai != 0)
                    {
                        textBox_Result.Text = (resultValue - resultCanBacHai).ToString();
                        resultCanBacHai = 0;
                    }
                    else if (resultBinhPhuong != 0)
                    {
                        textBox_Result.Text = (resultValue - resultBinhPhuong).ToString();
                        resultBinhPhuong = 0;
                    }
                    else if (resultThapPhan != 0)
                    {
                        textBox_Result.Text = (resultValue - resultThapPhan).ToString();
                        resultThapPhan = 0;
                    }
                    else if (resultMuMuoi != 0)
                    {
                        textBox_Result.Text = (resultValue - resultMuMuoi).ToString();
                        resultMuMuoi = 0;
                    }
                    else
                    {
                        textBox_Result.Text = (resultValue - double.Parse(textBox_Result.Text)).ToString();
                    }
                    break;
                case "x":
                    if (resultCanBacHai != 0)
                    {
                        textBox_Result.Text = (resultValue * resultCanBacHai).ToString();
                        resultCanBacHai = 0;
                    }
                    else if (resultBinhPhuong != 0)
                    {
                        textBox_Result.Text = (resultValue * resultBinhPhuong).ToString();
                        resultBinhPhuong = 0;
                    }
                    else if (resultThapPhan != 0)
                    {
                        textBox_Result.Text = (resultValue * resultThapPhan).ToString();
                        resultThapPhan = 0;
                    }
                    else if (resultMuMuoi != 0)
                    {
                        textBox_Result.Text = (resultValue * resultMuMuoi).ToString();
                        resultMuMuoi = 0;
                    }
                    else
                    {
                        textBox_Result.Text = (resultValue * double.Parse(textBox_Result.Text)).ToString();
                    }
                    break;
                case "÷":
                    if (resultCanBacHai != 0)
                    {
                        textBox_Result.Text = (resultValue / resultCanBacHai).ToString();
                        resultCanBacHai = 0;
                    }
                    else if (resultBinhPhuong != 0)
                    {
                        textBox_Result.Text = (resultValue / resultBinhPhuong).ToString();
                        resultBinhPhuong = 0;
                    }
                    else if (resultThapPhan != 0)
                    {
                        textBox_Result.Text = (resultValue / resultThapPhan).ToString();
                        resultThapPhan = 0;
                    }
                    else if (resultMuMuoi != 0)
                    {
                        textBox_Result.Text = (resultValue / resultMuMuoi).ToString();
                        resultMuMuoi = 0;
                    }
                    else
                    {
                        textBox_Result.Text = (resultValue / double.Parse(textBox_Result.Text)).ToString();
                    }
                    break;

                default:
                    break;
            }

            resultValue = double.Parse(textBox_Result.Text);
            labelCurrentOperation.Text = "";
            operationPerformed = "";
        }
        // Nút bình phương
        private void button15_Click(object sender, EventArgs e)
        {
            double bienLuuTamThoi = 0;
            bienLuuTamThoi = double.Parse(textBox_Result.Text);
            resultBinhPhuong = Math.Pow(bienLuuTamThoi, 2);
            labelCurrentOperation.Text = labelCurrentOperation.Text + resultBinhPhuong;
            textBox_Result.Clear();
        }
        // Nút căn bậc 2
        private void button20_Click(object sender, EventArgs e)
        {
            double bienLuuTamThoi = 0;
            bienLuuTamThoi = double.Parse(textBox_Result.Text);
            resultCanBacHai = Math.Sqrt(bienLuuTamThoi);
            labelCurrentOperation.Text = labelCurrentOperation.Text + resultCanBacHai;
            textBox_Result.Clear();
        }
        // Nút 1 / x
        private void button22_Click(object sender, EventArgs e)
        {
            double bienLuuTamThoi = 0;
            bienLuuTamThoi = double.Parse(textBox_Result.Text);
            resultThapPhan = 1 / bienLuuTamThoi;
            labelCurrentOperation.Text = labelCurrentOperation.Text + resultThapPhan;
            textBox_Result.Clear();
        }
        // nút 10 ^ x
        private void button21_Click(object sender, EventArgs e)
        {
            double bienLuuTamThoi = 0;
            bienLuuTamThoi = double.Parse(textBox_Result.Text);
            resultMuMuoi = Math.Pow(10, bienLuuTamThoi);
            labelCurrentOperation.Text = labelCurrentOperation.Text + resultMuMuoi;
            textBox_Result.Clear();
        }
    }
}