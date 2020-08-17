using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco.View
{
    public partial class frmRelatorio : Form
    {
        private List<Conta> contas;
        public frmRelatorio(List<Conta> conta)
        {
            this.contas = conta;
            InitializeComponent();
        }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {

        }

        private void btnMostrarSaldosMaior_Click(object sender, EventArgs e)
        {
            lstSaldos.Items.Clear();
            var contas = this.contas.Where(c => c.Saldo > 500);

            foreach (Conta c in contas)
            {
                lstSaldos.Items.Add((c.Titular.Nome).ToString());
            }
        }

        private void btnAntigas_Click(object sender, EventArgs e)
        {
            lstSaldos.Items.Clear();
            var contas = this.contas.Where(c => c.Saldo > 500 && c.Numero <= 3);

            foreach (Conta c in contas)
            {
                lstSaldos.Items.Add((c.Titular.Nome).ToString());
            }
        }
    }
}
