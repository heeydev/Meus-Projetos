Console.WriteLine("Digite os valores dos investimentos iniciais e redimentos finais: ");
string[] valores = Console.ReadLine().Split(' ');
double[] porcentagens = new double[3];

for (int i = 0; i < 3; i++)
{    
    double valor1 = Convert.ToDouble(valores[i * 2]);
    double valor2 = Convert.ToDouble(valores[i * 2 + 1]);
    porcentagens[i] = ((valor2 * 100) / valor1) - 100;
}

Console.WriteLine($"Projeto 1: \nPercentual dos juros da aplicacao: {porcentagens[0]:0.00}%\n\nProjeto 2: \nPercentual dos juros da aplicacao: {porcentagens[1]:0.00}%\n\nProjeto 3: \nPercentual dos juros da aplicacao: {porcentagens[2]:0.00}%");