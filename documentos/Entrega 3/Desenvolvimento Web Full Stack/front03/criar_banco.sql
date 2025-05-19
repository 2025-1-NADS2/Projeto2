-- Criação do banco de dados
CREATE DATABASE IF NOT EXISTS ong_db DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE ong_db;

-- Tabela de usuários
CREATE TABLE IF NOT EXISTS usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    senha VARCHAR(100) NOT NULL,
    tipo ENUM('admin', 'voluntario', 'participante', 'doador', 'instrutor') NOT NULL DEFAULT 'participante',
    telefone VARCHAR(20),
    rg VARCHAR(20),
    dataCadastro DATETIME DEFAULT CURRENT_TIMESTAMP,
    status TINYINT(1) DEFAULT 1
);

-- Tabela de projetos
CREATE TABLE IF NOT EXISTS projetos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    descricao TEXT,
    categoria VARCHAR(100),
    dataInicio DATE NOT NULL,
    dataFim DATE,
    horario TIME NOT NULL,
    endereco VARCHAR(255) NOT NULL,
    responsavelId INT,
    imagem VARCHAR(255),
    FOREIGN KEY (responsavelId) REFERENCES usuarios(id) ON DELETE SET NULL
);

-- Tabela de eventos
CREATE TABLE IF NOT EXISTS eventos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    descricao TEXT,
    data DATE NOT NULL,
    imagem VARCHAR(255),
    capacidade_total INT DEFAULT 0,
    participantes INT DEFAULT 0,
    endereco VARCHAR(255),
    cidade VARCHAR(100),
    estado VARCHAR(2)
);

-- Tabela de doações
CREATE TABLE IF NOT EXISTS doacoes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    usuario_id INT,
    nome_completo VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL,
    valor DECIMAL(10,2) NOT NULL,
    observacoes TEXT,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE SET NULL
);
