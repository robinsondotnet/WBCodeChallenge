using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using PagedList;
using Wonderbox.Exam.Data;
using Wonderbox.Exam.Data.Models;
using Wonderbox.Exam.Data.Repositories.Interfaces;
using Wonderbox.Exam.Infrastructure;
using Wonderbox.Exam.ViewModels;

namespace Wonderbox.Exam.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository, IMapper mapper) : base(mapper) 
            => _studentRepository = studentRepository;

        public async Task<ActionResult> Index(SearchFilterVM filter)
        {
            PopulateViewBagWithSearchFilter(filter);

            var sortOptions = new SortOptions(filter.SortField, filter.SortDirection);

            var paginatedStudentList = await _studentRepository.GetAsync(filter.SearchText, sortOptions, filter.Page);

            return View(Map<IPagedList<StudentVM>>(paginatedStudentList));
        }

        private void PopulateViewBagWithSearchFilter(SearchFilterVM filter)
        {
            ViewBag.CurrentSortDirection = filter.SortDirection == Constants.SORT_ASC ? Constants.SORT_ASC : Constants.SORT_DESC;
            ViewBag.NextSortDirection = filter.SortDirection == Constants.SORT_ASC ? Constants.SORT_DESC: Constants.SORT_ASC;

            ViewBag.CurrentSortField = filter.SortField;
            ViewBag.CurrentSearchText = filter.SearchText;
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var student = await _studentRepository.GetAsync(id.Value);

            if (student == null)
                return HttpNotFound();

            return View(Map<StudentVM>(student));
        }

        public ActionResult Create() => View();

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")]StudentVM studentVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _studentRepository.AddAsync(Map<Student>(studentVM));
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(studentVM);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var student = await _studentRepository.GetAsync(id.Value);

            if (student == null)
                return HttpNotFound();

            return View(Map<StudentVM>(student));
        }

        [HttpPost, ActionName("Edit")]
        public async Task<ActionResult> EditPost(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var studentToUpdate = await _studentRepository.GetAsync(id.Value);
            if (TryUpdateModel(studentToUpdate, "",
               new[] { "LastName", "FirstMidName", "EnrollmentDate" }))
            {
                try
                {
                    await _studentRepository.UpdateAsync(studentToUpdate);

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(Map<StudentVM>(studentToUpdate));
        }

        public async Task<ActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";

            var student = await _studentRepository.GetAsync(id.Value);

            if (student == null)
                return HttpNotFound();

            return View(Map<StudentVM>(student));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var student = await _studentRepository.GetAsync(id);
                await _studentRepository.DeleteAsync(student);

                return RedirectToAction("Index");
            }
            catch (RetryLimitExceededException)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id, saveChangesError = true });
            }
        }

    }
}
