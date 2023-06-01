using Allure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApiTests.Hooks
{
    [Binding]
    public class Hook
    {
        
        public static AllureLifecycle allure = AllureLifecycle.Instance;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            allure.CleanupResultDirectory();
        }
    }
}
