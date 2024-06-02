SELECT 
    v."Marca" AS Brand,
    v."Placa" AS Plate,
    p."CidadeDeOrigem" AS Origin,
    p."Endereco" AS Destination,
    m."Nome" AS DriverName,
    p."Nome" AS PassengerName
FROM 
    "public"."Viagem" t
INNER JOIN 
    "public"."MotoristaVeiculo" mv ON t."idMotoristaVeiculo" = mv."idMotoristaVeiculo"
INNER JOIN 
    "public"."Veiculos" v ON mv."idVeiculo" = v."idVeiculos" 
INNER JOIN 
    "public"."Motorista" m ON mv."idMotorista" = m."idMotorista"
INNER JOIN 
    "public"."Passageiro" p ON t."idPassageiro" = p."idPassageiro"
WHERE 
    v."Marca" = @Brand AND 
    t."DataDaViagem" BETWEEN @InitDate AND @EndDate
