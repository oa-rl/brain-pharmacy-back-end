using Core.Entities;
using Core.Specifications;

namespace core.Specifications
{
    public class SizeFilterSpecification: BaseSpecification<SizeEntity>
    {
        public SizeFilterSpecification(SizeSpecParams criteria) : base(x => (string.IsNullOrEmpty(criteria.Search) || x.Name.ToLower().Contains(criteria.Search)) &&
         (!criteria.id.HasValue || x.Id == criteria.id))
        {
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
