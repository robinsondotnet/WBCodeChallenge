using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration;
using PagedList;
using Wonderbox.Exam.Data.Models;
using Wonderbox.Exam.Data.Repositories;
using Wonderbox.Exam.ViewModels;

namespace Wonderbox.Exam.Mappers
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var cfg = new MapperConfigurationExpression();

            cfg.CreateMap<StudentVM, Student>().ReverseMap();

            cfg.CreateMap<IPaginatedList<Student>, IPagedList<StudentVM>>()
                .ConvertUsing((src, _, ctx) =>
                    new StaticPagedList<StudentVM>(ctx.Mapper.Map<List<StudentVM>>(src.Value), src.CurrentPage,
                        src.PageSize, src.TotalItemsCount));

            var configuration = new MapperConfiguration(cfg);
            configuration.AssertConfigurationIsValid();

            return configuration;
        }
    }
}