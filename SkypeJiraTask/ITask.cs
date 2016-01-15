using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkypeJiraTask
{
    public interface ITask
    {
        void Run(string[] args);
    }
}
