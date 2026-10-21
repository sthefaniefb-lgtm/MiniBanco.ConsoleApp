public class Transacao
{
    public string Descricao { get; set; }
    public string Tipo { get; set; }
    public decimal Valor { get; set; }

    public Transacao(string descricao, string tipo, decimal valor)
    {
        if (tipo != "Deposito" && tipo != "Saque" && tipo != "Tarifa")
        {
            throw new ArgumentException("Tipo de transação inválido.");
        }

        if (valor <= 0)
        {
            throw new ArgumentException("O valor deve ser maior que zero.");
        }

        Descricao = descricao;
        Tipo = tipo;
        Valor = valor;
    }
}