﻿using FluentValidation;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs;
using Kitchen.Application.Error;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.API.Controllers
{
    [Route("api/v1/menu")]
    [ApiController]
    public class MenuController(IMenuUseCase menuUseCase, IValidator<MenuDto> validator) : ControllerBase
    {
        private readonly IMenuUseCase _menuUseCase = menuUseCase;
        private readonly IValidator<MenuDto> _validator = validator;

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MenuDto input) { 
            try
            {
                var validation = _validator.Validate(input);

                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors.ToCustomValidationFailure());
                }

                await _menuUseCase.AddMenu(input);

                return Ok();
            } catch(Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}