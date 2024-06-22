using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatbotIA.Model
{
   public class Resposta
    {
        public List<Choice> choices { get; set; }
        public Data[] data { get; set; }
        public class Choice
        {
            public int index { get; set; }
            public string logoprobs { get; set; }
            public string finish_reason { get; set; }

            public message message { get; set; }
            public string description { get; set; }
        }

        public class message
        {
            public string role { get; set; }
            public string content { get; set; }
        }

        public class Data
        {
            public string url { get; set; }

        }
    }
}
