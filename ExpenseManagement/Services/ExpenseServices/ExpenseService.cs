using AutoMapper;
using ExpenseManagement.Data;
using ExpenseManagement.Entities;
using ExpenseManagement.Shared;

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
            Console.WriteLine($"Expense{_expense}");
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
    }
}
