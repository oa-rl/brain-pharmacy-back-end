using Core.Entities;

namespace Core.Specifications
{
    public class SaleInvoiceFilterSpecification : BaseSpecification<SaleInvoiceEntity>
    {
        public SaleInvoiceFilterSpecification(SaleInvoiceSpecParams criteria) : base(x => (string.IsNullOrEmpty(criteria.Search) || x.Authorization.ToLower().Contains(criteria.Search)) &&
 (!criteria.id.HasValue || x.Id == criteria.id))
        {
            if (criteria.details)
            {
                AddInclude(x => x.Customer!);
                AddInclude(x => x.SaleInvoiceDetails!);
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
                        AddOrderBy(x => x.Authorization);
                        break;
                }
            }
        }
    }
}
