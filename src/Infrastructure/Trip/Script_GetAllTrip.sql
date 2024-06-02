SELECT 
    "idViagem"                AS Id,
    "idMotoristaVeiculo"      AS DriverVehicleId,
    "idPassageiro"            AS PassengerId,
    "idTipoPagamento"         AS PaymentTypeId,
    "GerenteAutorizadoCode"   AS AuthorizedManagerCode,
    "ViagemCanceladaPeloMotorista" AS CanceledByDriver,
    "ViagemCanceladaPeloPassageiro" AS CanceledByPassenger,
    "Preco"                   AS Price,
    "DataDaViagem"            AS TripDate
FROM 
    "public"."Viagem"