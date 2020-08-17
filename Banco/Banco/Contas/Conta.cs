using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco {
    public abstract class Conta {

        // ctor tab tab - cria um novo construtor
        // prop tab tab - cria uma nova propriedade
        // ctrl + r, ctrl + r (2x) renomeia nomes de classes automaticamente

        public Cliente Titular;
        protected double _saldo;
        protected int _numero;
        public string tipoConta;
        private static int _qtdDeContas;

        public Conta() {
            Conta._qtdDeContas++;
            this.Numero = Conta._qtdDeContas;
        }
        
        public static int ProxNumero() {
            return Conta._qtdDeContas + 1;
        }


        public double Saldo {
            get {
                return this._saldo;
            }
            private set {

            }
        }
        
        public int Numero {
            get {
                return this._numero;
            }
            set {
                this._numero = value;
            }
        }

        public void SetNumero(int numero) {
            this._numero = numero;
        }

        public void Transfere(double valor,Conta destino) {
            Saca(valor);
            destino.Deposita(valor);
        }

        //ABSTRACT DIZ QUE O MÉTODO ESTÁ IMCOMPLETO, FORÇANDO AS CLASSES FILHAS A SOBRESCREVÊ-LO

        public abstract void Deposita(double valor);

        public override bool Equals(object outraConta)
        {
            if (!(outraConta is Conta))
            {
                return false;
            }

            Conta otherCount = (Conta)outraConta;
            return (otherCount.Numero == this.Numero);
            
        }

        public override string ToString()
        {
            return "Titular: " + this.Titular.Nome;
        }

        public abstract void Saca(double valor);
    }
}
