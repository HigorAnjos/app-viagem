INSERT INTO "public"."Viagem" (
    "idMotoristaVeiculo", 
    "idPassageiro", 
    "idTipoPagamento", 
    "GerenteAutorizadoCode", 
    "ViagemCanceladaPeloMotorista", 
    "ViagemCanceladaPeloPassageiro", 
    "Preco", 
    "DataDaViagem"
)
VALUES (
    @DriverVehicleId, 
    @PassengerId, 
    @PaymentTypeId, 
    @AuthorizedManagerCode, 
    @CanceledByDriver, 
    @CanceledByPassenger, 
    @Price, 
    @TripDate
)
RETURNING "idViagem";
