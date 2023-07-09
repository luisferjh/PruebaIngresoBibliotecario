using Application.Contratos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Adapters
{
    public class AutoMapperImplementation : IMapping
    {
        private readonly IMapper _mapper;
        public AutoMapperImplementation()
        {
            _mapper = AutomapperSingleton.GetMapper();
        }

        public TDestination Map<TDestination, TSource>(TSource source)
            where TDestination : class
            where TSource : class
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
