USE [master]
GO
/****** Object:  Database [Bookstore]    Script Date: 9/24/2024 1:20:18 PM ******/
CREATE DATABASE [Bookstore]
 
GO
USE [Bookstore]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 9/24/2024 1:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NOT NULL,
	[Author] [varchar](255) NOT NULL,
	[PublishedYear] [int] NULL,
	[Genre] [varchar](100) NULL,
	[UsuarioId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/24/2024 1:20:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](150) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[FullName] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Title], [Author], [PublishedYear], [Genre], [UsuarioId]) VALUES (1, N'El Alquimista', N'Paulo Coelho', 1988, N'Ficción', NULL)
INSERT [dbo].[Books] ([Id], [Title], [Author], [PublishedYear], [Genre], [UsuarioId]) VALUES (2, N'1984', N'George Orwell', 1949, N'Distopía', NULL)
INSERT [dbo].[Books] ([Id], [Title], [Author], [PublishedYear], [Genre], [UsuarioId]) VALUES (3, N'Cien años de soledad', N'Gabriel García Márquez', 1967, N'Realismo mágico', NULL)
INSERT [dbo].[Books] ([Id], [Title], [Author], [PublishedYear], [Genre], [UsuarioId]) VALUES (4, N'El Principito', N'Antoine de Saint-Exupéry', 1943, N'Fábula', NULL)
INSERT [dbo].[Books] ([Id], [Title], [Author], [PublishedYear], [Genre], [UsuarioId]) VALUES (5, N'Don Quijote de la Mancha', N'Miguel de Cervantes', 1605, N'Novela', NULL)
INSERT [dbo].[Books] ([Id], [Title], [Author], [PublishedYear], [Genre], [UsuarioId]) VALUES (6, N'El Hobbit', N'J.R.R. Tolkien', 1937, N'Fantasía', NULL)
INSERT [dbo].[Books] ([Id], [Title], [Author], [PublishedYear], [Genre], [UsuarioId]) VALUES (7, N'Moby Dick', N'Herman Melville', 1851, N'Aventura', NULL)
INSERT [dbo].[Books] ([Id], [Title], [Author], [PublishedYear], [Genre], [UsuarioId]) VALUES (8, N'Orgullo y prejuicio', N'Jane Austen', 1813, N'Romance', NULL)
INSERT [dbo].[Books] ([Id], [Title], [Author], [PublishedYear], [Genre], [UsuarioId]) VALUES (9, N'Crimen y castigo', N'Fiódor Dostoyevski', 1866, N'Ficción', NULL)
INSERT [dbo].[Books] ([Id], [Title], [Author], [PublishedYear], [Genre], [UsuarioId]) VALUES (10, N'La sombra del viento', N'Carlos Ruiz Zafón', 2001, N'Ficción', NULL)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO


SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__536C85E4E625E698]    Script Date: 9/24/2024 1:20:18 PM ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__A9D10534DF74A614]    Script Date: 9/24/2024 1:20:18 PM ******/
ALTER TABLE [dbo].[Usuarios] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Bookstore] SET  READ_WRITE 
GO
