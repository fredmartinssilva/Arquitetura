using AutoMapper;
using Demo.Domain.Entities;
using Demo.UI.Mvc.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.UI.Mvc.Mappers
{
    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Produto, ProdutoView>().ReverseMap();
        }
    }
}