namespace api.Domain.ViewModels
{
    public class CheckListViewModel
    {
        public bool EstaLimpo { get; set; }
        public bool EstaComTanqueCheio { get; set; }
        public bool EstaSemAmassados { get; set; }
        public bool EstaSemArranhoes { get; set; }
        public int LocacaoVeiculoId { get; set; }

    }
}