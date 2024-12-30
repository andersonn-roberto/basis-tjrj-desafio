# Desafio .NET TJRJ

## Tecnologias e frameworks utilizados

[ASP .NET Core](https://dotnet.microsoft.com/pt-br/apps/aspnet) versão 8 com C#

[Angular](https://angular.dev) versão 19.0.5 com [Typescript](https://www.typescriptlang.org/), [Angular CLI](https://angular.dev/tools/cli) versão 19.0.6

[Node.js](https://nodejs.org/en) versão 22.12.0

[Coverlet](https://github.com/coverlet-coverage/coverlet) e [ReportGenerator](https://github.com/danielpalme/ReportGenerator) para relatório de cobertura

[Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) para o banco de dados

## Requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download) versão 8.0.11
- [Node.js](https://nodejs.org/en) versão 22.12.0
- [Angular CLI](https://angular.dev/tools/cli) versão 19.0.6
- [Sql Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

## Instalação

- Clone o repositório do projeto:

```
git clone https://github.com/andersonn-roberto/basis-tjrj-desafio.git
```

- Entre no diretório do projeto clonado:

```
cd basis-tjrj-desafio
```

- Execute o comando para restaurar as dependências e fazer build da aplicação:

```
dotnet build
```

## Executando a aplicação

- Entre no diretório da aplicação back-end:

```
cd src\LivrosApp.Api
```

- Abra o arquivo `appsettings.Development.json` e altere a string de conexão com o banco de dados para a sua configuração:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=nomeouipdoservidor;Database=LivrosApp;User Id=usuariodobancodedados;Password=senhadousuario;TrustServerCertificate=True"
  }
```

- Mantenha o nome do banco de dados como `LivrosApp`.

- Salve o arquivo.

- Execute a aplicação:

```
dotnet run --launch-profile "https"
```

- Acesse a aplicação no endereço: [https://localhost:55733](https://localhost:55733)
  > Caso o browser reclame do certificado, continue mesmo assim.

## Executando os testes de unidade e gerando o relatório de cobertura

- Volte para o diretório do projeto clonado:

```
cd ..\..\tests\LivrosApp.Test
```

- Instale o pacote ReportGenerator:

```
dotnet tool install -g dotnet-reportgenerator-globaltool
```

- Execute os testes gerando o relatório de cobertura:

```
dotnet test --collect:"XPlat Code Coverage"
```

> Na saida do teste vai gerar algo assim:

`Attachments:
  C:\Projetos\TI\Estudos\Basis\LivrosApp\test\LivrosApp.Test\TestResults\cadd4836-4ffb-4d64-a14c-7f9884786d03\coverage.cobertura.xml`

- Execute o ReportGenerator para gerar uma página HTML do relatório utilizando o caminho do Attachments do passo anterior:

  > reportgenerator -reports:"C:\Projetos\TI\Estudos\Basis\LivrosApp\test\LivrosApp.Test\TestResults\cadd4836-4ffb-4d64-a14c-7f9884786d03\coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

- Entre no diterório que o ReportGenerator criou:

```
cd coveragereport
```

- Abra o file explorer:

```
explorer .
```

- Dê um duplo clique no arquivo `index.html`

---

Caso tenha problemas com o relatório de cobertura, veja [esse artigo da Microsoft](https://learn.microsoft.com/pt-br/dotnet/core/testing/unit-testing-code-coverage?tabs=windows).
