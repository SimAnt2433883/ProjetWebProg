using AutoMapper;
using ProjetWebProg.Data;
using ProjetWebProg.Models.Commande;
using ProjetWebProg.Models.Toutous;

namespace ProjetWebProg.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Commande, PostCommandeDTO>()
                .ForMember(dest => dest.IdsToutousQuantites, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ToutouQuantiteDTO, CommandeToutous>().ReverseMap();
            CreateMap<Toutous, GetToutousDTO>();
        }
    }
}
