using AutoMapper;
using ExpenseManagement.Data;
using ExpenseManagement.Entities;
using ExpenseManagement.Shared;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Services.ExpenseServices
{
    public class ExpenseService
    {
        IUnitOfWork _repository;
        private readonly IMapper _mapper;
        public Expense _expense;

        public ExpenseService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void createExpense(ExpenseDTO expenseDTO, string Userid)
        {
            _expense = _mapper.Map<Expense>(expenseDTO);
            _expense.UserID = Userid;
            _expense.ExpenseID = Guid.NewGuid().ToString();
            if (_expense == null)
            {
                Console.WriteLine("Expense mapping failed");
                throw new Exception("Expense Mapping Failed");
            }

            try
            {
                    _repository.ExpenseRepository.Create(_expense);
                    _repository.save();
            }
            catch (Exception ex)
            {
                throw new Exception("Expense addition failed", ex);
            }
        }

        public Task<List<Expense>> GetbyUserID(string userid)
        {
            try
            {
                return _repository.ExpenseRepository.FindbyUserID(userid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed  {ex.Message}");
            }
        }

        public Task<Expense> GetbyID(string id)
        {
            try
            {
                return _repository.ExpenseRepository.FindbyID(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed  {ex.Message}");
            }
        }


        public void updateExpense(Expense expense)
        {
/*            _expense = _mapper.Map<Expense>(expenseDTO);
            _expense.UserID = Userid;
            _expense.ExpenseID = Guid.NewGuid().ToString();*/
            if (expense == null)
            {
                Console.WriteLine("Expense mapping failed");
                throw new Exception("Expense Mapping Failed");
            }

            try
            {
                _repository.ExpenseRepository.Update(expense);
                _repository.save();
            }
            catch (Exception ex)
            {
                throw new Exception("Expense addition failed", ex);
            }
        }

        public Task<List<Expense>> GetbyDate(DateTime date)
        {
            try
            {
                return _repository.ExpenseRepository.FindbyDate(date);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed  {ex.Message}");
            }
        }

        public Task<List<Expense>> GetbyMonth(DateTime date)
        {
            try
            {
                return _repository.ExpenseRepository.FindbyMonth(date.Month);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed  {ex.Message}");
            }
        }

        public Task<List<Expense>> GetbyUserIdAndMonth(DateTime date, string userid)
        {
            try
            {
                return _repository.ExpenseRepository.FindbyMonthandUser(date.Month, userid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed  {ex.Message}");
            }
        }

        public Task<List<Expense>> GetbyUserIdAndDate(DateTime date, string userid)
        {
            try
            {
                return _repository.ExpenseRepository.FindbyDateandUser(date, userid);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed  {ex.Message}");
            }
        }







    }
}
