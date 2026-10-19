public class ContaCorrente : Conta
{
    public decimal LimiteChequeEspecial { get; set; }

    public ContaCorrente(string titular,int numero,decimal saldo,decimal limiteChequeEspecial) : base(titular, numero, saldo)
{
    this.LimiteChequeEspecial = limiteChequeEspecial;
}
public override void Sacar(decimal valor)
{
    if (valor > Saldo + LimiteChequeEspecial)
    {
        throw new SaldoInsuficienteException();
    }

    Saldo = Saldo - valor;

    RegistrarTransacao("Saque", "Saque", valor);
}
public override void AplicarFechamentoMensal()
{
    Saldo = Saldo - 10m;

    RegistrarTransacao("Tarifa de manutenção", "Tarifa", 10m);
}
}
