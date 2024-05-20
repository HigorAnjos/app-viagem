UPDATE "public"."Proprietario"
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
    "idProprietario" = @Id;
