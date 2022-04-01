using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskGenerator
{
    //Очень много букав, пришлось вынести в отдельный файл
    public class Task
    {
        public string number; //?
        public string condition;
        public List<string> questions;
        public List<string> answers;

        public Task()
        {
            questions = new List<string>();
            answers = new List<string>();
        }
    }
}
