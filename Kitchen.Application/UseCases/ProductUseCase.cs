﻿using AutoMapper;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs.Product;
using Kitchen.Application.Interfaces.UseCases.Product;
using Kitchen.Domain.Enums;
using Kitchen.Domain.Interfaces;

namespace Kitchen.Application.UseCases.Product;

public class ProductUseCase(IProductRepository productRepository, IMapper mapper) : IProductUseCase
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IMapper _mapper = mapper;

    /*public async Task AddInputToProduct(AddIngredientToProductInput product)
    {
        await GetById(product.ProductId);

        await _productRepository.AddInputToProduct(product);
    }*/

    public async Task<ProductDto> AddProduct(ProductDto product)
    {

        var productMapper = _mapper.Map<Domain.Entities.Product>(product);
        productMapper.Status = Status.Incomplete.ToString();
        var productCreated = await _productRepository.AddProduct(productMapper);

        return _mapper.Map<ProductDto>(productCreated);
    }

    public async Task<ProductDto> DeleteById(Guid id)
    {
        var product = await GetById(id);

        var productMapper = _mapper.Map<Domain.Entities.Product>(product);

        var productDeleted = await _productRepository.DeleteById(productMapper);

        return _mapper.Map<ProductDto>(productDeleted);
    }

    public async Task<ProductResponseDto> GetById(Guid id)
    {
        var product = await _productRepository.GetById(id)
                      ?? throw new Exception("Produto não encontrado");

        return _mapper.Map<ProductResponseDto>(product);
    }

  /*  public async Task<FindProductsResponseDto> LoadAll(int page, int pageSize, string sortOrder)
    {
        var products = await _productRepository.LoadAll(page, pageSize, sortOrder);

        return _mapper.Map<FindProductsResponseDto>(products);
    }*/

    public async Task RemoveInputToProduct(Guid productId, Guid ingredientId)
    {
        await GetById(productId);
        await _productRepository.RemoveInputToProduct(productId, ingredientId);
    }

   /* public async Task UpdateById(Guid id, UpdateProduct product)
    {
        await GetById(id);
        await _productRepository.UpdateById(id, product);
    }*/
}