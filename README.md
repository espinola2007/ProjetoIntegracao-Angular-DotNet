# 🛍️ Projeto de Integração Angular + .NET

Aplicação web desenvolvida com **Angular** no front-end e **ASP.NET Core Web API** no back-end, com o objetivo de praticar a integração entre uma interface web e uma API utilizando tecnologias do ecossistema .NET.

## 🎯 Objetivo do projeto

Este projeto tem como objetivo aplicar conceitos de desenvolvimento Full Stack, explorando a comunicação entre front-end e back-end, a organização de aplicações e o consumo de APIs.

## 🛠️ Tecnologias utilizadas

- **Angular** — desenvolvimento da interface do usuário.
- **TypeScript** — linguagem utilizada no desenvolvimento do front-end.
- **C#** — linguagem utilizada no back-end.
- **ASP.NET Core Web API** — criação e disponibilização de endpoints para comunicação com o front-end.
- **Node.js e npm** — execução do ambiente de desenvolvimento e gerenciamento de dependências do Angular.
- **Git e GitHub** — versionamento e armazenamento do código-fonte.

## 📁 Estrutura do projeto

```text
ProjetoIntegracao-Angular-DotNet/
├── MinhaPrimeiraApi/   # Back-end .NET
├── produtos-front/     # Front-end Angular
└── .gitignore
```

## ⚙️ Pré-requisitos

Antes de executar o projeto, instale:

- [Git](https://git-scm.com/)
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.dev/tools/cli)

Para verificar as instalações, execute no terminal:

```bash
git --version
dotnet --version
node --version
npm --version
ng version
```

## 🚀 Como executar o projeto

### 1. Clonar o repositório

```bash
git clone https://github.com/espinola2007/ProjetoIntegracao-Angular-DotNet.git
```

Entre na pasta do projeto:

```bash
cd ProjetoIntegracao-Angular-DotNet
```

### 2. Executar o back-end (.NET)

Abra um terminal na pasta do projeto e acesse:

```bash
cd MinhaPrimeiraApi
```

Restaure as dependências:

```bash
dotnet restore
```

Execute a aplicação:

```bash
dotnet run
```

Observe o terminal para identificar o endereço local em que a API está sendo executada.

### 3. Executar o front-end (Angular)

Abra **outro terminal** na raiz do repositório e execute:

```bash
cd produtos-front
```

Instale as dependências:

```bash
npm install
```

Inicie o servidor de desenvolvimento:

```bash
ng serve
```

Acesse o endereço informado no terminal. Por padrão, o Angular utiliza:

```text
http://localhost:4200
```

### 4. Verificar a integração

Com o back-end e o front-end em execução:

1. Acesse a aplicação Angular pelo navegador.
2. Utilize as funcionalidades disponíveis na interface.
3. Verifique se as requisições estão sendo enviadas para a API.
4. Caso ocorram erros, confira o console do navegador e o terminal do back-end.

**Importante:** o endereço da API configurado no Angular deve corresponder ao endereço em que o back-end está sendo executado. Se necessário, verifique também a configuração de CORS no ASP.NET Core.

## 📚 Aprendizados

O desenvolvimento deste projeto permite praticar:

- Integração entre Angular e ASP.NET Core.
- Consumo de APIs HTTP.
- Desenvolvimento de aplicações com TypeScript e C#.
- Organização de projetos de front-end e back-end.
- Execução e depuração de aplicações web.
- Utilização do Git e do GitHub para versionamento.

## 👩‍💻 Autoria

**Vitória Espínola**

- GitHub: [@espinola2007](https://github.com/espinola2007)
- Repositório: [ProjetoIntegracao-Angular-DotNet](https://github.com/espinola2007/ProjetoIntegracao-Angular-DotNet)

---

Desenvolvido para fins de aprendizado e prática de desenvolvimento web Full Stack.
