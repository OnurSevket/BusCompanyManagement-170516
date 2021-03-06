USE [master]
GO
/****** Object:  Database [BusManagementDb]    Script Date: 22.05.2017 04:56:39 ******/
CREATE DATABASE [BusManagementDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BusManagementDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BusManagementDb.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BusManagementDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\BusManagementDb_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [BusManagementDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BusManagementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BusManagementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BusManagementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BusManagementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BusManagementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BusManagementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BusManagementDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BusManagementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BusManagementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BusManagementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BusManagementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BusManagementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BusManagementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BusManagementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BusManagementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BusManagementDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BusManagementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BusManagementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BusManagementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BusManagementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BusManagementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BusManagementDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BusManagementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BusManagementDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BusManagementDb] SET  MULTI_USER 
GO
ALTER DATABASE [BusManagementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BusManagementDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BusManagementDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BusManagementDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BusManagementDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [BusManagementDb]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[City] [int] NOT NULL,
	[District] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Authory]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[AuthoryName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Authory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BranchEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchEmployee](
	[OfficeID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_BranchEmployee] PRIMARY KEY CLUSTERED 
(
	[OfficeID] ASC,
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bus]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Brand] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Year] [date] NOT NULL,
	[BusTypeID] [int] NOT NULL,
	[Plate] [nchar](10) NOT NULL,
 CONSTRAINT [PK_BusDescription] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusEmployee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BusID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[RouteMapID] [int] NOT NULL,
 CONSTRAINT [PK_BusEmployee_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusProperty]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusProperty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BusProperty] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusPropertyBusType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusPropertyBusType](
	[BusPropertyID] [int] NOT NULL,
	[BusTypeID] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusSeat]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusSeat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BusID] [int] NOT NULL,
	[BusTypeID] [int] NOT NULL,
	[SeatNumber] [int] NOT NULL,
	[IsWindow] [bit] NOT NULL,
 CONSTRAINT [PK_BusSeat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BusType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BackDoorIndex] [int] NOT NULL,
	[SeatCount] [int] NOT NULL,
 CONSTRAINT [PK_BusType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[District]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CityID] [int] NOT NULL,
 CONSTRAINT [PK_Distinct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SocialNumber] [nchar](11) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[StartWorkDate] [datetime] NOT NULL,
	[FinishWorkDate] [datetime] NOT NULL,
	[CreatedEmployeeID] [int] NULL,
	[RoleID] [int] NOT NULL,
	[Telephone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[IsAvaiable] [bit] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginPassenger]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginPassenger](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Office]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Office](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[OfficeName] [nvarchar](50) NOT NULL,
	[DistinctID] [int] NOT NULL,
	[IsCenterOffice] [bit] NOT NULL,
 CONSTRAINT [PK_Office] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SocialNumber] [nchar](11) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [bit] NOT NULL,
	[Telephone] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Passenger] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Payment]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TotalPrice] [decimal](18, 0) NOT NULL,
	[PaymentTypeID] [int] NOT NULL,
	[CreatePaymentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PaymentType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentyTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PaymentType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoadExpense]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoadExpense](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ExpenseName] [nvarchar](50) NOT NULL,
	[BusID] [int] NOT NULL,
	[TotalPrice] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_RoadExpense] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleAuthory]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAuthory](
	[RoleID] [int] NOT NULL,
	[AuthorID] [int] NOT NULL,
 CONSTRAINT [PK_RoleAuthory] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RouteMap]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteMap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TravelID] [int] NOT NULL,
	[Departure] [int] NOT NULL,
	[Arrival] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[BeforeRouteID] [int] NULL,
 CONSTRAINT [PK_RouteMap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PassengerID] [int] NOT NULL,
	[RouteMapID] [int] NOT NULL,
	[TravelID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[BusSeatID] [int] NOT NULL,
	[CreateTicketDate] [datetime] NOT NULL,
	[PaymentID] [int] NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Travel]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Travel](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TravelNumberName] [nchar](8) NOT NULL,
 CONSTRAINT [PK_Travel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WorkHour]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WorkHour](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StartHour] [char](5) NOT NULL,
	[EndHour] [char](5) NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_WorkHour] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Employee]
GO
ALTER TABLE [dbo].[BranchEmployee]  WITH CHECK ADD  CONSTRAINT [FK_BranchEmployee_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[BranchEmployee] CHECK CONSTRAINT [FK_BranchEmployee_Employee]
GO
ALTER TABLE [dbo].[BranchEmployee]  WITH CHECK ADD  CONSTRAINT [FK_BranchEmployee_Office] FOREIGN KEY([OfficeID])
REFERENCES [dbo].[Office] ([ID])
GO
ALTER TABLE [dbo].[BranchEmployee] CHECK CONSTRAINT [FK_BranchEmployee_Office]
GO
ALTER TABLE [dbo].[Bus]  WITH CHECK ADD  CONSTRAINT [FK_BusDescription_BusType] FOREIGN KEY([BusTypeID])
REFERENCES [dbo].[BusType] ([ID])
GO
ALTER TABLE [dbo].[Bus] CHECK CONSTRAINT [FK_BusDescription_BusType]
GO
ALTER TABLE [dbo].[BusEmployee]  WITH CHECK ADD  CONSTRAINT [FK_BusEmployee_Bus] FOREIGN KEY([BusID])
REFERENCES [dbo].[Bus] ([ID])
GO
ALTER TABLE [dbo].[BusEmployee] CHECK CONSTRAINT [FK_BusEmployee_Bus]
GO
ALTER TABLE [dbo].[BusEmployee]  WITH CHECK ADD  CONSTRAINT [FK_BusEmployee_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[BusEmployee] CHECK CONSTRAINT [FK_BusEmployee_Employee]
GO
ALTER TABLE [dbo].[BusEmployee]  WITH CHECK ADD  CONSTRAINT [FK_BusEmployee_RouteMap] FOREIGN KEY([RouteMapID])
REFERENCES [dbo].[RouteMap] ([ID])
GO
ALTER TABLE [dbo].[BusEmployee] CHECK CONSTRAINT [FK_BusEmployee_RouteMap]
GO
ALTER TABLE [dbo].[BusPropertyBusType]  WITH CHECK ADD  CONSTRAINT [FK_BusPropertyBusType_BusProperty] FOREIGN KEY([BusPropertyID])
REFERENCES [dbo].[BusProperty] ([ID])
GO
ALTER TABLE [dbo].[BusPropertyBusType] CHECK CONSTRAINT [FK_BusPropertyBusType_BusProperty]
GO
ALTER TABLE [dbo].[BusPropertyBusType]  WITH CHECK ADD  CONSTRAINT [FK_BusPropertyBusType_BusType] FOREIGN KEY([BusTypeID])
REFERENCES [dbo].[BusType] ([ID])
GO
ALTER TABLE [dbo].[BusPropertyBusType] CHECK CONSTRAINT [FK_BusPropertyBusType_BusType]
GO
ALTER TABLE [dbo].[BusSeat]  WITH CHECK ADD  CONSTRAINT [FK_BusSeat_Bus] FOREIGN KEY([BusID])
REFERENCES [dbo].[Bus] ([ID])
GO
ALTER TABLE [dbo].[BusSeat] CHECK CONSTRAINT [FK_BusSeat_Bus]
GO
ALTER TABLE [dbo].[BusSeat]  WITH CHECK ADD  CONSTRAINT [FK_BusSeat_BusType] FOREIGN KEY([BusTypeID])
REFERENCES [dbo].[BusType] ([ID])
GO
ALTER TABLE [dbo].[BusSeat] CHECK CONSTRAINT [FK_BusSeat_BusType]
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD  CONSTRAINT [FK_Distinct_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[City] ([ID])
GO
ALTER TABLE [dbo].[District] CHECK CONSTRAINT [FK_Distinct_City]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([CreatedEmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Role]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Employee] FOREIGN KEY([ID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Employee]
GO
ALTER TABLE [dbo].[LoginPassenger]  WITH CHECK ADD  CONSTRAINT [FK_LoginPassenger_Passenger] FOREIGN KEY([ID])
REFERENCES [dbo].[Passenger] ([ID])
GO
ALTER TABLE [dbo].[LoginPassenger] CHECK CONSTRAINT [FK_LoginPassenger_Passenger]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentType] FOREIGN KEY([PaymentTypeID])
REFERENCES [dbo].[PaymentType] ([ID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentType]
GO
ALTER TABLE [dbo].[RoadExpense]  WITH CHECK ADD  CONSTRAINT [FK_RoadExpense_Bus] FOREIGN KEY([BusID])
REFERENCES [dbo].[Bus] ([ID])
GO
ALTER TABLE [dbo].[RoadExpense] CHECK CONSTRAINT [FK_RoadExpense_Bus]
GO
ALTER TABLE [dbo].[RoleAuthory]  WITH CHECK ADD  CONSTRAINT [FK_RoleAuthory_Authory] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authory] ([ID])
GO
ALTER TABLE [dbo].[RoleAuthory] CHECK CONSTRAINT [FK_RoleAuthory_Authory]
GO
ALTER TABLE [dbo].[RoleAuthory]  WITH CHECK ADD  CONSTRAINT [FK_RoleAuthory_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[RoleAuthory] CHECK CONSTRAINT [FK_RoleAuthory_Role]
GO
ALTER TABLE [dbo].[RouteMap]  WITH CHECK ADD  CONSTRAINT [FK_RouteMap_Distinct] FOREIGN KEY([Departure])
REFERENCES [dbo].[District] ([ID])
GO
ALTER TABLE [dbo].[RouteMap] CHECK CONSTRAINT [FK_RouteMap_Distinct]
GO
ALTER TABLE [dbo].[RouteMap]  WITH CHECK ADD  CONSTRAINT [FK_RouteMap_Distinct1] FOREIGN KEY([Arrival])
REFERENCES [dbo].[District] ([ID])
GO
ALTER TABLE [dbo].[RouteMap] CHECK CONSTRAINT [FK_RouteMap_Distinct1]
GO
ALTER TABLE [dbo].[RouteMap]  WITH CHECK ADD  CONSTRAINT [FK_RouteMap_RouteMap1] FOREIGN KEY([BeforeRouteID])
REFERENCES [dbo].[RouteMap] ([ID])
GO
ALTER TABLE [dbo].[RouteMap] CHECK CONSTRAINT [FK_RouteMap_RouteMap1]
GO
ALTER TABLE [dbo].[RouteMap]  WITH CHECK ADD  CONSTRAINT [FK_RouteMap_Travel] FOREIGN KEY([TravelID])
REFERENCES [dbo].[Travel] ([ID])
GO
ALTER TABLE [dbo].[RouteMap] CHECK CONSTRAINT [FK_RouteMap_Travel]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_BusSeat] FOREIGN KEY([BusSeatID])
REFERENCES [dbo].[BusSeat] ([ID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_BusSeat]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Employee]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Passenger] FOREIGN KEY([PassengerID])
REFERENCES [dbo].[Passenger] ([ID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Passenger]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Payment] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[Payment] ([ID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Payment]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_RouteMap] FOREIGN KEY([RouteMapID])
REFERENCES [dbo].[RouteMap] ([ID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_RouteMap]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Travel] FOREIGN KEY([TravelID])
REFERENCES [dbo].[Travel] ([ID])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Travel]
GO
ALTER TABLE [dbo].[WorkHour]  WITH CHECK ADD  CONSTRAINT [FK_WorkHour_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[WorkHour] CHECK CONSTRAINT [FK_WorkHour_Employee]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddAuthory]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_AddAuthory] 
@authoryName nvarchar(50)
 as 
 begin
 Insert Authory(AuthoryName) values (@authoryName)
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_AddBranchEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create procedure [dbo].[sp_AddBranchEmployee]
   @officeID int,
   @employeeID int
   as
   begin 
     insert into BranchEmployee(OfficeID,EmployeeID) values (@officeID,@employeeID)
   end

GO
/****** Object:  StoredProcedure [dbo].[sp_AddBus]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_AddBus]    
 @brand nvarchar(50),
 @model nvarchar(50),
 @year datetime,
 @busType int,
 @plate nchar(10)
  as 
  begin
  Insert Bus(Brand,Model,Year,BusTypeID,Plate) values (@brand,@model,@year,@busType,@plate)
  end 

GO
/****** Object:  StoredProcedure [dbo].[sp_AddBusEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_AddBusEmployee] 
@busId int,
@employeeId int,
@createDate datetime,
@routeMapId int
 as 
 begin
 Insert into BusEmployee(BusID,EmployeeID,CreateDate,RouteMapID) values (@busId,@employeeId,@createDate,@routeMapId) 
 end


GO
/****** Object:  StoredProcedure [dbo].[sp_AddBusProperty]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_AddBusProperty]   

  @name nvarchar(50)
as 
begin
Insert BusProperty(Name) values (@name)  
end



GO
/****** Object:  StoredProcedure [dbo].[sp_AddBusProperyBusType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_AddBusProperyBusType]
 @busPropertyID int,
 @busTypeID int
 as
 begin 
 	insert into BusPropertyBusType(BusTypeID,BusPropertyID) values(@busTypeID,@busPropertyID)
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_AddBusSeat]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_AddBusSeat]
  @busId int,
  @BusTypeId int,
  @seatNumber int,
  @isWindow bit
as 
begin
Insert BusSeat(BusID,BusTypeID,SeatNumber,IsWindow) values (@busId,@BusTypeId,@seatNumber,@isWindow) 
end


GO
/****** Object:  StoredProcedure [dbo].[sp_AddBusType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_AddBusType] 
@name nvarchar(50),
@backDoorIndex int,
@seatCount int
as 
begin
Insert BusType(BackDoorIndex,Name,SeatCount) values (@backDoorIndex,@name,@seatCount) 
SELECT SCOPE_IDENTITY()
end


GO
/****** Object:  StoredProcedure [dbo].[sp_AddRoleAuthory]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_AddRoleAuthory]
   @roleId int,
   @authoryId int
   as
   begin 
     insert into RoleAuthory(RoleID,AuthorID) values (@roleId,@authoryId)
   end
-------------

-------RoleData Delete


GO
/****** Object:  StoredProcedure [dbo].[sp_AddRoleInsert]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_AddRoleInsert]    --Insert Bus
    @roleName nvarchar(50) 
  as 
  begin
  Insert Role(RoleName) values (@roleName) 
  SELECT SCOPE_IDENTITY()
  end 
-------------

GO
/****** Object:  StoredProcedure [dbo].[sp_AddRouteMap]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_AddRouteMap]
   @travelId int,
   @departure int,
   @arrival int,
   @startDate datetime,
   @endDate datetime,
   @price decimal,
   @beforeRouteId int
   as
   begin
   Insert into RouteMap(TravelID,Departure,Arrival,StartDate,EndDate,Price,BeforeRouteID) values(@travelId,@departure,@arrival,@startDate,@endDate,@price,@beforeRouteId)
   end  
-------------

-------RouteMap Update

GO
/****** Object:  StoredProcedure [dbo].[sp_AddTicket]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_AddTicket]
    @passengerId int,
    @routeMapId int,
    @travelId int,
    @employeeId int,
    @busSeatId int,
    @createTicketDate datetime,
    @paymentId int
    as
    begin
    Insert into Ticket(PassengerID,RouteMapID,TravelID,EmployeeID,BusSeatID,CreateTicketDate,PaymentID) values(@passengerId,@routeMapId,@travelId,@employeeId,@busSeatId,@createTicketDate,@paymentId)
    end  
------------ 

------TicketDAL  Update

GO
/****** Object:  StoredProcedure [dbo].[sp_AddTravel]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_AddTravel]
 @travelNumberName nvarchar(50)
 as
 begin
 Insert into Travel(TravelNumberName) values(@travelNumberName)
 end 

------


-----TravelDAL Update

GO
/****** Object:  StoredProcedure [dbo].[sp_AddWorkHour]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_AddWorkHour]
      @name nvarchar(50),
      @startHour nchar(5),
      @endHour nchar(5),
      @employeeID int
      as
      begin
      Insert into WorkHour(Name,StartHour,EndHour,EmployeeID) values(@name,@startHour,@endHour,@employeeID)
      end    
	 -----------------------
	 
---------WorkHourDAL  Update

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteAddress]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DeleteAddress]
@id int
as
begin
	delete from Address where ID=@id
end
--Authory

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteAuthory]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeleteAuthory]
@Id int
as
begin
delete from Authory where Authory.ID = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteBranchEmployeeById]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DeleteBranchEmployeeById]
@officeID int
as
begin
	delete from BranchEmployee where OfficeID=@officeID 
end
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 
		 

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteBus]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeleteBus]
@Id int
as
begin
 delete from Bus where Bus.ID = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteBusEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeleteBusEmployee]
@Id int
as
begin
delete from BusEmployee where BusEmployee.ID = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteBusProperty]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeleteBusProperty]
@Id int
as
begin
delete from BusProperty where BusProperty.ID = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteBusProperyBusTypeById]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DeleteBusProperyBusTypeById]
@busPropertyID int,
@busTypeID int
as
begin 
	insert into BusPropertyBusType(BusTypeID,BusPropertyID) values(@busTypeID,@busPropertyID)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteBusSeat]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sp_DeleteBusSeat]
@Id int
as
begin
delete from BusSeat where BusSeat.ID = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteBusType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeleteBusType]
 @Id int
 as
 begin
 delete from BusType where BusType.ID = @Id
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteCity]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DeleteCity]
@id int
as
begin
	delete from City where ID=@id
end
---- District------------


GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteDistrict]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DeleteDistrict]
@id int
as
begin
 delete from District where ID=@id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[sp_DeleteEmployee]
               @id int
               as
               begin
                  delete from Employee where ID=@id
               end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteLogin]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DeleteLogin]
              @id int
              as
              begin
               delete from Login where ID=@id
              end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteOffice]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[sp_DeleteOffice]
  @id int
  as
  begin 
    delete from Office where ID=@id
  end
------------- 

GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePassenger]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_DeletePassenger]
  @id int
  as
  begin
  Delete from Passenger where ID=@id
  end
-------------  




 
-------------------------################     Office işlemleri

-------Office Get

GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePayment]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeletePayment]
   @id int
   as
   begin
   Delete from Payment where ID=@id
   end
-------------   


 
-------------------------################     Passenger işlemleri

-------Passenger Get

GO
/****** Object:  StoredProcedure [dbo].[sp_DeletePaymentType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeletePaymentType]
  @id int
  as
  begin
  Delete from PaymentType where ID=@id
  end
-------------  


-------------------------################     Payment işlemleri

-------Payment Get

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteRoadExpense]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_DeleteRoadExpense]
  @id int
  as
  begin
  Delete from RoadExpense where ID=@id
  end
------------- 
	
	
-------------------------################     PaymentType işlemleri

-------PaymentType Get

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteRole]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_DeleteRole]
   @Id int
   as
   begin
   delete from Role where Role.ID = @Id
   end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteRoleAuthoryById]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_DeleteRoleAuthoryById]
 @roleID int
 as
 begin
 	delete from RoleAuthory where RoleId=@roleID 
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteRouteMap]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_DeleteRouteMap]
 @id int
 as
 begin
 Delete from RouteMap where ID=@id
 end  
-------------

-------------------------################     RoleData işlemleri

-------RoleData Get

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTicket]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_DeleteTicket]
 @id int
 as
 begin
 Delete from Ticket where ID=@id
 end
------------


-------------------------################     RouteMap işlemleri

-------RouteMap Get

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteTravel]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_DeleteTravel]
 @id int
 as
 begin
 Delete from Travel where ID=@id
 end

---



----------------#############  TicketDAL İşlemleri

------TicketDAL  Get

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteWorkHour]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_DeleteWorkHour]
 @id int
 as
 begin
 Delete from WorkHour where ID=@id
 end

---

---################ TravelDAl İşlemleri

----TravelDAl Get

GO
/****** Object:  StoredProcedure [dbo].[sp_EmployeeLogin]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_EmployeeLogin]
@name nvarchar(50),
@password nvarchar(50)
as
select
ID
from
Login where Name='@name' and Password='@password'

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAddressByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetAddressByID]
  @id int
  as
  select ID,Name,City,District,EmployeeID from Address where ID=@id
  

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAdress]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetAllAdress]
  as
  select ID,Name,City,District,EmployeeID from Address

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllAuthory]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetAllAuthory]
 as
 begin
 select Authory.ID,AuthoryName  from Authory
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllBus]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sp_GetAllBus]
as
begin
select bus.ID,Bus.Brand,Bus.BusTypeID,Bus.Model, Bus.Plate, Bus.Year from Bus
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllBusEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetAllBusEmployee]
 as
 begin
 select *from BusEmployee
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllBusProperty]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetAllBusProperty]
as
 begin
 select *from BusProperty
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllBusSeat]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create proc [dbo].[sp_GetAllBusSeat]
 as
 begin
 select * from BusSeat
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllBusType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetAllBusType]
 as
begin
select * from BusType
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCity]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetAllCity]
 as
 select ID,Name from City

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllDistrict]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetAllDistrict]
as
select ID,Name,CityID from District

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetAllEmployee]
               as
               select ID,SocialNumber,FirstName,LastName,Gender,DateOfBirth,StartWorkDate,FinishWorkDate,CreatedEmployeeID,RoleID,Telephone,Email
                from Employee

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllLogin]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetAllLogin]
                as
                select ID,Name,Password from Login

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllOffice]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[sp_GetAllOffice]
  as
  select ID,OfficeName,DistinctID,IsCenterOffice from Office
-------------

-------Office Insert 

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPassenger]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetAllPassenger]
 as
 select ID,SocialNumber,FirstName,LastName,Gender,Telephone,Email from Passenger                      
  
-------------

-------Passenger Insert 

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPayment]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetAllPayment]
 as
 select ID,TotalPrice,PaymentTypeID,CreatePaymentDate from Payment  
-------------

-------Payment Insert 

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPaymentType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetAllPaymentType]
   as
   select ID,PaymentyTypeName from PaymentType 
-------------

-------PaymentType Update


GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllRoadExpense]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetAllRoadExpense]
  as
  select ID,ExpenseName,BusID,TotalPrice from RoadExpense  
-------------

-------PaymentType Insert 

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllRouteMap]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetAllRouteMap]
 as
 select ID,TravelID,Departure,Arrival,StartDate,EndDate,Price,BeforeRouteID from RouteMap                       
-------------

-------RouteMap Insert 

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllTicket]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetAllTicket]
   as
   select ID,PassengerID,RouteMapID,TravelID,EmployeeID,BusSeatID,CreateTicketDate,PaymentID from Ticket                        
------------

------TicketDAL Insert

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllTravel]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetAllTravel]
    as
    select * from Travel  

------


-----TraveDAL Insert

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllWorkHour]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 create proc [dbo].[sp_GetAllWorkHour]
         as
         select ID,Name,StartHour,EndHour,EmployeeID from WorkHour  
------------------

-----WorkHourDal Insert

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAuthoryById]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetAuthoryById]
  @Id int
  as
  begin
  select Authory.ID, Authory.AuthoryName from Authory where ID = @Id
  end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetBusById]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetBusById]
 as
 begin
 select bus.ID,Bus.Brand,Bus.BusTypeID,Bus.Model, Bus.Plate, Bus.Year from Bus
 end


GO
/****** Object:  StoredProcedure [dbo].[sp_GetBusEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetBusEmployee]
@Id int
as
begin
select BusEmployee.ID, BusEmployee.CreateDate,BusEmployee.BusID,BusEmployee.EmployeeID,BusEmployee.RouteMapID from BusEmployee where ID = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetBusPropertyById]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetBusPropertyById]
@Id int
as
begin
select BusProperty.ID,BusProperty.Name from BusProperty where ID = @Id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetBusProperyBusTypeByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetBusProperyBusTypeByID]
 @busTypeID int
 as
 begin 
 	select BusTypeID,BusPropertyID from  BusPropertyBusType  where BusTypeID=@busTypeID
 end
 


GO
/****** Object:  StoredProcedure [dbo].[sp_GetBusSeat]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetBusSeat]
 @Id int
 as
 begin
 select * from BusSeat where ID = @Id
 end


GO
/****** Object:  StoredProcedure [dbo].[sp_GetBusTypeById]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetBusTypeById]
 @Id int
 as
 begin
 select * from BusType where ID = @Id
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetCityByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetCityByID]
@id int
as
select ID,Name from City where ID=@id

GO
/****** Object:  StoredProcedure [dbo].[sp_GetDistrictByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetDistrictByID]
@id int
as
select ID,Name,CityID from District where ID=@id

GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetEmployeeByID]
         @id int
         as
         select ID,SocialNumber,FirstName,LastName,Gender,DateOfBirth,StartWorkDate,FinishWorkDate,CreatedEmployeeID,RoleID,Telephone,Email
          from Employee where ID=@id

GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmployeeInOfficeByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[sp_GetEmployeeInOfficeByID]
  @officeID int
  as
  begin 
      select OfficeID,EmployeeID from  BranchEmployee  where OfficeID=@officeID
  end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetLoginByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetLoginByID]
                @id int
                as
                select ID,Name,Password from Login where ID=@id

GO
/****** Object:  StoredProcedure [dbo].[sp_GetOfficeByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[sp_GetOfficeByID]
  @id int
  as
  select ID,OfficeName,DistinctID,IsCenterOffice from Office where ID=@id

-------------

-------Office List

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPassengerByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetPassengerByID]
 @id int
 as
 select ID,SocialNumber,FirstName,LastName,Gender,Telephone,Email from Passenger where ID=@id                      
-------------

-------Passenger List

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPaymentByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetPaymentByID]
 @id int
 as
 select ID,TotalPrice,PaymentTypeID,CreatePaymentDate from Payment where ID=@id
-------------

-------Payment List

GO
/****** Object:  StoredProcedure [dbo].[sp_GetPaymentTypeByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetPaymentTypeByID]
 @id int
 as
 select ID,PaymentyTypeName from PaymentType where ID=@id 
-------------

-------PaymentType List

GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoadExpenseByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetRoadExpenseByID]
 @id int
 as
 select ID,ExpenseName,BusID,TotalPrice from RoadExpense where ID=@id                        
-------------

-------RoadExpense List

GO
/****** Object:  StoredProcedure [dbo].[sp_GetRole]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetRole]
 @Id int
 as
 begin
 select ID, RoleName from Role where ID = @Id
 end  
-------------

-------RoleData List

GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoleAuthoryByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create procedure [dbo].[sp_GetRoleAuthoryByID]
  @roleID int
  as
  begin 
      select RoleID,AuthorID from  RoleAuthory  where RoleID=@roleID
  end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetRoleList]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_GetRoleList]

  as
  begin
  select ID, RoleName from Role 
  end   
-------------

-------RoleData Insert 

GO
/****** Object:  StoredProcedure [dbo].[sp_GetRouteMapByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetRouteMapByID]
 @id int
 as
 select ID,TravelID,Departure,Arrival,StartDate,EndDate,Price,BeforeRouteID from RouteMap where ID=@id                       
-------------

-------RouteMap List

GO
/****** Object:  StoredProcedure [dbo].[sp_GetTicketByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetTicketByID]
  @id int
  as
  select ID,PassengerID,RouteMapID,TravelID,EmployeeID,BusSeatID,CreateTicketDate,PaymentID from Ticket where ID=@id                       
------------ 

------TicketDAL List

GO
/****** Object:  StoredProcedure [dbo].[sp_GetTravelByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

 create proc [dbo].[sp_GetTravelByID]
 @id int
 as
 select TravelNumberName from Travel where ID=@id 


------

-----TravelDAL  List

GO
/****** Object:  StoredProcedure [dbo].[sp_GetWorkHourByID]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_GetWorkHourByID]
     @id int
     as
     select ID,Name,StartHour,EndHour,EmployeeID from WorkHour where ID=@id   

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAddress]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertAddress]
  @name nvarchar(50),
  @city int ,
  @district int,
  @employeeId int
  as
  begin
      insert into Address(Name,City,District,EmployeeID)values(@name,@city,@district,@employeeId)
  end

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertCity]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertCity]
@name nvarchar(50)
as
begin
    insert into City(Name)values(@name)
end

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertDistrict]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertDistrict]
 @name nvarchar(50),
 @cityId int 
 as
 begin
     insert into District(Name,CityID)values(@name,@cityId)
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertEmployee]
            @socialNumber nchar(11),
            @firstName nvarchar(50),
            @lastName nvarchar(50),
            @gender bit,
            @dateofbirth date,
            @startWorkDate datetime ,
            @finishWorkDate datetime,
            @createdEmployeeID int,
            @roleID int,
            @telephone nvarchar(20),
            @email nvarchar(50)
            as
            begin
                insert into Employee
              (SocialNumber,FirstName,LastName,Gender,DateOfBirth,StartWorkDate,FinishWorkDate,CreatedEmployeeID,RoleID,Telephone,Email)
              values
              (@socialNumber,@firstName,@lastName,@gender,@dateofbirth,@startWorkDate,@finishWorkDate,@createdEmployeeID,@roleID,@telephone,@email)
             SELECT SCOPE_IDENTITY()
             end

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertLogin]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertLogin]
@ID int,
 @name nvarchar(50),
 @password nvarchar(50)
 as
 begin
     insert into Login(ID,Name,Password)values(@ID,@name,@password)
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertLoginPassenger]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InsertLoginPassenger]
   @ID int,
   @name nvarchar(50),
   @password nvarchar(50)
   as
   begin
       insert into LoginPassenger(ID,Name,Password)values(@ID,@name,@password)
   end




GO
/****** Object:  StoredProcedure [dbo].[sp_InsertOffice]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_InsertOffice]
   @officeName nvarchar(50),
   @districtId int,
   @isCenterOffice bit
   as
   begin
       insert into Office(OfficeName,DistinctID,IsCenterOffice) values(@officeName,@districtId,@isCenterOffice)
	   SELECT SCOPE_IDENTITY()
   end
-------------

-------Office Update

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPassenger]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InsertPassenger]
  @socialNumber nvarchar(50),
  @firstName nvarchar(50),
  @lastName nvarchar(50),
  @gender bit,
  @telephone nvarchar(50),
  @email nvarchar(50)
  as
  begin
  Insert into Passenger(SocialNumber,FirstName,LastName,Gender,Telephone,Email) values(@socialNumber,@firstName,@lastName,@gender,@telephone,@email)
  SELECT SCOPE_IDENTITY()
  end   
-------------

-------Passenger Update

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPayment]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_InsertPayment]
 @totalPrice decimal,
 @paymentTypeID int,
 @createPaymentDate datetime
 as
 begin
 Insert into Payment(TotalPrice,PaymentTypeID,CreatePaymentDate) values(@totalPrice,@paymentTypeID,@createPaymentDate)
 end  
                    
-------------

-------Payment Update

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertPaymentType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_InsertPaymentType]
 @paymentTypeName nvarchar(50)
 as
 begin
 Insert into PaymentType(PaymentyTypeName) values(@paymentTypeName)
 end  
-------------

-------PaymentType Update

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertRoadExpense]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InsertRoadExpense]
 @expenseName nvarchar(50),
 @busId int,
 @totalPrice decimal
 as
 begin
 Insert into RoadExpense(ExpenseName,BusID,TotalPrice) values(@expenseName,@busId,@totalPrice)
 end   
-------------

-------RoadExpense Update

GO
/****** Object:  StoredProcedure [dbo].[sp_PassangerLogin]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_PassangerLogin]
@name nvarchar(50),
@password nvarchar(50)
as
select
ID
from
LoginPassenger where Name='@name' and Password='@password'

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAddress]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_UpdateAddress]
@name nvarchar(50),
@city int ,
@district int,
@employeeId int,
@id int
as
begin
   update Address set Name=@name,City=@city,District=@district,EmployeeID=@employeeId where ID=@id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAuthory]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateAuthory]
 @authoryName nvarchar(50),
 @id int
 as 
 begin
 update Authory set AuthoryName = @authoryName where ID=@id;
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateBus]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_UpdateBus]
 @brand nvarchar(50),
 @model nvarchar(50),
 @year datetime,
 @busType int,
 @plate nchar(10),
 @id int
 as
 begin
 update Bus set Brand = @brand, Model=@model,Year = @year, BusTypeID = @busType, Plate = @plate where ID=@id
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateBusEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateBusEmployee]
@busId int,
@employeeId int,
@createDate datetime,
@routeMapID int,
@Id int
as 
begin
update BusEmployee set BusID=@busId,EmployeeID=@employeeId,CreateDate = @createDate,RouteMapID=@routeMapID where BusEmployee.ID = @Id 
end


GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateBusProperty]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   create proc [dbo].[sp_UpdateBusProperty] 
@name nvarchar(50),
@Id int
 as 
 begin
 update BusProperty  set BusProperty.Name = @name where BusProperty .ID = @Id 
 end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateBusSeat]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_UpdateBusSeat]
 @busId int,
 @busTypeId int,
 @seatNumber int,
 @isWidow bit,
 @Id int
     as 
     begin
     update BusSeat set BusID=@busId,BusTypeID=@busTypeId,IsWindow = @isWidow, SeatNumber=@seatNumber where BusSeat.ID = @Id 
     end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateBusType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_UpdateBusType]
 @name nvarchar(50) ,
 @Id int,
 @seatCount int,
 @backDoorIndex int
     as 
     begin
     update BusType set BackDoorIndex = @backDoorIndex, Name=@name, SeatCount = @seatCount where BusType.ID = @Id 
     end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateCity]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_UpdateCity]
@name nvarchar(50),
@id int
as
begin
   update City set Name=@name where ID=@id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDistrict]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_UpdateDistrict]
@name nvarchar(50),
@cityID int ,
@id int
as
begin
   update District set Name=@name,CityID=@cityID where ID=@id
end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_UpdateEmployee]
              @socialNumber nchar(11),
              @firstName nvarchar(50),
              @lastName nvarchar(50),
              @gender bit,
              @dateofbirth date,
              @startWorkDate datetime ,
              @finishWorkDate datetime,
              @createdEmployeeID int,
              @roleID int,
              @telephone nvarchar(20),
              @email nvarchar(50),
              @id int
              as
              begin
                  Update Employee
                 set SocialNumber=@socialNumber,FirstName=@firstName,LastName=@lastName,Gender=@gender,
                 DateOfBirth=@dateofbirth,StartWorkDate=@startWorkDate,FinishWorkDate=@finishWorkDate,
                 CreatedEmployeeID=@createdEmployeeID,RoleID=@roleID,Telephone=@telephone,Email=@email
                 where ID=@id
              end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateLogin]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_UpdateLogin]
               @name nvarchar(50),
               @password nvarchar(50),
               @id int
               as
               begin
                  update Login set Name=@name,Password=@password where ID=@id
               end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateOffice]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_UpdateOffice]
 @officeName nvarchar(50),
 @districtId int,
 @isCenterOffice bit,
 @id int
  as
  begin
     update Office set OfficeName=@officeName,DistinctID=@districtId,IsCenterOffice=@isCenterOffice where ID=@id
  end
-------------

-------Office Delete

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePassenger]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdatePassenger]
  @id int,
  @socialNumber nvarchar(50),
  @firstName nvarchar(50),
  @lastName nvarchar(50),
  @gender bit,
  @telephone nvarchar(50),
  @email nvarchar(50)
  as
  begin
  Update Passenger set SocialNumber=@socialNumber,FirstName=@firstName,LastName=@lastName,Gender=@gender,Telephone=@telephone,Email=@email where ID=@id
  end
-------------

-------Passenger Delete

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePayment]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_UpdatePayment]
 @id int,
 @totalPrice decimal,
 @paymentTypeID int,
 @createPaymentDate datetime
 as
 begin
 Update Payment set TotalPrice=@totalPrice,PaymentTypeID=@paymentTypeID,CreatePaymentDate=@createPaymentDate where ID=@id
 end
-------------

-------Payment Delete

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdatePaymentType]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdatePaymentType]
  @id int,
  @paymentTypeName nvarchar(50)
  as
  begin
  Update PaymentType set PaymentyTypeName=@paymentTypeName where ID=@id
  end     
-------------

-------PaymentType Delete

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateRoadExpense]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateRoadExpense]
 @id int,
 @expenseName nvarchar(50),
 @busId int,
 @totalPrice decimal
 as
 begin
 Update RoadExpense set ExpenseName=@expenseName,BusID=@busId,TotalPrice=@totalPrice where ID=@id
 end
-------------

-------RoadExpense Delete

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateRole]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateRole]
  @roleName nvarchar(50),
  @Id int
as 
begin
update Role set RoleName = @roleName where Role.ID = @Id 
end

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateRouteMap]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateRouteMap]
 @id int,
 @travelId int,
 @departure int,
 @arrival int,
 @startDate datetime,
 @endDate datetime,
 @price decimal,
 @beforeRouteId int
 as
 begin
 Update RouteMap set TravelID=@travelId,Departure=@departure,Arrival=@arrival,StartDate=@startDate,EndDate=@endDate,Price=@price,BeforeRouteID=@beforeRouteId where ID=@id
 end

-------------

-------RouteMap Delete

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTicket]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_UpdateTicket]
  @id int,
  @passengerId int,
  @routeMapId int,
  @travelId int,
  @employeeId int,
  @busSeatId int,
  @createTicketDate datetime,
  @paymentId int
  as
  begin
  Update Ticket set  PassengerID=@passengerId,RouteMapID=@routeMapId,TravelID=@travelId,EmployeeID=@employeeId,BusSeatID=@busSeatId,CreateTicketDate=@createTicketDate,PaymentID=@paymentId where ID=@id
  end

------------

------TicketDAL  Delete

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateTravel]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[sp_UpdateTravel]
 @travelNumberName nchar(8),
 @id int
 as
 begin
 Update Travel set  TravelNumberName=@travelNumberName where ID=@id
 end

---------

----TravelDAL Delete

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateWorkHour]    Script Date: 22.05.2017 04:56:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  create proc [dbo].[sp_UpdateWorkHour]
  @id int,
 @name nvarchar(50),
 @startHour nchar(5),
 @endHour nchar(5),
 @employeeID int
 as
 begin
 Update WorkHour set Name=@name,StartHour= @startHour,EndHour=@endHour,EmployeeID=@employeeID where ID=@id
 end

-------------

------WorkHourDAl Delete

GO
USE [master]
GO
ALTER DATABASE [BusManagementDb] SET  READ_WRITE 
GO
