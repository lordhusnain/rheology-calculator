using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        const double rc = (2.095 / 2) / 1000;
        const double Rcylinder = 4.775 / 1000;
        const double L = 8.0 / 1000;
        const double Rpiston = 4.737 / 1000;

        public double F
        {
            get
            {
                return Convert.ToDouble(txtMnom.Text.ToString()) * 9.81;
            }
        }

        public double V
        {
            get
            {
                return Am * Convert.ToDouble(txtLt.Text.ToString());
            }
        }

        public double Rm
        {
            get
            {
                return (Rcylinder + Rpiston) / 2;
            }
        }

        public double Am
        {
            get
            {
                return Math.Pow(Rm , 2) * 3.14;
            }
        }

        public Form1()
        {
            InitializeComponent();
            Calculate();
        }

        private void txtTime_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            var shearStress = (F * rc) / (2 * 3.142 * (Math.Pow(Rcylinder, 2)) * L);
            var shearRate = (4 * V) / (3.142 * Math.Pow(rc, 3) * Convert.ToDouble(txtTime.Text.ToString()));
            var viscosity = shearStress / shearRate;

            txtShearStress.Text = shearStress.ToString();
            txtShearRate.Text = shearRate.ToString();
            txtViscosity.Text = (shearStress / shearRate).ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
