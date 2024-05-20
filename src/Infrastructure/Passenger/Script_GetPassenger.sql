SELECT 
    "idPassageiro"                 AS Id,
    "Nome"                        AS Name,
    "Endereco"                    AS Address,
    "Telefone"                    AS Phone,
    "CartaoDeCredito"             AS CreditCard,
    "Sexo"                        AS Gender,
    "CidadeDeOrigem"              AS CityOfOrigin,
    "Email"
FROM 
    "public"."Passageiro"
WHERE 
    "idPassageiro" = @PassengerId;
