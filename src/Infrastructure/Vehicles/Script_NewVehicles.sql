INSERT INTO "public"."Veiculos" (
    "idProprietario", 
    "Placa", 
    "Marca", 
    "Modelo", 
    "AnoFabricacao", 
    "Capacidade", 
    "Cor", 
    "TipoCombustivel", 
    "PotenciaDoMotor"
)
VALUES (
    @OwnerId, 
    @LicensePlate, 
    @Brand, 
    @Model, 
    @ManufactureYear, 
    @Capacity, 
    @Color, 
    @FuelType, 
    @EnginePower
)
RETURNING "idVeiculos";
