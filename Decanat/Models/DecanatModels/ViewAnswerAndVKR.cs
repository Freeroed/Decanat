using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decanat.Models.DecanatModels
{
    public class ViewAnswerAndVKR
    {
        public List<Answer> answers;
        public VKR vkr;
        public int id;

        public ViewAnswerAndVKR(List<Answer> answers, VKR vkr)
        {
            this.answers = answers;
            this.vkr = vkr;
        }
        public ViewAnswerAndVKR(List<Answer> answers)
        {
            this.answers = answers;
        }
        public ViewAnswerAndVKR(List<Answer> answers, int id)
        {
            this.answers = answers;
            this.id = id;
        }
        public ViewAnswerAndVKR(VKR vkr)
        {
            this.vkr =vkr;
        }
        public ViewAnswerAndVKR(VKR vkr, int id) 
        {
            this.vkr = vkr;
            this.id = id;
        }
    }
}