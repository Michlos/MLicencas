namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G003_TipoRegistro : IG003_TipoRegistro
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
