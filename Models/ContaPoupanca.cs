public class ContaPoupanca : Conta
{
    public double TaxaRendimentoMensal { get; set; }
    public int DiaAniversario { get; set; }

     public ContaPoupanca(
        string titular,
        int numero,
        decimal saldo,
        double taxaRendimentoMensal,
        int diaAniversario
    ) : base(titular, numero, saldo)
    {
        this.TaxaRendimentoMensal = taxaRendimentoMensal;
        this.DiaAniversario = diaAniversario;
    }
    public override void AplicarFechamentoMensal()
{
    decimal rendimento = Saldo * (decimal)TaxaRendimentoMensal / 100;

    Saldo = Saldo + rendimento;

    RegistrarTransacao("Rendimento mensal", "Deposito", rendimento);
}
}
