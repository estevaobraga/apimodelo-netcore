-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

-- ************************************** [Usuario]

CREATE TABLE [Usuario]
(
 [id]    int identity NOT NULL ,
 [Nome]  varchar(50) NOT NULL ,
 [Login] varchar(50) NOT NULL ,
 [Senha] varchar(50) NOT NULL ,

 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO








-- ************************************** [Livros]

CREATE TABLE [Livros]
(
 [id]        int identity NOT NULL ,
 [Nome]      varchar(50) NOT NULL ,
 [Autor]     varchar(50) NOT NULL ,
 [paginas]   int NOT NULL ,
 [categoria] varchar(50) NOT NULL ,
 [nota]      int check (nota >= 0 and nota <=5) NOT NULL ,

 CONSTRAINT [PK_Livros] PRIMARY KEY CLUSTERED ([id] ASC)
);
GO








