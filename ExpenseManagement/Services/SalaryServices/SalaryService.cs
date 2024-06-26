using AutoMapper;
using ExpenseManagement.Data;
using ExpenseManagement.Entities;
using ExpenseManagement.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManagement.Services.SalaryServices
{
    public class SalaryService : ISalaryService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public SalaryService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateSalaryRecord(SalaryDto salaryDto)
        {
            var salaryRecord = _mapper.Map<SalaryRecord>(salaryDto);

            // If no SalaryRecordID provided, generate a new one
            if (string.IsNullOrEmpty(salaryRecord.SalaryRecordID))
            {
                salaryRecord.SalaryRecordID = Guid.NewGuid().ToString();
            }

            await _repository.SalaryRepository.CreateSalaryRecord(salaryRecord);
            await _repository.save();
        }

        public async Task UpdateSalaryRecord(SalaryDto salaryDto)
        {
            var salaryRecord = _mapper.Map<SalaryRecord>(salaryDto);

            // If no SalaryRecordID provided, generate a new one
            if (string.IsNullOrEmpty(salaryRecord.SalaryRecordID))
            {
                throw new ArgumentException("Salary Record ID not provided.");
            }

            await _repository.SalaryRepository.UpdateSalaryRecord(salaryRecord);
            await _repository.save();
        }

        public async Task<SalaryDto> GetSalaryRecordById(string id)
        {
            var salaryRecord = await _repository.SalaryRepository.GetSalaryRecordById(id);
            return _mapper.Map<SalaryDto>(salaryRecord);
        }

        public async Task<List<SalaryDto>> GetSalaryRecordsByUserId(string userId)
        {
            var salaryRecords = await _repository.SalaryRepository.GetSalaryRecordsByUserId(userId);
            return _mapper.Map<List<SalaryDto>>(salaryRecords);
        }

        public async Task<SalaryDto> GetSalaryByMonthAndUserId(string userId, int year, int month)
        {
            var salaryRecord = await _repository.SalaryRepository.GetSalaryByMonthAndUserId(userId, year, month);
            return _mapper.Map<SalaryDto>(salaryRecord);

        }

        public async Task<List<SalaryDto>> GetSalariesByYearAndUserId(string userId, int year)
        {
            var salaryRecords = await _repository.SalaryRepository.GetSalariesByYearAndUserId(userId, year);
            return _mapper.Map<List<SalaryDto>>(salaryRecords);
        }
    }
}
