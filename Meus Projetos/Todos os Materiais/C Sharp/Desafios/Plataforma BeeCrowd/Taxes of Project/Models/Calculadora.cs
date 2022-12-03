using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxes_of_Project.Models
{
    public class Calculadora
    {
        public int AporteInicial { get; set; }
        public int AporteFinal { get; set; }

        public Calculadora(int aoporteInicial, int aporteFinal)
        {
            AporteInicial = aoporteInicial;
            AporteFinal = aporteFinal;
        }
        public void CalcularRendimento()
        {
            Console.WriteLine("Digite os valores dos investimentos iniciais e redimentos finais: ");
            string[] valores = Console.ReadLine().Split(' ');
            double[] porcentagens = new double[3];

            for(int i = 0; i < 3; i++)
            {
                double valor1 = Convert.ToDouble(valores[i*2]);
                double valor2 = Convert.ToDouble(valores[i*2+1]);
                porcentagens[i] = CalculaPorcentagemLucro(valor2, valor1);
            }         
            
            Console.WriteLine($"Projeto 1: \nPercentual dos juros da aplicacao: {porcentagens[0]:0.00}%\n" +
                              "\n" +
                              $"Projeto 2: \nPercentual dos juros da aplicacao: {porcentagens[1]:0.00}%\n" +
                              "\n" +
                              $"Projeto 3: \nPercentual dos juros da aplicacao: {porcentagens[2]:0.00}%");

        }
        private double CalculaPorcentagemLucro(double valor1, double valor2)
        {
            return ((valor1 * 100) / valor2) - 100;
        }
    }
}