Transacao Salario = new Transacao("Salario","Deposito",10000m); 
Console.WriteLine(Salario.Descricao);
Console.WriteLine(Salario.Tipo);
Console.WriteLine(Salario.Valor); 

Transacao Cartao = new Transacao("Cartao","Tarifa",4000m);
Console.WriteLine(Cartao.Descricao);
Console.WriteLine(Cartao.Tipo);
Console.WriteLine(Cartao.Valor);

Transacao SaqueOutubro = new Transacao ("SaqueOutubro","Saque",3000m);
Console.WriteLine(SaqueOutubro.Descricao);
Console.WriteLine(SaqueOutubro.Tipo);
Console.WriteLine(SaqueOutubro.Valor);

ContaCorrente conta = new ContaCorrente("Martina", 123, 10000m, 5000m);

Console.WriteLine("Saldo inicial: " + conta.Saldo);

conta.Depositar(2000m, "Deposito teste");
Console.WriteLine("Depois do depósito: " + conta.Saldo);

conta.Sacar(3300m);
Console.WriteLine("Depois do saque: " + conta.Saldo);

conta.AplicarFechamentoMensal();
Console.WriteLine("Depois do fechamento: " + conta.Saldo);