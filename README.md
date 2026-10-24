# MiniBanco.ConsoleApp

Projeto desenvolvido em C#/.NET como mini-projeto avaliativo do módulo de Programação Orientada a Objetos.

## Objetivo

O MiniBanco é uma aplicação de console responsável por gerenciar diferentes tipos de contas bancárias, registrar movimentações, aplicar regras específicas de cada conta, calcular um índice de saúde financeira e gerar relatórios para apoio à gerência.

## Tipos de Conta

O sistema trabalha com três tipos de conta:

### Conta Corrente
- Possui limite de cheque especial.
- Permite saque utilizando saldo + limite.
- Aplica tarifa de manutenção de R$ 10,00 no fechamento mensal.

### Conta Poupança
- Possui taxa de rendimento mensal.
- Possui dia de aniversário.
- Aplica rendimento mensal sobre o saldo.

### Conta Salário
- Possui empregador.
- Possui limite de saques mensais.
- Após ultrapassar o limite de saques, é cobrada tarifa de R$ 5,00.
- No fechamento mensal, a contagem de saques é reiniciada.

## Transações

As movimentações são registradas como:
- Deposito
- Saque
- Tarifa

Cada transação recebe uma pontuação:
- Depósito: 10 pontos
- Saque: 5 pontos
- Tarifa: 0 pontos

## Índice de Saúde Financeira

O sistema calcula o percentual de saúde da conta utilizando a pontuação obtida em relação à pontuação máxima possível.

Classificação:
- 90% a 100%: Saudável
- 60% a 89%: Atenção
- 0% a 59%: Risco

## Funcionalidades

O menu permite:
1. Abrir nova conta
2. Registrar movimentação
3. Aplicar fechamento mensal
4. Gerar relatório das contas
0. Sair

O relatório apresenta dados da conta, movimentações, pontuação, índice de saúde, classificação, pendências e recomendações.

## Tratamento de Exceções

O sistema trata situações como:
- Saldo insuficiente
- Valores inválidos
- Tipos de transação inválidos
- Entrada de texto onde deveria ser informado um número

## Estrutura do Projeto

```text
MiniBanco.ConsoleApp/
├── Program.cs
├── Models/
│   ├── Transacao.cs
│   ├── Conta.cs
│   ├── ContaCorrente.cs
│   ├── ContaPoupanca.cs
│   └── ContaSalario.cs
├── Exceptions/
│   └── SaldoInsuficienteException.cs
├── Services/

## Versão MiniBancoDigital

Após a conclusão da versão principal do projeto, foi criada uma branch separada para experimentar funcionalidades mais próximas de um banco digital.

Nesta versão foram adicionadas:

- Transferência via Pix entre contas cadastradas no sistema.
- Pagamento de boleto utilizando o saldo da conta.

A proposta dessa branch foi testar uma evolução simples do projeto original sem alterar a versão principal já finalizada.

Como possibilidade de melhoria futura, a versão digital poderia incluir recursos como chave Pix, QR Code e uma interface gráfica.
│   └── MotorAnalise.cs
└── MiniBanco.ConsoleApp.csproj
