using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JsonExceptionRepro.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
