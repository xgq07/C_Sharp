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
            // server=127.0.0.1/localhost ���������˿ں�portĬ����3306���Բ�д
            MySqlConnection conn = new MySqlConnection(connetStr);
            try
            {
                conn.Open();//��ͨ�����������ӣ����ܳ����쳣,ʹ��try catch���
                Console.WriteLine("�Ѿ���������");
                //������ʹ�ô�������ݿ������ɾ���
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