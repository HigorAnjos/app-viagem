UPDATE "public"."Veiculos"
SET
    "idProprietario" = @OwnerId,
    "Placa" = @LicensePlate,
    "Marca" = @Brand,
    "Modelo" = @Model,
    "AnoFabricacao" = @ManufactureYear,
    "Capacidade" = @Capacity,
    "Cor" = @Color,
    "TipoCombustivel" = @FuelType,
    "PotenciaDoMotor" = @EnginePower
WHERE
    "idVeiculos" = @Id;
