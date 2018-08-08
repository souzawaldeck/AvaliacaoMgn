USE [Cadastro]
GO

/****** Object:  Table [dbo].[pessoa]    Script Date: 08/08/2018 04:46:50 ******/
DROP TABLE [dbo].[pessoa]
GO

/****** Object:  Table [dbo].[pessoa]    Script Date: 08/08/2018 04:46:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[pessoa](
	[id_pessoa] [int] IDENTITY(1,1) NOT NULL,
	[nome] [nchar](100) NOT NULL,
	[cpf] [numeric](11, 0) NULL,
	[rg] [numeric](14, 0) NULL,
 CONSTRAINT [PK_pessoa] PRIMARY KEY CLUSTERED 
(
	[id_pessoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

