-- Inserção de 10 registros na tabela tbl_missaovisaovalores
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

-- Inserção de 10 registros na tabela tbl_politicadisciplinar
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

-- Inserção de 10 registros na tabela tbl_empresa
INSERT INTO [dbo].[tbl_empresa] ([senha], [razao_social], [cnpj], [nome_responsavel], [cpf_responsavel], [logradouro], [numero], [complemento], [bairro], [cep], [cidade], [uf], [telefone], [telefone2], [email], [status], [vt], [vr], [ass_medica], [odonto], [gympass], [id_missaovisaovalores], [id_politicadisciplinar])
VALUES
('senha1', 'Empresa 1', '1234567890', 'Responsável 1', '12345678901', 'Endereço 1', '123', 'Comp. 1', 'Bairro 1', '12345-678', 'Cidade 1', 'UF1', '123-4567-8901', '123-4567-8902', 'email1@empresa.com', 'Ativo', 1.00, 2.00, 3.00, 4.00, 5.00, 1, 1),
('senha2', 'Empresa 2', '2345678901', 'Responsável 2', '23456789012', 'Endereço 2', '234', 'Comp. 2', 'Bairro 2', '23456-789', 'Cidade 2', 'UF2', '234-5678-9012', '234-5678-9013', 'email2@empresa.com', 'Inativo', 1.00, 2.00, 3.00, 4.00, 5.00, 2, 2),
('senha3', 'Empresa 3', '3456789012', 'Responsável 3', '34567890123', 'Endereço 3', '345', 'Comp. 3', 'Bairro 3', '34567-890', 'Cidade 3', 'UF3', '345-6789-0123', '345-6789-0124', 'email3@empresa.com', 'Ativo', 2.00, 3.00, 4.00, 5.00, 6.00, 3, 3),
('senha4', 'Empresa 4', '4567890123', 'Responsável 4', '45678901234', 'Endereço 4', '456', 'Comp. 4', 'Bairro 4', '45678-901', 'Cidade 4', 'UF4', '456-7890-1234', '456-7890-1235', 'email4@empresa.com', 'Inativo', 2.00, 3.00, 4.00, 5.00, 6.00, 4, 4),
('senha5', 'Empresa 5', '5678901234', 'Responsável 5', '56789012345', 'Endereço 5', '567', 'Comp. 5', 'Bairro 5', '56789-012', 'Cidade 5', 'UF5', '567-8901-2345', '567-8901-2346', 'email5@empresa.com', 'Ativo', 3.00, 4.00, 5.00, 6.00, 7.00, 5, 5),
('senha6', 'Empresa 6', '6789012345', 'Responsável 6', '67890123456', 'Endereço 6', '678', 'Comp. 6', 'Bairro 6', '67890-123', 'Cidade 6', 'UF6', '678-9012-3456', '678-9012-3457', 'email6@empresa.com', 'Inativo', 3.00, 4.00, 5.00, 6.00, 7.00, 6, 6),
('senha7', 'Empresa 7', '7890123456', 'Responsável 7', '78901234567', 'Endereço 7', '789', 'Comp. 7', 'Bairro 7', '78901-234', 'Cidade 7', 'UF7', '789-0123-4567', '789-0123-4568', 'email7@empresa.com', 'Ativo', 4.00, 5.00, 6.00, 7.00, 8.00, 7, 7),
('senha8', 'Empresa 8', '8901234567', 'Responsável 8', '89012345678', 'Endereço 8', '890', 'Comp. 8', 'Bairro 8', '89012-345', 'Cidade 8', 'UF8', '890-1234-5678', '890-1234-5679', 'email8@empresa.com', 'Inativo', 4.00, 5.00, 6.00, 7.00, 8.00, 8, 8),
('senha9', 'Empresa 9', '9012345678', 'Responsável 9', '90123456789', 'Endereço 9', '901', 'Comp. 9', 'Bairro 9', '90123-456', 'Cidade 9', 'UF9', '901-2345-6789', '901-2345-6790', 'email9@empresa.com', 'Ativo', 5.00, 6.00, 7.00, 8.00, 9.00, 9, 9),
('senha10', 'Empresa 10', '0123456789', 'Responsável 10', '01234567890', 'Endereço 10', '0123', 'Comp. 10', 'Bairro 10', '01234-567', 'Cidade 10', 'UF10', '012-3456-7890', '012-3456-7891', 'email10@empresa.com', 'Inativo', 5.00, 6.00, 7.00, 8.00, 9.00, 10, 10);

-- Inserção de 10 registros na tabela tbl_normaregra
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

-- Inserção de 10 registros na tabela tbl_setor
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

-- Inserção de 10 registros na tabela tbl_colaborador
INSERT INTO [dbo].[tbl_colaborador] ([nome], [data_nascimento], [cpf], [tipo_contrato], [salario_bruto], [senha], [carga_horaria], [logradouro], [numero], [complemento], [bairro], [cep], [cidade], [uf], [telefone], [telefone2], [email], [id_setor], [cargo], [status], [id_empresa], [horas_banco])
VALUES
('Colaborador 1', '1990-01-01', '12345678901', 'Contrato 1', 3000.00, 'senha1', 220, 'Endereço 1', '123', 'Comp. 1', 'Bairro 1', '12345-678', 'Cidade 1', 'UF1', '123-4567-8901', '123-4567-8902', 'email1@colaborador.com', 1, 'Cargo 1', 'Ativo', 1, '08.00'),
('Colaborador 2', '1991-02-02', '23456789012', 'Contrato 2', 3500.00, 'senha2', 220, 'Endereço 2', '234', 'Comp. 2', 'Bairro 2', '23456-789', 'Cidade 2', 'UF2', '234-5678-9012', '234-5678-9013', 'email2@colaborador.com', 1, 'Cargo 2', 'Ativo', 1, '09.00'),
('Colaborador 3', '1992-03-03', '34567890123', 'Contrato 3', 4000.00, 'senha3', 220, 'Endereço 3', '345', 'Comp. 3', 'Bairro 3', '34567-890', 'Cidade 3', 'UF3', '345-6789-0123', '345-6789-0124', 'email3@colaborador.com', 1, 'Cargo 3', 'Inativo', 1, '10.00'),
('Colaborador 4', '1993-04-04', '45678901234', 'Contrato 1', 3200.00, 'senha4', 220, 'Endereço 4', '456', 'Comp. 4', 'Bairro 4', '45678-901', 'Cidade 4', 'UF4', '456-7890-1234', '456-7890-1235', 'email4@colaborador.com', 1, 'Cargo 1', 'Inativo', 1, '07.00'),
('Colaborador 5', '1994-05-05', '56789012345', 'Contrato 2', 3700.00, 'senha5', 220, 'Endereço 5', '567', 'Comp. 5', 'Bairro 5', '56789-012', 'Cidade 5', 'UF5', '567-8901-2345', '567-8901-2346', 'email5@colaborador.com', 1, 'Cargo 2', 'Ativo', 1, '08.30'),
('Colaborador 6', '1995-06-06', '67890123456', 'Contrato 3', 4100.00, 'senha6', 220, 'Endereço 6', '678', 'Comp. 6', 'Bairro 6', '67890-123', 'Cidade 6', 'UF6', '678-9012-3456', '678-9012-3457', 'email6@colaborador.com', 1, 'Cargo 3', 'Ativo', 1, '08.00'),
('Colaborador 7', '1996-07-07', '78901234567', 'Contrato 1', 3400.00, 'senha7', 220, 'Endereço 7', '789', 'Comp. 7', 'Bairro 7', '78901-234', 'Cidade 7', 'UF7', '789-0123-4567', '789-0123-4568', 'email7@colaborador.com', 1, 'Cargo 1', 'Inativo', 1, '09.30'),
('Colaborador 8', '1997-08-08', '89012345678', 'Contrato 2', 3800.00, 'senha8', 220, 'Endereço 8', '890', 'Comp. 8', 'Bairro 8', '89012-345', 'Cidade 8', 'UF8', '890-1234-5678', '890-1234-5679', 'email8@colaborador.com', 8, 'Cargo 2', 'Ativo', 8, '10.00'),
('Colaborador 9', '1998-09-09', '90123456789', 'Contrato 3', 4200.00, 'senha9', 220, 'Endereço 9', '901', 'Comp. 9', 'Bairro 9', '90123-456', 'Cidade 9', 'UF9', '901-2345-6789', '901-2345-6790', 'email9@colaborador.com', 9, 'Cargo 3', 'Inativo', 9, '07.30'),
('Colaborador 10', '1999-10-10', '01234567890', 'Contrato 1', 3600.00, 'senha10', 220, 'Endereço 10', '0123', 'Comp. 10', 'Bairro 10', '01234-567', 'Cidade 10', 'UF10', '012-3456-7890', '012-3456-7891', 'email10@colaborador.com', 10, 'Cargo 1', 'Ativo', 10, '09.00');

-- Inserção de 10 registros na tabela tbl_pontoeletronico
INSERT INTO [dbo].[tbl_pontoeletronico] ([data], [entrada], [saida_almoco], [retorno_almoco], [saida], [tipo_justificativa], [descricao], [documento], [id_colaborador], [abono])
VALUES
('2023-09-01', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-02', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-05', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-06', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-07', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-08', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-09', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-12', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-13', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-14', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-15', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-16', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-19', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-20', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-21', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-22', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-23', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-26', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-27', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-28', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-29', '08:00:00', '12:00:00', '13:00:00', '17:00:00', 'Entrada/Saída', 'Descrição 1', NULL, 1, 0),
('2023-09-02', '08:15:00', '12:15:00', '13:15:00', '17:15:00', 'Entrada/Saída', 'Descrição 2', NULL, 2, 0),
('2023-09-03', '08:30:00', '12:30:00', '13:30:00', '17:30:00', 'Entrada/Saída', 'Descrição 3', NULL, 3, 0),
('2023-09-04', '08:45:00', '12:45:00', '13:45:00', '17:45:00', 'Entrada/Saída', 'Descrição 4', NULL, 4, 0),
('2023-09-05', '09:00:00', '13:00:00', '14:00:00', '18:00:00', 'Entrada/Saída', 'Descrição 5', NULL, 5, 0),
('2023-09-06', '09:15:00', '13:15:00', '14:15:00', '18:15:00', 'Entrada/Saída', 'Descrição 6', NULL, 6, 0),
('2023-09-07', '09:30:00', '13:30:00', '14:30:00', '18:30:00', 'Entrada/Saída', 'Descrição 7', NULL, 7, 0),
('2023-09-08', '09:45:00', '13:45:00', '14:45:00', '18:45:00', 'Entrada/Saída', 'Descrição 8', NULL, 8, 0),
('2023-09-09', '10:00:00', '14:00:00', '15:00:00', '19:00:00', 'Entrada/Saída', 'Descrição 9', NULL, 9, 0),
('2023-09-10', '10:15:00', '14:15:00', '15:15:00', '19:15:00', 'Entrada/Saída', 'Descrição 10', NULL, 10, 0);