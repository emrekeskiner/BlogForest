using AutoMapper;
using BlogForest.BusinessLayer.Abstract;
using BlogForest.DtoLayer.IssueDto;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [Authorize]
    public class IssueController:Controller
    {
        private readonly IIssueService _issueService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public IssueController(IIssueService issueService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _issueService = issueService;
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> IssueList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);
            var value = _issueService.TGetIssuesWithUser()
                .Where(x=> x.ReportedByUserId == user.Id)
                .Where(x=>x.IsResolved==false)
                .ToList();
            var issues = _mapper.Map<List<ResultIssueDto>>(value);
            return View(issues);
        }

        [HttpGet]
        public async Task<IActionResult> IssueResolvedList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);
            var value = _issueService.TGetIssuesWithUser()
                .Where(x => x.ReportedByUserId == user.Id)
                .Where(x => x.IsResolved == true)
                .ToList();
            var issues = _mapper.Map<List<ResultIssueDto>>(value);
            return View(issues);
        }

        [HttpGet]
        public IActionResult CreateIssue()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssue(CreateWriterIssueDto createWriterIssueDto)
        {

            var createIssue = _mapper.Map<Issue>(createWriterIssueDto);
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);
            createIssue.ReportedByUserId = user.Id;

            _issueService.TInsert(createIssue);

            return RedirectToAction("IssueList","Issue", new {area="Writer"});
        }

       
    }
}
