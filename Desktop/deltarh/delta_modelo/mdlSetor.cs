namespace delta_modelo
{
    public class mdlSetor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int idEmpresa { get; set; }

        public mdlEmpresa empresa { get; set; }
    }
}
