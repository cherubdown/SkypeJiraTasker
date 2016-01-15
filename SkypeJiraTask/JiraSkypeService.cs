using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SkypeJiraTask
{
    public partial class JiraSkypeService : ServiceBase
    {
        public JiraSkypeService()
        {
            InitializeComponent();
        }

        public void OnDebug(string[] args)
        {
            OnStart(args);
        }

        protected override void OnStart(string[] args)
        {
            JiraSkypeTask task = new JiraSkypeTask();
            task.Run(args);

        }

        protected override void OnStop()
        {

        }
    }
}
