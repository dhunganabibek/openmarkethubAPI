public interface IProductService
{
    Task<List<ProductDTO>> GetAllProductsAsync(CancellationToken cancellationToken);
    Task<ProductDTO> GetProductByIdAsync(Guid productId, CancellationToken cancellationToken);
    Task SaveOrEditProductAsync(ProductDTO request, CancellationToken cancellationToken);
}