using BlogForest.EntityLayer.Concrete;

namespace BlogForest.BusinessLayer.Abstract
{
    public interface IIssueService:IGenericService<Issue>
    {
        List<Issue> TGetIssuesWithUser();
    }
}
