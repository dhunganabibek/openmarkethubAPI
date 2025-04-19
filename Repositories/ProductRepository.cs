using Microsoft.EntityFrameworkCore;
using openmarkethubAPI.Entities;

namespace openmarkethubAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MasterContext _masterContext;
    public ProductRepository(MasterContext masterContext)
    {
        _masterContext = masterContext;
    }

    public async Task<List<ProductDTO>> GetAllProductsAsync(CancellationToken cancellationToken){

        var allProducts = await _masterContext.Product
            .Select(x => new ProductDTO{
                ProductID = x.ProductID,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).ToListAsync(cancellationToken);

        return allProducts;
    }

    public async Task<ProductDTO> GetProductByIdAsync(Guid productId, CancellationToken cancellationToken)
    {
        var product = await _masterContext.Product
            .Where(x => x.ProductID == productId)
            .Select(x => new ProductDTO{
                ProductID = x.ProductID,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).SingleAsync(cancellationToken);

        if(product == null)
        {
            throw new InvalidOperationException("Product does not exist.");
        }

        return product;
    }

    public async Task SaveOrEditProductAsync(ProductDTO request, CancellationToken cancellationToken)
    {
        if(request.ProductID == default)
        {
            var newProduct = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            await _masterContext.Product.AddAsync(newProduct, cancellationToken);
        }

        var existingProduct = await _masterContext.Product
            .Where(x => x.ProductID == request.ProductID)
            .SingleAsync(cancellationToken);

        if(existingProduct == null)
        {
            throw new InvalidOperationException("Product does not exist.");
        }

        existingProduct.Name = request.Name;
        existingProduct.Description = request.Description;
        existingProduct.Price = request.Price;
        
        await _masterContext.SaveChangesAsync(cancellationToken);
    }
}