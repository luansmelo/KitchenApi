using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Models.Ingredient.Validation;

namespace Kitchen.Application.UseCases
{
    public class IngredientUseCase(
        IIngredientRepository ingredientRepository,
        IMeasurementRepository measurementRepository,
        IGroupRepository groupRepository
    ) : IIngredientUseCase
    {
        private readonly IIngredientRepository _ingredientRepository = ingredientRepository;
        private readonly IMeasurementRepository _measurementRepository = measurementRepository;
        private readonly IGroupRepository _groupRepository = groupRepository;

        public async Task AddIngredient(IngredientInput input)
        {
            var measurement = await _measurementRepository.GetById(input.MeasurementId)
                ?? throw new Exception("Unidade de medida não encontrada");

            var ingredient = new Ingredient
            {
                Name = input.Name,
                Code = input.Code,
                UnitPrice = input.UnitPrice,
                MeasurementId = measurement.Id,
                GroupsOnIngredient = new List<GroupsOnIngredient>()
            };

            foreach (var groupId in input.GroupIds)
            {
                var group = await _groupRepository.GetById(groupId);
                if (group != null)
                {
                    ingredient.GroupsOnIngredient.Add(new GroupsOnIngredient 
                        { GroupId = group.Id, IngredientId = ingredient.Id}
                    );
                }
                else
                {
                    throw new Exception($"Group com Id {groupId} não encontrado");
                }
            }

            await _ingredientRepository.AddIngredient(ingredient);
        }


        public async Task DeleteById(Guid id)
        {
            return;
        }

        public async Task<Ingredient> GetById(Guid id)
        {
            return null;
        }

        public async Task<FindIngredientsResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            return null;
        }

        public async Task UpdateById(Guid id, Ingredient ingredient)
        {
            return;
        }
    }
}
