using ListaExercicios.Models;

Console.WriteLine($"Olá, digite o seu nome, sobrenome e salário: ");

Pessoa p1 = new Pessoa(nome: "Hiago", sobrenome: "Crespo");
Console.WriteLine($"Olá {p1.NomeCompleto}");

Reajuste r1 = new Reajuste(salario: 400);
r1.VerificarSalario();