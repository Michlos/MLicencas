namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G040_TipoMoeda : IG040_TipoMoeda
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
