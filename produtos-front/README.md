# Gerenciamento de Produtos — Angular + .NET + SQLite

Aplicação web desenvolvida para a atividade de **Integração Front-End com Back-End .NET**, com uma interface em Angular, uma API REST em ASP.NET Core e persistência de dados em SQLite.

O sistema permite realizar as operações básicas de um **CRUD de produtos**: cadastrar, listar, buscar por ID, editar e excluir.

## Tecnologias utilizadas

- **Front-end:** Angular, TypeScript, HTML e CSS
- **Back-end:** C#, ASP.NET Core Web API e Entity Framework Core
- **Banco de dados:** SQLite
- **Ferramentas:** Visual Studio Code, .NET CLI, Angular CLI e DBeaver
- **Versionamento:** Git e GitHub

## Funcionalidades

| Funcionalidade | Método HTTP | Endpoint |
| --- | --- | --- |
| Listar todos os produtos | `GET` | `/api/Produtos` |
| Buscar produto por ID | `GET` | `/api/Produtos/{id}` |
| Cadastrar produto | `POST` | `/api/Produtos` |
| Atualizar produto | `PUT` | `/api/Produtos/{id}` |
| Excluir produto | `DELETE` | `/api/Produtos/{id}` |

Cada produto possui os campos:

| Campo | Tipo | Descrição |
| --- | --- | --- |
| `id` | Número inteiro | Identificador gerado automaticamente |
| `nome` | Texto | Nome do produto |
| `preco` | Número decimal | Preço do produto |

## Estrutura do projeto

```text
ProjetoIntegracao/
├── MinhaPrimeiraApi/               # API REST em ASP.NET Core
│   ├── Controllers/                # Endpoints da API
│   ├── Data/                       # Contexto do Entity Framework Core
│   ├── Models/                     # Modelo Produto
│   ├── Migrations/                 # Migrações do banco de dados
│   └── Program.cs                  # Configuração da aplicação e CORS
└── produtos-front/                 # Aplicação Angular
    └── src/
        └── app/
            ├── models/            # Interface Produto
            ├── services/          # Comunicação HTTP com a API
            ├── app.ts             # Lógica da interface
            ├── app.html           # Estrutura visual
            ├── app.css            # Estilos
            └── app.config.ts      # Configuração do HttpClient
```

## Pré-requisitos

- .NET SDK compatível com o projeto (utilizado: **.NET 10**)
- Node.js e npm
- Angular CLI
- DBeaver (opcional, para visualizar o banco SQLite)

## Como executar

Clone o repositório:

```bash
git clone https://github.com/espinola2007/ProjetoIntegracao-Angular-DotNet.git
cd ProjetoIntegracao-Angular-DotNet
```

### 1. Iniciar o back-end

Em um terminal:

```bash
cd MinhaPrimeiraApi
dotnet restore
dotnet ef database update
dotnet run
```

> O comando `dotnet ef database update` aplica as migrações do Entity Framework Core. Caso a ferramenta `dotnet ef` não esteja instalada, será necessário instalá-la antes. Se o banco já estiver configurado, basta iniciar a API.

A API foi utilizada neste projeto em:

**http://localhost:5059/api/Produtos**

> Confira a porta exibida no terminal ao executar `dotnet run`. Se for diferente de `5059`, atualize a URL no serviço Angular em `produtos-front/src/app/services/produtos.ts`.

### 2. Iniciar o front-end

Abra **outro terminal**, a partir da raiz do repositório:

```bash
cd produtos-front
npm install
ng serve --open
```

Acesse no navegador:

**http://localhost:4200**

**Mantenha os dois terminais abertos** durante o uso da aplicação.

## Exemplo de requisição

Cadastro de produto:

**POST** `http://localhost:5059/api/Produtos`

```json
{
  "nome": "Mouse Gamer",
  "preco": 120.50
}
```

O ID é gerado automaticamente pelo banco de dados.

## Banco de dados

O projeto utiliza **SQLite** por meio do Entity Framework Core. Durante o desenvolvimento, o banco foi acessado no arquivo:

```text
MinhaPrimeiraApi/minhaapi.db
```

Para consultar os produtos no DBeaver, conecte-se ao arquivo SQLite e execute:

```sql
SELECT * FROM Produtos;
```

> O banco local pode precisar ser criado pelas migrações ao configurar o projeto em outro computador.

## Integração entre as camadas

```text
Usuário
   ↓
Interface Angular (localhost:4200)
   ↓ Requisições HTTP
API REST ASP.NET Core (localhost:5059)
   ↓ Entity Framework Core
Banco SQLite
```

A API está configurada para aceitar requisições da origem `http://localhost:4200` por meio de uma política de **CORS**.

## Testes realizados

As funcionalidades foram verificadas manualmente pelo navegador, e as operações de escrita foram confirmadas no banco SQLite utilizando o DBeaver:

- [x] Listagem de produtos
- [x] Busca de produto por ID
- [x] Cadastro de produto
- [x] Atualização de produto
- [x] Exclusão de produto
- [x] Persistência dos dados no SQLite

## Objetivo acadêmico

Demonstrar, na prática, como uma aplicação front-end em Angular pode consumir uma API REST desenvolvida em .NET, executando operações CRUD e persistindo informações em um banco de dados relacional.
