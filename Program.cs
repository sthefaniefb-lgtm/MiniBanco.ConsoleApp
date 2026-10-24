List<Conta> contas = new List<Conta>();

int opcao = -1;

while (opcao != 0)
{
    try
    {
        Console.WriteLine();
        Console.WriteLine("===== MINIBANCO DIGITAL =====");
        Console.WriteLine("1 - Abrir Nova Conta");
        Console.WriteLine("2 - Registrar Movimentação");
        Console.WriteLine("3 - Fazer Pix");
        Console.WriteLine("4 - Pagar Boleto");
        Console.WriteLine("5 - Aplicar Fechamento Mensal");
        Console.WriteLine("6 - Gerar Relatório");
        Console.WriteLine("0 - Sair");

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
            Console.WriteLine();
            Console.WriteLine("===== PIX =====");

            Console.Write("Número da conta de origem: ");
            int numeroOrigem = int.Parse(Console.ReadLine());

            Console.Write("Número da conta de destino: ");
            int numeroDestino = int.Parse(Console.ReadLine());

            Conta contaOrigem = null;
            Conta contaDestino = null;

            foreach (Conta conta in contas)
            {
                if (conta.Numero == numeroOrigem)
                {
                    contaOrigem = conta;
                }

                if (conta.Numero == numeroDestino)
                {
                    contaDestino = conta;
                }
            }

            if (contaOrigem == null || contaDestino == null)
            {
                Console.WriteLine("Conta de origem ou destino não encontrada.");
            }
            else if (numeroOrigem == numeroDestino)
            {
                Console.WriteLine("A conta de origem e destino não podem ser iguais.");
            }
            else
            {
                Console.Write("Valor do Pix: ");
                decimal valorPix = decimal.Parse(Console.ReadLine());

                contaOrigem.Sacar(valorPix);

                contaDestino.Depositar(
                    valorPix,
                    "Pix recebido de " + contaOrigem.Titular
                );

                Console.WriteLine("Pix realizado com sucesso!");
                Console.WriteLine(
                    "Destino: " +
                    contaDestino.Titular +
                    " | Valor: R$ " +
                    valorPix
                );
            }
        }
        else if (opcao == 4)
        {
            Console.WriteLine();
            Console.WriteLine("===== PAGAMENTO DE BOLETO =====");

            Console.Write("Número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Conta contaBoleto = null;

            foreach (Conta conta in contas)
            {
                if (conta.Numero == numeroConta)
                {
                    contaBoleto = conta;
                    break;
                }
            }

            if (contaBoleto == null)
            {
                Console.WriteLine("Conta não encontrada.");
            }
            else
            {
                Console.Write("Código do boleto: ");
                string codigoBoleto = Console.ReadLine();

                Console.Write("Valor do boleto: ");
                decimal valorBoleto = decimal.Parse(Console.ReadLine());

                contaBoleto.Sacar(valorBoleto);

                Console.WriteLine("Boleto pago com sucesso!");
                Console.WriteLine("Código: " + codigoBoleto);
                Console.WriteLine("Valor pago: R$ " + valorBoleto);
            }
        }
        else if (opcao == 5)
        {
            foreach (Conta conta in contas)
            {
                conta.AplicarFechamentoMensal();
            }

            Console.WriteLine("Fechamento mensal aplicado com sucesso!");
        }
        else if (opcao == 6)
        {
            if (contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta aberta até o momento.");
            }
            else
            {
                MotorAnalise motor = new MotorAnalise();

                foreach (Conta conta in contas)
                {
                    motor.ExibirRelatorio(conta);
                }
            }
        }
    }
    catch (SaldoInsuficienteException)
    {
        Console.WriteLine("Saldo insuficiente para realizar a operação.");
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