using AutoMapper;
using Notes.Domian.Models;
using System.Linq;

namespace Notes.DataAccess
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Entites.Note, Note>()
                .ReverseMap();
            CreateMap<Entites.User, User>()
                .ReverseMap(); 
            CreateMap<Entites.User[], User[]>()
                .ReverseMap();
        }
    }
}