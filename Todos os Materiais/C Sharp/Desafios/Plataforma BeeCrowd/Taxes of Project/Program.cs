using Taxes_of_Project.Models;

int aporteInicial = 0;
int aporteFinal= 0;

Calculadora investimentos = new Calculadora(aporteInicial, aporteFinal);

investimentos.CalcularRendimento();