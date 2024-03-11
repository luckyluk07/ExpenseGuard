﻿using ExpenseGuardBackend.DTOs.Income;
using ExpenseGuardBackend.Services.Incomes;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseGuardBackend.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class IncomeController : ControllerBase
	{
		private readonly IIncomeService _incomeService;

		public IncomeController(IIncomeService incomeService)
		{
			_incomeService = incomeService;
		}

		[HttpGet]
		public ActionResult<List<IncomeDto>> Get()
		{
			return Ok(_incomeService.GetAll());
		}

		[HttpGet("{id}")]
		public ActionResult<IncomeDto> Get(int id)
		{
			var income = _incomeService.Get(id);
			if (income is null)
			{
				return NotFound();
			}
			return Ok(income);
		}

		[HttpPost]
		public ActionResult<IncomeDto> Create(CreateIncomeDto income)
		{
			var newIncome = _incomeService.Create(income);
			if (newIncome is null)
			{
				return BadRequest();
			}
			return Created("todo uri to new element", newIncome);
		}

		[HttpPut("{id}")]
		public ActionResult<IncomeDto> Update([FromBody] UpdateIncomeDto income, int id) 
		{
			var updatedIncome = _incomeService.Update(income, id);
			if (updatedIncome is null)
			{
				return NotFound();
			}
			return Ok(updatedIncome);
		}


		[HttpDelete("{id}")]
		public ActionResult<bool> Delete(int id) 
		{
			var isRemoved = _incomeService.Delete(id);
			if (!isRemoved)
			{
				return NotFound();
			}
			return Ok(isRemoved);
		}
	}
}
