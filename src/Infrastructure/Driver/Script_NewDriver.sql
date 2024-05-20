INSERT INTO "public"."Proprietario" ("Nome", "CPF", "Endereco", "Telefone", "CNH", "Banco", "Agencia", "Conta")
VALUES (@Name, @CPF, @Address, @Phone, @CNH, @Bank, @Agency, @Account)
RETURNING "idProprietario";
