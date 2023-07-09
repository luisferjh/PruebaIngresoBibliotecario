using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Contratos
{
    public interface IMapping
    {
        TDestination Map<TDestination, TSource>(TSource source)
            where TDestination : class
            where TSource : class;
    }
}
