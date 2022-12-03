using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaExercicios.Models;

namespace ListaExercicios.Models
{
    public class Reajuste
    {
        public decimal Salario { get; set; }

        public Reajuste(decimal salario)
        {
            Salario = salario;
        }

        public decimal VerificarSalario()
        {
            decimal NovoSalario = 0;

            if (Salario < 300)
            {
                NovoSalario = Salario + ((Salario * 50) / 100);
                Console.WriteLine($"O seu salário de {Salario} foi reajustado para {NovoSalario}.");
            }
            else if (Salario > 300)
            {
                NovoSalario = Salario + ((Salario * 30) / 100);
                Console.WriteLine($"O seu salário de {Salario} foi reajustado para {NovoSalario}.");
            }
            else
            {
                Console.WriteLine($"Não é necessário reajuste.");
                NovoSalario = Salario;
            } 

            return NovoSalario;           
        }
    }
}