using DesafioPOO.Models;


Console.WriteLine("Smartphone Nokia:");
Nokia nokia = new Nokia(numero:"123456", modelo: "Modelo 1", imei: "111111111", memoria: 64);
nokia.Ligar();
nokia.InstalarAplicativo("Instagram");

Console.WriteLine("\n");

Console.WriteLine("Smartphone IPhone:");
Nokia iphone = new Nokia(numero:"123456", modelo: "Modelo 1", imei: "111111111", memoria: 64);
nokia.ReceberLigacao();
nokia.InstalarAplicativo("Facebook");