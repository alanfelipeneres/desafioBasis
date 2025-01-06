-- Verifica se a database 'Biblioteca' já existe
IF NOT EXISTS (
    SELECT 1
    FROM sys.databases
    WHERE name = 'Biblioteca'
)
BEGIN
    -- Cria a database 'Biblioteca' caso ela não exista
    CREATE DATABASE Biblioteca;
END
GO

-- Seleciona a base de dados 'Biblioteca'
USE Biblioteca;
GO

-- Verifica e remove as tabelas, se existirem
IF OBJECT_ID('dbo.Livro_Assunto', 'U') IS NOT NULL DROP TABLE Livro_Assunto;
IF OBJECT_ID('dbo.Livro_Autor', 'U') IS NOT NULL DROP TABLE Livro_Autor;
IF OBJECT_ID('dbo.Livro', 'U') IS NOT NULL DROP TABLE Livro;
IF OBJECT_ID('dbo.Assunto', 'U') IS NOT NULL DROP TABLE Assunto;
IF OBJECT_ID('dbo.Autor', 'U') IS NOT NULL DROP TABLE Autor;
GO

-- Criação da tabela Autor
CREATE TABLE Autor (
    CodAu INTEGER IDENTITY PRIMARY KEY,
    Nome VARCHAR(40) NOT NULL
);

-- Criação da tabela Assunto
CREATE TABLE Assunto (
    CodAs INTEGER IDENTITY PRIMARY KEY,
    Descricao VARCHAR(20) NOT NULL
);

-- Criação da tabela Livro
CREATE TABLE Livro (
    CodL INTEGER IDENTITY PRIMARY KEY,
    Titulo VARCHAR(40) NOT NULL,
    Editora VARCHAR(40) NOT NULL,
    Edicao INTEGER NOT NULL,
    AnoPublicacao VARCHAR(4) NOT NULL
);

-- Criação da tabela Livro_Autor (tabela associativa para Livro e Autor)
CREATE TABLE Livro_Autor (
    Livro_CodL INTEGER NOT NULL,
    Autor_CodAu INTEGER NOT NULL,
    PRIMARY KEY (Livro_CodL, Autor_CodAu),
    FOREIGN KEY (Livro_CodL) REFERENCES Livro(CodL) ON DELETE CASCADE,
    FOREIGN KEY (Autor_CodAu) REFERENCES Autor(CodAu) ON DELETE CASCADE
);

-- Criação da tabela Livro_Assunto (tabela associativa para Livro e Assunto)
CREATE TABLE Livro_Assunto (
    Livro_CodL INTEGER NOT NULL,
    Assunto_CodAs INTEGER NOT NULL,
    PRIMARY KEY (Livro_CodL, Assunto_CodAs),
    FOREIGN KEY (Livro_CodL) REFERENCES Livro(CodL) ON DELETE CASCADE,
    FOREIGN KEY (Assunto_CodAs) REFERENCES Assunto(CodAs) ON DELETE CASCADE
);

GO
-- Criação da View para listar os livros agrupados por autor e incluindo os assuntos
CREATE OR ALTER VIEW vw_LivrosPorAutor AS
SELECT 
    a.Nome AS Autor,
    l.Titulo AS Livro,
    l.Editora,
    l.Edicao,
    l.AnoPublicacao,
    -- Concatenando os assuntos associados ao livro
    STRING_AGG(asu.Descricao, ', ') AS Assuntos
FROM 
    Autor a
JOIN 
    Livro_Autor la ON a.CodAu = la.Autor_CodAu
JOIN 
    Livro l ON la.Livro_CodL = l.CodL
LEFT JOIN 
    Livro_Assunto las ON l.CodL = las.Livro_CodL
LEFT JOIN 
    Assunto asu ON las.Assunto_CodAs = asu.CodAs
GROUP BY 
    a.CodAu, a.Nome, l.CodL, l.Titulo, l.Editora, l.Edicao, l.AnoPublicacao;

