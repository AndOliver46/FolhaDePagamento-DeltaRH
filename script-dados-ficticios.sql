

-- Inserção de 10 registros na tabela tbl_empresa
INSERT INTO [dbo].[tbl_empresa] ([senha], [razao_social], [cnpj], [nome_responsavel], [cpf_responsavel], [logradouro], [numero], [complemento], [bairro], [cep], [cidade], [uf], [telefone], [telefone2], [email], [status], [vt], [vr], [ass_medica], [odonto], [gympass], [id_missaovisaovalores], [id_politicadisciplinar])
VALUES
('leroymerlin', 'Leroy Merlin', '01438784000105', 'El Leroy Che', '77788899901', 'Avenida', '456', '´Prédio', 'Alaconda', '05815-000', 'São Paulo', 'SP', '162-4967-0901', '249-6577-0902', 'leroy@comercial.com', 'Ativo', 1.00, 1.00, 3.00, 3.00, 2.00, 1, 1),
('ibm', 'ibm', '33372251010038', 'Austin Mayer', '55596314403', 'Rua Jose', '1', 'Conjunto', 'Ipiranga', '56900-455', 'São Paulo', 'SP', '231-5118-9552', '330-5668-9993', 'ibm@comercial.com', 'ativo', 1.00, 1.00, 2.00, 4.00, 2.00, 2, 2),
('cocacola', 'Coca Cola', '45997418000153', 'The Coco Colo', '54678912300', 'Rua Doce', '69', 'Fábrica', 'Liberdade', '34333-890', 'Niterói', 'RJ', '113-0895-7594', '363-2226-1456', 'cocacola@comercial.com', 'Ativo', 2.00, 3.00, 4.00, 2.00, 3.00, 3, 3),
('globo', 'GLOBO', '27865757000102', 'Maranhão do Sul', '89855500647', 'Rua das Celebridades', '6', 'Estúdio', 'Celebridades anonimas', '55698-901', 'Rondopólis', 'SP', '996-4230-1994', '776-7690-1035', 'globo@record.com', 'ativo', 2.00, 3.00, 4.00, 5.00, 6.00, 4, 4);


-- Inserção de 10 registros na tabela tbl_colaborador
INSERT INTO [dbo].[tbl_colaborador] ([nome], [data_nascimento], [cpf], [tipo_contrato], [salario_bruto], [senha], [carga_horaria], [logradouro], [numero], [complemento], [bairro], [cep], [cidade], [uf], [telefone], [telefone2], [email], [id_setor], [cargo], [status], [id_empresa], [horas_banco], [data_admissao])
VALUES
('Wagner Cristiano Santos Schunck', '1999-09-07', '47963465895', 'Fixo', 195000.00, 'wagner', 220, 'Rua Narciso Milanez', '108', 'Casa', 'Jardim Emilia', '06900-658', 'Embu-Guaçu', 'SP', '119-9722-3380', '155-0708-1102', 'assessor@adm.com', 1, 'Assessor', 'Ativo', 1, '08.00', '2022-02-22'),
('Alessandro Delfim Louro Riedel', '1981-06-22', '24456766012', 'Fixo', 7500.00, 'alessandro', 220, 'Avenida Trinta e Três', '4', 'Casa', 'Centro', '71936-999', 'Embu das Artes', 'SP', '554-5676-9165', '115-1130-9223', 'financas@pref.com', 2, 'Secretario de Finanças', 'Ativo', 1, '08.00', '2022-07-17'),
('Ana Paula Inacio Feitoza', '1988-12-20', '69110595481', 'Fixo', 5500.00, 'anapaula', 220, 'Estrada das Laranjeiras', '697', 'H', 'Val Flor', '82613-009', 'São Paulo', 'SP', '658-7099-0553', '997-6700-0104', 'til@pref.com', 1, 'Diretora de TI', 'ativo', 1, '08.00', '2022-08-01'),
('Moises da Madalena', '1976-05-04', '96423700119', 'Fixo', 7500.00, 'moises', 220, 'Rua Colina Alice', '36', 'Apartamento F2', 'BeijaFLor', '74400-901', 'Embu-Guaçu', 'SP', '963-8813-1249', '714-7136-1266', 'governo@pref.com', 3, 'Secretario de Governo', 'Ativo', 1, '08.00', '2021-01-02'),
('Marcia Ferraz Gervásio', '1988-02-05', '42668446901', 'Fixo', 4300.00, 'marcia', 220, 'Rua Jovial', '35', 'Casa', 'Vazio', '56609-011', 'São Paulo', 'SP', '887-8944-2165', '567-0530-2376', 'gabinete@pref.com', 4, 'Chefe de Gabinete', 'Ativo', 1, '08.30', '2021-05-28');
('Josue de Alves', '1993-02-06', '32965400121', 'Fixo', 180000.00, 'josue', 220, 'Rua Adonis de Plama', '632', 'Prédio', 'Plenario do Sul', '60450-123', 'São Paulo', 'SP', '110-3090-4400', '611-6947-1157', 'adm@globo.com', 21, 'Diretor Geral', 'Ativo', 5, '10.00', '2004-11-23'),
('Grazi Massafera', '1997-04-07', '11487569433', 'Fixo', 50400.00, 'grazi', 220, 'Estrada do Local Azul', '1000', 'Sobrado', 'Vazio', '64219-234', 'São Paulo', 'SP', '119-0123-077', '639-4944-9368', 'comercial@globo.com', 22, 'Diretora de TI', 'ativo', 5, '12.00', '2011-06-19'),
('Boninho da Silva', '1998-02-08', '73325409805', 'Fixo', 80800.00, 'boninho', 220, 'Rua Esther de Freitas', '133', 'Apartamento Z1', 'Pedrovez', '89119-345', 'São Paulo', 'SP', '910-1694-1118', '030-1994-4419', 'ti@globo.com', 23, 'Analista Senior', 'Ativo', 5, '08.00', '2009-02-01'),
('Luana Paes Leme', '1973-11-23', '99910498466', 'Fixo', 35000.00, 'luana', 220, 'Estrada dos Cachos', '91', 'Mansão', 'Zetto de Vele', '99664-401', 'São Paulo', 'SP', '911-6499-0110', '991-9107-6790', 'rh@globo.com', 24, 'Encarregado', 'ativo', 5, '08.30', '2001-11-06'),
('Fernanda Montegro', '1924-10-21', '65775902406', 'Fixo', 103600.00, 'fernanda', 220, 'Rua dos Quase lá', '1000', 'Palácio', 'Avenida Dourada', '11852-567', 'São Paulo', 'SP', '912-6046-6743', '662-4458-7891', 'finanças@globo.com', 25, 'Gerente Financeiro', 'Ativo', 5, '08.00', '1995-11-05');

-- Inserção de 10 registros na tabela tbl_pontoeletronico
USE BD_DELTA
SET DATEFORMAT ymd;  INSERT INTO [dbo].[tbl_pontoeletronico] 
([data], [entrada], [saida_almoco], [retorno_almoco], [saida], [tipo_justificativa], [descricao], [documento], [id_colaborador], [abono])
VALUES
('2023-11-01', '08:01:00', '12:10:00', '13:00:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-02', '08:04:00', '12:00:00', '13:00:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-03', '08:00:00', '12:09:00', '13:01:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-06', '08:00:00', '12:00:00', '13:00:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-07', '08:06:00', '12:05:00', '13:00:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-08', '08:00:00', '12:00:00', '13:00:00', '17:12:00', NULL, NULL, NULL, 1, 0),
('2023-11-09', '08:00:00', '12:00:00', '13:54:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-10', '08:02:00', '12:00:00', '13:01:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-13', '08:01:00', '12:00:00', '13:30:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-14', '08:00:00', '12:00:00', '13:10:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-15', '08:00:00', '12:00:00', '13:00:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-16', '08:00:00', '12:02:00', '13:00:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-17', '08:04:00', '12:00:00', '13:00:00', '17:38:00', NULL, NULL, NULL, 1, 0),
('2023-11-20', '08:08:00', '12:00:00', '13:00:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-21', '08:10:00', '12:34:00', '13:00:00', '17:21:00', NULL, NULL, NULL, 1, 0),
('2023-11-22', '08:00:00', '12:00:00', '13:00:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-23', '08:05:00', '12:00:00', '13:00:00', '17:23:00', NULL, NULL, NULL, 1, 0),
('2023-11-24', '08:00:00', '12:00:00', '13:00:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-27', '08:06:00', '12:21:00', '13:05:00', '17:00:00', NULL, NULL, NULL, 1, 0),
('2023-11-28', '08:00:00', '12:00:00', '13:33:00', '17:54:00', NULL, NULL, NULL, 1, 0);