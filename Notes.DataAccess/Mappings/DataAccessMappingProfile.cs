using AutoMapper;
using Notes.Domian.Models;

namespace Notes.DataAccess
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Note, Entites.Note>()
                .ReverseMap();
        }
    }
}