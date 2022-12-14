using System;
using Core.Entities;

namespace Core.Specifications
{
	public class ProductCombinationFilterSpecification: BaseSpecification<ProductCombinationEntity>
    {
        public ProductCombinationFilterSpecification(ProductCombinationSpecParams criteria) : base(x => (string.IsNullOrEmpty(criteria.Search)) &&
     (!criteria.id.HasValue || x.Id == criteria.id))
        {
            if (criteria.details)
            {
                AddInclude(x => x.Product!);
                AddInclude(x => x.Size!);
                AddInclude(x => x.MedicalHouse!);
                AddInclude(x => x.SaleFor!);
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
                        AddOrderByDesc(x => x.Id);
                        break;
                }
            }
        }
    }
}

