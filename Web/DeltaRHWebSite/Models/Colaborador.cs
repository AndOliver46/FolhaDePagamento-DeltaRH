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
        public int id_colaborador {  get; private set; }
        public string? nome {  get; private set; }
        public string? data_nascimento {  get; private set; }
        public string? cpf {  get; private set; }
        public double salario_bruto { get; private set; }
        public string? senha { get; private set; }
        public TipoContrato tipo_contrato {  get; private set; }
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
        //public Setor setor { get; private set; }

        public Colaborador(string? nome, string? data_nascimento, string? cpf, double salario_bruto, string? senha, TipoContrato tipo_contrato, int carga_horaria, string? logradouro, string? numero, string? complemento, string? bairro, string? cep, string? cidade, string? uf, string? telefone, string? telefone2, string? email)
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
        }
      
    }
}
