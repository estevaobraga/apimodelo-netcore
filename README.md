# API Modelo - .NET Core, SQL Server e Autenticação JWT

## Descrição
Modelo de API usando padrões DDD(_Domain Driven Design_), _Auto Mapper_, _Fluent Validation_ e _Swagger_   

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
`docker-compose up`   
`docker exec 'create database xyz'`   

- No Sql Server   
Crie a base de dados 'xyz'   

## Testar
