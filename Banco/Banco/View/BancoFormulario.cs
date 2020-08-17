using Banco.View;
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
    public partial class BancoFormulario:Form {

        private List<Conta> contas;
        private Dictionary<string, Conta> dicionario;

        public BancoFormulario() {
            InitializeComponent();
        }

        
        // PARA PASSAR OPCIONALMENTE NO CONSTRUTOR, CRIA SE 2 CONSTRUTORES, 1 SEM REFERENCIA E O OUTRO COM REFERENCIA                  

        public void AdicionaConta(Conta conta) {

            this.contas.Add(conta);

            cbxContas.Items.Add(conta);
            cbxTransferencia.Items.Add(conta);

            this.dicionario.Add(conta.Titular.Nome, conta);

        }

        private void Form1_Load(object sender,EventArgs e) {
            contas = new List<Conta>();
            this.dicionario = new Dictionary<string, Conta>();
        }

        private void btnDepositar_Click(object sender,EventArgs e) {

            Conta contaSelecionada = (Conta)cbxContas.SelectedItem;

            string valorDigitado = txtValor.Text;
            double valor = Convert.ToDouble(valorDigitado);

            contaSelecionada.Deposita(valor);

            txtSaldo.Text = Convert.ToString(contaSelecionada.Saldo);

            MessageBox.Show("Deposito concluído com sucesso!");
            
        }

        private void btnSacar_Click(object sender,EventArgs e) {

            Conta contaSelecionada = (Conta)cbxContas.SelectedItem;


            string valorSaque = txtValor.Text;
            double valor = Convert.ToDouble(valorSaque);

            try {
                contaSelecionada.Saca(valor);
                txtSaldo.Text = Convert.ToString(contaSelecionada.Saldo);
                MessageBox.Show("Saque realizado.");
            } catch(ValorAcimaDoSaldo) {
                MessageBox.Show("Saque não realizado, valor maior que o saldo.");
            } catch(MenorDeIdade) {
                MessageBox.Show("Você é menor de idade, portanto, saques maiores que 200R$ são negados.");
            } catch(Exception ex) {
                MessageBox.Show("Valor muito baixo para transferencia.");
            }
        }

        private void cbxContas_SelectedIndexChanged(object sender,EventArgs e) {
            int indice = cbxContas.SelectedIndex;
            Conta conta = this.contas[indice];

            txtNumero.Text = Convert.ToString(conta.Numero);
            txtSaldo.Text = Convert.ToString(conta.Saldo);
            txtTitular.Text = conta.Titular.Nome;
            txtTipoConta.Text = conta.tipoConta;
        }

        private void txtValorTransfer_TextChanged(object sender,EventArgs e) {
            
        }

        private void btnTransferir_Click(object sender,EventArgs e) {

            int indice1 = cbxTransferencia.SelectedIndex;
            int indice2 = cbxContas.SelectedIndex;

            try {
                this.contas[indice2].Transfere(Convert.ToDouble(txtValorTransfer.Text),this.contas[indice1]);
                MessageBox.Show("Transferencia realizada.");
            } catch(ValorAcimaDoSaldo ez) {
                MessageBox.Show("Transferencia não realizada, valor maior que o seu saldo.");
            } catch(MenorDeIdade ez) {
                MessageBox.Show("Você é menor de idade, portanto, as transferencias maiores que 200R$ são negadas.");
            } catch(Exception ez) {
                MessageBox.Show("Valor muito baixo para transferencia.");
            }

        }

        private void btnNovaConta_Click(object sender,EventArgs e) {

            /*ContaCorrente c = new ContaCorrente()
            {
                Numero = 1
            };

            ContaPoupanca cp = new ContaPoupanca()
            {
                Numero = 1
            };

            if (c.Equals(cp))
            {
                MessageBox.Show("iguais");
            }else
            {
                MessageBox.Show("Diferentes");
            }*/


            frmCadastroDeContas frm = new frmCadastroDeContas(this);
            frm.ShowDialog();
        }

        private void btnCalcularImpostos_Click(object sender,EventArgs e) {

            TotalizadorDeTributos tdt = new TotalizadorDeTributos();

            for(int x = 0; x < contas.Count; x++) {
                if(contas[x].tipoConta == "Conta Corrente") {

                    ContaCorrente cp = new ContaCorrente();
                    cp.Deposita(this.contas[x].Saldo);

                    tdt.Adiciona(cp);
                }
            }

            MessageBox.Show("Imposto Total: " + tdt.Total);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            string nomeTitular = txtBuscar.Text;

            try
            {
                Conta conta = dicionario[nomeTitular];

                txtNumero.Text = Convert.ToString(conta.Numero);
                txtSaldo.Text = Convert.ToString(conta.Saldo);
                txtTitular.Text = conta.Titular.Nome;
                txtTipoConta.Text = conta.tipoConta;

                cbxContas.SelectedItem = conta;
            }
            catch (KeyNotFoundException)
            {
                lblError.Text = "Conta inexistente.";
            }          
        }

        private void btnRelatorio_Click(object sender, EventArgs e)
        {
            frmRelatorio frm = new frmRelatorio(this.contas);
            frm.ShowDialog();
        }
    }
}
