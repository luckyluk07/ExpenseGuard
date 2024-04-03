using ExpenseGuardBackend.DTOs.CompanyShares;
using ExpenseGuardBackend.Mappers;
using ExpenseGuardBackend.Repositories.CompanyShares;

namespace ExpenseGuardBackend.Services.CompanyShares
{
	public class CompanyShareService : ICompanyShareService
	{
		private readonly ICompanyShareRepository _companyShareRepository;
		private readonly EntityMapper _entityMapper;

		public CompanyShareService(ICompanyShareRepository companyShareRepository, EntityMapper entityMapper)
		{
			_companyShareRepository = companyShareRepository;
			_entityMapper = entityMapper;
		}

		public List<CompanyShareDto> GetAll()
		{
			return _companyShareRepository.GetAll()
				.Select(DtoMapper.CompanyShareToDto)
				.ToList();
		}

		public CompanyShareDto? Get(int id)
		{
			var result = _companyShareRepository.Get(id);
			if (result is not null)
			{
				return DtoMapper.CompanyShareToDto(result);
			}
			return null;
		}

		public CompanyShareDto? Create(CreateCompanyShareDto createCompanyShareDto)
		{
			var companyShareToAdd = _entityMapper.CreateCompanyShareDtoToCompanyShare(createCompanyShareDto);
			var result = _companyShareRepository.Create(companyShareToAdd);
			if (result is null)
			{
				return null;
			}
			return DtoMapper.CompanyShareToDto(result);
		}

		public CompanyShareDto? Update(UpdateCompanyShareDto updateCompanyShareDto, int id)
		{
			if (Get(id) is null)
			{
				return null;
			}
			var companyShareToUpdate = _entityMapper.UpdateCompanyShareDtoToCompanyShare(updateCompanyShareDto);
			var result = _companyShareRepository.Update(companyShareToUpdate, id);
			if (result is null)
			{
				return null;
			}
			return DtoMapper.CompanyShareToDto(result);
		}

		public bool Remove(int id)
		{
			return _companyShareRepository.Remove(id);
		}
	}
}
