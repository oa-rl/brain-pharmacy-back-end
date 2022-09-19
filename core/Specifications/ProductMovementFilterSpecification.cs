using Core.Entities;

namespace Core.Specifications
{
    public class ProductMovementFilterSpecification: BaseSpecification<ProductMovementEntity>
    {
        public ProductMovementFilterSpecification(ProductMovementSpecParams criteria) : base(x => (string.IsNullOrEmpty(criteria.Search)) &&
(!criteria.id.HasValue || x.Id == criteria.id))
        {
            if (criteria.details)
            {
                AddInclude(x => x.ProductCombination!);
                AddInclude(x => x.ProductCombination!.Product!);
                AddInclude(x => x.ProductCombination!.MedicalHouse!);
                AddInclude(x => x.ProductCombination!.SaleFor!);
                AddInclude(x => x.ProductCombination!.Size!);
                AddInclude(x => x.Operationtype!);
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
