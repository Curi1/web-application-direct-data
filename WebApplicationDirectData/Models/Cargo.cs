namespace CRUDModals.Models;

public class Cargo
{
    public int CargoId { get; set; }
    public string Titulo { get; set; }
    public ICollection<Pessoa> Pessoas { get; set; }
}