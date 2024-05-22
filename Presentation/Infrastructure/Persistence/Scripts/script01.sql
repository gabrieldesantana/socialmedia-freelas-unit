CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
    "ProductVersion" TEXT NOT NULL
);

BEGIN TRANSACTION;

CREATE TABLE "TB_Clientes" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TB_Clientes" PRIMARY KEY,
    "NumeroDocumento" TEXT NOT NULL,
    "Nome" TEXT NOT NULL,
    "DataNascimento" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Telefone" TEXT NOT NULL,
    "Senha" TEXT NOT NULL,
    "Actived" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL,
    CONSTRAINT "FK_TB_Clientes_TB_Vagas_Id" FOREIGN KEY ("Id") REFERENCES "TB_Vagas" ("Id") ON DELETE CASCADE
);

CREATE TABLE "TB_Vagas" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TB_Vagas" PRIMARY KEY AUTOINCREMENT,
    "Titulo" TEXT NOT NULL,
    "Descricao" TEXT NOT NULL,
    "Cargo" TEXT NOT NULL,
    "Tipo" TEXT NOT NULL,
    "Remuneracao" TEXT NOT NULL,
    "FreelancerId" INTEGER NOT NULL,
    "ClienteId" INTEGER NOT NULL,
    "ClienteId1" INTEGER NULL,
    "Actived" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL,
    CONSTRAINT "FK_TB_Vagas_TB_Clientes_ClienteId1" FOREIGN KEY ("ClienteId1") REFERENCES "TB_Clientes" ("Id")
);

CREATE TABLE "TB_Experiencias" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TB_Experiencias" PRIMARY KEY AUTOINCREMENT,
    "FreelancerId" INTEGER NOT NULL,
    "Projeto" TEXT NOT NULL,
    "Empresa" TEXT NOT NULL,
    "Tecnologia" TEXT NOT NULL,
    "Valor" TEXT NOT NULL,
    "Avaliacao" INTEGER NOT NULL,
    "FreelancerId1" INTEGER NULL,
    "Actived" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL,
    CONSTRAINT "FK_TB_Experiencias_TB_Freelancers_FreelancerId1" FOREIGN KEY ("FreelancerId1") REFERENCES "TB_Freelancers" ("Id")
);

CREATE TABLE "TB_Freelancers" (
    "Id" INTEGER NOT NULL CONSTRAINT "PK_TB_Freelancers" PRIMARY KEY,
    "NumeroDocumento" TEXT NOT NULL,
    "Nome" TEXT NOT NULL,
    "DataNascimento" TEXT NOT NULL,
    "Email" TEXT NOT NULL,
    "Telefone" TEXT NOT NULL,
    "Senha" TEXT NOT NULL,
    "PretensaoSalarial" TEXT NOT NULL,
    "Actived" INTEGER NOT NULL,
    "CreatedAt" TEXT NOT NULL,
    CONSTRAINT "FK_TB_Freelancers_TB_Experiencias_Id" FOREIGN KEY ("Id") REFERENCES "TB_Experiencias" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_TB_Freelancers_TB_Vagas_Id" FOREIGN KEY ("Id") REFERENCES "TB_Vagas" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_TB_Experiencias_FreelancerId1" ON "TB_Experiencias" ("FreelancerId1");

CREATE INDEX "IX_TB_Vagas_ClienteId1" ON "TB_Vagas" ("ClienteId1");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240522171111_FirstMigration', '7.0.0');

COMMIT;

