using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using delta_modelo;

namespace delta_controle
{
    public class ConsultaBanco
    {
        StringConexao conecta = new StringConexao();

        public mdlEmpresa ConsultarEmpresa(string cnpj)
        {
            string consulta = conecta.stringSql;

            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string query = "SELECT * FROM tbl_empresa WHERE cnpj = @cnpj";


                    SqlCommand cmd = new SqlCommand(query, conexaodb);

                    cmd.Parameters.AddWithValue("@cnpj", cnpj);

                    SqlDataReader rd = cmd.ExecuteReader();

                    mdlEmpresa empresa = null;
                    while (rd.Read())
                    {
                        empresa = new mdlEmpresa();
                        empresa.id = rd.GetInt32(0);
                        empresa.senha = rd.GetString(1);
                        empresa.razao = rd.GetString(2);
                        empresa.cnpj = rd.GetString(3);
                        empresa.responsavel = rd.GetString(4);
                        empresa.cpf = rd.GetString(5);
                        empresa.logradouro = rd.GetString(6);
                        empresa.numero = rd.GetString(7);
                        empresa.complemento = rd.GetString(8);
                        empresa.bairro = rd.GetString(9);
                        empresa.cep = rd.GetString(10);
                        empresa.cidade = rd.GetString(11);
                        empresa.uf = rd.GetString(12);
                        empresa.fone1 = rd.GetString(13);
                        empresa.fone2 = rd.GetString(14);
                        empresa.email = rd.GetString(15);
                        empresa.status = rd.GetString(16);
                        empresa.vt = rd["vt"] == DBNull.Value ? 0.0M : (decimal?)rd["vt"];
                        empresa.vr = rd["vr"] == DBNull.Value ? 0.0M : (decimal?)rd["vr"];
                        empresa.assMedica = rd["ass_medica"] == DBNull.Value ? 0.0M : (decimal?)rd["ass_medica"];
                        empresa.odonto = rd["odonto"] == DBNull.Value ? 0.0M : (decimal?)rd["odonto"];
                        empresa.gym = rd["gympass"] == DBNull.Value ? 0.0M : (decimal?)rd["gympass"];
                        empresa.id_missao = rd.GetInt32(22);
                        empresa.id_politica = rd.GetInt32(23);
                    }
                    rd.Close();

                    if (empresa != null)
                    {
                        string query_m = "SELECT descricao FROM tbl_missaovisaovalores WHERE id_missaovisaovalores = @id_missao";

                        SqlCommand cmd_m = new SqlCommand(query_m, conexaodb);

                        cmd_m.Parameters.AddWithValue("@id_missao", empresa.id_missao);

                        SqlDataReader rd_m = cmd_m.ExecuteReader();

                        mdlMissao missao = new mdlMissao();

                        while (rd_m.Read())
                        {
                            missao.descricao = rd_m.GetString(0);
                        }
                        rd_m.Close();

                        string query_p = "SELECT descricao FROM tbl_politicadisciplinar WHERE id_politicadisciplinar = @id_politica";

                        SqlCommand cmd_p = new SqlCommand(query_p, conexaodb);

                        cmd_p.Parameters.AddWithValue("@id_politica", empresa.id_politica);

                        SqlDataReader rd_p = cmd_p.ExecuteReader();

                        mdlPolitica politica = new mdlPolitica();

                        while (rd_p.Read())
                        {
                            politica.descricao = rd_p.GetString(0);
                        }
                        rd_p.Close();
                        empresa.missao = missao;
                        empresa.politica = politica;
                    }

                    return empresa;
                }
            }
            catch(Exception ex) 
            {
                return null;
            }
        }

        public mdlEmpresa ConsultarEmpresaId(int id)
        {
            string consulta = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string query = "SELECT * FROM tbl_empresa WHERE id_empresa = @id_empresa";


                    SqlCommand cmd = new SqlCommand(query, conexaodb);

                    cmd.Parameters.AddWithValue("@id_empresa", id);

                    SqlDataReader rd = cmd.ExecuteReader();

                    mdlEmpresa empresa = null;
                    while (rd.Read())
                    {
                        empresa = new mdlEmpresa();
                        empresa.id = rd.GetInt32(0);
                        empresa.senha = rd.GetString(1);
                        empresa.razao = rd.GetString(2);
                        empresa.cnpj = rd.GetString(3);
                        empresa.responsavel = rd.GetString(4);
                        empresa.cpf = rd.GetString(5);
                        empresa.logradouro = rd.GetString(6);
                        empresa.numero = rd.GetString(7);
                        empresa.complemento = rd.GetString(8);
                        empresa.bairro = rd.GetString(9);
                        empresa.cep = rd.GetString(10);
                        empresa.cidade = rd.GetString(11);
                        empresa.uf = rd.GetString(12);
                        empresa.fone1 = rd.GetString(13);
                        empresa.fone2 = rd.GetString(14);
                        empresa.email = rd.GetString(15);
                        empresa.status = rd.GetString(16);
                        empresa.vt = rd["vt"] == DBNull.Value ? 0.0M : (decimal?)rd["vt"];
                        empresa.vr = rd["vr"] == DBNull.Value ? 0.0M : (decimal?)rd["vr"];
                        empresa.assMedica = rd["ass_medica"] == DBNull.Value ? 0.0M : (decimal?)rd["ass_medica"];
                        empresa.odonto = rd["odonto"] == DBNull.Value ? 0.0M : (decimal?)rd["odonto"];
                        empresa.gym = rd["gympass"] == DBNull.Value ? 0.0M : (decimal?)rd["gympass"];
                        empresa.id_missao = rd.GetInt32(22);
                        empresa.id_politica = rd.GetInt32(23);
                    }
                    rd.Close();

                    if (empresa != null)
                    {
                        string query_m = "SELECT descricao FROM tbl_missaovisaovalores WHERE id_missaovisaovalores = @id_missao";

                        SqlCommand cmd_m = new SqlCommand(query_m, conexaodb);

                        cmd_m.Parameters.AddWithValue("@id_missao", empresa.id_missao);

                        SqlDataReader rd_m = cmd_m.ExecuteReader();

                        mdlMissao missao = new mdlMissao();

                        while (rd_m.Read())
                        {
                            missao.descricao = rd_m.GetString(0);
                        }
                        rd_m.Close();

                        string query_p = "SELECT descricao FROM tbl_politicadisciplinar WHERE id_politicadisciplinar = @id_politica";

                        SqlCommand cmd_p = new SqlCommand(query_p, conexaodb);

                        cmd_p.Parameters.AddWithValue("@id_politica", empresa.id_politica);

                        SqlDataReader rd_p = cmd_p.ExecuteReader();

                        mdlPolitica politica = new mdlPolitica();

                        while (rd_p.Read())
                        {
                            politica.descricao = rd_p.GetString(0);
                        }
                        rd_p.Close();
                        empresa.missao = missao;
                        empresa.politica = politica;
                    }

                    return empresa;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public mdlColaborador ConsultarColab(string cpf)
        {
            string consulta = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_colaborador WHERE cpf = @cpf";


                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@cpf", cpf);

                    SqlDataReader rd = cmd.ExecuteReader();

                    mdlColaborador colaborador = null;
                    while (rd.Read())
                    {
                        colaborador = new mdlColaborador();
                        colaborador.id = rd.GetInt32(0);
                        colaborador.nome = rd.GetString(1);
                        colaborador.nascimento = rd.GetDateTime(2);
                        colaborador.cpf = rd.GetString(3);
                        colaborador.contrato = rd.GetString(4);
                        colaborador.salario = rd.GetDecimal(5);
                        colaborador.senha = rd.GetString(6);
                        colaborador.cHoraria = rd.GetInt32(7);
                        colaborador.logradouro = rd.GetString(8);
                        colaborador.numero = rd.GetString(9);
                        colaborador.complemento = rd.GetString(10);
                        colaborador.bairro = rd.GetString(11);
                        colaborador.cep = rd.GetString(12);
                        colaborador.cidade = rd.GetString(13);
                        colaborador.uf = rd.GetString(14);
                        colaborador.fone1 = rd.GetString(15);
                        colaborador.fone2 = rd.GetString(16);
                        colaborador.email = rd.GetString(17);
                        colaborador.id_setor = rd.GetInt32(18);
                        colaborador.cargo = rd.GetString(19);
                        colaborador.status = rd.GetString(20);
                        colaborador.idEmpresa = rd.GetInt32(21);
                        colaborador.horas_banco = rd.GetDecimal(22);
                    }
                    rd.Close();

                    if (colaborador != null)
                    {
                        string query_s = "SELECT nome_setor FROM tbl_setor WHERE id_setor = @id_setor";

                        SqlCommand cmd_s = new SqlCommand(query_s, conexaodb);

                        cmd_s.Parameters.AddWithValue("@id_setor", colaborador.id_setor);

                        SqlDataReader rd_s = cmd_s.ExecuteReader();

                        mdlSetor setor = new mdlSetor();

                        while (rd_s.Read())
                        {
                            setor.nome = rd_s.GetString(0);
                        }
                        rd_s.Close();

                        colaborador.setor = setor;
                    }
                    return colaborador;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<mdlSetor> ConsultarSetor(int idempresa)
        {
            string consulta = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_setor WHERE id_empresa = @id_empresa";
                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@id_empresa", idempresa);

                    SqlDataReader rd = cmd.ExecuteReader();

                    List<mdlSetor> setores = new List<mdlSetor>();
                    while (rd.Read())
                    {
                       mdlSetor setor = new mdlSetor();
                        setor.id = rd.GetInt32(0);
                        setor.nome = rd.GetString(1);
                        setor.idEmpresa = rd.GetInt32(2);

                        setores.Add(setor);
                    }
                    rd.Close();

                    return setores;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<mdlEmpresa> ListarEmpresas() 
        {
            string consulta = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_empresa";
                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    SqlDataReader rd = cmd.ExecuteReader();

                    List<mdlEmpresa> empresas = new List<mdlEmpresa>();
                    while (rd.Read())
                    {
                        mdlEmpresa empresa = new mdlEmpresa();
                        empresa.id = rd.GetInt32(0);
                        empresa.razao = rd.GetString(2);

                        empresas.Add(empresa);
                    }
                    rd.Close();

                    return empresas;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<mdlColaborador> ListarColaborador(int id_setor)
        {
            string consulta = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_colaborador WHERE id_setor = @id_setor";
                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@id_setor", id_setor);

                    SqlDataReader rd = cmd.ExecuteReader();

                    List<mdlColaborador> colabs = new List<mdlColaborador>();
                    while (rd.Read())
                    {
                        mdlColaborador colab = new mdlColaborador();

                        colab.id = rd.GetInt32(0);
                        colab.nome = rd.GetString(1);

                        colabs.Add(colab);
                    }
                    rd.Close();

                    return colabs;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public mdlSetor BuscarSetor(string id)
        {
            string consulta = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_setor WHERE id_empresa = @id_empresa";

                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@id_empresa", id);

                    SqlDataReader rd = cmd.ExecuteReader();

                    mdlSetor setor = new mdlSetor(); ;
                    while (rd.Read())
                    {
                        
                        setor.id = rd.GetInt32(0);
                        setor.nome = rd.GetString(1);
                        setor.idEmpresa = rd.GetInt32(2);

                    }
                    rd.Close();

                    if (setor != null)
                    {
                        string query_s = "SELECT razao_social FROM tbl_empresa WHERE id_empresa = @id_empresa";

                        SqlCommand cmd_s = new SqlCommand(query_s, conexaodb);

                        cmd_s.Parameters.AddWithValue("@id_empresa", setor.idEmpresa);

                        SqlDataReader rd_s = cmd_s.ExecuteReader();

                        mdlEmpresa empresa = new mdlEmpresa();

                        while (rd_s.Read())
                        {
                            empresa.razao = rd_s.GetString(2);
                        }
                        rd_s.Close();

                        setor.empresa = empresa;
                    }
                    return setor;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public mdlFolhaDePagamento BuscarFolha(int id_empresa, string mes_referencia)
        {
            string consulta = conecta.stringSql;
            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_folhadepagamento WHERE mes_referencia = @mes_referencia AND id_empresa = @id_empresa";

                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@mes_referencia", mes_referencia);
                    cmd.Parameters.AddWithValue("@id_empresa", id_empresa);

                    SqlDataReader rd = cmd.ExecuteReader();

                    mdlFolhaDePagamento folha_banco = null;
                    while (rd.Read())
                    {
                        folha_banco = new mdlFolhaDePagamento();
                        folha_banco.id_folha = (int)rd["id_folhadepagamento"];
                        if (rd["doc_folhadepagamento"] == DBNull.Value)
                        {
                            folha_banco.relatorio = null;
                        }
                        else
                        {
                            folha_banco.relatorio = (byte[])rd["doc_folhadepagamento"];
                        }
                        folha_banco.salario_base = (decimal)rd["valor_folhafinal"];
                        folha_banco.valor_desconto = (decimal)rd["valor_desc_total"];
                        folha_banco.horas_trabalhadas = (decimal)rd["horas_trab"];
                        folha_banco.salario_liquido = (decimal)rd["salario_liq"];
                        folha_banco.periodo_inicio = (DateTime)rd["periodo_inicio"];
                        folha_banco.periodo_fim = (DateTime)rd["periodo_fim"];
                        folha_banco.status_folha = (string)rd["status_folha"];
                        folha_banco.id_empresa = (int)rd["id_empresa"];
                        folha_banco.mes_referencia = (string)rd["mes_referencia"];
                    }
                    rd.Close();
                    
                    return folha_banco;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<mdlColaborador> BuscarColaboradoresAtivosEmpresa(int id_empresa)
        {
            string consulta = conecta.stringSql;

            List<mdlColaborador> colaboradores = new List<mdlColaborador>();

            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_colaborador WHERE id_empresa = @id_empresa AND status = 'ATIVO'";

                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@id_empresa", id_empresa);

                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        mdlColaborador colaborador = new mdlColaborador();
                        colaborador.id = (int)rd["id_colaborador"];
                        colaborador.nome = (string)rd["nome"];
                        colaborador.salario = (decimal)rd["salario_bruto"];
                        colaborador.cHoraria = (int)rd["carga_horaria"];
                        colaborador.horas_banco = (decimal)rd["horas_banco"];
                        colaborador.cargo = (string)rd["cargo"];
                        colaboradores.Add(colaborador);
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return colaboradores;
        }

        private mdlColaborador BuscarColaboradorPorId(int id_colaborador)
        {
            string consulta = conecta.stringSql;

            mdlColaborador colaborador = null;

            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_colaborador WHERE id_colaborador = @id_colaborador";

                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@id_colaborador", id_colaborador);

                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        colaborador = new mdlColaborador();
                        colaborador.id = (int)rd["id_colaborador"];
                        colaborador.nome = (string)rd["nome"];
                        colaborador.salario = (decimal)rd["salario_bruto"];
                        colaborador.cHoraria = (int)rd["carga_horaria"];
                        colaborador.horas_banco = (decimal)rd["horas_banco"];
                        colaborador.cargo = (string)rd["cargo"];
                    }
                    rd.Close();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return colaborador;
        }

        public List<mdlFolhaIndividual> GerarFolhasIndividuais(mdlEmpresa empresa, int id_folha_de_pagamento, DateTime periodo_inicio, DateTime periodo_fim, string mes_referencia)
        {
            List<mdlFolhaIndividual> folhas_individuais = new List<mdlFolhaIndividual>();
            
            string consulta = conecta.stringSql;

            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    List<mdlColaborador> colaboradores = BuscarColaboradoresAtivosEmpresa(empresa.id);

                    foreach (mdlColaborador colaborador in colaboradores)
                    {
                        string sql = "SELECT * FROM tbl_pontoeletronico WHERE id_colaborador = @id_colaborador AND data >= @periodo_inicio AND data <= @periodo_fim";

                        SqlCommand cmd = new SqlCommand(sql, conexaodb);

                        cmd.Parameters.AddWithValue("@id_colaborador", colaborador.id);
                        cmd.Parameters.AddWithValue("@periodo_inicio", periodo_inicio);
                        cmd.Parameters.AddWithValue("@periodo_fim", periodo_fim);

                        SqlDataReader rd = cmd.ExecuteReader();

                        List<mdlPontoEletronico> pontos_eletronicos = new List<mdlPontoEletronico>();
                        while (rd.Read())
                        {
                            mdlPontoEletronico ponto = new mdlPontoEletronico();

                            ponto.id_pontoeletronico = (int)rd["id_pontoeletronico"];
                            ponto.data = (DateTime)rd["data"];
                            ponto.entrada = rd["entrada"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)rd["entrada"];
                            ponto.saida_almoco = rd["saida_almoco"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)rd["saida_almoco"];
                            ponto.retorno_almoco = rd["retorno_almoco"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)rd["retorno_almoco"];
                            ponto.saida = rd["saida"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)rd["saida"];
                            ponto.tipo_justificativa = rd["tipo_justificativa"] == DBNull.Value ? null : (string)rd["tipo_justificativa"];
                            ponto.descricao = rd["descricao"] == DBNull.Value ? null : (string)rd["descricao"];
                            ponto.documento = rd["documento"] == DBNull.Value ? null : (byte[])rd["documento"];
                            ponto.id_colaborador = (int)rd["id_colaborador"];
                            ponto.abono = rd["abono"] == DBNull.Value ? false : (bool)rd["abono"];

                            pontos_eletronicos.Add(ponto);
                        }
                        rd.Close();


                        mdlFolhaIndividual folhaIndividual = new mdlFolhaIndividual();

                        folhaIndividual.id_folhadepagamento = id_folha_de_pagamento;
                        folhaIndividual.mes_referencia = mes_referencia;
                        folhaIndividual.colaborador = colaborador;
                        folhaIndividual.id_colaborador = colaborador.id;
                        folhaIndividual.pontos_eletronicos = pontos_eletronicos;
                        folhaIndividual.periodo_inicio = periodo_inicio;
                        folhaIndividual.periodo_fim = periodo_fim;
                        folhaIndividual.empresa = empresa;
                        folhaIndividual.status = "Pendente";

                        folhaIndividual.CalcularFolhaIndividual();

                        folhas_individuais.Add(folhaIndividual);
                    }
                }

                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    foreach (mdlFolhaIndividual folha_individual in folhas_individuais)
                    {
                        string sql = "INSERT INTO tbl_folhaindividual " +
                            "(periodo_inicio, periodo_fim, valor_folhafinal, valor_venc_total, valor_desc_total, horas_trab, horas_extras, valor_horas_extras, horas_atraso, valor_desc_atrasos, salario_liq, id_folhadepagamento, id_colaborador, mes_referencia, status) " +
                            "VALUES " +
                            "(@periodo_inicio, @periodo_fim, @valor_folhafinal, @valor_venc_total, @valor_desc_total, @horas_trab, @horas_extras, @valor_horas_extras, @horas_atraso, @valor_desc_atrasos, @salario_liq, @id_folhadepagamento, @id_colaborador, @mes_referencia, @status)";

                        SqlCommand cmd = new SqlCommand(sql, conexaodb);

                        cmd.Parameters.AddWithValue("@valor_folhafinal", folha_individual.salario_base);
                        cmd.Parameters.AddWithValue("@valor_venc_total", folha_individual.valor_vencimento);
                        cmd.Parameters.AddWithValue("@valor_desc_total", folha_individual.valor_desconto);
                        cmd.Parameters.AddWithValue("@horas_trab", folha_individual.horas_trabalhadas);
                        cmd.Parameters.AddWithValue("@horas_extras", folha_individual.horas_extras);
                        cmd.Parameters.AddWithValue("@valor_horas_extras", folha_individual.valor_horas_extras);
                        cmd.Parameters.AddWithValue("@horas_atraso", folha_individual.horas_atraso);
                        cmd.Parameters.AddWithValue("@valor_desc_atrasos", folha_individual.valor_desc_atraso);
                        cmd.Parameters.AddWithValue("@salario_liq", folha_individual.salario_liquido);
                        cmd.Parameters.AddWithValue("@id_folhadepagamento", folha_individual.id_folhadepagamento);
                        cmd.Parameters.AddWithValue("@id_colaborador", folha_individual.id_colaborador);
                        cmd.Parameters.AddWithValue("@mes_referencia", folha_individual.mes_referencia);
                        cmd.Parameters.AddWithValue("@status", folha_individual.status);
                        cmd.Parameters.AddWithValue("@periodo_inicio", folha_individual.periodo_inicio);
                        cmd.Parameters.AddWithValue("@periodo_fim", folha_individual.periodo_fim);

                        int afetados = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return folhas_individuais;
        }

        public List<mdlFolhaIndividual> BuscarFolhasIndividuais(mdlEmpresa empresa, int id_folhadepagamento)
        {
            List<mdlFolhaIndividual> folhas_individuais = new List<mdlFolhaIndividual>();

            string consulta = conecta.stringSql;

            try
            {
                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    string sql = "SELECT * FROM tbl_folhaindividual WHERE id_folhadepagamento = @id_folhadepagamento";

                    SqlCommand cmd = new SqlCommand(sql, conexaodb);

                    cmd.Parameters.AddWithValue("@id_folhadepagamento", id_folhadepagamento);

                    SqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        mdlFolhaIndividual folhaIndividual = new mdlFolhaIndividual
                        {
                            salario_base = (decimal)rd["valor_folhafinal"],
                            valor_vencimento = (decimal)rd["valor_venc_total"],
                            valor_desconto = (decimal)rd["valor_desc_total"],
                            horas_trabalhadas = (decimal)rd["horas_trab"],
                            horas_extras = (decimal)rd["horas_extras"],
                            valor_horas_extras = (decimal)rd["valor_horas_extras"],
                            horas_atraso = (decimal)rd["horas_atraso"],
                            valor_desc_atraso = (decimal)rd["valor_desc_atrasos"],
                            salario_liquido = (decimal)rd["salario_liq"],
                            id_folhadepagamento = (int)rd["id_folhadepagamento"],
                            id_colaborador = (int)rd["id_colaborador"],
                            mes_referencia = (string)rd["mes_referencia"],
                            status = (string)rd["status"],
                            periodo_inicio = (DateTime)rd["periodo_inicio"],
                            periodo_fim = (DateTime)rd["periodo_fim"]
                        };

                        folhas_individuais.Add(folhaIndividual);
                    }
                }

                using (SqlConnection conexaodb = new SqlConnection(consulta))
                {
                    conexaodb.Open();

                    foreach (mdlFolhaIndividual folha_individual in folhas_individuais)
                    {
                        mdlColaborador colaborador = BuscarColaboradorPorId(folha_individual.id_colaborador);
                        List<mdlPontoEletronico> pontos_eletronicos = new List<mdlPontoEletronico>();

                        string sql = "SELECT * FROM tbl_pontoeletronico WHERE id_colaborador = @id_colaborador AND data >= @periodo_inicio AND data <= @periodo_fim";

                        SqlCommand cmd = new SqlCommand(sql, conexaodb);

                        cmd.Parameters.AddWithValue("@id_colaborador", folha_individual.id_colaborador);
                        cmd.Parameters.AddWithValue("@periodo_inicio", folha_individual.periodo_inicio);
                        cmd.Parameters.AddWithValue("@periodo_fim", folha_individual.periodo_fim);

                        SqlDataReader rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            mdlPontoEletronico ponto = new mdlPontoEletronico();

                            ponto.id_pontoeletronico = (int)rd["id_pontoeletronico"];
                            ponto.data = (DateTime)rd["data"];
                            ponto.entrada = rd["entrada"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)rd["entrada"];
                            ponto.saida_almoco = rd["saida_almoco"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)rd["saida_almoco"];
                            ponto.retorno_almoco = rd["retorno_almoco"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)rd["retorno_almoco"];
                            ponto.saida = rd["saida"] == DBNull.Value ? TimeSpan.Zero : (TimeSpan)rd["saida"];
                            ponto.tipo_justificativa = rd["tipo_justificativa"] == DBNull.Value ? null : (string)rd["tipo_justificativa"];
                            ponto.descricao = rd["descricao"] == DBNull.Value ? null : (string)rd["descricao"];
                            ponto.documento = rd["documento"] == DBNull.Value ? null : (byte[])rd["documento"];
                            ponto.id_colaborador = (int)rd["id_colaborador"];
                            ponto.abono = rd["abono"] == DBNull.Value ? false : (bool)rd["abono"];

                            pontos_eletronicos.Add(ponto);
                        }
                        rd.Close();

                        folha_individual.colaborador = colaborador;
                        folha_individual.pontos_eletronicos = pontos_eletronicos;
                        folha_individual.empresa = empresa;
                    }
                }

                return folhas_individuais;
            }
            catch (Exception ex)
            {
                return null;
            }
        }





    }
}
