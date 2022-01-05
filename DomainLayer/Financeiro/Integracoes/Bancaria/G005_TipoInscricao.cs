namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G005_TipoInscricao : IG005_TipoInscricao
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
