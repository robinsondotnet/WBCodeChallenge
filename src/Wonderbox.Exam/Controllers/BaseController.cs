using System.Web.Mvc;
using AutoMapper;

namespace Wonderbox.Exam.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly IMapper _mapper;

        protected BaseController(IMapper mapper) => _mapper = mapper;

        protected TViewModel Map<TViewModel>(object model) => _mapper.Map<TViewModel>(model);
    }
}