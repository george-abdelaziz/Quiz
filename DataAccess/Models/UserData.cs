using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class UserData
    {
        [Key]
        public string Email { get; set; }
        public List<QuizAnswer> QuizAnswers { get; set; }
    }
}
