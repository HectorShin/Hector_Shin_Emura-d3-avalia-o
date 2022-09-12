CREATE DATABASE [Users];

USE [Users];

CREATE TABLE Users(
	Id	VARCHAR(255) NOT NULL UNIQUE,
	[Name]	VARCHAR(255) NOT NULL,
	Email	VARCHAR(255) NOT NULL UNIQUE,
	Senha	VARCHAR(255) NOT NULL
);

SELECT * FROM Users;

INSERT INTO Users (Id, [Name], Email, Senha)
VALUES ('a66c0980-dd93-41b5-9415-ee664002c089', 'admin', 'admin@email.com', 'admin123');