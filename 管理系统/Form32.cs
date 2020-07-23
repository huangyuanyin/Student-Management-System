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
    public partial class Form32 : Form
    {

        string SID;
        public Form32()
        {
            
            InitializeComponent();
        }

        public Form32(string sid)
        {
            InitializeComponent();
            SID = sid;
            string sql = "select * from Student where id='"+SID+"'";
            Dao dao = new Dao();
            dao.read(sql);
            IDataReader dr = dao.read(sql);
            dr.Read();
            textBox1.Text = dr["Password"].ToString();
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "Update Student set Password = '"+textBox2.Text+"'where Id = '"+SID+"'";
            Dao dao = new Dao();
            int i = dao.Excute(sql);
            if (i>0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }
    }
}
