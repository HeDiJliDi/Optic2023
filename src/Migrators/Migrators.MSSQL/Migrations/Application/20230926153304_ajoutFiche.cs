using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.MSSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class ajoutFiche : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fiches",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroFiche = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateNaissance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conventionne = table.Column<bool>(type: "bit", nullable: false),
                    PorteurLentille = table.Column<bool>(type: "bit", nullable: false),
                    Tel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroImportation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateImportation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateExportation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vip = table.Column<bool>(type: "bit", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumSecuriteSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumMutuelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeSocietePec = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantAnnuelle = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreationFiche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodeCarteFidelite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeCarteFidelitePartDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeFamille = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assurer = table.Column<bool>(type: "bit", nullable: false),
                    Contencieux = table.Column<bool>(type: "bit", nullable: false),
                    ExonorerTva = table.Column<bool>(type: "bit", nullable: false),
                    Timbre = table.Column<bool>(type: "bit", nullable: false),
                    MatriculeFiscal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistreCommerce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumAttestation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RaisonSociale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteWeb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AncienSolde = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeSolde = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumAncienFiche = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AdresseProfessionnel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebutExoneration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateFinExoneration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Porteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiches", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fiches",
                schema: "Catalog");
        }
    }
}
