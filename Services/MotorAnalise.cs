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
}