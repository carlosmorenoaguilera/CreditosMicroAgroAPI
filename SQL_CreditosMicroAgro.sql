USE [CreditosMicroAgro]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 18/08/2022 3:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[identidad] [nvarchar](max) NOT NULL,
	[ciudad] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[creditos]    Script Date: 18/08/2022 3:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[creditos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha] [datetime] NOT NULL,
	[tipo_producto] [nvarchar](max) NOT NULL,
	[monto] [money] NOT NULL,
	[plazo] [nvarchar](max) NOT NULL,
	[cliente] [bigint] NOT NULL,
 CONSTRAINT [PK_creditos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[empleados]    Script Date: 18/08/2022 3:44:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[empleados](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](max) NOT NULL,
	[nombre] [nvarchar](max) NOT NULL,
	[identidad] [nvarchar](max) NOT NULL,
	[tipo] [nvarchar](max) NOT NULL,
	[idGUID] [uniqueidentifier] NOT NULL,
	[email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_empleados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[empleados] ADD  DEFAULT (newid()) FOR [idGUID]
GO
