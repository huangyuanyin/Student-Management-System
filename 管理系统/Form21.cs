using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 管理系统
{
    public partial class Form21 : Form
    {
        Form2 form2;
        string[] str = new string[5];
        public Form21(Form2 f)
        {
            InitializeComponent();
            button3.Visible = false;//插入时隐藏插入修改按钮
            form2 = f;

        }

        //用于修改，参数为一个数组
        public Form21(string[]a, Form2 f)
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            button1.Visible = false;//修改时隐藏插入保存按钮
            form2 = f;
        }

        //添加一条学生记录
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""|| textBox2.Text == "" || textBox3.Text == ""|| textBox4.Text == ""|| textBox5.Text == "")
            {
                MessageBox.Show("输入不完整，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into Student values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','123456')";
                MessageBox.Show(sql);
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("插入成功");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                    textBox5.Text = null;
                }
                form2.Table();
                this.Close();

            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("修改后有空项，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text!=str[0])
                {
                    string sql = "update Student set Id = '"+textBox1.Text+"'where Id = '"+str[0]+"'and Name = '"+str[1]+"'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[0] = textBox1.Text;
                }
                if (textBox2.Text!= str[1])
                {
                    string sql = "update Student set Name = '" + textBox2.Text + "'where Id = '" + str[0] + "'and Name = '" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[1] = textBox2.Text;
                }
                if (textBox3.Text != str[2])
                {
                    string sql = "update Student set Class = '" + textBox3.Text + "'where Id = '" + str[0] + "'and Name = '" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[2] = textBox3.Text;
                }
                if (textBox4.Text != str[3])
                {
                    string sql = "update Student set Birthday = '" + textBox4.Text + "'where Id = '" + str[0] + "'and Name = '" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[3] = textBox4.Text;
                }
                if (textBox5.Text != str[4])
                {
                    string sql = "update Student set JG = '" + textBox5.Text + "'where Id = '" + str[0] + "'and Name = '" + str[1] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[4] = textBox5.Text;
                }
                form2.Table();
                this.Close();
            }
        }
    }
}
