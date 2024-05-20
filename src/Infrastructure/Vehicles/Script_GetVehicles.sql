SELECT 
    "idVeiculos"            AS Id,
    "idProprietario"        AS OwnerId,
    "Placa"                 AS LicensePlate,
    "Marca"                 AS Brand,
    "Modelo"                AS Model,
    "AnoFabricacao"         AS ManufactureYear,
    "Capacidade"            AS Capacity,
    "Cor"                   AS Color,
    "TipoCombustivel"       AS FuelType,
    "PotenciaDoMotor"       AS EnginePower
FROM 
    "public"."Veiculos"
WHERE 
    "idVeiculos" = @VehicleId;
