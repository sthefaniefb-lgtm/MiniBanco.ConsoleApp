public class ContaSalario : Conta
{
    public string Empregador { get; set; }
    public int LimiteSaquesMensais { get; set; }

    public ContaSalario(
    string titular,
    int numero,
    decimal saldo,
    string empregador,
    int limiteSaquesMensais
) : base(titular, numero, saldo)
{
    this.Empregador = empregador;
    this.LimiteSaquesMensais = limiteSaquesMensais;
}
private int saquesRealizadosMes = 0;
public override void Sacar(decimal valor)
{
    decimal tarifa = 0m;

    if (saquesRealizadosMes >= LimiteSaquesMensais)
    {
        tarifa = 5m;
    }

    if (valor + tarifa > Saldo)
    {
        throw new SaldoInsuficienteException();
    }

    Saldo = Saldo - valor;
    RegistrarTransacao("Saque", "Saque", valor);

    if (tarifa > 0)
    {
        Saldo = Saldo - tarifa;
        RegistrarTransacao("Tarifa de saque", "Tarifa", tarifa);
    }

    saquesRealizadosMes++;
}
public override void AplicarFechamentoMensal()
{
    saquesRealizadosMes = 0;
}
}
