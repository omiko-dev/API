using API.Models.User;
using AutoMapper;

namespace API.Helper
{
    public class AutoMapper : Profile 
    {

        public AutoMapper()
        {

            CreateMap<RegisterDto, User>();


        }

    }
}
