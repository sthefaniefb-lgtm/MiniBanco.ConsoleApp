public class MotorAnalise
{
    public int CalcularPontuacaoTransacao(Transacao transacao)
    {
        if (transacao.Tipo == "Deposito")
        {
            return 10;
        }

        if (transacao.Tipo == "Saque")
        {
            return 5;
        }

        return 0;
    }

    public int CalcularPontuacaoTotal(List<Transacao> extrato)
    {
        int pontuacaoTotal = 0;

        foreach (Transacao transacao in extrato)
        {
            pontuacaoTotal = pontuacaoTotal + CalcularPontuacaoTransacao(transacao);
        }

        return pontuacaoTotal;
    }
    public double CalcularPercentualSaude(List<Transacao> extrato)
{
    if (extrato.Count == 0)
    {
        return 0;
    }

    int pontuacaoObtida = CalcularPontuacaoTotal(extrato);
    int pontuacaoMaxima = extrato.Count * 10;

    return (double)pontuacaoObtida / pontuacaoMaxima * 100;
}
public string ClassificarSaude(double percentual)
{
    if (percentual >= 90)
    {
        return "Saudável";
    }

    if (percentual >= 60)
    {
        return "Atenção";
    }

    return "Risco";
}
public List<Transacao> ObterTransacoesCriticas(List<Transacao> extrato)
{
    List<Transacao> criticas = new List<Transacao>();

    foreach (Transacao transacao in extrato)
    {
        if (transacao.Tipo == "Tarifa")
        {
            criticas.Add(transacao);
        }
    }

    return criticas;
}
public List<Transacao> ObterTransacoesAtencao(List<Transacao> extrato)
{
    List<Transacao> atencao = new List<Transacao>();

    foreach (Transacao transacao in extrato)
    {
        if (transacao.Tipo == "Saque")
        {
            atencao.Add(transacao);
        }
    }

    return atencao;
}
public string GerarRecomendacao(List<Transacao> extrato)
{
    List<Transacao> criticas = ObterTransacoesCriticas(extrato);
    List<Transacao> atencao = ObterTransacoesAtencao(extrato);

    if (criticas.Count > 0)
    {
        return "Revisar o pacote de tarifas e avaliar negociação com o cliente.";
    }

    if (atencao.Count > 0)
    {
        return "Entrar em contato com o cliente para orientação financeira.";
    }

    return "Nenhuma pendência identificada. Avaliar oferta de investimentos.";
}
public void ExibirRelatorio(Conta conta)
{
    Console.WriteLine("====================================================================");
    Console.WriteLine("        MINIBANCO .NET - MOTOR DE GESTÃO DE CONTAS");
    Console.WriteLine("====================================================================");

    Console.WriteLine("> DADOS DA CONTA:");
    Console.WriteLine("Titular: " + conta.Titular);
    Console.WriteLine("Número da conta: " + conta.Numero);
    Console.WriteLine("Saldo atual: R$ " + conta.Saldo);
    if (conta is ContaCorrente)
{
    ContaCorrente contaCorrente = (ContaCorrente)conta;

    Console.WriteLine("Tipo: Conta Corrente");
    Console.WriteLine("Limite do cheque especial: R$ " + contaCorrente.LimiteChequeEspecial);
}
else if (conta is ContaPoupanca)
{
    ContaPoupanca contaPoupanca = (ContaPoupanca)conta;

    Console.WriteLine("Tipo: Conta Poupança");
    Console.WriteLine("Taxa de rendimento mensal: " + contaPoupanca.TaxaRendimentoMensal + "%");
    Console.WriteLine("Dia do aniversário: " + contaPoupanca.DiaAniversario);
}
else if (conta is ContaSalario)
{
    ContaSalario contaSalario = (ContaSalario)conta;

    Console.WriteLine("Tipo: Conta Salário");
    Console.WriteLine("Empregador: " + contaSalario.Empregador);
    Console.WriteLine("Limite de saques mensais: " + contaSalario.LimiteSaquesMensais);
}
Console.WriteLine();
Console.WriteLine("> MOVIMENTAÇÕES REGISTRADAS:");

foreach (Transacao transacao in conta.Extrato)
{
    int pontos = CalcularPontuacaoTransacao(transacao);

    Console.WriteLine(
        transacao.Descricao + " - " +
        transacao.Tipo + ": R$ " +
        transacao.Valor + " (" +
        pontos + " pts)"
    );
}
int pontuacaoTotal = CalcularPontuacaoTotal(conta.Extrato);
int pontuacaoMaxima = conta.Extrato.Count * 10;
double percentual = CalcularPercentualSaude(conta.Extrato);
string classificacao = ClassificarSaude(percentual);

Console.WriteLine();
Console.WriteLine("> RESUMO DA PONTUAÇÃO:");
Console.WriteLine("Pontuação atingida: " + pontuacaoTotal + " de " + pontuacaoMaxima);
Console.WriteLine("Índice de saúde: " + percentual.ToString("F1") + "%");
Console.WriteLine("Classificação final: " + classificacao);

Console.WriteLine();
Console.WriteLine("> RELATÓRIO DE PENDÊNCIAS E RECOMENDAÇÕES:");

List<Transacao> criticas = ObterTransacoesCriticas(conta.Extrato);
List<Transacao> atencao = ObterTransacoesAtencao(conta.Extrato);

Console.WriteLine("ITENS CRÍTICOS:");

foreach (Transacao transacao in criticas)
{
    Console.WriteLine(
        transacao.Descricao + " - R$ " + transacao.Valor
    );
}

Console.WriteLine("ITENS DE ATENÇÃO:");

foreach (Transacao transacao in atencao)
{
    Console.WriteLine(
        transacao.Descricao + " - R$ " + transacao.Valor
    );
}

Console.WriteLine();
Console.WriteLine("RECOMENDAÇÃO:");
Console.WriteLine(GerarRecomendacao(conta.Extrato));
}
}