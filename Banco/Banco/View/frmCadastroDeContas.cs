using Banco.Busca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco {
    public partial class frmCadastroDeContas:Form {

        private BancoFormulario frm;

        private ICollection<string> devedores;
        


        public frmCadastroDeContas(BancoFormulario bf) {
            this.frm = bf;
            InitializeComponent();

            Devedores gerador = new Devedores();
            this.devedores = gerador.GeraLista();
        }

        private void btnCadastrar_Click(object sender,EventArgs e) {

            string titular = txtTitular.Text;

            bool ehDevedor = this.devedores.Contains(titular);

            if (!ehDevedor)
            {
                Conta novaConta;

                if (cbxTipoConta.SelectedIndex == 0)
                {
                    novaConta = new ContaCorrente();
                    novaConta.tipoConta = "Conta Corrente";
                }
                else if (cbxTipoConta.SelectedIndex == 1)
                {
                    novaConta = new ContaPoupanca();
                    novaConta.tipoConta = "Conta Poupança";
                }
                else
                {
                    novaConta = new ContaInvestimentos();
                    novaConta.tipoConta = "Conta Investimentos";
                }

                novaConta.tipoConta = Convert.ToString(cbxTipoConta.SelectedItem);
                novaConta.Titular = new Cliente(txtTitular.Text, Convert.ToInt32(txtIdade.Text));

                this.frm.AdicionaConta(novaConta);
                this.Close();
            }
            else
            {
                MessageBox.Show("Você é um devedor.");
            }           
        }

        private void frmCadastroDeContas_Load(object sender,EventArgs e) {

            txtNumero.Text = Convert.ToString(Conta.ProxNumero());

            cbxTipoConta.Items.Add("Conta Corrente");
            cbxTipoConta.Items.Add("Conta Poupança");
            cbxTipoConta.Items.Add("Conta Investimentos");

            cbxTipoConta.SelectedIndex = 0;
        }

        private void txtNumero_TextChanged(object sender,EventArgs e) {

        }
    }
}
