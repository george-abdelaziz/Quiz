using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IQuizAnswerRepository : IGenericRepository<QuizAnswer>
    {
        void Update(QuizAnswer answer);
    }
}
