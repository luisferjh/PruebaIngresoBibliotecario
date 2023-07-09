using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Adapters
{
    public class AutomapperSingleton
    {
        private static IMapper mapper = null;
        private static string CreatedOn;
        private AutomapperSingleton()
        {
            CreatedOn = DateTime.Now.ToString();
        }

        public static IMapper GetMapper()
        {
            if (mapper == null)
            {
                var configMapper = new MapperConfiguration(cfg => {
                    cfg.AddProfile<PrestamoProfile>();
                   
                });

                mapper = configMapper.CreateMapper();
                return mapper;
            }
            else
            {
                return mapper;
            }
        }
    }
}
