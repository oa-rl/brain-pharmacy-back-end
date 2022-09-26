using Core.Entities;

namespace Core.Specifications
{
    public class SaleInvoiceDetailsFilterSpecification : BaseSpecification<SaleInvoiceDetailsEntity>
    {
        public SaleInvoiceDetailsFilterSpecification(SaleInvoiceDetailsSpecParams criteria) : base(x => (string.IsNullOrEmpty(criteria.Search)) &&
   (!criteria.id.HasValue || x.Id == criteria.id))
        {
            if (criteria.details)
            {
                AddInclude(x => x.ProductCombination!);
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
                        AddOrderBy(x => x.Id);
                        break;
                }
            }
        }
    }
}
