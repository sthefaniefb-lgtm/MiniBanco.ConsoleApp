public abstract class Conta
{
    public string Titular { get; set; }
    public int Numero { get; set; }
    public decimal Saldo { get; protected set; }
    public List<Transacao> Extrato { get; set; }

    public Conta(string titular, int numero, decimal saldo)
    {
        this.Titular = titular;
        this.Numero = numero;
        this.Saldo = saldo;
        this.Extrato = new List<Transacao>();
    }

    public void RegistrarTransacao(string descricao, string tipo, decimal valor)
    {
        Transacao transacao = new Transacao(descricao, tipo, valor);
        Extrato.Add(transacao);
    }

    public void Depositar(decimal valor, string descricao)
    {
        Saldo = Saldo + valor;
        RegistrarTransacao(descricao, "Deposito", valor);
    }

    public virtual void Sacar(decimal valor)
    {
        if (valor > Saldo)
        {
            throw new SaldoInsuficienteException();
        }

        Saldo = Saldo - valor;
        RegistrarTransacao("Saque", "Saque", valor);
    }

    public virtual void AplicarFechamentoMensal()
    {
    }
}

public class SaldoInsuficienteException : Exception
{
}