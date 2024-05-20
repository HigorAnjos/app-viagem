INSERT INTO "public"."Passageiro" ("Nome", "Endereco", "Telefone", "CartaoDeCredito", "Sexo", "CidadeDeOrigem", "Email")
VALUES (@Name, @Address, @Phone, @CreditCard, @Gender, @CityOfOrigin, @Email)
RETURNING "idPassageiro";
