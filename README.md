# Ambev Developer Evaluation

Este projeto é uma API para gerenciamento de vendas, construída com .Net 8 e PostgreSQL.

## Requisitos

- .NET 8 SDK ou superior
- Banco de dados PostgreSQL

## Configuração do Banco de Dados

1. Crie um banco de dados PostgreSQL.
2. Atualize a string de conexão no arquivo `appsettings.json` com as informações do seu banco de dados.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=ambev;Username=seu_usuario;Password=sua_senha"
  }
}
```

## 1-Clone o repositório:
git clone https://github.com/AntonioTCabral/ambev-developer-evaluation.git
cd ambev-developer-evaluation

## 2-Instale as dependências:
dotnet restore

## 3-Crie o banco de dados:
dotnet ef database update

## 4-Execute o projeto:
Acesse a api em http://localhost:5119/swagger/index.html

## Estrutura do projeto
```
root
├── src/
├── tests/
└── README.md
```