namespace DomainLayer.Financeiro.Integracoes.Bancaria
{
    public class G061_CodigoInstrucaoMovimento : IG061_CodigoInstrucaoMovimento
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
