using DeltaRHWebSite.Models.Enums;

namespace DeltaRHWebSite.Models.DTO
{
    public class ColaboradorDTO
    {
        public int id_colaborador { get; set; }
        public string? nome { get; set; }
        public DateTime? data_nascimento { get; set; }
        public string? cpf { get; set; }
        public decimal salario_bruto { get; set; }
        public string? senha { get; set; }
        public string? tipo_contrato { get; set; }
        public int carga_horaria { get; set; }
        public string? logradouro { get; set; }
        public string? numero { get; set; }
        public string? complemento { get; set; }
        public string? bairro { get; set; }
        public string? cep { get; set; }
        public string? cidade { get; set; }
        public string? uf { get; set; }
        public string? telefone { get; set; }
        public string? telefone2 { get; set; }
        public string? email { get; set; }
        public int id_setor { get; set; }
        public string? cargo { get; private set; }
        public TimeSpan? horas_banco { get; private set; }

        public ColaboradorDTO(Colaborador colaborador)
        {
            this.id_colaborador = colaborador.id_colaborador;
            this.nome = colaborador.nome;
            this.data_nascimento = colaborador.data_nascimento;
            this.cpf = colaborador.cpf;
            this.salario_bruto = colaborador.salario_bruto;
            this.senha = colaborador.senha;
            this.tipo_contrato = colaborador.tipo_contrato;
            this.carga_horaria = colaborador.carga_horaria;
            this.logradouro = colaborador.logradouro;
            this.numero = colaborador.numero;
            this.complemento = colaborador.complemento;
            this.bairro = colaborador.bairro;
            this.cep = colaborador.cep;
            this.cidade = colaborador.cidade;
            this.uf = colaborador.uf;
            this.telefone = colaborador.telefone;
            this.telefone2 = colaborador.telefone2;
            this.email = colaborador.email;
            this.id_setor = colaborador.id_setor;
            this.cargo = colaborador.cargo;
            this.horas_banco = colaborador.horas_banco;
        }
    }
}
