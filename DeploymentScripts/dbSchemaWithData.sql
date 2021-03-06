USE [master]
GO
/****** Object:  Database [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6]    Script Date: 11/6/2018 9:14:57 PM ******/
CREATE DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6', FILENAME = N'C:\Users\a.shuvaev\ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6_log', FILENAME = N'C:\Users\a.shuvaev\ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET ARITHABORT OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET  MULTI_USER 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/6/2018 9:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bids]    Script Date: 11/6/2018 9:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bids](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InvestorId] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[LoanRequestId] [int] NOT NULL,
 CONSTRAINT [PK_Bids] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoanRequests]    Script Date: 11/6/2018 9:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoanRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreditSeekerId] [int] NOT NULL,
	[InterestRate] [decimal](18, 2) NOT NULL,
	[AmountRequest] [decimal](18, 2) NOT NULL,
	[RepaymentStartDate] [datetime2](7) NOT NULL,
	[RepaymentEndDate] [datetime2](7) NOT NULL,
	[ActiveTo] [datetime2](7) NOT NULL,
	[IsWithdrawn] [bit] NOT NULL,
	[CurrencyId] [int] NOT NULL,
	[Purpose] [nvarchar](250) NULL,
 CONSTRAINT [PK_LoanRequests] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181103182721_initialVersion', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181103212957_updateBid', N'2.1.3-rtm-32065')
SET IDENTITY_INSERT [dbo].[Bids] ON 

INSERT [dbo].[Bids] ([Id], [InvestorId], [Amount], [LoanRequestId]) VALUES (1, 100, CAST(8000.00 AS Decimal(18, 2)), 2)
SET IDENTITY_INSERT [dbo].[Bids] OFF
SET IDENTITY_INSERT [dbo].[LoanRequests] ON 

INSERT [dbo].[LoanRequests] ([Id], [CreditSeekerId], [InterestRate], [AmountRequest], [RepaymentStartDate], [RepaymentEndDate], [ActiveTo], [IsWithdrawn], [CurrencyId], [Purpose]) VALUES (1, 0, CAST(0.99 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), CAST(N'2018-11-16T21:10:54.0862690' AS DateTime2), CAST(N'2027-01-23T21:10:54.0861647' AS DateTime2), CAST(N'9999-12-31T23:59:59.9999999' AS DateTime2), 0, 0, N'Lorem ipsum dolor sit amet, diam nostrud minimum sed no, omnesque interesset mei at, ut usu choro affert persecuti. Cum quem viderer at, id vel idque debet. In sea inani consetetur definiebas, esse luptatum vel ei. Nibh inermis vim ea.')
INSERT [dbo].[LoanRequests] ([Id], [CreditSeekerId], [InterestRate], [AmountRequest], [RepaymentStartDate], [RepaymentEndDate], [ActiveTo], [IsWithdrawn], [CurrencyId], [Purpose]) VALUES (2, 0, CAST(28.00 AS Decimal(18, 2)), CAST(1.99 AS Decimal(18, 2)), CAST(N'2018-11-08T21:10:54.0864249' AS DateTime2), CAST(N'2018-11-26T21:10:54.0864246' AS DateTime2), CAST(N'2018-11-06T21:10:54.0864240' AS DateTime2), 0, 0, N'Lorem ipsum dolor sit amet, diam nostrud minimum sed no, omnesque interesset mei at, ut usu choro affert persecuti. Cum quem viderer at, id vel idque debet. In sea inani consetetur definiebas, esse luptatum vel ei. Nibh inermis vim ea.')
INSERT [dbo].[LoanRequests] ([Id], [CreditSeekerId], [InterestRate], [AmountRequest], [RepaymentStartDate], [RepaymentEndDate], [ActiveTo], [IsWithdrawn], [CurrencyId], [Purpose]) VALUES (3, 0, CAST(0.01 AS Decimal(18, 2)), CAST(1000000.99 AS Decimal(18, 2)), CAST(N'2018-11-08T21:10:54.0864255' AS DateTime2), CAST(N'2018-11-26T21:10:54.0864255' AS DateTime2), CAST(N'2018-11-08T21:10:54.0864252' AS DateTime2), 0, 0, N'Lorem ipsum dolor sit amet, diam nostrud minimum sed no, omnesque interesset mei at, ut usu choro affert persecuti. Cum quem viderer at, id vel idque debet. In sea inani consetetur definiebas, esse luptatum vel ei. Nibh inermis vim ea.')
INSERT [dbo].[LoanRequests] ([Id], [CreditSeekerId], [InterestRate], [AmountRequest], [RepaymentStartDate], [RepaymentEndDate], [ActiveTo], [IsWithdrawn], [CurrencyId], [Purpose]) VALUES (4, 0, CAST(30.00 AS Decimal(18, 2)), CAST(1.99 AS Decimal(18, 2)), CAST(N'2018-11-08T21:10:54.0864264' AS DateTime2), CAST(N'2018-11-26T21:10:54.0864261' AS DateTime2), CAST(N'2018-11-05T21:10:54.0864258' AS DateTime2), 0, 0, N'Lorem ipsum dolor sit amet, diam nostrud minimum sed no, omnesque interesset mei at, ut usu choro affert persecuti. Cum quem viderer at, id vel idque debet. In sea inani consetetur definiebas, esse luptatum vel ei. Nibh inermis vim ea.')
INSERT [dbo].[LoanRequests] ([Id], [CreditSeekerId], [InterestRate], [AmountRequest], [RepaymentStartDate], [RepaymentEndDate], [ActiveTo], [IsWithdrawn], [CurrencyId], [Purpose]) VALUES (5, 0, CAST(12.50 AS Decimal(18, 2)), CAST(1.99 AS Decimal(18, 2)), CAST(N'2018-11-08T21:10:54.0864273' AS DateTime2), CAST(N'2018-11-26T21:10:54.0864270' AS DateTime2), CAST(N'2018-11-05T21:10:54.0864267' AS DateTime2), 0, 0, N'Lorem ipsum dolor sit amet, diam nostrud minimum sed no, omnesque interesset mei at, ut usu choro affert persecuti. Cum quem viderer at, id vel idque debet. In sea inani consetetur definiebas, esse luptatum vel ei. Nibh inermis vim ea.')
SET IDENTITY_INSERT [dbo].[LoanRequests] OFF
/****** Object:  Index [IX_Bids_LoanRequestId]    Script Date: 11/6/2018 9:14:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Bids_LoanRequestId] ON [dbo].[Bids]
(
	[LoanRequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bids] ADD  DEFAULT ((0)) FOR [LoanRequestId]
GO
ALTER TABLE [dbo].[Bids]  WITH CHECK ADD  CONSTRAINT [FK_Bids_LoanRequests_LoanRequestId] FOREIGN KEY([LoanRequestId])
REFERENCES [dbo].[LoanRequests] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Bids] CHECK CONSTRAINT [FK_Bids_LoanRequests_LoanRequestId]
GO
USE [master]
GO
ALTER DATABASE [ApplicationDbContext-2252a3a7-ab5e-4361-a9e1-2d31ef7566f6] SET  READ_WRITE 
GO
