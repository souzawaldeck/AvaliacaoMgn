USE [Cadastro]
GO

ALTER TABLE [dbo].[telefones] DROP CONSTRAINT [FK_telefones_pessoa]
GO

/****** Object:  Table [dbo].[telefones]    Script Date: 08/08/2018 04:47:44 ******/
DROP TABLE [dbo].[telefones]
GO

/****** Object:  Table [dbo].[telefones]    Script Date: 08/08/2018 04:47:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[telefones](
	[id_telefone] [int] IDENTITY(1,1) NOT NULL,
	[tipo] [nchar](15) NOT NULL,
	[numero] [numeric](20, 0) NOT NULL,
	[id_pessoa] [int] NOT NULL,
 CONSTRAINT [PK_telefones] PRIMARY KEY CLUSTERED 
(
	[id_telefone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[telefones]  WITH CHECK ADD  CONSTRAINT [FK_telefones_pessoa] FOREIGN KEY([id_pessoa])
REFERENCES [dbo].[pessoa] ([id_pessoa])
GO

ALTER TABLE [dbo].[telefones] CHECK CONSTRAINT [FK_telefones_pessoa]
GO

