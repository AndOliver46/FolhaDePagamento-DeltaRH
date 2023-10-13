USE BD_DELTA

INSERT INTO [dbo].[tbl_missaovisaovalores] ([descricao])
VALUES
  ('Missão 1'),
  ('Missão 2'),
  ('Missão 3'),
  ('Missão 4'),
  ('Missão 5'),
  ('Missão 6'),
  ('Missão 7'),
  ('Missão 8'),
  ('Missão 9'),
  ('Missão 10');
INSERT INTO [dbo].[tbl_politicadisciplinar] ([descricao])
VALUES
  ('Política 1'),
  ('Política 2'),
  ('Política 3'),
  ('Política 4'),
  ('Política 5'),
  ('Política 6'),
  ('Política 7'),
  ('Política 8'),
  ('Política 9'),
  ('Política 10');
INSERT INTO [dbo].[tbl_empresa] (
  [senha], [razao_social], [cnpj], [nome_responsavel], [cpf_responsavel],
  [logradouro], [numero], [complemento], [bairro], [cep], [cidade], [uf],
  [telefone], [telefone2], [email], [status], [id_missaovisaovalores], [id_politicadisciplinar])
VALUES
  ('senha1', 'Empresa 1', '1234567890', 'Responsável 1', '12345678901',
   'Rua A', '123', NULL, 'Bairro 1', '12345-678', 'Cidade 1', 'UF1',
   '123-456-7890', '987-654-3210', 'empresa1@email.com', 'Ativa', 1, 1),
  ('senha2', 'Empresa 2', '2345678901', 'Responsável 2', '23456789012',
   'Rua B', '456', 'Complemento 2', 'Bairro 2', '23456-789', 'Cidade 2', 'UF2',
   '234-567-8901', '876-543-2109', 'empresa2@email.com', 'Inativa', 2, 2),
  ('senha3', 'Empresa 3', '3456789012', 'Responsável 3', '34567890123',
   'Rua C', '789', NULL, 'Bairro 3', '34567-890', 'Cidade 3', 'UF3',
   '345-678-9012', '765-432-1098', 'empresa3@email.com', 'Ativa', 3, 3),
  ('senha4', 'Empresa 4', '4567890123', 'Responsável 4', '45678901234',
   'Rua D', '101', 'Complemento 4', 'Bairro 4', '45678-901', 'Cidade 4', 'UF4',
   '456-789-0123', '654-321-0987', 'empresa4@email.com', 'Ativa', 4, 4),
  ('senha5', 'Empresa 5', '5678901234', 'Responsável 5', '56789012345',
   'Rua E', '202', NULL, 'Bairro 5', '56789-012', 'Cidade 5', 'UF5',
   '567-890-1234', '543-210-9876', 'empresa5@email.com', 'Inativa', 5, 5),
  ('senha6', 'Empresa 6', '6789012345', 'Responsável 6', '67890123456',
   'Rua F', '303', 'Complemento 6', 'Bairro 6', '67890-123', 'Cidade 6', 'UF6',
   '678-901-2345', '432-109-8765', 'empresa6@email.com', 'Ativa', 6, 6),
  ('senha7', 'Empresa 7', '7890123456', 'Responsável 7', '78901234567',
   'Rua G', '404', NULL, 'Bairro 7', '78901-234', 'Cidade 7', 'UF7',
   '789-012-3456', '321-098-7654', 'empresa7@email.com', 'Ativa', 7, 7),
  ('senha8', 'Empresa 8', '8901234567', 'Responsável 8', '89012345678',
   'Rua H', '505', 'Complemento 8', 'Bairro 8', '89012-345', 'Cidade 8', 'UF8',
   '890-123-4567', '210-987-6543', 'empresa8@email.com', 'Inativa', 8, 8),
  ('senha9', 'Empresa 9', '9012345678', 'Responsável 9', '90123456789',
   'Rua I', '606', NULL, 'Bairro 9', '90123-456', 'Cidade 9', 'UF9',
   '901-234-5678', '098-765-4321', 'empresa9@email.com', 'Ativa', 9, 9),
  ('senha10', 'Empresa 10', '0123456789', 'Responsável 10', '01234567890',
   'Rua J', '707', 'Complemento 10', 'Bairro 10', '01234-567', 'Cidade 10', 'UF10',
   '012-345-6789', '987-654-3210', 'empresa10@email.com', 'Ativa', 10, 10);
INSERT INTO [dbo].[tbl_normaregra] ([tipo], [descricao], [id_empresa])
VALUES
  ('Tipo 1', 'Regra 1', 1),
  ('Tipo 2', 'Regra 2', 2),
  ('Tipo 3', 'Regra 3', 3),
  ('Tipo 1', 'Regra 4', 4),
  ('Tipo 2', 'Regra 5', 5),
  ('Tipo 3', 'Regra 6', 6),
  ('Tipo 1', 'Regra 7', 7),
  ('Tipo 2', 'Regra 8', 8),
  ('Tipo 3', 'Regra 9', 9),
  ('Tipo 1', 'Regra 10', 10);
INSERT INTO [dbo].[tbl_setor] ([nome_setor], [id_empresa])
VALUES
  ('Setor 1', 1),
  ('Setor 2', 2),
  ('Setor 3', 3),
  ('Setor 4', 4),
  ('Setor 5', 5),
  ('Setor 6', 6),
  ('Setor 7', 7),
  ('Setor 8', 8),
  ('Setor 9', 9),
  ('Setor 10', 10);
INSERT INTO [dbo].[tbl_colaborador] (
  [nome], [data_nascimento], [cpf], [tipo_contrato], [salario_bruto], [senha],
  [carga_horaria], [logradouro], [numero], [complemento], [bairro], [cep], [cidade], [uf],
  [telefone], [telefone2], [email], [id_setor])
VALUES
  ('Colaborador 1', '1990-01-01', '12345678901', 'Contrato 1', 3500.00, 'senha1',
   40, 'Rua A', '101', NULL, 'Bairro 1', '12345-678', 'Cidade 1', 'UF1',
   '123-456-7890', '987-654-3210', 'colaborador1@email.com', 1),
  ('Colaborador 2', '1985-02-15', '23456789012', 'Contrato 2', 4200.00, 'senha2',
   35, 'Rua B', '202', 'Complemento 2', 'Bairro 2', '23456-789', 'Cidade 2', 'UF2',
   '234-567-8901', '876-543-2109', 'colaborador2@email.com', 2),
  ('Colaborador 3', '1993-03-25', '34567890123', 'Contrato 3', 3800.00, 'senha3',
   38, 'Rua C', '303', NULL, 'Bairro 3', '34567-890', 'Cidade 3', 'UF3',
   '345-678-9012', '765-432-1098', 'colaborador3@email.com', 3),
  ('Colaborador 4', '1988-04-10', '45678901234', 'Contrato 1', 3200.00, 'senha4',
   40, 'Rua D', '404', 'Complemento 4', 'Bairro 4', '45678-901', 'Cidade 4', 'UF4',
   '456-789-0123', '654-321-0987', 'colaborador4@email.com', 4),
  ('Colaborador 5', '1995-05-20', '56789012345', 'Contrato 2', 4000.00, 'senha5',
   35, 'Rua E', '505', NULL, 'Bairro 5', '56789-012', 'Cidade 5', 'UF5',
   '567-890-1234', '543-210-9876', 'colaborador5@email.com', 5),
  ('Colaborador 6', '1992-06-30', '67890123456', 'Contrato 3', 3600.00, 'senha6',
   38, 'Rua F', '606', 'Complemento 6', 'Bairro 6', '67890-123', 'Cidade 6', 'UF6',
   '678-901-2345', '432-109-8765', 'colaborador6@email.com', 6),
  ('Colaborador 7', '1991-07-05', '78901234567', 'Contrato 1', 3300.00, 'senha7',
   40, 'Rua G', '707', NULL, 'Bairro 7', '78901-234', 'Cidade 7', 'UF7',
   '789-012-3456', '321-098-7654', 'colaborador7@email.com', 7),
  ('Colaborador 8', '1987-08-15', '89012345678', 'Contrato 2', 4100.00, 'senha8',
   35, 'Rua H', '808', 'Complemento 8', 'Bairro 8', '89012-345', 'Cidade 8', 'UF8',
   '890-123-4567', '210-987-6543', 'colaborador8@email.com', 8),
  ('Colaborador 9', '1994-09-22', '90123456789', 'Contrato 3', 3700.00, 'senha9',
   38, 'Rua I', '909', NULL, 'Bairro 9', '90123-456', 'Cidade 9', 'UF9',
   '901-234-5678', '098-765-4321', 'colaborador9@email.com', 9),
  ('Colaborador 10', '1986-10-03', '01234567890', 'Contrato 1', 3400.00, 'senha10',
   40, 'Rua J', '1010', 'Complemento 10', 'Bairro 10', '01234-567', 'Cidade 10', 'UF10',
   '012-345-6789', '987-654-3210', 'colaborador10@email.com', 10);
INSERT INTO [dbo].[tbl_folhadepagamento] (
  [valor_folhafinal], [valor_desc_total], [horas_trab], [salario_liq],
  [periodo_inicio], [periodo_fim], [id_empresa])
VALUES
  (3500.00, 300.00, 160.00, 3200.00, '2023-08-01', '2023-08-31', 1),
  (4200.00, 350.00, 140.00, 3850.00, '2023-08-01', '2023-08-31', 2),
  (3800.00, 320.00, 152.00, 3480.00, '2023-08-01', '2023-08-31', 3),
  (3200.00, 280.00, 160.00, 2920.00, '2023-08-01', '2023-08-31', 4),
  (4000.00, 340.00, 136.00, 3660.00, '2023-08-01', '2023-08-31', 5),
  (3600.00, 310.00, 156.00, 3290.00, '2023-08-01', '2023-08-31', 6),
  (3300.00, 290.00, 160.00, 3010.00, '2023-08-01', '2023-08-31', 7),
  (4100.00, 350.00, 140.00, 3760.00, '2023-08-01', '2023-08-31', 8),
  (3700.00, 320.00, 152.00, 3380.00, '2023-08-01', '2023-08-31', 9),
  (3400.00, 280.00, 160.00, 3120.00, '2023-08-01', '2023-08-31', 10);
INSERT INTO [dbo].[tbl_folhaindividual] (
  [periodo_inicio], [periodo_fim], [valor_folhafinal], [valor_desc_total],
  [horas_trab], [salario_liq], [id_folhadepagamento], [id_colaborador])
VALUES
  ('2023-08-01', '2023-08-31', 3200.00, 300.00, 160.00, 3200.00, 1, 1),
  ('2023-08-01', '2023-08-31', 3850.00, 350.00, 140.00, 3850.00, 2, 2),
  ('2023-08-01', '2023-08-31', 3480.00, 320.00, 152.00, 3480.00, 3, 3),
  ('2023-08-01', '2023-08-31', 2920.00, 280.00, 160.00, 2920.00, 4, 4),
  ('2023-08-01', '2023-08-31', 3660.00, 340.00, 136.00, 3660.00, 5, 5),
  ('2023-08-01', '2023-08-31', 3290.00, 310.00, 156.00, 3290.00, 6, 6),
  ('2023-08-01', '2023-08-31', 3010.00, 290.00, 160.00, 3010.00, 7, 7),
  ('2023-08-01', '2023-08-31', 3760.00, 350.00, 140.00, 3760.00, 8, 8),
  ('2023-08-01', '2023-08-31', 3380.00, 320.00, 152.00, 3380.00, 9, 9),
  ('2023-08-01', '2023-08-31', 3120.00, 280.00, 160.00, 3120.00, 10, 10);
INSERT INTO [dbo].[tbl_holerite] (
  [horas_trab], [valor_desc_total], [salario_liq], [id_folhadepagamento], [id_colaborador])
VALUES
  (160.00, 30.00, 3200.00, 1, 1),
  (140.00, 35.00, 3850.00, 2, 2),
  (152.00, 32.00, 3480.00, 3, 3),
  (160.00, 28.00, 2920.00, 4, 4),
  (136.00, 34.00, 3660.00, 5, 5),
  (156.00, 31.00, 3290.00, 6, 6),
  (160.00, 29.00, 3010.00, 7, 7),
  (140.00, 35.00, 3760.00, 8, 8),
  (152.00, 32.00, 3380.00, 9, 9),
  (160.00, 28.00, 3120.00, 10, 10);
INSERT INTO [dbo].[tbl_pontoeletronico] (
  [data], [entrada], [saida_almoco], [retorno_almoco], [saida], [tipo_justificativa],
  [descricao], [documento], [id_colaborador])
VALUES
  ('2023-08-01 00:00:00', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada', 'Ponto do dia 1', NULL, 1),
  ('2023-08-02 00:00:00', '08:15:00', '12:30:00', '13:30:00', '17:15:00', 'Entrada', 'Ponto do dia 2', NULL, 2),
  ('2023-08-03 00:00:00', '08:10:00', '12:20:00', '13:20:00', '17:10:00', 'Entrada', 'Ponto do dia 3', NULL, 3),
  ('2023-08-04 00:00:00', '08:05:00', '12:10:00', '13:10:00', '17:05:00', 'Entrada', 'Ponto do dia 4', NULL, 4),
  ('2023-08-05 00:00:00', '08:30:00', '12:45:00', '13:45:00', '17:30:00', 'Entrada', 'Ponto do dia 5', NULL, 5),
  ('2023-08-06 00:00:00', '08:20:00', '12:40:00', '13:40:00', '17:20:00', 'Entrada', 'Ponto do dia 6', NULL, 6),
  ('2023-08-07 00:00:00', '08:25:00', '12:35:00', '13:35:00', '17:25:00', 'Entrada', 'Ponto do dia 7', NULL, 7),
  ('2023-08-08 00:00:00', '08:15:00', '12:30:00', '13:30:00', '17:15:00', 'Entrada', 'Ponto do dia 8', NULL, 8),
  ('2023-08-09 00:00:00', '08:10:00', '12:20:00', '13:20:00', '17:10:00', 'Entrada', 'Ponto do dia 9', NULL, 9),
  ('2023-08-10 00:00:00', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada', 'Ponto do dia 10', NULL, 10);
