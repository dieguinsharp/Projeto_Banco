using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco {
    public class TotalizadorDeContas {
        private static double ValorTotal;

        public static void Adiciona(Conta conta) {
            ValorTotal += conta.Saldo;
        }
        public static double GetTotal() {
            return ValorTotal;
        }
    }
}
