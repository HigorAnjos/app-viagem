SELECT 
    "idMotorista"                 AS Id,
    "Nome"                        AS Name,
    "CPF",
    "Endereco"                    AS Address,
    "Telefone"                    AS Phone,
    "CNH",
    "Banco"                       AS Bank,
    "Agencia"                     AS Agency,
    "Conta"                       AS Account
FROM 
    "public"."Motorista"
WHERE 
    "idMotorista" = @DriverId;
