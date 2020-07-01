using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AverageCredit
{
    public partial class Form1 : Form
    {
        class Class
        {
            public double score;
            public double credit;

            public Class(double s, double c)
            {
                this.score = s;
                this.credit = c;
            }
        }

        List<Class> classes = new List<Class>();
        double totScore = 0;  //乘权值之后的总分
        double totCredit = 0; //总权值
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double score = 0;
            double credit = 0;
            Score.Focus();
            try
            {
                score = Convert.ToDouble(Score.Text);
                credit = Convert.ToDouble(Credit.Text);
                Score.Clear();
                Credit.Clear();
            }
            catch
            {
                FinalScore.Text = "数据异常!";
                return;
            }
            classes.Add(new Class(score, credit));
            totScore += score * credit;
            totCredit += credit;
            FinalScore.Text = (totScore / totCredit).ToString("#0.000");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            classes.Clear();
            totScore = 0;
            totCredit = 0;
            FinalScore.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (classes.Count == 0)
            {
                FinalScore.Text = "已都清空";
                return;
            }
            Class lastClass = classes.Last();
            totScore -= lastClass.score * lastClass.credit;
            totCredit -= lastClass.credit;
            classes.Remove(lastClass);
            if (totCredit == 0)
            {
                FinalScore.Text = "";
                return;
            }
            FinalScore.Text = (totScore / totCredit).ToString("#0.000");
        }
    }
}
