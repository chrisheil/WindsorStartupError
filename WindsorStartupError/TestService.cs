using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindsorStartupError
{
    public interface ITestService
    {
        string GetRandomData();
    }
    public class TestService : ITestService
    {
        public string GetRandomData()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
