using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco {
    public class ContaPoupanca : Conta {

        //	Estamos	chamando	o	construtor	da	classe	pai	que	já	faz	a	inicialização
        //	do	número	e	por	isso	o	corpo	do	construtor	pode	ficar	vazio.

        public override void Deposita(double valor) {
            this._saldo += (valor - 0.05);
        }

        public override void Saca(double valor) {
            if(valor < 0.0) {
                throw new Exception();
            }

            if(this._saldo >= valor && valor > 0) {
                if(this.Titular.EhMaiorDeIdade()) {
                    this._saldo -= (valor + 0.10);
                } else if(valor <= 200) {
                    this._saldo -= (valor + 0.10);
                } else {
                    throw new MenorDeIdade();
                }
            } else {
                throw new ValorAcimaDoSaldo();
            }
        }
    }
}
