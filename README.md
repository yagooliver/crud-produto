# Crud de produtos
Aplicação para realizar cruds de produtos.

## Requerimentos
- Necessário versão do visual studio 2019 16.8.2+.
- .NET 5.0 (podem ser baixados em https://dotnet.microsoft.com/download).
- Docker
- Linux ou Windows com Hyper-V e WSL ativados

## Tecnologias:
- .NET 5
- Entity Framework Core 5.0
- ET Core Native DI
- MediatR
- JWT Token
- Swagger UI
- UnitTests (MSTEST)
- Docker

## Arquitetura:
- SOLID
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Notification
- CQRS
- Unit of Work
- Repository and Generic Repository

## Instructions
Para executar essa aplicação é necessário ter o docker instalado e executar o comando `"docker-compose build"` no diretório base do projeto e em seguida executar o comando `"docker-compose up -d"`. Os comandos irão iniciar os containers automaticamente, se possível, checar se os containers estão sendo executados `"docker container ps -a"`. Após a execução a API será acessada via http://localhost:8081/swagger e a aplicação através da url http://localhost:8080/

Em caso de execução direta pelo visual studio é necessário checar as connectionstrings e a url da api no arquivo .ENV do projeto web-app
