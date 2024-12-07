-- Tabla para los gestores
CREATE TABLE Gestores (
    id INT PRIMARY KEY IDENTITY(1,1),
    nombre NVARCHAR(100)
);

-- Tabla para los saldos
CREATE TABLE Saldos (
    id INT PRIMARY KEY IDENTITY(1,1),
    saldo DECIMAL(18,2)
);

-- Tabla para almacenar los saldos asignados a los gestores
CREATE TABLE SaldosAsignados (
    id INT IDENTITY PRIMARY KEY,
    id_gestor INT,
    saldo DECIMAL(18,2),
    CONSTRAINT FK_Gestor FOREIGN KEY (id_gestor) REFERENCES Gestores(id)
);
