using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delta_controle
{
    
    public class StringConexao
    {
        public string stringSql = Environment.GetEnvironmentVariable("BANCO_DELTARH", EnvironmentVariableTarget.User);
    }
}
