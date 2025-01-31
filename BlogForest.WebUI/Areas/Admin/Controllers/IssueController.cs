using AutoMapper;
using BlogForest.BusinessLayer.Abstract;
using BlogForest.DtoLayer.IssueDto;
using BlogForest.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class IssueController : Controller
    {
        private readonly IIssueService _issueService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public IssueController(IIssueService issueService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _issueService = issueService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult IssueList()
        {
            var value = _issueService.TGetIssuesWithUser()
               // .Where(x => x.IsResolved == false)
                .ToList();
            var issues = _mapper.Map<List<ResultIssueDto>>(value);
            return View(issues);
        }


        [HttpGet]
        public IActionResult ResponseIssue(int id)
        {
            var value = _issueService.TGetById(id);
            var issue = _mapper.Map<UpdateAdminIssueDto>(value);
            return View(issue);
        }
        [HttpPost]
        public async Task<IActionResult> ResponseIssue(UpdateAdminIssueDto updateAdminIssue)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name);
            var value = _issueService.TGetById(updateAdminIssue.IssueId);
            value.Response = updateAdminIssue.Response;
            value.ResolutionDetails = updateAdminIssue.ResolutionDetails;
            value.ResolvedAt = updateAdminIssue.ResolvedAt;
            value.AdminComments = updateAdminIssue.AdminComments;
            value.AdminUserId = user.Id;
            value.IsResolved = true;
            _issueService.TUpdate(value);
            return RedirectToAction("IssueList", "Issue", new { area = "Writer" });
        }
    }
}
