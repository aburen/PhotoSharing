using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace PhotoSharing.BLL.Infrastructure
{
    public class AutoMapperCollection
    {
        public IEnumerable<TDestination> Map<TSource, TDestination>(IEnumerable<TSource> source) where TSource:class where TDestination:class
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>()).CreateMapper();
            return source.Select(x => mapper.Map<TDestination>(x));
        }
    }
}
