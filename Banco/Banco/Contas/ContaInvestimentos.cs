using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco {
    class ContaInvestimentos : Conta, ITributos {
        public double CalculaTributos() {
            return (this.Saldo * 0.3);
        }

        public override void Deposita(double valor) {
            this._saldo += valor;
        }

        public override void Saca(double valor) {
            if(valor < 0.0) {
                throw new Exception();
            }

            if(this._saldo >= valor && valor > 0) {
                if(this.Titular.EhMaiorDeIdade()) {
                    this._saldo -= (valor + 0.15);
                } else if(valor <= 200) {
                    this._saldo -= (valor + 0.15);
                } else {
                    throw new MenorDeIdade();
                }
            } else {
                throw new ValorAcimaDoSaldo();
            }
        }
    }

    
}
