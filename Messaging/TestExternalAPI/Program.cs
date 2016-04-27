using ExternalDataProvider;

namespace TestExternalAPI
{
    class Program
    {
        static async void Main(string[] args)
        {
            ExternalCalls extCalls = new ExternalCalls();
            string token = await extCalls.GetAuthenticationToken("tommy", "abcde");

            string accInfo = await extCalls.GetAccountInfo(token, "bobby");
        }
    }
}
