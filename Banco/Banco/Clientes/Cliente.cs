using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco {
    public class Cliente {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Endereço { get; set; }
        public int Idade { get; set; }

        public Cliente(string nome, int idade) {
            this.Nome = nome;
            this.Idade = idade;
        }

        public bool EhMaiorDeIdade() {
            if(this.Idade >= 18) {
                return true;
            }
            return false;
        }       
    }
}
