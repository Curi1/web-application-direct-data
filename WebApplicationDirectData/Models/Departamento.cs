namespace CRUDModals.Models;

public class Departamento
{
    public int DepartamentoId { get; set; }
    public string Nome { get; set; }
    public ICollection<Pessoa> Pessoas { get; set; }
}