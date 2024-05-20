UPDATE "public"."Motorista"
SET
    "Nome" = @Name,
    "CPF" = @CPF,
    "Endereco" = @Address,
    "Telefone" = @Phone,
    "CNH" = @CNH,
    "Banco" = @Bank,
    "Agencia" = @Agency,
    "Conta" = @Account
WHERE
    "idMotorista" = @Id;
