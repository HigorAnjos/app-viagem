SELECT 
    v."Marca" AS Brand,
    v."Placa" AS Plate,
    m."Nome" AS DriverName,
    SUM(t."Preco") AS TotalRevenue
FROM 
    "public"."Viagem" t
INNER JOIN 
    "public"."MotoristaVeiculo" mv ON t."idMotoristaVeiculo" = mv."idMotoristaVeiculo"
INNER JOIN 
    "public"."Veiculos" v ON mv."idVeiculo" = v."idVeiculos"
INNER JOIN 
    "public"."Motorista" m ON mv."idMotorista" = m."idMotorista"
WHERE 
    DATE_TRUNC('month', t."DataDaViagem") = DATE_TRUNC('month', @Month)
GROUP BY 
    v."Marca", v."Placa", m."Nome"
ORDER BY 
    TotalRevenue DESC
LIMIT 20
