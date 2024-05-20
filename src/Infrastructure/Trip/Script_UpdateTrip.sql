UPDATE "public"."Viagem"
SET
    "idMotoristaVeiculo" = @DriverVehicleId,
    "idPassageiro" = @PassengerId,
    "idTipoPagamento" = @PaymentTypeId,
    "GerenteAutorizadoCode" = @AuthorizedManagerCode,
    "ViagemCanceladaPeloMotorista" = @CanceledByDriver,
    "ViagemCanceladaPeloPassageiro" = @CanceledByPassenger,
    "Preco" = @Price,
    "DataDaViagem" = @TripDate
WHERE
    "idViagem" = @Id;
