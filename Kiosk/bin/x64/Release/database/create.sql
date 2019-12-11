USE [master]

/****** Object:  Database [Kiosk]    Script Date: 11/26/2019 12:19:07 ******/
CREATE DATABASE [Kiosk] ON  PRIMARY 
( NAME = N'Kiosk', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Kiosk.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Kiosk_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Kiosk_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)

ALTER DATABASE [Kiosk] SET COMPATIBILITY_LEVEL = 100

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Kiosk].[dbo].[sp_fulltext_database] @action = 'enable'
end

ALTER DATABASE [Kiosk] SET ANSI_NULL_DEFAULT OFF

ALTER DATABASE [Kiosk] SET ANSI_NULLS OFF

ALTER DATABASE [Kiosk] SET ANSI_PADDING OFF

ALTER DATABASE [Kiosk] SET ANSI_WARNINGS OFF

ALTER DATABASE [Kiosk] SET ARITHABORT OFF

ALTER DATABASE [Kiosk] SET AUTO_CLOSE OFF

ALTER DATABASE [Kiosk] SET AUTO_CREATE_STATISTICS ON

ALTER DATABASE [Kiosk] SET AUTO_SHRINK OFF

ALTER DATABASE [Kiosk] SET AUTO_UPDATE_STATISTICS ON

ALTER DATABASE [Kiosk] SET CURSOR_CLOSE_ON_COMMIT OFF

ALTER DATABASE [Kiosk] SET CURSOR_DEFAULT  GLOBAL

ALTER DATABASE [Kiosk] SET CONCAT_NULL_YIELDS_NULL OFF

ALTER DATABASE [Kiosk] SET NUMERIC_ROUNDABORT OFF

ALTER DATABASE [Kiosk] SET QUOTED_IDENTIFIER OFF

ALTER DATABASE [Kiosk] SET RECURSIVE_TRIGGERS OFF

ALTER DATABASE [Kiosk] SET  DISABLE_BROKER

ALTER DATABASE [Kiosk] SET AUTO_UPDATE_STATISTICS_ASYNC OFF

ALTER DATABASE [Kiosk] SET DATE_CORRELATION_OPTIMIZATION OFF

ALTER DATABASE [Kiosk] SET TRUSTWORTHY OFF

ALTER DATABASE [Kiosk] SET ALLOW_SNAPSHOT_ISOLATION OFF

ALTER DATABASE [Kiosk] SET PARAMETERIZATION SIMPLE

ALTER DATABASE [Kiosk] SET READ_COMMITTED_SNAPSHOT OFF

ALTER DATABASE [Kiosk] SET HONOR_BROKER_PRIORITY OFF

ALTER DATABASE [Kiosk] SET  READ_WRITE

ALTER DATABASE [Kiosk] SET RECOVERY FULL

ALTER DATABASE [Kiosk] SET  MULTI_USER

ALTER DATABASE [Kiosk] SET PAGE_VERIFY CHECKSUM

ALTER DATABASE [Kiosk] SET DB_CHAINING OFF

EXEC sys.sp_db_vardecimal_storage_format N'Kiosk', N'ON'

USE [Kiosk]

/****** Object:  Table [dbo].[restaurants]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[restaurants](
	[id] [int] NULL,
	[user_name] [text] NULL,
	[name] [text] NULL,
	[image] [text] NULL,
	[token] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** Object:  Table [dbo].[receipt]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[receipt](
	[num] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
	[price] [nvarchar](50) NULL,
	[count] [nvarchar](50) NULL,
	[cost] [nvarchar](50) NULL
) ON [PRIMARY]

/****** Object:  Table [dbo].[products]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[products](
	[id] [int] NULL,
	[restaurant_id] [int] NULL,
	[catery_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[price] [int] NULL,
	[discount_percent] [int] NULL,
	[d_price] [int] NULL,
	[description] [text] NULL,
	[image] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** Object:  Table [dbo].[printers]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[printers](
	[restaurant_id] [int] NULL,
	[name] [nvarchar](50) NULL
) ON [PRIMARY]

/****** Object:  Table [dbo].[orders_content]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[orders_content](
	[id] [int] NULL,
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[cost] [int] NOT NULL,
	[count] [int] NOT NULL
) ON [PRIMARY]

/****** Object:  Table [dbo].[orders]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

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

/****** Object:  Table [dbo].[order_content_desserts]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[order_content_desserts](
	[order_content_id] [int] NULL,
	[dessert_id] [int] NULL,
	[price] [int] NULL
) ON [PRIMARY]

/****** Object:  Table [dbo].[device]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[device](
	[id] [int] NULL,
	[user_name] [text] NULL,
	[name] [text] NULL,
	[token] [text] NULL,
	[client_key] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** Object:  Table [dbo].[desserts]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[desserts](
	[id] [int] NULL,
	[product_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[price] [int] NULL,
	[image] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

/****** Object:  Table [dbo].[cateries]    Script Date: 11/26/2019 12:19:07 ******/
SET ANSI_NULLS ON

SET QUOTED_IDENTIFIER ON

CREATE TABLE [dbo].[cateries](
	[id] [int] NULL,
	[restaurant_id] [int] NULL,
	[name] [nvarchar](50) NULL,
	[image] [text] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

