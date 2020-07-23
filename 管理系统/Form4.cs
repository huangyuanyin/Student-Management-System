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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from Teacher";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["Id"].ToString();
                b = dr["Name"].ToString();
                c = dr["Password"].ToString();
                d = dr["ZC"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接

        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form41 f = new Form41(this);
            f.ShowDialog();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a, b, c, d;
            a = dataGridView1.SelectedCells[0].Value.ToString();
            
            b = dataGridView1.SelectedCells[1].Value.ToString();
            c = dataGridView1.SelectedCells[2].Value.ToString();
            d = dataGridView1.SelectedCells[3].Value.ToString();
            string[] str = { a,b,c,d};
            Form41 f = new Form41(str,this);
            f.ShowDialog();

        }

        private void 删除学生系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r =  MessageBox.Show("确认删除吗？","",MessageBoxButtons.OKCancel);
            if (r==DialogResult.OK)
            {
                string tID = dataGridView1.SelectedCells[0].Value.ToString();
                string tName = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from Teacher where Id = '" + tID + "'and Name = '" + tName + "'";
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("删除成功");
                }
            }
            Table();
            
        }
    }
}
