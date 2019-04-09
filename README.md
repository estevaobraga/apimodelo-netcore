# API Modelo - .NET Core, SQL Server e Autenticação JWT

## Descrição
Modelo de API usando DDD(_Domain Driven Design_), _Auto Mapper_, _Fluent Validation_ e _Swagger_   

ORM: _Entity Framework Core 2.2.3_
Autenticação: _JSON Web Tokens_
Documentação: _Swagger 4.0.1_

## Requisitos
- dotnet core SDK - 2.2   
- dotnet core runtime - 2.2   
- Docker (Recomendado) ou Sql Server   
- Windows ou Linux   

## Rodar Projeto
#### Baixe o projeto
`git clone https://github.com/estevaobraga/apimodelo-netcore.git`
#### Restaure os pacotes
`dotnet restore`
#### Crie a base de dados
- No Docker   
- Iniciar container Sql Server   
`docker-compose up`   
- Criar base de dados   
`docker exec -it mongo-atm bash -c "sqlserver create database"`   

- No Sql Server   

Crie a base de dados e configure em apimodelo.netcore.infra.CrossCutting.IoC/NativeInjectorBootStrapper.cs   
`"Server=myServerAddress;Database=DataBase;User Id=sa;Password=sa@12345;"`   

## Testar
