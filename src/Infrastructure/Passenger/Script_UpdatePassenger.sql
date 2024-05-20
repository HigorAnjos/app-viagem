UPDATE "public"."Passageiro"
SET
    "Nome" = @Name,
    "Endereco" = @Address,
    "Telefone" = @Phone,
    "CartaoDeCredito" = @CreditCard,
    "Sexo" = @Gender,
    "CidadeDeOrigem" = @CityOfOrigin,
    "Email" = @Email
WHERE
    "idPassageiro" = @Id;
