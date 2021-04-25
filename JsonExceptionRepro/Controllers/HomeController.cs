using JsonExceptionRepro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JsonExceptionRepro.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ThisWillWork()
        {
            Question question = new()
            { Id = 1, Text = "Is this a test question?" };


            //Note here that I have left Answer.Question property unset
            List<Answer> answers = new()
            {
                new() { Id = 1, Text = "Yes", IsCorrect = true},
                new() { Id = 2, Text = "No", IsCorrect = false}
            };

            question.Answers = answers;

            return View("ParentView", question);
        }

      
        public IActionResult ThisWillNotWork()
        {
            Question question = new()
            { Id = 1, Text = "Is this a test question?" };


            //Here I'm setting Answer.Question for each answer, this creates a cycle
            List<Answer> answers = new()
            {
                new() { Id = 1, Text = "Yes", IsCorrect = true, Question = question },
                new() { Id = 2, Text = "No", IsCorrect = false, Question = question }
            };

            question.Answers = answers;

            return View("ParentView", question);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
