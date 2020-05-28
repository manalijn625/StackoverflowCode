using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlow.Models.IRepository
{
    interface IQuestionInfo
    {
        //IEnumerable<Question> GetAll();
        //Employee GetEmployeeByID(int Id);
        void Create(QuestionInfo questioninfo);
        //void DeleteEmployee(int Id);
        //void UpdateEmployee(Employee employee);
        //void Save();
    }
}
