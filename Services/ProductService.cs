namespace openmarkethubAPI.Services;

public class ProductService : IProductService
{
    public readonly IProductRepository _productRepository;
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<List<ProductDTO>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllProductsAsync(cancellationToken);

    }

    public async Task<ProductDTO> GetProductByIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        return await _productRepository.GetProductByIdAsync(productId, cancellationToken);
    }

    public async Task SaveOrEditProductAsync(ProductDTO request, CancellationToken cancellationToken)
    {
        await _productRepository.SaveOrEditProductAsync(request, cancellationToken);
    }
}