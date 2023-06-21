using AutoMapper;
using ECommerce.Schema.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ECommerce.Service.RestExtension
{
    public static class MapperExtension
    {
        public static void AddMapperExtension(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile<MapperProfile>();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
