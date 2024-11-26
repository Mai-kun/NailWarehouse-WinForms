# Иванов Дмитрий Андреевич, ИП-21-3  
# Задания:   
 1) (Вариант 1) Создание реестра имеющихся товаров на Window Forms
 2) Создание пакета NuGet
 3) Структурное логирование для ProductManager
 4) Написание Юнит-тестов
 5) Работа с базой данных через ORM (EF)
 6) Написание Веб-приложения на AspNet MVC

# Дисциплина: 
Инструментальные средства разработки программного обеспечения.

# SQL скрипт для базы данных:
```
USE master
GO
CREATE DATABASE [DataGridView]
GO
USE [DataGridView]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Size] [numeric](18, 2) NULL,
	[Material] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[MinimumQuantity] [int] NULL,
	[Price] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
```
