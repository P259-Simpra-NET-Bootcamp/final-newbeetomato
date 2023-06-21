using AutoMapper;
using ECommerce.Data.Domain;
using ECommerce.Schema.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Schema.Mapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<Data.Domain.Category, CategoryResponse>();

    }


}
