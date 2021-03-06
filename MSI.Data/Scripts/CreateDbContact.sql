CREATE DATABASE [Contact]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Contact', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Contact.mdf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Contact_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Contact_log.ldf' , SIZE = 8192KB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Contact] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [Contact] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Contact] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Contact] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Contact] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Contact] SET ARITHABORT OFF 
GO
ALTER DATABASE [Contact] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Contact] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Contact] SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF)
GO
ALTER DATABASE [Contact] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Contact] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Contact] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Contact] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Contact] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Contact] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Contact] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Contact] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Contact] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Contact] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Contact] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Contact] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Contact] SET  READ_WRITE 
GO
ALTER DATABASE [Contact] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Contact] SET  MULTI_USER 
GO
ALTER DATABASE [Contact] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Contact] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Contact] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Contact]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = Off;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = Primary;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = On;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = Primary;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = Off;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = Primary;
GO
USE [Contact]
GO
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY') ALTER DATABASE [Contact] MODIFY FILEGROUP [PRIMARY] DEFAULT
GO
