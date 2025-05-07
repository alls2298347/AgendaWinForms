using System.Data.SqlClient;
using System.Configuration;

namespace AgendaWF
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
