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
        public int id {  get; private set; }
        public string? nome {  get; private set; }
        public string? data_nascimento {  get; private set; }
        public string? cpf {  get; private set; }
        public TipoContrato tipo_contrato {  get; private set; }
        public double salario_base {  get; private set; }
        public int carga_horaria {  get; private set; }
        public string? senha {  get; private set; }

        public Colaborador(string? nome, string? data_nascimento, string? cpf, TipoContrato tipo_contrato, double salario_base, int carga_horaria, string? senha)
        {
            this.nome = nome;
            this.data_nascimento = data_nascimento;
            this.cpf = cpf;
            this.tipo_contrato = tipo_contrato;
            this.salario_base = salario_base;
            this.carga_horaria = carga_horaria;
            this.senha = senha;
        }
    }
}
