using BlogForest.EntityLayer.Concrete;

namespace BlogForest.DataAccessLayer.Abstract
{
    public interface IIssueDal:IGenericDal<Issue>
    {
        List<Issue> GetIssuesWithUser();
    }
}
