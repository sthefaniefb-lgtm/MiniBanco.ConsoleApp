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
}
