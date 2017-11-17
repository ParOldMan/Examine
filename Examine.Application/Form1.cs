using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examine.Domain.Events;
using Examine.Events.handlers;
using Examine.Events;
using Examine.Domain.Model;

namespace Examine.Applications
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventButs eventButs = new EventButs();
            HeadquartersEvent events = new HeadquartersEvent();
            events.headquarters = new Domain.Model.Headquarters();
            events.headquarters.业户名称 = "昆明交通运输集团";
            events.headquarters.核发日期 = new DateTime(2017,10,1,12,10,00);
            events.headquarters.经营范围 = "市";
            MessageBox.Show("数据添加成功\n提交行业审核");

            ExamineEventHandler handler = new ExamineEventHandler();

            //handler.Handle(events);
            //EventButs.Instance.Subscribe(new HeadquartersEvent());
            //eventButs..Subscribe(Headquarters);

            if (handler.headquarters != null)
            {
                MessageBox.Show("待审核总公司："+ handler.headquarters.业户名称+ "\n+++++++审核内容+++++++\n经营范围："+ handler.headquarters.经营范围+ "\n核发日期："+ handler.headquarters.核发日期);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
