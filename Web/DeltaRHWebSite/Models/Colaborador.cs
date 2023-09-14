using DeltaRHWebSite.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace DeltaRHWebSite.Models
{
    [Table("tbl_colaborador")]
    public class Colaborador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_colaborador {  get; private set; }
        public string? nome {  get; private set; }
        public DateTime? data_nascimento {  get; private set; }
        public string? cpf {  get; private set; }
        public decimal salario_bruto { get; private set; }
        public string? senha { get; private set; }
        public string? tipo_contrato {  get; private set; }
        public int carga_horaria {  get; private set; }
        public string? logradouro { get; private set; }
        public string? numero { get; private set; }
        public string? complemento { get; private set; }
        public string? bairro { get; private set; }
        public string? cep { get; private set; }
        public string? cidade { get; private set; }
        public string? uf { get; private set; }
        public string? telefone { get; private set; }
        public string? telefone2 { get; private set; }
        public string? email { get; private set; }

        //Associacoes
        public int id_setor { get; set; }
        [NotMapped]
        public Setor? setor { get; set; }

        public Colaborador(string? nome, DateTime? data_nascimento, string? cpf, decimal salario_bruto, string? senha, string? tipo_contrato, int carga_horaria, string? logradouro, string? numero, string? complemento, string? bairro, string? cep, string? cidade, string? uf, string? telefone, string? telefone2, string? email, int id_setor)
        {
            this.nome = nome;
            this.data_nascimento = data_nascimento;
            this.cpf = cpf;
            this.salario_bruto = salario_bruto;
            this.senha = senha;
            this.tipo_contrato = tipo_contrato;
            this.carga_horaria = carga_horaria;
            this.logradouro = logradouro;
            this.numero = numero;
            this.complemento = complemento;
            this.bairro = bairro;
            this.cep = cep;
            this.cidade = cidade;
            this.uf = uf;
            this.telefone = telefone;
            this.telefone2 = telefone2;
            this.email = email;
            this.id_setor = id_setor;
        }


      
    }
}
