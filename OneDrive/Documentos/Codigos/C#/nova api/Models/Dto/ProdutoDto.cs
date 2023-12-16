using AutoMapper;
using Gerenciador_de_caixa.Models;
using Gerenciador_de_caixa.Models.Dto;

namespace Gerenciador_de_caixa.Models.Dto
{
    public class ProdutoDto
    {
        public string Nome { get; set; }
        public double PrecoVenda { get; set; }
        public double PrecoCompra { get; set; }
        public int Quantidade { get; set; }
        public string? Descricao { get; set; }
    }
}

public class ProdutoDtoProdutoMappingProfile : Profile
{
    public ProdutoDtoProdutoMappingProfile()
    {
        CreateMap<ProdutoDto, Produto>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
    }
}