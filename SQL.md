USE gdmdb;

CREATE TABLE SuiteType (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Motel (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Location VARCHAR(255) NOT NULL
);

CREATE TABLE Client (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    PhoneNumber VARCHAR(20)  -- Adicionei o campo PhoneNumber conforme seu possível futuro uso
);

CREATE TABLE Reservation (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Date DATETIME NOT NULL,
    ClientId INT NOT NULL,
    SuiteTypeId INT NOT NULL,
    MotelId INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (ClientId) REFERENCES Client(Id),
    FOREIGN KEY (SuiteTypeId) REFERENCES SuiteType(Id),
    FOREIGN KEY (MotelId) REFERENCES Motel(Id)
);


CREATE TABLE User (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Token VARCHAR(255)
);
