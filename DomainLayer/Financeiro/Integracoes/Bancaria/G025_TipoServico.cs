namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G025_TipoServico : IG025_TipoServico
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
