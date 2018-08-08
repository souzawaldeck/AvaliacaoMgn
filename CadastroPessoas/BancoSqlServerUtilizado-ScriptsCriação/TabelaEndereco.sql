USE [Cadastro]
GO

ALTER TABLE [dbo].[endereco] DROP CONSTRAINT [FK_endereco_pessoa]
GO

/****** Object:  Table [dbo].[endereco]    Script Date: 08/08/2018 04:47:16 ******/
DROP TABLE [dbo].[endereco]
GO

/****** Object:  Table [dbo].[endereco]    Script Date: 08/08/2018 04:47:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[endereco](
	[id_pessoa] [int] NOT NULL,
	[cep] [numeric](10, 0) NULL,
	[logradouro] [nchar](40) NULL,
	[numero] [numeric](9, 0) NULL,
	[bairro] [nchar](30) NULL,
	[municipio] [nchar](30) NULL,
	[uf] [nchar](2) NULL,
 CONSTRAINT [PK_endereco] PRIMARY KEY CLUSTERED 
(
	[id_pessoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[endereco]  WITH CHECK ADD  CONSTRAINT [FK_endereco_pessoa] FOREIGN KEY([id_pessoa])
REFERENCES [dbo].[pessoa] ([id_pessoa])
GO

ALTER TABLE [dbo].[endereco] CHECK CONSTRAINT [FK_endereco_pessoa]
GO

