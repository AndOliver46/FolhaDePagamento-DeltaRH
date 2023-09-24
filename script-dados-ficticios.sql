USE BD_DELTA;

-- Inserir mais 10 valores fictícios na tabela tbl_missaovisaovalores
INSERT INTO dbo.tbl_missaovisaovalores (descricao)
VALUES
  ('Missão 11'),
  ('Missão 12'),
  ('Missão 13'),
  ('Missão 14'),
  ('Missão 15'),
  ('Missão 16'),
  ('Missão 17'),
  ('Missão 18'),
  ('Missão 19'),
  ('Missão 20');

-- Inserir mais 10 valores fictícios na tabela tbl_politicadisciplinar
INSERT INTO dbo.tbl_politicadisciplinar (descricao)
VALUES
  ('Política 11'),
  ('Política 12'),
  ('Política 13'),
  ('Política 14'),
  ('Política 15'),
  ('Política 16'),
  ('Política 17'),
  ('Política 18'),
  ('Política 19'),
  ('Política 20');

-- Inserir mais 10 valores fictícios na tabela tbl_empresa
INSERT INTO dbo.tbl_empresa (senha, razao_social, cnpj, nome_responsavel, cpf_responsavel, logradouro, numero, complemento, bairro, cep, cidade, uf, telefone, telefone2, email, status, id_missaovisaovalores, id_politicadisciplinar)
VALUES
  ('SenhaEmpresa11', 'Empresa 11', '12345678901111', 'Responsável 11', '11111111111', 'Rua 11', '1111', 'Sala 11A', 'Bairro 11', '11111-111', 'Cidade 11', 'SP', '(11) 1111-1111', '(11) 1111-1111', 'empresa11@example.com', 'Ativo', 1, 1),
  ('SenhaEmpresa12', 'Empresa 12', '12345678901222', 'Responsável 12', '22222222222', 'Rua 12', '1222', 'Sala 12B', 'Bairro 12', '22222-222', 'Cidade 12', 'RJ', '(22) 2222-2222', '(22) 2222-2222', 'empresa12@example.com', 'Ativo', 2, 2),
  ('SenhaEmpresa13', 'Empresa 13', '12345678901333', 'Responsável 13', '33333333333', 'Rua 13', '1333', 'Sala 13C', 'Bairro 13', '33333-333', 'Cidade 13', 'MG', '(33) 3333-3333', '(33) 3333-3333', 'empresa13@example.com', 'Ativo', 3, 3),
  ('SenhaEmpresa14', 'Empresa 14', '12345678901444', 'Responsável 14', '44444444444', 'Rua 14', '1444', 'Sala 14D', 'Bairro 14', '44444-444', 'Cidade 14', 'RS', '(44) 4444-4444', '(44) 4444-4444', 'empresa14@example.com', 'Ativo', 4, 4),
  ('SenhaEmpresa15', 'Empresa 15', '12345678901555', 'Responsável 15', '55555555555', 'Rua 15', '1555', 'Sala 15E', 'Bairro 15', '55555-555', 'Cidade 15', 'BA', '(55) 5555-5555', '(55) 5555-5555', 'empresa15@example.com', 'Ativo', 5, 5),
  ('SenhaEmpresa16', 'Empresa 16', '12345678901666', 'Responsável 16', '66666666666', 'Rua 16', '1666', 'Sala 16F', 'Bairro 16', '66666-666', 'Cidade 16', 'CE', '(66) 6666-6666', '(66) 6666-6666', 'empresa16@example.com', 'Ativo', 6, 6),
  ('SenhaEmpresa17', 'Empresa 17', '12345678901777', 'Responsável 17', '77777777777', 'Rua 17', '1777', 'Sala 17G', 'Bairro 17', '77777-777', 'Cidade 17', 'PE', '(77) 7777-7777', '(77) 7777-7777', 'empresa17@example.com', 'Ativo', 7, 7),
  ('SenhaEmpresa18', 'Empresa 18', '12345678901888', 'Responsável 18', '88888888888', 'Rua 18', '1888', 'Sala 18H', 'Bairro 18', '88888-888', 'Cidade 18', 'PR', '(88) 8888-8888', '(88) 8888-8888', 'empresa18@example.com', 'Ativo', 8, 8),
  ('SenhaEmpresa19', 'Empresa 19', '12345678901999', 'Responsável 19', '99999999999', 'Rua 19', '1999', 'Sala 19I', 'Bairro 19', '99999-999', 'Cidade 19', 'SC', '(99) 9999-9999', '(99) 9999-9999', 'empresa19@example.com', 'Ativo', 9, 9),
  ('SenhaEmpresa20', 'Empresa 20', '12345678902020', 'Responsável 20', '20202020202', 'Rua 20', '2020', 'Sala 20J', 'Bairro 20', '20202-020', 'Cidade 20', 'GO', '(20) 2020-2020', '(20) 2020-2020', 'empresa20@example.com', 'Ativo', 10, 10);

-- Inserir mais 10 valores fictícios na tabela tbl_normaregra
INSERT INTO dbo.tbl_normaregra (tipo, descricao, id_empresa)
VALUES
  ('Regra 2', 'Regra 2 de Conduta', 2),
  ('Regra 3', 'Regra 3 de Conduta', 3),
  ('Regra 4', 'Regra 4 de Conduta', 4),
  ('Regra 5', 'Regra 5 de Conduta', 5),
  ('Regra 6', 'Regra 6 de Conduta', 6),
  ('Regra 7', 'Regra 7 de Conduta', 7),
  ('Regra 8', 'Regra 8 de Conduta', 8),
  ('Regra 9', 'Regra 9 de Conduta', 9),
  ('Regra 10', 'Regra 10 de Conduta', 10);

-- Inserir mais 10 valores fictícios na tabela tbl_setor
INSERT INTO dbo.tbl_setor (nome_setor, id_empresa)
VALUES
  ('Departamento 2', 1),
  ('Departamento 3', 2),
  ('Departamento 4', 3),
  ('Departamento 5', 4),
  ('Departamento 6', 5),
  ('Departamento 7', 6),
  ('Departamento 8', 7),
  ('Departamento 9', 8),
  ('Departamento 10', 9);

-- Inserir mais 10 valores fictícios na tabela tbl_colaborador
INSERT INTO dbo.tbl_colaborador (nome, data_nascimento, cpf, tipo_contrato, salario_bruto, senha, carga_horaria, logradouro, numero, complemento, bairro, cep, cidade, uf, telefone, telefone2, email, id_setor)
VALUES
  ('Carlos Rodrigues', '1985-09-20', '12345678912', 'CLT', 4000.00, 'SenhaColaborador11', 40, 'Av. 21', '21', 'Bloco B', 'Bairro C', '21212-121', 'Cidade C', 'RJ', '(21) 2121-2121', '(21) 9876-5432', 'carlos@example.com', 1),
  ('Ana Silva', '1992-03-10', '98765432123', 'CLT', 3500.00, 'SenhaColaborador12', 40, 'Rua 22', '22', 'Sala 22A', 'Bairro D', '22222-222', 'Cidade D', 'SP', '(22) 2222-2222', '(22) 9876-5432', 'ana@example.com', 2),
  ('Roberto Pereira', '1988-06-15', '23456789034', 'CLT', 3800.00, 'SenhaColaborador13', 40, 'Rua 23', '23', 'Sala 23B', 'Bairro E', '23232-323', 'Cidade E', 'MG', '(33) 3333-3333', '(33) 9876-5432', 'roberto@example.com', 3),
  ('Carla Santos', '1990-01-05', '34567890145', 'CLT', 4200.00, 'SenhaColaborador14', 40, 'Av. 24', '24', 'Bloco C', 'Bairro F', '24242-424', 'Cidade F', 'RS', '(44) 4444-4444', '(44) 9876-5432', 'carla@example.com', 4),
  ('Paulo Oliveira', '1983-12-30', '45678901256', 'CLT', 3700.00, 'SenhaColaborador15', 40, 'Rua 25', '25', 'Sala 25D', 'Bairro G', '25252-525', 'Cidade G', 'BA', '(55) 5555-5555', '(55) 9876-5432', 'paulo@example.com', 5),
  ('Fernanda Lima', '1995-04-18', '56789012367', 'CLT', 3900.00, 'SenhaColaborador16', 40, 'Av. 26', '26', 'Sala 26E', 'Bairro H', '26262-626', 'Cidade H', 'PE', '(66) 6666-6666', '(66) 9876-5432', 'fernanda@example.com', 6),
  ('Ricardo Sousa', '1987-07-22', '67890123478', 'CLT', 4100.00, 'SenhaColaborador17', 40, 'Rua 27', '27', 'Sala 27F', 'Bairro I', '27272-727', 'Cidade I', 'PR', '(77) 7777-7777', '(77) 9876-5432', 'ricardo@example.com', 7),
  ('Sandra Almeida', '1998-10-12', '78901234589', 'CLT', 3600.00, 'SenhaColaborador18', 40, 'Av. 28', '28', 'Sala 28G', 'Bairro J', '28282-828', 'Cidade J', 'SC', '(88) 8888-8888', '(88) 9876-5432', 'sandra@example.com', 8),
  ('Márcio Pereira', '1980-02-25', '89012345690', 'CLT', 4300.00, 'SenhaColaborador19', 40, 'Rua 29', '29', 'Sala 29H', 'Bairro K', '29292-929', 'Cidade K', 'GO', '(99) 9999-9999', '(99) 9876-5432', 'marcio@example.com', 9);

-- Inserir mais 10 valores fictícios na tabela tbl_folhadepagamento
INSERT INTO dbo.tbl_folhadepagamento (valor_folhafinal, valor_desc_total, horas_trab, salario_liq, periodo_inicio, periodo_fim, id_empresa)
VALUES
  (3800.00, 450.00, 152, 3350.00, '2023-09-01', '2023-09-30', 1),
  (4200.00, 520.00, 168, 3680.00, '2023-09-01', '2023-09-30', 2),
  (3900.00, 480.00, 156, 3420.00, '2023-09-01', '2023-09-30', 3),
  (3700.00, 460.00, 148, 3240.00, '2023-09-01', '2023-09-30', 4),
  (4100.00, 510.00, 164, 3590.00, '2023-09-01', '2023-09-30', 5),
  (3600.00, 440.00, 140, 3080.00, '2023-09-01', '2023-09-30', 6),
  (4300.00, 530.00, 172, 3770.00, '2023-09-01', '2023-09-30', 7),
  (3950.00, 490.00, 158, 3460.00, '2023-09-01', '2023-09-30', 8),
  (4150.00, 520.00, 166, 3630.00, '2023-09-01', '2023-09-30', 8);

-- Inserir mais 10 valores fictícios na tabela tbl_folhaindividual
INSERT INTO dbo.tbl_folhaindividual (periodo_inicio, periodo_fim, valor_folhafinal, valor_desc_total, horas_trab, salario_liq, id_folhadepagamento, id_colaborador)
VALUES
  ('2023-09-01', '2023-09-30', 3800.00, 450.00, 152, 3350.00, 1, 1),
  ('2023-09-01', '2023-09-30', 4200.00, 520.00, 168, 3680.00, 2, 2),
  ('2023-09-01', '2023-09-30', 3900.00, 480.00, 156, 3420.00, 3, 3),
  ('2023-09-01', '2023-09-30', 3700.00, 460.00, 148, 3240.00, 4, 4),
  ('2023-09-01', '2023-09-30', 4100.00, 510.00, 164, 3590.00, 5, 5),
  ('2023-09-01', '2023-09-30', 3600.00, 440.00, 140, 3080.00, 6, 6),
  ('2023-09-01', '2023-09-30', 4300.00, 530.00, 172, 3770.00, 7, 7),
  ('2023-09-01', '2023-09-30', 3950.00, 490.00, 158, 3460.00, 8, 8),
  ('2023-09-01', '2023-09-30', 4150.00, 520.00, 166, 3630.00, 9, 9);

-- Inserir mais 10 valores fictícios na tabela tbl_holerite
INSERT INTO dbo.tbl_holerite (horas_trab, valor_desc_total, salario_liq, id_folhadepagamento, id_colaborador)
VALUES
  (160, 50.00, 3500.00, 1, 1),
  (152, 45.00, 3350.00, 2, 2),
  (168, 52.00, 3680.00, 3, 3),
  (156, 48.00, 3420.00, 4, 4),
  (148, 46.00, 3240.00, 5, 5),
  (164, 51.00, 3590.00, 6, 6),
  (140, 44.00, 3080.00, 7, 7),
  (172, 53.00, 3770.00, 8, 8),
  (158, 49.00, 3460.00, 9, 9),
  (166, 52.00, 3630.00, 9, 9);

-- Inserir mais 10 valores fictícios na tabela tbl_pontoeletronico
INSERT INTO dbo.tbl_pontoeletronico (data, entrada, saida_almoco, retorno_almoco, saida, tipoJustificativa, id_colaborador)
VALUES
  ('2023-09-01', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'N/A', 1),
  ('2023-09-01', '08:15:00', '12:15:00', '13:15:00', '17:15:00', 'N/A', 1),
  ('2023-09-01', '08:30:00', '12:30:00', '13:30:00', '17:30:00', 'N/A', 2),
  ('2023-09-01', '08:45:00', '12:45:00', '13:45:00', '17:45:00', 'N/A', 3),
  ('2023-09-01', '09:00:00', '13:00:00', '14:00:00', '18:00:00', 'N/A', 4),
  ('2023-09-01', '09:15:00', '13:15:00', '14:15:00', '18:15:00', 'N/A', 5),
  ('2023-09-01', '09:30:00', '13:30:00', '14:30:00', '18:30:00', 'N/A', 6),
  ('2023-09-01', '09:45:00', '13:45:00', '14:45:00', '18:45:00', 'N/A', 7),
  ('2023-09-01', '10:00:00', '14:00:00', '15:00:00', '19:00:00', 'N/A', 8),
  ('2023-09-01', '10:15:00', '14:15:00', '15:15:00', '19:15:00', 'N/A', 9);
