using AzureCloudLabs.API.Domain.Entities;

namespace AzureCloudLabs.API.Application.Interfaces
{
    public interface IDataReaderService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
    }
}
