using SeparateDMAndPMWithTracking.Domain.Common;

namespace SeparateDMAndPMWithTracking.Contracts
{
    public abstract class ModelsMapper<TDomainModel, TEntityModel>
        where TDomainModel : IAggregateRoot
        where TEntityModel : IEntityModel
    {
        protected abstract TDomainModel ToDomainModel(TEntityModel entityModel);
        protected abstract TEntityModel ToEntityModel(TDomainModel domainModel);

        protected virtual TDomainModel GetDomainResult(TEntityModel entityModel)
        {
            TDomainModel domainModel = ToDomainModel(entityModel);
            // Tip: Check on the domain model returned... is it empty? return a 'Result' for that            
            return domainModel;
        }
    }
}
