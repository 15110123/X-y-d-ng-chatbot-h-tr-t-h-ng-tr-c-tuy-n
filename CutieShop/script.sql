USE [master]
GO
/****** Object:  Database [CutieShop]    Script Date: 16/2/2018 4:09:09 PM ******/
CREATE DATABASE [CutieShop]
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CutieShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CutieShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CutieShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CutieShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CutieShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CutieShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [CutieShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CutieShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CutieShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CutieShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CutieShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CutieShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CutieShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CutieShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CutieShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CutieShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CutieShop] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [CutieShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CutieShop] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [CutieShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CutieShop] SET  MULTI_USER 
GO
ALTER DATABASE [CutieShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CutieShop] SET ENCRYPTION ON
GO
ALTER DATABASE [CutieShop] SET QUERY_STORE = ON
GO
ALTER DATABASE [CutieShop] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 100, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO)
GO
USE [CutieShop]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET OPTIMIZE_FOR_AD_HOC_WORKLOADS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET XTP_PROCEDURE_EXECUTION_STATISTICS = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET XTP_QUERY_EXECUTION_STATISTICS = OFF;
GO
USE [CutieShop]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_diagramobjects]    Script Date: 16/2/2018 4:09:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE FUNCTION [dbo].[fn_diagramobjects]() 
	RETURNS int
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		declare @id_upgraddiagrams		int
		declare @id_sysdiagrams			int
		declare @id_helpdiagrams		int
		declare @id_helpdiagramdefinition	int
		declare @id_creatediagram	int
		declare @id_renamediagram	int
		declare @id_alterdiagram 	int 
		declare @id_dropdiagram		int
		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),
			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),
			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),
			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),
			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),
			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),
			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 
			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null
			select @InstalledObjects = @InstalledObjects + 1
		if @id_sysdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 2
		if @id_helpdiagrams is not null
			select @InstalledObjects = @InstalledObjects + 4
		if @id_helpdiagramdefinition is not null
			select @InstalledObjects = @InstalledObjects + 8
		if @id_creatediagram is not null
			select @InstalledObjects = @InstalledObjects + 16
		if @id_renamediagram is not null
			select @InstalledObjects = @InstalledObjects + 32
		if @id_alterdiagram  is not null
			select @InstalledObjects = @InstalledObjects + 64
		if @id_dropdiagram is not null
			select @InstalledObjects = @InstalledObjects + 128
		
		return @InstalledObjects 
	END
	
GO
/****** Object:  Table [dbo].[Accessory]    Script Date: 16/2/2018 4:09:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accessory](
	[Id] [varchar](36) NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[Smell] [nvarchar](100) NOT NULL,
	[Region] [varchar](36) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Advertisement]    Script Date: 16/2/2018 4:09:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advertisement](
	[Id] [varchar](36) NOT NULL,
	[ImgUrl] [varchar](2083) NOT NULL,
	[Owner] [varchar](36) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Auth]    Script Date: 16/2/2018 4:09:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auth](
	[Id] [varchar](36) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cage]    Script Date: 16/2/2018 4:09:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cage](
	[Id] [varchar](36) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Material] [varchar](36) NOT NULL,
	[SizeX] [int] NOT NULL,
	[SizeY] [int] NOT NULL,
	[Region] [varchar](36) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Conversation]    Script Date: 16/2/2018 4:09:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Conversation](
	[MessageSession] [varchar](36) NOT NULL,
	[IsEmployee] [bit] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[ImgUrl] [varchar](2083) NULL,
	[SentDate] [datetime2](7) NOT NULL,
	[Id] [varchar](36) NOT NULL,
 CONSTRAINT [Conversation_Id_pk] PRIMARY KEY CLUSTERED 
(
	[MessageSession] ASC,
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 16/2/2018 4:09:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [varchar](36) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[Email] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocType]    Script Date: 16/2/2018 4:09:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocType](
	[Id] [varchar](36) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documentation]    Script Date: 16/2/2018 4:09:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documentation](
	[Id] [varchar](36) NOT NULL,
	[Type] [varchar](36) NOT NULL,
	[Owner] [varchar](36) NOT NULL,
	[HTMLContent] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 16/2/2018 4:09:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [varchar](36) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[HomeTown] [nvarchar](200) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[Type] [varchar](36) NOT NULL,
	[Store] [varchar](36) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmpType]    Script Date: 16/2/2018 4:09:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmpType](
	[Id] [varchar](36) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedingRoutine]    Script Date: 16/2/2018 4:09:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedingRoutine](
	[Id] [varchar](36) NOT NULL,
	[FrequencyPerDay] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 16/2/2018 4:09:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[Id] [varchar](36) NOT NULL,
	[Region] [varchar](36) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Good]    Script Date: 16/2/2018 4:09:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Good](
	[Id] [varchar](36) NOT NULL,
	[ImageUrl] [varchar](2083) NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [int] NULL,
	[Quantity] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Good] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GoodofOrder]    Script Date: 16/2/2018 4:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GoodofOrder](
	[Good] [varchar](36) NOT NULL,
	[Order] [varchar](36) NOT NULL,
 CONSTRAINT [PK__GoodofOr__67A3D86D36C368B9] PRIMARY KEY CLUSTERED 
(
	[Good] ASC,
	[Order] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Material]    Script Date: 16/2/2018 4:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Material](
	[Id] [varchar](36) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialofAccessory]    Script Date: 16/2/2018 4:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialofAccessory](
	[Material] [varchar](36) NOT NULL,
	[Accessory] [varchar](36) NOT NULL,
 CONSTRAINT [PK_MaterialofAccessory] PRIMARY KEY CLUSTERED 
(
	[Material] ASC,
	[Accessory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialofCage]    Script Date: 16/2/2018 4:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialofCage](
	[Material] [varchar](36) NOT NULL,
	[Cage] [varchar](36) NOT NULL,
 CONSTRAINT [PK_MaterialofCage] PRIMARY KEY CLUSTERED 
(
	[Material] ASC,
	[Cage] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialofToy]    Script Date: 16/2/2018 4:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialofToy](
	[Material] [varchar](36) NOT NULL,
	[Toy] [varchar](36) NOT NULL,
 CONSTRAINT [PK_MaterialofToy] PRIMARY KEY CLUSTERED 
(
	[Material] ASC,
	[Toy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MessageSession]    Script Date: 16/2/2018 4:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessageSession](
	[Id] [varchar](36) NOT NULL,
	[Employee] [varchar](36) NOT NULL,
	[Customer] [varchar](36) NOT NULL,
	[DateStart] [datetime2](7) NOT NULL,
	[DateEnd] [datetime2](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nutrition]    Script Date: 16/2/2018 4:09:12 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nutrition](
	[Id] [varchar](36) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NutritionofFood]    Script Date: 16/2/2018 4:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NutritionofFood](
	[Nutrition] [varchar](36) NOT NULL,
	[Food] [varchar](36) NOT NULL,
 CONSTRAINT [PK_NutritionofFood] PRIMARY KEY CLUSTERED 
(
	[Nutrition] ASC,
	[Food] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 16/2/2018 4:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [varchar](36) NOT NULL,
	[UsedScore] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pet]    Script Date: 16/2/2018 4:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pet](
	[Id] [varchar](36) NOT NULL,
	[Size] [varchar](36) NOT NULL,
	[Longevity] [int] NOT NULL,
	[MaxBornChild] [int] NOT NULL,
	[IsFurDrop] [bit] NOT NULL,
	[FeedingRoutine] [varchar](36) NOT NULL,
	[Type] [varchar](36) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetSize]    Script Date: 16/2/2018 4:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetSize](
	[Id] [varchar](36) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PetType]    Script Date: 16/2/2018 4:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PetType](
	[Id] [varchar](36) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Post]    Script Date: 16/2/2018 4:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Post](
	[Id] [varchar](36) NOT NULL,
	[Employee] [varchar](36) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[VidUrl] [varchar](2083) NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Region]    Script Date: 16/2/2018 4:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region](
	[Id] [varchar](36) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Score]    Script Date: 16/2/2018 4:09:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Score](
	[Customer] [varchar](36) NOT NULL,
	[Value] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Customer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 16/2/2018 4:09:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[Id] [varchar](36) NOT NULL,
	[Pet] [varchar](36) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ServiceOnlineOrder]    Script Date: 16/2/2018 4:09:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ServiceOnlineOrder](
	[Id] [varchar](36) NOT NULL,
	[Service] [varchar](36) NOT NULL,
	[DateStart] [datetime2](7) NOT NULL,
	[TicketId] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShipableGood]    Script Date: 16/2/2018 4:09:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipableGood](
	[Id] [varchar](36) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShipableGoodofShipment]    Script Date: 16/2/2018 4:09:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipableGoodofShipment](
	[ShipableGood] [varchar](36) NOT NULL,
	[Shipment] [varchar](36) NOT NULL,
 CONSTRAINT [PK_ShipableGoodofShipment] PRIMARY KEY CLUSTERED 
(
	[ShipableGood] ASC,
	[Shipment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipment]    Script Date: 16/2/2018 4:09:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shipment](
	[Id] [varchar](36) NOT NULL,
	[Customer] [varchar](36) NOT NULL,
	[Shipper] [varchar](36) NULL,
	[DateReceived] [datetime2](7) NULL,
	[ShipStatus] [varchar](36) NOT NULL,
	[AltAddress] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShipStatus]    Script Date: 16/2/2018 4:09:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipStatus](
	[Id] [varchar](36) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 16/2/2018 4:09:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [varchar](36) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[IsPrimary] [bit] NOT NULL,
	[Manager] [varchar](36) NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Toy]    Script Date: 16/2/2018 4:09:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toy](
	[Id] [varchar](36) NOT NULL,
	[Color] [varchar](50) NOT NULL,
	[Region] [varchar](36) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Auth_Username_uindex]    Script Date: 16/2/2018 4:09:17 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Auth_Username_uindex] ON [dbo].[Auth]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Conversation_MessageSession_pk]    Script Date: 16/2/2018 4:09:17 PM ******/
ALTER TABLE [dbo].[Conversation] ADD  CONSTRAINT [Conversation_MessageSession_pk] UNIQUE NONCLUSTERED 
(
	[MessageSession] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [Employee_Email_uindex]    Script Date: 16/2/2018 4:09:17 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Employee_Email_uindex] ON [dbo].[Employee]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accessory]  WITH CHECK ADD  CONSTRAINT [Accessory_Region_Id_fk] FOREIGN KEY([Region])
REFERENCES [dbo].[Region] ([Id])
GO
ALTER TABLE [dbo].[Accessory] CHECK CONSTRAINT [Accessory_Region_Id_fk]
GO
ALTER TABLE [dbo].[Accessory]  WITH CHECK ADD  CONSTRAINT [Accessory_ShipableGood_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[ShipableGood] ([Id])
GO
ALTER TABLE [dbo].[Accessory] CHECK CONSTRAINT [Accessory_ShipableGood_Id_fk]
GO
ALTER TABLE [dbo].[Advertisement]  WITH CHECK ADD  CONSTRAINT [Advertisement_Employee_Id_fk] FOREIGN KEY([Owner])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Advertisement] CHECK CONSTRAINT [Advertisement_Employee_Id_fk]
GO
ALTER TABLE [dbo].[Cage]  WITH CHECK ADD  CONSTRAINT [Cage_Region_Id_fk] FOREIGN KEY([Region])
REFERENCES [dbo].[Region] ([Id])
GO
ALTER TABLE [dbo].[Cage] CHECK CONSTRAINT [Cage_Region_Id_fk]
GO
ALTER TABLE [dbo].[Cage]  WITH CHECK ADD  CONSTRAINT [Cage_ShipableGood_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[ShipableGood] ([Id])
GO
ALTER TABLE [dbo].[Cage] CHECK CONSTRAINT [Cage_ShipableGood_Id_fk]
GO
ALTER TABLE [dbo].[Conversation]  WITH CHECK ADD  CONSTRAINT [Conversation_MessageSession_Id_fk] FOREIGN KEY([MessageSession])
REFERENCES [dbo].[MessageSession] ([Id])
GO
ALTER TABLE [dbo].[Conversation] CHECK CONSTRAINT [Conversation_MessageSession_Id_fk]
GO
ALTER TABLE [dbo].[Documentation]  WITH CHECK ADD  CONSTRAINT [Documentation_DocType_Id_fk] FOREIGN KEY([Type])
REFERENCES [dbo].[DocType] ([Id])
GO
ALTER TABLE [dbo].[Documentation] CHECK CONSTRAINT [Documentation_DocType_Id_fk]
GO
ALTER TABLE [dbo].[Documentation]  WITH CHECK ADD  CONSTRAINT [Documentation_Employee_Id_fk] FOREIGN KEY([Owner])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Documentation] CHECK CONSTRAINT [Documentation_Employee_Id_fk]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [Employee_Auth_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Auth] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [Employee_Auth_Id_fk]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [Employee_EmpType_Id_fk] FOREIGN KEY([Type])
REFERENCES [dbo].[EmpType] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [Employee_EmpType_Id_fk]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [Employee_Store_Id_fk] FOREIGN KEY([Store])
REFERENCES [dbo].[Store] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [Employee_Store_Id_fk]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [Food_Region_Id_fk] FOREIGN KEY([Region])
REFERENCES [dbo].[Region] ([Id])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [Food_Region_Id_fk]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [Food_ShipableGood_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[ShipableGood] ([Id])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [Food_ShipableGood_Id_fk]
GO
ALTER TABLE [dbo].[GoodofOrder]  WITH CHECK ADD  CONSTRAINT [GoodofOrder_Good_Id_fk] FOREIGN KEY([Good])
REFERENCES [dbo].[Good] ([Id])
GO
ALTER TABLE [dbo].[GoodofOrder] CHECK CONSTRAINT [GoodofOrder_Good_Id_fk]
GO
ALTER TABLE [dbo].[GoodofOrder]  WITH CHECK ADD  CONSTRAINT [GoodofOrder_Order_Id_fk] FOREIGN KEY([Order])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[GoodofOrder] CHECK CONSTRAINT [GoodofOrder_Order_Id_fk]
GO
ALTER TABLE [dbo].[MaterialofAccessory]  WITH CHECK ADD  CONSTRAINT [MaterialofAccessory_Accessory_Id_fk] FOREIGN KEY([Accessory])
REFERENCES [dbo].[Accessory] ([Id])
GO
ALTER TABLE [dbo].[MaterialofAccessory] CHECK CONSTRAINT [MaterialofAccessory_Accessory_Id_fk]
GO
ALTER TABLE [dbo].[MaterialofAccessory]  WITH CHECK ADD  CONSTRAINT [MaterialofAccessory_Material_Id_fk] FOREIGN KEY([Material])
REFERENCES [dbo].[Material] ([Id])
GO
ALTER TABLE [dbo].[MaterialofAccessory] CHECK CONSTRAINT [MaterialofAccessory_Material_Id_fk]
GO
ALTER TABLE [dbo].[MaterialofCage]  WITH CHECK ADD  CONSTRAINT [MaterialofCage_Cage_Id_fk] FOREIGN KEY([Cage])
REFERENCES [dbo].[Cage] ([Id])
GO
ALTER TABLE [dbo].[MaterialofCage] CHECK CONSTRAINT [MaterialofCage_Cage_Id_fk]
GO
ALTER TABLE [dbo].[MaterialofCage]  WITH CHECK ADD  CONSTRAINT [MaterialofCage_Material_Id_fk] FOREIGN KEY([Material])
REFERENCES [dbo].[Material] ([Id])
GO
ALTER TABLE [dbo].[MaterialofCage] CHECK CONSTRAINT [MaterialofCage_Material_Id_fk]
GO
ALTER TABLE [dbo].[MaterialofToy]  WITH CHECK ADD  CONSTRAINT [MaterialofToy_Material_Id_fk] FOREIGN KEY([Material])
REFERENCES [dbo].[Material] ([Id])
GO
ALTER TABLE [dbo].[MaterialofToy] CHECK CONSTRAINT [MaterialofToy_Material_Id_fk]
GO
ALTER TABLE [dbo].[MaterialofToy]  WITH CHECK ADD  CONSTRAINT [MaterialofToy_Toy_Id_fk] FOREIGN KEY([Toy])
REFERENCES [dbo].[Toy] ([Id])
GO
ALTER TABLE [dbo].[MaterialofToy] CHECK CONSTRAINT [MaterialofToy_Toy_Id_fk]
GO
ALTER TABLE [dbo].[MessageSession]  WITH CHECK ADD  CONSTRAINT [MessageSession_Customer_Id_fk] FOREIGN KEY([Customer])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[MessageSession] CHECK CONSTRAINT [MessageSession_Customer_Id_fk]
GO
ALTER TABLE [dbo].[MessageSession]  WITH CHECK ADD  CONSTRAINT [MessageSession_Employee_Id_fk] FOREIGN KEY([Employee])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[MessageSession] CHECK CONSTRAINT [MessageSession_Employee_Id_fk]
GO
ALTER TABLE [dbo].[NutritionofFood]  WITH CHECK ADD  CONSTRAINT [NutritionofFood_Food_Id_fk] FOREIGN KEY([Food])
REFERENCES [dbo].[Food] ([Id])
GO
ALTER TABLE [dbo].[NutritionofFood] CHECK CONSTRAINT [NutritionofFood_Food_Id_fk]
GO
ALTER TABLE [dbo].[NutritionofFood]  WITH CHECK ADD  CONSTRAINT [NutritionofFood_Nutrition_Id_fk] FOREIGN KEY([Nutrition])
REFERENCES [dbo].[Nutrition] ([Id])
GO
ALTER TABLE [dbo].[NutritionofFood] CHECK CONSTRAINT [NutritionofFood_Nutrition_Id_fk]
GO
ALTER TABLE [dbo].[Pet]  WITH CHECK ADD  CONSTRAINT [FK_Pet_Good] FOREIGN KEY([Id])
REFERENCES [dbo].[Good] ([Id])
GO
ALTER TABLE [dbo].[Pet] CHECK CONSTRAINT [FK_Pet_Good]
GO
ALTER TABLE [dbo].[Pet]  WITH CHECK ADD  CONSTRAINT [Pet_FeedingRoutine_Id_fk] FOREIGN KEY([FeedingRoutine])
REFERENCES [dbo].[FeedingRoutine] ([Id])
GO
ALTER TABLE [dbo].[Pet] CHECK CONSTRAINT [Pet_FeedingRoutine_Id_fk]
GO
ALTER TABLE [dbo].[Pet]  WITH CHECK ADD  CONSTRAINT [Pet_PetSize_Id_fk] FOREIGN KEY([Size])
REFERENCES [dbo].[PetSize] ([Id])
GO
ALTER TABLE [dbo].[Pet] CHECK CONSTRAINT [Pet_PetSize_Id_fk]
GO
ALTER TABLE [dbo].[Pet]  WITH CHECK ADD  CONSTRAINT [Pet_PetType_Id_fk] FOREIGN KEY([Type])
REFERENCES [dbo].[PetType] ([Id])
GO
ALTER TABLE [dbo].[Pet] CHECK CONSTRAINT [Pet_PetType_Id_fk]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [Post_Employee_Id_fk] FOREIGN KEY([Employee])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [Post_Employee_Id_fk]
GO
ALTER TABLE [dbo].[Score]  WITH CHECK ADD  CONSTRAINT [Score_Customer_Id_fk] FOREIGN KEY([Customer])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Score] CHECK CONSTRAINT [Score_Customer_Id_fk]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [Service_Good_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Good] ([Id])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [Service_Good_Id_fk]
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [Service_Pet_Id_fk] FOREIGN KEY([Pet])
REFERENCES [dbo].[Pet] ([Id])
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [Service_Pet_Id_fk]
GO
ALTER TABLE [dbo].[ServiceOnlineOrder]  WITH CHECK ADD  CONSTRAINT [ServiceOnlineOrder_Order_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[ServiceOnlineOrder] CHECK CONSTRAINT [ServiceOnlineOrder_Order_Id_fk]
GO
ALTER TABLE [dbo].[ServiceOnlineOrder]  WITH CHECK ADD  CONSTRAINT [ServiceOnlineOrder_Service_Id_fk] FOREIGN KEY([Service])
REFERENCES [dbo].[Service] ([Id])
GO
ALTER TABLE [dbo].[ServiceOnlineOrder] CHECK CONSTRAINT [ServiceOnlineOrder_Service_Id_fk]
GO
ALTER TABLE [dbo].[ShipableGoodofShipment]  WITH CHECK ADD  CONSTRAINT [ShipableGoodofShipment_ShipableGood_Id_fk] FOREIGN KEY([ShipableGood])
REFERENCES [dbo].[ShipableGood] ([Id])
GO
ALTER TABLE [dbo].[ShipableGoodofShipment] CHECK CONSTRAINT [ShipableGoodofShipment_ShipableGood_Id_fk]
GO
ALTER TABLE [dbo].[ShipableGoodofShipment]  WITH CHECK ADD  CONSTRAINT [ShipableGoodofShipment_Shipment_Id_fk] FOREIGN KEY([Shipment])
REFERENCES [dbo].[Shipment] ([Id])
GO
ALTER TABLE [dbo].[ShipableGoodofShipment] CHECK CONSTRAINT [ShipableGoodofShipment_Shipment_Id_fk]
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [Shipment_Customer_Id_fk] FOREIGN KEY([Customer])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [Shipment_Customer_Id_fk]
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [Shipment_Employee_Id_fk] FOREIGN KEY([Shipper])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [Shipment_Employee_Id_fk]
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [Shipment_Order_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [Shipment_Order_Id_fk]
GO
ALTER TABLE [dbo].[Shipment]  WITH CHECK ADD  CONSTRAINT [Shipment_ShipStatus_Id_fk] FOREIGN KEY([ShipStatus])
REFERENCES [dbo].[ShipStatus] ([Id])
GO
ALTER TABLE [dbo].[Shipment] CHECK CONSTRAINT [Shipment_ShipStatus_Id_fk]
GO
ALTER TABLE [dbo].[Store]  WITH CHECK ADD  CONSTRAINT [Store_Employee_Id_fk] FOREIGN KEY([Manager])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Store] CHECK CONSTRAINT [Store_Employee_Id_fk]
GO
ALTER TABLE [dbo].[Toy]  WITH CHECK ADD  CONSTRAINT [Toy_Region_Id_fk] FOREIGN KEY([Region])
REFERENCES [dbo].[Region] ([Id])
GO
ALTER TABLE [dbo].[Toy] CHECK CONSTRAINT [Toy_Region_Id_fk]
GO
ALTER TABLE [dbo].[Toy]  WITH CHECK ADD  CONSTRAINT [Toy_ShipableGood_Id_fk] FOREIGN KEY([Id])
REFERENCES [dbo].[ShipableGood] ([Id])
GO
ALTER TABLE [dbo].[Toy] CHECK CONSTRAINT [Toy_ShipableGood_Id_fk]
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 16/2/2018 4:09:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();	 
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		revert;
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 16/2/2018 4:09:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID(); 
		select @IsDbo = IS_MEMBER(N'db_owner');
		revert; 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 16/2/2018 4:09:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT; 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 16/2/2018 4:09:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner');
		if(@owner_id is null)
			select @owner_id = @theId;
		revert; 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 16/2/2018 4:09:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER;
			SET @user = USER_NAME();
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));
		REVERT;
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 16/2/2018 4:09:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER;
		select @theId = DATABASE_PRINCIPAL_ID();
		select @IsDbo = IS_MEMBER(N'db_owner'); 
		if(@owner_id is null)
			select @owner_id = @theId;
		REVERT;
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
	
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 16/2/2018 4:09:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
	
GO
USE [master]
GO
ALTER DATABASE [CutieShop] SET  READ_WRITE 
GO
