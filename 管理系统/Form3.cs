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
    public partial class Form3 : Form
    {
        string SID;//记录登录选课系统的账户的学号
        public Form3(string sID)
        {
            SID = sID;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
            toolStripStatusLabel1.Text = "欢迎学号为" + SID + "的同学登录选课系统";
            timer1.Start();
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Course";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["Id"].ToString();
                b = dr["Name"].ToString();
                c = dr["Teacher"].ToString();
                d = dr["Credit"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接

        }


        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           string cID = dataGridView1.SelectedCells[0].Value.ToString();//获取选中的课程号
            string sql1 = "select *  from CourseRecord where sId = '"+SID+"'and cId = '"+cID+"'";
            Dao dao = new Dao();

            IDataReader dc = dao.read(sql1);

            if (!dc.Read())
            {
                MessageBox.Show("cdscsdcsdc");
                string sql = "insert into CourseRecord values('" + SID + "','" + cID + "')";
                MessageBox.Show(sql);
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("选课成功");
                }
                
            }
            else
            {
                MessageBox.Show("不允许重复选课");
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
            
            timer1.Start();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 我的课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 f = new Form31(SID);
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //设定列不能自动作成
            dataGridView1.AutoGenerateColumns = false;

        
        }

        private void 修改个人密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form32 f = new Form32(SID);
            f.ShowDialog();
        }
    }
}
