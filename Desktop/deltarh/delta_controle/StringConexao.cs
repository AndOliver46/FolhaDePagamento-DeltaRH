using System;

namespace delta_controle
{

    public class StringConexao
    {
        public string stringSql = Environment.GetEnvironmentVariable("BANCO_DELTARH", EnvironmentVariableTarget.User);
    }
}
