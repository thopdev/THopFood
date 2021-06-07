using System.Collections.Generic;
using AutoMapper;

namespace ThopFood.API.Extensions
{
    public static class MapperExtensions
    {
        public static IEnumerable<TOut> MapIEnumerable<TIn, TOut>(this IMapper mapper, List<TIn> input)
        {
            return mapper.Map<IEnumerable<TOut>>(input);
        }

    }
}
