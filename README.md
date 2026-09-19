# APICancelaFaturamento

API simples em C# / ASP.NET Core para receber um JSON de entrada e devolver um JSON de resposta, com autenticação por API Key fixa para uso em testes.

## Objetivo

Esta API foi desenvolvida para:

- receber um JSON no formato do payload de entrada (`payloadRecebimento`);
- validar a presença de uma API Key;
- devolver um JSON no formato do payload de resposta (`payloadResposta`);
- funcionar sem banco de dados;
- manter o código simples, limpo e fácil de manter.

## Stack

- C#
- ASP.NET Core
- .NET SDK mais recente disponível

## Estrutura do projeto

- `Controllers/` - endpoints da API
- `DTOs/` - contratos de entrada e saída
- `Services/` - lógica de leitura de arquivos JSON e montagem da resposta
- `Middleware/` - autenticação por API Key
- `JSON/` - exemplos de payloads de entrada e saída

## Requisitos

- .NET SDK instalado
- Acesso ao projeto em uma pasta local

## Como executar

No terminal, na raiz do projeto:

```bash
dotnet restore
dotnet run --urls http://localhost:5025
```

## Endpoint principal

### POST /api/recebimento

Exemplo de requisição:

```http
POST http://localhost:5025/api/recebimento
Content-Type: application/json
x-api-key: APICANCELA-FATURAMENTO-TESTE
```

```json
{
  "idPedido": "PED-001",
  "documento": "12345678900",
  "nomeCliente": "Cliente Exemplo",
  "valorTotal": 1500.00,
  "observacao": "Pedido de teste",
  "itens": [
    {
      "codigo": "PROD-001",
      "descricao": "Produto Exemplo",
      "quantidade": 2,
      "valorUnitario": 750.00
    }
  ]
}
```

Resposta esperada:

```json
{
  "status": "sucesso",
  "mensagem": "Requisição recebida com sucesso.",
  "codigoOperacao": "11712CDA",
  "dataProcessamento": "2026-09-19T19:50:09.3003862Z",
  "origem": "APICancelaFaturamento",
  "dadosRecebidos": {
    "idPedido": "PED-001",
    "documento": "12345678900",
    "nomeCliente": "Cliente Exemplo",
    "valorTotal": 1500.00,
    "observacao": "Pedido de teste",
    "itens": [
      {
        "codigo": "PROD-001",
        "descricao": "Produto Exemplo",
        "quantidade": 2,
        "valorUnitario": 750.00
      }
    ]
  }
}
```

## API Key

A chave de autenticação foi definida diretamente no código, em `Middleware/ApiKeyMiddleware.cs`.

Valor atual:

```text
APICANCELA-FATURAMENTO-TESTE
```

Ela deve ser enviada no header:

```http
x-api-key: APICANCELA-FATURAMENTO-TESTE
```

## Exemplos de JSON

Os exemplos prontos estão na pasta:

- `JSON/payloadRecebimento.json`
- `JSON/payloadResposta.json`

## Observações

- Este projeto foi pensado para testes e validação.
- Não há persistência em banco de dados.
- Não há processamento de negócio complexo.
- A ideia é manter a API simples, previsível e de fácil manutenção.
