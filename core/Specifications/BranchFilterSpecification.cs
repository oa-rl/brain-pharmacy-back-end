using Core.Entities;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BranchFilterSpecification : BaseSpecification<BranchEntity>
    {
        public BranchFilterSpecification(BranchSpecParams criteria) : base(x => (string.IsNullOrEmpty(criteria.Search) || x.Name.ToLower().Contains(criteria.Search)) &&
        (!criteria.id.HasValue || x.Id == criteria.id))
        {
            if (criteria.details) {
                AddInclude(x => x.Company!);
            }
            ApplyPaging(criteria.PageSize * (criteria.PageIndex - 1), criteria.PageSize);
            if (!string.IsNullOrEmpty(criteria.sort))
            {
                switch (criteria.sort)
                {
                    case "idAsc":
                        AddOrderBy(x => x.Id);
                        break;
                    case "idDesc":
                        AddOrderByDesc(x => x.Id);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }
    }
}
