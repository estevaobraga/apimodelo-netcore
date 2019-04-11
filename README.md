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
	- Acesse a base de dados  
usuário: sa  
senha: sa@12345  

	- crie a base de dados  
`create database dbapimodelo`   
`use dbapimodelo`   
	- rode o script.SQL

- No Sql Server   

	- Crie a base de dados e execute o script.SQL  
	- Depois configure usuário e senha em: /apimodelo.netcore.infra.CrossCutting.IoC/NativeInjectorBootStrapper.cs   
`"Server=myServerAddress;Database=DataBase;User Id=sa;Password=sa@12345;"`   

#### Rodar projeto

- Pelo terminal /apimodelo.netcore.presentation.webapi  
`dotnet run`

- Pelo Visual Studio:  
Selecione a opção de execução pelo IIS Express

## Testar
Acesse a URL /swagger do projeto para visualizar a documentação e realizar as chamadas a API  

Criar novo usuário  
Método POST para a rota /api/usuario  
![Alt Text](/docs/usuario-POST.PNG)  

Realizar login  
![Alt Text](/docs/Login1-swagger.PNG)  
Token  
![Alt Text](/docs/Login2-swagger.PNG)  

Acessar rotas protegidas  
![Alt Text](/docs/Login5-swagger.PNG)  

Rotas do usuário  
![Alt Text](/docs/Usuario-swagger.PNG)  

Rotas da entidade livro  
![Alt Text](/docs/livro-swagger.PNG)  

## Melhorias em construção:  
- Reduzir o retorno do fluent validate em caso de erro
```
{
	[
		"propertyName": "Nome",
		"errorMessage": "Preencha o campo Nome"
	],
	[
		...
	]
}
```

- Criptografar a senha do usuário  

- Endereço, usuário e senha da base de dados variável em arquivo de configuração  (appsettings)
