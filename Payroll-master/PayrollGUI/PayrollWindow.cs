using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Payroll.UI;
using MySql.Data.MySqlClient;


namespace PayrollGUI
{
    public partial class PayrollWindow : Form, PayrollView
    {
        private PayrollPresenter presenter;

        public PayrollWindow()
        {
            InitializeComponent();
            //TestMySql();
        }

        private void TestMySql()
        {
       
            String connetStr = "server=localhost;port=3306;user=root;password=123456; database=payroll;";
            // server=127.0.0.1/localhost 代表本机，端口号port默认是3306可以不写
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句
                Console.WriteLine("已经建立连接");
                //在这里使用代码对数据库进行增删查改
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public string TransactionsText
        {
            set { transactionsTextBox.Text = value; }
        }

        public string EmployeesText
        {
            set { employeesTextBox.Text = value; }
        }

        public PayrollPresenter Presenter
        {
            get { return presenter; }
            set { presenter = value; }
        }

        private void addEmployeeMenuItem_Click(object sender, EventArgs e)
        {
            presenter.AddEmployeeActionInvoked();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            presenter.RunTransactions();
        }
    }
}