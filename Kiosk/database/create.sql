USE [master]
GO
/****** Object:  Database [Kiosk]    Script Date: 11/26/2019 12:19:07 ******/
CREATE DATABASE [Kiosk] ON  PRIMARY 
( NAME = N'Kiosk', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Kiosk.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Kiosk_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Kiosk_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Kiosk] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kiosk].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Kiosk] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Kiosk] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Kiosk] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Kiosk] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Kiosk] SET ARITHABORT OFF
GO
ALTER DATABASE [Kiosk] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Kiosk] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Kiosk] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Kiosk] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Kiosk] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Kiosk] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Kiosk] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Kiosk] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Kiosk] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Kiosk] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Kiosk] SET  DISABLE_BROKER
GO
ALTER DATABASE [Kiosk] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Kiosk] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Kiosk] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Kiosk] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Kiosk] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Kiosk] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Kiosk] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Kiosk] SET  READ_WRITE
GO
ALTER DATABASE [Kiosk] SET RECOVERY FULL
GO
ALTER DATABASE [Kiosk] SET  MULTI_USER
GO
ALTER DATABASE [Kiosk] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Kiosk] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'Kiosk', N'ON'
GO
USE [Kiosk]
GO
/****** Object:  Table [dbo].[restaurants]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[restaurants](
	[id] [int] NULL,
	[user_name] [text] NULL,
	[name] [text] NULL,
	[image] [text] NULL,
	[token] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[receipt]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[receipt](
	[num] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[price] [nvarchar](50) NULL,
	[count] [nvarchar](50) NULL,
	[cost] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[products]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[products](
	[id] [int] NULL,
	[restaurant_id] [int] NULL,
	[category_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[price] [int] NULL,
	[discount_percent] [int] NULL,
	[d_price] [int] NULL,
	[description] [text] NULL,
	[image] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[printers]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[printers](
	[restaurant_id] [int] NULL,
	[name] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders_content]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders_content](
	[id] [int] NULL,
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[cost] [int] NOT NULL,
	[count] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[orders]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orders](
	[id] [int] NOT NULL,
	[restaurant_id] [int] NULL,
	[discount_id] [int] NULL,
	[order_number] [nvarchar](50) NULL,
	[is_out] [int] NULL,
	[cost] [int] NULL,
	[d_cost] [int] NULL,
	[time] [nvarchar](50) NULL,
	[pan] [nvarchar](50) NULL,
	[req_id] [nvarchar](50) NULL,
	[serial_transaction] [nvarchar](50) NULL,
	[terminal_no] [nvarchar](50) NULL,
	[trace_number] [nvarchar](50) NULL,
	[transaction_date] [nvarchar](50) NULL,
	[transaction_time] [nvarchar](50) NULL,
 CONSTRAINT [PK_orders] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_content_desserts]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_content_desserts](
	[order_content_id] [int] NULL,
	[dessert_id] [int] NULL,
	[price] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[device]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[device](
	[id] [int] NULL,
	[user_name] [text] NULL,
	[name] [text] NULL,
	[token] [text] NULL,
	[client_key] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[desserts]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[desserts](
	[id] [int] NULL,
	[product_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[price] [int] NULL,
	[image] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] NULL,
	[restaurant_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[image] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
