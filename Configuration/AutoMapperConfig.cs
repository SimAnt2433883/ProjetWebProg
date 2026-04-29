using AutoMapper;
using ProjetWebProg.Data;
using ProjetWebProg.Models.Commande;

namespace ProjetWebProg.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CommandeToutous, PostCommandeDTO>().ReverseMap();
            CreateMap<Commande, PostCommandeDTO>().ReverseMap();
            
        }
    }
}
