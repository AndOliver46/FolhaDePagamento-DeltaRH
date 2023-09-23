USE [BD_DELTA]

/****** Object:  Table [dbo].[tbl_MissaoVisaoValores]    Script Date: 31/08/2023 21:30:24 ******/
CREATE TABLE [dbo].[tbl_missaovisaovalores](
	[id_missaovisaovalores] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[descricao] [varchar](256) NOT NULL;

/****** Object:  Table [dbo].[tbl_PoliticaDisciplinar]    Script Date: 31/08/2023 21:30:24 ******/
CREATE TABLE [dbo].[tbl_politicadisciplinar](
	[id_politicadisciplinar] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[descricao] [varchar](256) NOT NULL;

/****** Object:  Table [dbo].[tbl_empresa]    Script Date: 31/08/2023 21:30:24 ******/
CREATE TABLE [dbo].[tbl_empresa](
	[id_empresa] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[senha] [varchar](20) NOT NULL,
	[razao_social] [varchar](40) NOT NULL,
	[cnpj] [varchar](20) NOT NULL UNIQUE,
	[nome_responsavel] [varchar](50) NOT NULL,
	[cpf_responsavel] [varchar](15) NOT NULL UNIQUE,
	[logradouro] [varchar](15) NOT NULL,
	[numero] [varchar](10) NOT NULL,
	[complemento] [varchar](15) NULL,
	[bairro] [varchar](15) NOT NULL,
	[cep] [varchar](9) NOT NULL,
	[cidade] [varchar](30) NOT NULL,
	[uf] [varchar](2) NOT NULL,
	[telefone] [varchar](20) NOT NULL,
	[telefone2] [varchar](20) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[id_missaovisaovalores] [int] NOT NULL,
	[id_politicadisciplinar] [int] NOT NULL,
	CONSTRAINT FK_empresa_missaovisaovalores FOREIGN KEY (id_missaovisaovalores) 
	REFERENCES tbl_missaovisaovalores(id_missaovisaovalores),
	CONSTRAINT FK_empresa_politicadisciplinar FOREIGN KEY (id_politicadisciplinar) 
	REFERENCES tbl_politicadisciplinar(id_politicadisciplinar));

/****** Object:  Table [dbo].[tbl_NormaRegra]    Script Date: 31/08/2023 21:30:24 ******/

CREATE TABLE [dbo].[tbl_normaregra](
	[id_normaregra] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[tipo] [varchar](20) NULL,
	[descricao] [varchar](200) NULL,
	[id_empresa] [int] NOT NULL,
	CONSTRAINT FK_normaregra_empresa FOREIGN KEY (id_empresa) 
	REFERENCES tbl_empresa(id_empresa));

/****** Object:  Table [dbo].[tbl_setor]    Script Date: 31/08/2023 21:30:24 ******/

CREATE TABLE [dbo].[tbl_setor](
	[id_setor] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[nome_setor] [varchar](25) NOT NULL,
	[id_empresa] [int] NOT NULL,
	CONSTRAINT FK_setor_empresa FOREIGN KEY (id_empresa) 
	REFERENCES tbl_empresa(id_empresa));

CREATE TABLE [dbo].[tbl_colaborador](
	[id_colaborador] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[nome] [varchar](50) NOT NULL,
	[data_nascimento] [date] NOT NULL,
	[cpf] [varchar](15) NOT NULL UNIQUE,
	[tipo_contrato] [varchar](20) NOT NULL,
	[salario_bruto] [decimal](8, 2) NOT NULL,
	[senha] [varchar](200) NOT NULL,
	[carga_horaria] [int] NOT NULL,
	[logradouro] [varchar](80) NOT NULL,
	[numero] [varchar](10) NOT NULL,
	[complemento] [varchar](20) NULL,
	[bairro] [varchar](20) NOT NULL,
	[cep] [varchar](15) NOT NULL,
	[cidade] [varchar](30) NOT NULL,
	[uf] [varchar](3) NOT NULL,
	[telefone] [varchar](15) NOT NULL,
	[telefone2] [varchar](15) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[id_setor] [int] NOT NULL,
	CONSTRAINT FK_colaborador_setor FOREIGN KEY (id_setor) 
	REFERENCES tbl_setor(id_setor));

/****** Object:  Table [dbo].[tbl_FolhadePgt]    Script Date: 31/08/2023 21:30:24 ******/
CREATE TABLE [dbo].[tbl_folhadepagamento](
	[id_folhadepagamento] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[valor_folhafinal] [decimal](12, 2) NOT NULL,
	[valor_desc_total] [decimal](12, 2) NOT NULL,
	[horas_trab] [decimal](5, 2) NOT NULL,
	[salario_liq] [decimal](12, 2) NOT NULL,
	[periodo_inicio] [date] NOT NULL,
	[periodo_fim] [date] NOT NULL,
	[id_empresa] [int] NOT NULL,
	CONSTRAINT FK_folhadepagamento_empresa FOREIGN KEY (id_empresa) 
	REFERENCES tbl_empresa(id_empresa));

/****** Object:  Table [dbo].[tbl_FolhaInd]    Script Date: 31/08/2023 21:30:24 ******/
CREATE TABLE [dbo].[tbl_folhaindividual](
	[id_folhaindividual] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[periodo_inicio] [date] NOT NULL,
	[periodo_fim] [date] NOT NULL,
	[valor_folhafinal] [decimal](12, 2) NOT NULL,
	[valor_desc_total] [decimal](12, 2) NOT NULL,
	[horas_trab] [decimal](5, 2) NOT NULL,
	[salario_liq] [decimal](12, 2) NOT NULL,
	[id_folhadepagamento] [int] NOT NULL,
	[id_colaborador] [int] NOT NULL,
	CONSTRAINT FK_folhaindividual_folhadepagamento FOREIGN KEY (id_folhadepagamento) 
	REFERENCES tbl_folhadepagamento(id_folhadepagamento),
	CONSTRAINT FK_folhaindividual_colaborador FOREIGN KEY (id_colaborador) 
	REFERENCES tbl_colaborador(id_colaborador));

/****** Object:  Table [dbo].[tbl_Holerite]    Script Date: 31/08/2023 21:30:24 ******/
CREATE TABLE [dbo].[tbl_holerite](
	[id_holerite] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[horas_trab] [decimal](5, 2) NOT NULL,
	[valor_desc_total] [decimal](12, 2) NOT NULL,
	[salario_liq] [decimal](12, 2) NOT NULL,
	[id_folhadepagamento] [int] NOT NULL,
	[id_colaborador] [int] NOT NULL,
	CONSTRAINT FK_holerite_folhadepagamento FOREIGN KEY (id_folhadepagamento) 
	REFERENCES tbl_folhadepagamento(id_folhadepagamento),
	CONSTRAINT FK_holerite_colaborador FOREIGN KEY (id_colaborador) 
	REFERENCES tbl_colaborador(id_colaborador));

/****** Object:  Table [dbo].[tbl_PontoEletronico]    Script Date: 31/08/2023 21:30:24 ******/

CREATE TABLE [dbo].[tbl_pontoeletronico](
	[id_pontoeletronico] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[data] [date] NOT NULL,
	[entrada] [datetime] NOT NULL,
	[saida_almoco] [datetime] NOT NULL,
	[retorno_almoco] [datetime] NOT NULL,
	[saida] [datetime] NOT NULL,
	[tipoJustificativa] [varchar](20),
	[descricao] [varchar](200),
	[documento] VARBINARY(MAX),
	[id_colaborador] [int] NOT NULL,
	CONSTRAINT FK_pontoeletronico_colaborador FOREIGN KEY (id_colaborador) 
	REFERENCES tbl_colaborador(id_colaborador));

/****** Object:  Table [dbo].[tbl_UsuarioRH]    Script Date: 31/08/2023 21:30:24 ******/

CREATE TABLE [dbo].[tbl_usuariodesktop](
	[id_acesso] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[nome] [varchar](40) NOT NULL,
	[senha] [varchar](16) NOT NULL,
	[tipo_acesso] [varchar](10) NOT NULL);
