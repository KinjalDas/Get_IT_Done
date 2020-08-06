using AutoMapper;
using Get_IT_Done.DTOs;
using Get_IT_Done.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Get_IT_Done.DTOs
{
    public class DTOMapper
    {
        public static IMapper mapper { get; set; }

        public static void InitializeMapper()
        {
            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UsersDTO>();
                cfg.CreateMap<UsersDTO,Users>();
            })
            .CreateMapper(); 
        }
    }
}