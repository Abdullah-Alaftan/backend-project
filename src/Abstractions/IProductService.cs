using sda_onsite_2_csharp_backend_teamwork.src.DTOs;
using sda_onsite_2_csharp_backend_teamwork.src.Entities;
namespace sda_onsite_2_csharp_backend_teamwork.src.Abstractions
{
    public interface IProductService
    {
        public IEnumerable<ProductReadDto> FindAll(string? searchKeyword);
        public ProductReadDto FindOne(Guid productId );
        public ProductReadDto CreateOne(ProductCreateDto product);
        public bool? DeleteOne(Guid productId);
        public   ProductReadDto  UpdateOne(Guid productId, ProductUpdateDto product);
    }
}