using BlogForest.BusinessLayer.Abstract;
using BlogForest.DataAccessLayer.Abstract;
using BlogForest.EntityLayer.Concrete;

namespace BlogForest.BusinessLayer.Concrete
{
    public class IssueManager : IIssueService
    {
        private readonly IIssueDal _issueDal;

        public IssueManager(IIssueDal issueDal)
        {
            _issueDal = issueDal;
        }

        public List<Issue> TGetIssuesWithUser()
        {
            return _issueDal.GetIssuesWithUser();
        }

        public void TDelete(int id)
        {
            _issueDal.Delete(id);
        }

        public Issue TGetById(int id)
        {
            return _issueDal.GetById(id);
        }

        public List<Issue> TGetListAll()
        {
            return _issueDal.GetListAll();
        }

        public void TInsert(Issue entity)
        {
            _issueDal.Insert(entity);
        }

        public void TUpdate(Issue entity)
        {
            _issueDal.Update(entity);
        }
    }
}
