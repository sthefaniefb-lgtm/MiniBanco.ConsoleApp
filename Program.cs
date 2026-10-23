List<Conta> contas = new List<Conta>();

int opcao = -1;

while (opcao != 0)
{
    try
    {
        Console.WriteLine();
Console.WriteLine("======================================");
Console.WriteLine("          MINIBANCO DIGITAL");
Console.WriteLine("======================================");
Console.WriteLine("1 - Abrir Nova Conta");
Console.WriteLine("2 - Registrar Movimentação");
Console.WriteLine("3 - Aplicar Fechamento Mensal");
Console.WriteLine("4 - Gerar Relatório");
Console.WriteLine("0 - Sair");
Console.WriteLine("======================================");

        Console.Write("Escolha uma opção: ");

        opcao = int.Parse(Console.ReadLine());

        if (opcao == 1)
        {
            Console.WriteLine();
            Console.WriteLine("Qual tipo de conta deseja abrir?");
            Console.WriteLine("1 - Conta Corrente");
            Console.WriteLine("2 - Conta Poupança");
            Console.WriteLine("3 - Conta Salário");

            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Titular: ");
            string titular = Console.ReadLine();

            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Saldo inicial: ");
            decimal saldo = decimal.Parse(Console.ReadLine());

            if (tipoConta == 1)
            {
                Console.Write("Limite do cheque especial: ");
                decimal limite = decimal.Parse(Console.ReadLine());

                ContaCorrente novaConta = new ContaCorrente(
                    titular,
                    numero,
                    saldo,
                    limite
                );

                contas.Add(novaConta);

                Console.WriteLine("Conta Corrente criada com sucesso!");
            }
            else if (tipoConta == 2)
            {
                Console.Write("Taxa de rendimento mensal: ");
                double taxa = double.Parse(Console.ReadLine());

                Console.Write("Dia do aniversário: ");
                int diaAniversario = int.Parse(Console.ReadLine());

                ContaPoupanca novaConta = new ContaPoupanca(
                    titular,
                    numero,
                    saldo,
                    taxa,
                    diaAniversario
                );

                contas.Add(novaConta);

                Console.WriteLine("Conta Poupança criada com sucesso!");
            }
            else if (tipoConta == 3)
            {
                Console.Write("Empregador: ");
                string empregador = Console.ReadLine();

                Console.Write("Limite de saques mensais: ");
                int limiteSaques = int.Parse(Console.ReadLine());

                ContaSalario novaConta = new ContaSalario(
                    titular,
                    numero,
                    saldo,
                    empregador,
                    limiteSaques
                );

                contas.Add(novaConta);

                Console.WriteLine("Conta Salário criada com sucesso!");
            }
        }
        else if (opcao == 2)
        {
            Console.Write("Número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Conta contaEncontrada = null;

            foreach (Conta conta in contas)
            {
                if (conta.Numero == numeroConta)
                {
                    contaEncontrada = conta;
                    break;
                }
            }

            if (contaEncontrada == null)
            {
                Console.WriteLine("Conta não encontrada.");
            }
            else
            {
                Console.WriteLine("1 - Depósito");
                Console.WriteLine("2 - Saque");

                int tipoMovimentacao = int.Parse(Console.ReadLine());

                if (tipoMovimentacao == 1)
                {
                    Console.Write("Valor do depósito: ");
                    decimal valor = decimal.Parse(Console.ReadLine());

                    Console.Write("Descrição: ");
                    string descricao = Console.ReadLine();

                    contaEncontrada.Depositar(valor, descricao);

                    Console.WriteLine("Depósito realizado com sucesso!");
                }
                else if (tipoMovimentacao == 2)
                {
                    Console.Write("Valor do saque: ");
                    decimal valor = decimal.Parse(Console.ReadLine());

                    contaEncontrada.Sacar(valor);

                    Console.WriteLine("Saque realizado com sucesso!");
                }
            }
        }
        else if (opcao == 3)
        {
            foreach (Conta conta in contas)
            {
                conta.AplicarFechamentoMensal();
            }

            Console.WriteLine("Fechamento mensal aplicado com sucesso!");
        }
        else if (opcao == 4)
        {
            MotorAnalise motor = new MotorAnalise();

            foreach (Conta conta in contas)
            {
                motor.ExibirRelatorio(conta);
            }
        }
    }
    catch (SaldoInsuficienteException)
    {
        Console.WriteLine("Saldo insuficiente para realizar o saque.");
    }
    catch (ArgumentException erro)
    {
        Console.WriteLine("Erro: " + erro.Message);
    }
    catch (FormatException)
    {
        Console.WriteLine("Valor informado em formato inválido.");
    }
}