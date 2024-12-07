CREATE OR ALTER PROCEDURE AsignarSaldosAGestores
AS
BEGIN
    -- Variables
    DECLARE @TotalSaldos INT, @TotalGestores INT, @Index INT, @GestorId INT
    DECLARE @Saldo DECIMAL(18,2)

    -- Obtener la cantidad total de saldos y gestores
    SELECT @TotalSaldos = COUNT(*) FROM Saldos;
    SELECT @TotalGestores = COUNT(*) FROM Gestores;

    -- Si no hay saldos o gestores, terminamos el proceso
    IF @TotalSaldos = 0 OR @TotalGestores = 0
    BEGIN
        PRINT 'No hay saldos o gestores disponibles.';
        RETURN;
    END

    -- Ordenar los saldos de manera descendente
    ;WITH SaldosOrdenados AS (
        SELECT saldo, ROW_NUMBER() OVER (ORDER BY saldo DESC) AS RowNum
        FROM Saldos
    )
    -- Asignar los saldos a los gestores
    INSERT INTO SaldosAsignados (id_gestor, saldo)
    SELECT 
        G.id,  -- Asignar el saldo a un gestor
        SO.saldo
    FROM 
        SaldosOrdenados SO
    CROSS APPLY 
        (SELECT id FROM Gestores WHERE id = ((SO.RowNum - 1) % @TotalGestores) + 1) G
    ORDER BY SO.RowNum;

    -- Devolver los resultados de la asignación
    SELECT * FROM SaldosAsignados
END;
