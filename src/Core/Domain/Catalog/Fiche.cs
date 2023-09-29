using System.Xml.Linq;

namespace FSH.WebApi.Domain.Catalog;

 
public partial class Fiche : AuditableEntity, IAggregateRoot
{
    public string NumeroFiche { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string DateNaissance { get; set; } = null!;

    public int Age { get; set; }

    public string Sexe { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public string Profession { get; set; } = null!;

    public bool Conventionne { get; set; }

    public bool PorteurLentille { get; set; }

    public string Tel1 { get; set; } = null!;

    public string Tel2 { get; set; } = null!;

    public string Observation { get; set; } = null!;

    public string NumeroImportation { get; set; } = null!;

    public string DateImportation { get; set; } = null!;

    public string DateExportation { get; set; } = null!;

    public bool Vip { get; set; }

    public string Mail { get; set; } = null!;

    public string NumSecuriteSocial { get; set; } = null!;

    public string NumMutuelle { get; set; } = null!;

    public string CodeSocietePec { get; set; } = null!;

    public decimal MontantAnnuelle { get; set; }

    public DateTime DateCreationFiche { get; set; }

    public string CodeCarteFidelite { get; set; } = null!;

    public string CodeCarteFidelitePartDe { get; set; } = null!;

    public string CodeFamille { get; set; } = null!;

    public string Cin { get; set; } = null!;

    public string CodePostal { get; set; } = null!;

    public string Pays { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public bool Assurer { get; set; }

    public bool Contencieux { get; set; }

    public bool ExonorerTva { get; set; }

    public bool Timbre { get; set; }

    public string MatriculeFiscal { get; set; } = null!;

    public string RegistreCommerce { get; set; } = null!;

    public string NumAttestation { get; set; } = null!;

    public string Reference { get; set; } = null!;

    public string RaisonSociale { get; set; } = null!;

    public string SiteWeb { get; set; } = null!;

    public decimal AncienSolde { get; set; }

    public string TypeSolde { get; set; } = null!;

    public string NumAncienFiche { get; set; } = null!;

    public byte[]? Image { get; set; }

    public string AdresseProfessionnel { get; set; } = null!;

    public string DateDebutExoneration { get; set; } = null!;

    public string DateFinExoneration { get; set; } = null!;

    public string Porteur { get; set; } = null!;


    public Fiche Update(string? name, string? description)
    {
        if (name is not null && Nom?.Equals(name) is not true) Nom = name;
        if (description is not null && Prenom?.Equals(description) is not true) Prenom = description;
        return this;
    }
    public Fiche(string nom, string? prenom)
    {
        Nom = nom;
        Prenom = prenom;
    }
}
