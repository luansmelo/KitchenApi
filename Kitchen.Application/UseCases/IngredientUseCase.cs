using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs.Group;
using Kitchen.Application.DTOs.Ingredient;
using Kitchen.Application.DTOs.Measurement;
using Kitchen.Application.Interfaces.UseCases.Ingredient;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;
using Kitchen.Shared.Responses;

namespace Kitchen.Application.UseCases.Ingredient;

public class IngredientUseCase(
    IIngredientRepository ingredientRepository,
    IMeasurementRepository measurementRepository,
    IGroupRepository groupRepository
) : IIngredientUseCase
{
    private readonly IIngredientRepository _ingredientRepository = ingredientRepository;
    private readonly IMeasurementRepository _measurementRepository = measurementRepository;
    private readonly IGroupRepository _groupRepository = groupRepository;

    public async Task AddIngredient(IngredientDto input)
    {
        var measurement = await _measurementRepository.GetById(input.MeasurementId)
                          ?? throw new Exception("Unidade de medida não encontrada");

        var ingredient = new Domain.Entities.Ingredient()
        {
            Name = input.Name,
            Code = input.Code,
            UnitPrice = input.UnitPrice,
            MeasurementId = measurement.Id,
            GroupsOnIngredient = []
        };

        foreach (var groupId in input.GroupIds)
        {
            var group = await _groupRepository.GetById(groupId);
            if (group != null)
            {
                ingredient.GroupsOnIngredient.Add(new GroupsOnIngredient
                    { GroupId = group.Id, IngredientId = ingredient.Id }
                );
            }
        }

        await _ingredientRepository.AddIngredient(ingredient);
    }

    /* public async Task DeleteById(Guid id)
     {
         await GetById(id);

         await _ingredientRepository.DeleteById(id);
     }

     public async Task<IngredientResponse> GetById(Guid id)
     {
         var ingredient = await _ingredientRepository.GetById(id)
                          ?? throw new Exception("Insumo não encontrado");

         var groups = ingredient.GroupsOnIngredient
             .Select(g => new GroupDto
             {
                 Id = g.Id,
                 Name = g.Group.Name
             }).ToList();

         var ingredientResponse = new IngredientResponse()
         {
             Id = ingredient.Id,
             Name = ingredient.Name,
             Code = ingredient.Code,
             UnitPrice = ingredient.UnitPrice,
             Measurement = new Measurement
             {
                 Id = ingredient.Measurement.Id,
                 Name = ingredient.Measurement.Name,
             },
             Groups = groups
         };

         return ingredientResponse;
     }

     public async Task<PagedResponse<IngredientResponse>> LoadAll(int page, int pageSize, string sortOrder)
     {
         return await _ingredientRepository.LoadAll(page, pageSize, sortOrder);
     }

     public async Task UpdateById(Guid id, IngredientInput input)
     {
         await GetById(id);

         await _ingredientRepository.UpdateById(id, input);
     }*/
}