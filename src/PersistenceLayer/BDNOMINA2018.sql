USE [master]
GO
CREATE DATABASE [BDNOMINA2018]
GO
ALTER DATABASE [BDNOMINA2018] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDNOMINA2018] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDNOMINA2018] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDNOMINA2018] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDNOMINA2018] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDNOMINA2018] SET  MULTI_USER 
GO
ALTER DATABASE [BDNOMINA2018] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDNOMINA2018] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDNOMINA2018] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDNOMINA2018] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDNOMINA2018] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDNOMINA2018] SET QUERY_STORE = OFF
GO
USE [BDNOMINA2018]
GO
/****** Object:  Table [dbo].[Departamentos]    Script Date: 02/03/2021 04:01:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamentos](
	[DepartamentoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Departamentos] PRIMARY KEY CLUSTERED 
(
	[DepartamentoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 02/03/2021 04:01:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[EmpleadoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[ApellidoPaterno] [varchar](100) NOT NULL,
	[ApellidoMaterno] [varchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Direccion] [varchar](200) NOT NULL,
	[Telefono] [varchar](12) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[NSS] [varchar](12) NOT NULL,
	[PuestoId] [int] NOT NULL,
	[FechaIngreso] [date] NOT NULL,
	[FechaBaja] [date] NULL,
	[Estatus] [bit] NOT NULL,
 CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED 
(
	[EmpleadoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Periodos]    Script Date: 02/03/2021 04:01:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Periodos](
	[PeriodoId] [int] NOT NULL,
	[fechaInicial] [date] NULL,
	[fechaFinal] [date] NULL,
 CONSTRAINT [PK_Periodos] PRIMARY KEY CLUSTERED 
(
	[PeriodoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puestos]    Script Date: 02/03/2021 04:01:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puestos](
	[PuestoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[DepartamentoId] [int] NOT NULL,
 CONSTRAINT [PK_Puestos] PRIMARY KEY CLUSTERED 
(
	[PuestoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 02/03/2021 04:01:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TabuladorSueldosEmpleados]    Script Date: 02/03/2021 04:01:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TabuladorSueldosEmpleados](
	[EmpleadoId] [int] NULL,
	[Sueldo] [money] NOT NULL,
	[ValesDespensa] [money] NOT NULL,
	[ISR] [money] NOT NULL,
	[IMMS] [money] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 02/03/2021 04:01:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioId] [int] IDENTITY(1,1) NOT NULL,
	[Alias] [varchar](50) NOT NULL,
	[NombreUsuario] [varchar](8) NOT NULL,
	[Contra] [varchar](8) NOT NULL,
	[Acceso] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuariosRoles]    Script Date: 02/03/2021 04:01:30 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuariosRoles](
	[UsuarioId] [int] NULL,
	[RoleId] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Departamentos] ON 

INSERT [dbo].[Departamentos] ([DepartamentoId], [Nombre]) VALUES (1, N'RECURSOS HUMANOS')
INSERT [dbo].[Departamentos] ([DepartamentoId], [Nombre]) VALUES (2, N'MARKETING')
INSERT [dbo].[Departamentos] ([DepartamentoId], [Nombre]) VALUES (3, N'SISTEMAS')
SET IDENTITY_INSERT [dbo].[Departamentos] OFF
GO
SET IDENTITY_INSERT [dbo].[Empleados] ON 

INSERT [dbo].[Empleados] ([EmpleadoId], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Direccion], [Telefono], [Email], [NSS], [PuestoId], [FechaIngreso], [FechaBaja], [Estatus]) VALUES (2, N'YARITZA', N'EK', N'ARREOLA', CAST(N'1993-04-01' AS Date), N'PARAISO MAYA CANCUN', N'9984251582', N'test@hotmail.com', N'88888', 3, CAST(N'2021-03-02' AS Date), NULL, 1)
INSERT [dbo].[Empleados] ([EmpleadoId], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Direccion], [Telefono], [Email], [NSS], [PuestoId], [FechaIngreso], [FechaBaja], [Estatus]) VALUES (3, N'JORGE', N'LOPEZ', N'LOPEZ', CAST(N'1991-06-06' AS Date), N'PARAISO MAYA CANCUN', N'9984251582', N'test@hotmail.com', N'99999', 2, CAST(N'2021-03-02' AS Date), CAST(N'2021-03-05' AS Date), 0)
INSERT [dbo].[Empleados] ([EmpleadoId], [Nombre], [ApellidoPaterno], [ApellidoMaterno], [FechaNacimiento], [Direccion], [Telefono], [Email], [NSS], [PuestoId], [FechaIngreso], [FechaBaja], [Estatus]) VALUES (4, N'TEST', N'TEST', N'TEST', CAST(N'2021-03-02' AS Date), N'PARAISO MAYA CANCUN', N'9984251582', N'test@hotmail.com', N'5555555', 1, CAST(N'2021-03-02' AS Date), NULL, 1)
SET IDENTITY_INSERT [dbo].[Empleados] OFF
GO
INSERT [dbo].[Periodos] ([PeriodoId], [fechaInicial], [fechaFinal]) VALUES (202104, CAST(N'2021-02-16' AS Date), CAST(N'2021-02-28' AS Date))
INSERT [dbo].[Periodos] ([PeriodoId], [fechaInicial], [fechaFinal]) VALUES (202105, CAST(N'2021-03-01' AS Date), CAST(N'2021-03-15' AS Date))
GO
SET IDENTITY_INSERT [dbo].[Puestos] ON 

INSERT [dbo].[Puestos] ([PuestoId], [Nombre], [DepartamentoId]) VALUES (1, N'JEFE', 1)
INSERT [dbo].[Puestos] ([PuestoId], [Nombre], [DepartamentoId]) VALUES (2, N'GERENTE', 2)
INSERT [dbo].[Puestos] ([PuestoId], [Nombre], [DepartamentoId]) VALUES (3, N'PROGRAMADOR', 3)
SET IDENTITY_INSERT [dbo].[Puestos] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name]) VALUES (1, N'ADMIN')
INSERT [dbo].[Roles] ([Id], [Name]) VALUES (2, N'TEST')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([UsuarioId], [Alias], [NombreUsuario], [Contra], [Acceso]) VALUES (1, N'Usuario Test', N'admin', N'admin', 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
INSERT [dbo].[UsuariosRoles] ([UsuarioId], [RoleId]) VALUES (1, 1)
GO
ALTER TABLE [dbo].[Empleados]  WITH CHECK ADD FOREIGN KEY([PuestoId])
REFERENCES [dbo].[Puestos] ([PuestoId])
GO
ALTER TABLE [dbo].[Puestos]  WITH CHECK ADD FOREIGN KEY([DepartamentoId])
REFERENCES [dbo].[Departamentos] ([DepartamentoId])
GO
ALTER TABLE [dbo].[UsuariosRoles]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[UsuariosRoles]  WITH CHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuarios] ([UsuarioId])
GO
USE [master]
GO
ALTER DATABASE [BDNOMINA2018] SET  READ_WRITE 
GO
