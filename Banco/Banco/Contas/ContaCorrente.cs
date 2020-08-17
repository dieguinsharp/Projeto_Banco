using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco {
    public class ContaCorrente : Conta, ITributos{

        public double CalculaTributos() {
            return (this.Saldo * 0.05);
        }

        public override void Saca(double valor) {

            if(valor < 0.0) {
                throw new Exception();
            }

            if(this._saldo >= valor) {
                if(this.Titular.EhMaiorDeIdade()) {
                    this._saldo -= (valor + 0.05);
                } else if(valor <= 200) {
                    this._saldo -= (valor + 0.05);
                } else {
                    throw new MenorDeIdade();
                }
            }else {
                throw new ValorAcimaDoSaldo();
            }
            
        }
        public override void Deposita(double valor) {
            this._saldo += (valor - 0.10);
        }
    }
}
