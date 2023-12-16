using AutoMapper;
using Gerenciador_de_caixa.Models;
using Gerenciador_de_caixa.Models.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Produto, ProdutoDto>().ReverseMap();
        //CreateMap<Produto, ProdutoCreateDto>().ReverseMap();
        //CreateMap<Produto, ProdutoUpdateDto>().ReverseMap();
        //CreateMap<Produto, ProdutoPatchDto>().ReverseMap();
    }
}
