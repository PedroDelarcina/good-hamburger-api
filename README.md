# GOOD HAMBURGER API

Este projeto é uma API para a empresa fictícia "GOOD HAMBURGER", que permite aos clientes fazer pedidos de sanduíches e extras via aplicativo ou website. A API foi desenvolvida em C# utilizando o .NET Core 8.0 e usa um banco de dados em memória para armazenamento temporário dos dados.

## Funcionalidades

- Listar sanduíches disponíveis.
- Listar extras disponíveis.
- Fazer pedidos com regras de desconto.
- Atualizar um pedido existente.
- Remover um pedido.
- Listar todos os pedidos feitos.

## Regras de Negócio

A API aplica as seguintes regras de desconto aos pedidos:
- **20% de desconto** se o cliente selecionar um sanduíche, batata frita e refrigerante.
- **15% de desconto** se o cliente selecionar um sanduíche e refrigerante.
- **10% de desconto** se o cliente selecionar um sanduíche e batata frita.

Além disso, a API não permite mais de um item de cada tipo (sanduíche, batata frita ou refrigerante) por pedido. Se um pedido contiver mais de um item do mesmo tipo, a API retornará uma mensagem de erro.

## Endpoints

### Listar Sanduíches e Extras

- **GET /api/sandwiches**
  - Retorna uma lista de todos os sanduíches disponíveis.
  
- **GET /api/extras**
  - Retorna uma lista de todos os extras disponíveis.

### Pedidos

- **POST /api/orders**
  - Cria um novo pedido e aplica os descontos conforme as regras de negócio.
  - **Exemplo de Request Body:**
    ```json
    {
      "sandwichId": 1,
      "friesId": 2,
      "drinkId": 1
    }
    ```

- **GET /api/orders**
  - Retorna todos os pedidos feitos.

- **PUT /api/orders/{id}**
  - Atualiza um pedido existente.
  - **Exemplo de Request Body:**
    ```json
    {
      "sandwichId": 2,
      "friesId": 1,
      "drinkId": 2
    }
    ```

- **DELETE /api/orders/{id}**
  - Remove um pedido existente.

## Configuração e Execução

### Pré-requisitos

- .NET Core 8.0 SDK
- Visual Studio ou outro editor de código compatível

### Como Rodar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/PedroDelarcina/good-hamburger-api.git
   cd good-hamburger-api