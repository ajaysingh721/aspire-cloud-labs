using AzureCloudLabs.API.Domain.Entities;

namespace AzureCloudLabs.API.Application.Interfaces
{
    public interface IDataWriterService<T> where T : BaseEntity
    {
        Task<int> Add(T entity);
    }
}
