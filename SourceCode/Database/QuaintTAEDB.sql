USE [master]
GO
/****** Object:  Database [QuaintTMSDB]    Script Date: 5/5/2018 4:15:49 AM ******/
CREATE DATABASE [QuaintTMSDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuaintTMSDB', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuaintTMSDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuaintTMSDB_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QuaintTMSDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuaintTMSDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuaintTMSDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuaintTMSDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QuaintTMSDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuaintTMSDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuaintTMSDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuaintTMSDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuaintTMSDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuaintTMSDB] SET  MULTI_USER 
GO
ALTER DATABASE [QuaintTMSDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuaintTMSDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuaintTMSDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuaintTMSDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QuaintTMSDB]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Email]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Email]
	@EmailId int
As
Begin
	Delete
		dbo.Subcribes
	Where
		[EmailId] = @EmailId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Event]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Event]
	@EventId int
As
Begin
	Delete
		dbo.Events
	Where
		[EventId] = @EventId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Guide]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Guide]
	@GuideId int
As
Begin
	Delete
		dbo.Guides
	Where
		[GuideId] = @GuideId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_HotelReservation]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_HotelReservation]
	@HotelId int
As
Begin
	Delete
		dbo.HotelReservations
	Where
		[HotelId] = @HotelId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Location]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Location]
	@LocationId int
As
Begin
	Delete
		dbo.Locations
	Where
		[LocationId] = @LocationId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_Registration]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_Registration]
	@RegistrationId int
As
Begin
	Delete
		dbo.Registrations
	Where
		[RegistrationId] = @RegistrationId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Delete_User]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Delete_User]
	@UserId int
As
Begin
	Delete
		dbo.Users
	Where
		[UserId] = @UserId

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Get_All_Email]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Get_All_Email]
As
Begin
	Select
		*
	From
		dbo.Subcribes
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Event]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Get_All_Event]
As
Begin
	Select
		*
	From
		dbo.Events
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Guide]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Get_All_Guide]
As
Begin
	Select
		g.*
		, l.LocationId
		, l.Name as LocationName
		, l.IsActive as LocationIsActive
	From
		dbo.Guides g
	Left Join
		dbo.Locations l
	On
		g.LocationId = l.LocationId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_HotelReservation]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Get_All_HotelReservation]
As
Begin
	Select
		*
	From
		dbo.HotelReservations
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Location]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Get_All_Location]
As
Begin
	Select
		*
	From
		dbo.Locations
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_Registration]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Get_All_Registration]
As
Begin
	Select
		*
	From
		dbo.Registrations
End
GO
/****** Object:  StoredProcedure [dbo].[Get_All_User]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_All_User]
As
Begin
	Select
		*
	From
		dbo.Users
End

GO
/****** Object:  StoredProcedure [dbo].[Get_Event_By_Id]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
CREATE Procedure [dbo].[Get_Event_By_Id]
	@EventId int
As
Begin
	Select
		*
	From
		dbo.Events
	Where
		[EventId] = @EventId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Guide_By_Id]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
CREATE Procedure [dbo].[Get_Guide_By_Id]
	@GuideId int
As
Begin
	Select
		*
	From
		dbo.Guides
	Where
		[GuideId] = @GuideId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_HotelReservation_By_Id]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
CREATE Procedure [dbo].[Get_HotelReservation_By_Id]
	@HotelId int
As
Begin
	Select
		*
	From
		dbo.HotelReservations
	Where
		[HotelId] = @HotelId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Location_By_Id]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
CREATE Procedure [dbo].[Get_Location_By_Id]
	@LocationId int
As
Begin
	Select
		*
	From
		dbo.Locations
	Where
		[LocationId] = @LocationId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_Registration_By_Id]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
CREATE Procedure [dbo].[Get_Registration_By_Id]
	@RegistrationId int
As
Begin
	Select
		*
	From
		dbo.Registrations
	Where
		[RegistrationId] = @RegistrationId
End
GO
/****** Object:  StoredProcedure [dbo].[Get_User_By_Id]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Get_User_By_Id]
	@UserId int
As
Begin
	Select
		*
	From
		dbo.Users
	Where
		[UserId] = @UserId
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_Email]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Insert_Email]
	@EmailCode nvarchar(50),
	@Email nvarchar(50)
As
Begin
	Insert Into dbo.Subcribes
		(EmailCode, Email)
	Values
		(@EmailCode, @Email)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_Event]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Insert_Event]
	@EventCode nvarchar(50),
	@Title nvarchar(100),
	@Slag nvarchar(MAX) = null,	
	@FromDate datetime,
	@ToDate datetime,
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@LocationId int
As
Begin
	Insert Into dbo.Events
		(EventCode, Title, Slag, FromDate, ToDate, Description, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, LocationId)
	Values
		(@EventCode, @Title, @Slag, @FromDate, @ToDate, @Description, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @LocationId)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_Guide]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Insert_Guide]
	@GuideCode nvarchar(50),
	@Name nvarchar(50),
	@ContactNumber nvarchar(50),	
	@Email nvarchar(50),
	@AddressLine1 nvarchar(50),
	@AddressLine2 nvarchar(50) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@LocationId int
As
Begin
	Insert Into dbo.Guides
		(GuideCode, Name, ContactNumber, Email, AddressLine1, AddressLine2, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, LocationId)
	Values
		(@GuideCode, @Name, @ContactNumber, @Email, @AddressLine1, @AddressLine2,@IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @LocationId)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_HotelReservation]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Insert_HotelReservation]
	@HotelCode nvarchar(50),
	@Slag nvarchar(MAX) = null,
	@HotelName nvarchar(50),
	@ArrivalDate datetime,
	@DepartureDate datetime,
	@RoomType nvarchar(50),
	@BookedBy nvarchar(50),
	@Email nvarchar(50),
	@ContactNumber nvarchar(50),
	@Address nvarchar(50),
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.HotelReservations
		(HotelCode, Slag, HotelName, ArrivalDate, DepartureDate, RoomType, BookedBy, Email,	ContactNumber, Address,	IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@HotelCode, @Slag, @HotelName, @ArrivalDate, @DepartureDate, @RoomType, @BookedBy, @Email, @ContactNumber, @Address, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_Location]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour And Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Insert_Location]
	@LocationCode nvarchar(50),
	@Name nvarchar(50),
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Insert Into dbo.Locations
		(LocationCode, Name, Description, IsActive, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom)
	Values
		(@LocationCode, @Name, @Description, @IsActive, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End
GO
/****** Object:  StoredProcedure [dbo].[Insert_Registration]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Insert_Registration]
	@RegistrationCode nvarchar(50),
	@FullName nvarchar(100),	
	@Email nvarchar(50) = null,
	@ContactNumber nvarchar(50),
	@Address nvarchar(50),
	@EventId int
As
Begin
	Insert Into dbo.Registrations
		(RegistrationCode, FullName, Email, ContactNumber, Address, EventId)
	Values
		(@RegistrationCode, @FullName, @Email, @ContactNumber, @Address, @EventId)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Insert_User]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Insert_User]
	@UserCode nvarchar(50),
	@FullName nvarchar(50),
	@Email nvarchar(50) = null,
	@UserName nvarchar(50),
	@Password nvarchar(MAX),
	@PasswordStamp nvarchar(MAX) = null,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@UserType nvarchar(50),
	@IsActive bit
As
Begin
	Insert Into dbo.Users
		(UserCode, FullName, Email, UserName, Password, PasswordStamp, CreatedDate, CreatedBy, CreatedFrom, UpdatedDate, UpdatedBy, UpdatedFrom, UserType, IsActive)
	Values
		(@UserCode, @FullName, @Email, @UserName, @Password, @PasswordStamp, @CreatedDate, @CreatedBy, @CreatedFrom, @UpdatedDate, @UpdatedBy, @UpdatedFrom, @UserType, @IsActive)

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID
End

GO
/****** Object:  StoredProcedure [dbo].[Update_Event]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Update_Event]
	@EventId int,
	@EventCode nvarchar(50),
	@Title nvarchar(100),
	@Slag nvarchar(MAX) = null,	
	@FromDate datetime,
	@ToDate datetime,
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@LocationId int
As
Begin
	Update
		dbo.Events
	Set
		 [EventCode] = @EventCode
		,[Title] = @Title
		,[Slag] = @Slag
		,[FromDate] = @FromDate
		,[ToDate] = @ToDate
		,[Description] = @Description
		,[IsActive]= @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[LocationId] = @LocationId
	Where		
		[EventId] = @EventId
End

GO
/****** Object:  StoredProcedure [dbo].[Update_Guide]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Update_Guide]
	@GuideId int,
	@GuideCode nvarchar(50),
	@Name nvarchar(50),
	@ContactNumber nvarchar(50),	
	@Email nvarchar(50),
	@AddressLine1 nvarchar(50),
	@AddressLine2 nvarchar(50) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@LocationId int
As
Begin
	Update
		dbo.Guides
	Set
		 [GuideCode] = @GuideCode
		,[Name] = @Name
		,[ContactNumber] = @ContactNumber
		,[Email]=@Email
		,[AddressLine1] = @AddressLine1
		,[AddressLine2] = @AddressLine2
		,[IsActive]= @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[LocationId] = @LocationId
	Where		
		[GuideId] = @GuideId
End

GO
/****** Object:  StoredProcedure [dbo].[Update_HotelReservation]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Update_HotelReservation]
	@HotelId int,
	@HotelCode nvarchar(50),
	@Slag nvarchar(MAX) = null,
	@HotelName nvarchar(50),
	@ArrivalDate datetime,
	@DepartureDate datetime,
	@RoomType nvarchar(50),
	@BookedBy nvarchar(50),
	@Email nvarchar(50),
	@ContactNumber nvarchar(50),
	@Address nvarchar(50),
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Update
		dbo.HotelReservations
	Set
		 [HotelCode] = @HotelCode
		,[Slag] = @Slag
		,[HotelName] = @HotelName
		,[ArrivalDate] = @ArrivalDate
		,[DepartureDate] = @DepartureDate
		,[RoomType] = @RoomType
		,[BookedBy] = @BookedBy
		,[Email] = @Email
		,[ContactNumber] = @ContactNumber
		,[Address] = @Address
		,[IsActive]= @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
	Where		
		[HotelId] = @HotelId
End

GO
/****** Object:  StoredProcedure [dbo].[Update_Location]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * ---------------------------------------------------------------------
-- * Description          : Quaint Tour And Event Management System (QTAE)
--*/
--========================================================================
CREATE Procedure [dbo].[Update_Location]
	@LocationId int,
	@LocationCode nvarchar(50),
	@Name nvarchar(50),
	@Description nvarchar(MAX) = null,
	@IsActive bit,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null
As
Begin
	Update
		dbo.Locations
	Set
		 [LocationCode] = @LocationCode
		,[Name] = @Name
		,[Description] = @Description
		,[IsActive] = @IsActive
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
	Where		
		[LocationId] = @LocationId
End
GO
/****** Object:  StoredProcedure [dbo].[Update_User]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--/*
-- * Author               : Quaint Park
-- * Copyright            : © 2018 Quaint Park.
-- * Official Website     : www.quaintpark.com
-- * --------------------------------------------------------------------
-- * Description          : Quaint Tour and Event Management System (QTAE)
--*/
--=======================================================================
CREATE Procedure [dbo].[Update_User]
	@UserId int,
	@UserCode nvarchar(50),
	@FullName nvarchar(50),
	@Email nvarchar(50) = null,
	@UserName nvarchar(50),
	@Password nvarchar(MAX),
	@PasswordStamp nvarchar(MAX) = null,
	@CreatedDate datetime = null,
	@CreatedBy nvarchar(500) = null,
	@CreatedFrom nvarchar(500) = null,
	@UpdatedDate datetime = null,
	@UpdatedBy nvarchar(500) = null,
	@UpdatedFrom nvarchar(500) = null,
	@UserType nvarchar(50),
	@IsActive bit
As
Begin
	Update
		dbo.Users
	Set
		[UserCode] = @UserCode
		,[FullName] = @FullName
		,[Email] = @Email
		,[UserName] = @UserName
		,[Password] = @Password
		,[PasswordStamp] = @PasswordStamp
		,[CreatedDate] = @CreatedDate
		,[CreatedBy] = @CreatedBy
		,[CreatedFrom] = @CreatedFrom
		,[UpdatedDate] = @UpdatedDate
		,[UpdatedBy] = @UpdatedBy
		,[UpdatedFrom] = @UpdatedFrom
		,[UserType] = @UserType
		,[IsActive] = @IsActive
	Where		
		[UserId] = @UserId
End

GO
/****** Object:  Table [dbo].[Events]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[EventCode] [nvarchar](50) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Slag] [nvarchar](max) NULL,
	[FromDate] [datetime] NOT NULL,
	[ToDate] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Guides]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guides](
	[GuideId] [int] IDENTITY(1,1) NOT NULL,
	[GuideCode] [nvarchar](50) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContactNumber] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[AddressLine1] [nvarchar](50) NOT NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[LocationId] [int] NULL,
 CONSTRAINT [PK_Guides] PRIMARY KEY CLUSTERED 
(
	[GuideId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HotelReservations]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HotelReservations](
	[HotelId] [int] IDENTITY(1,1) NOT NULL,
	[HotelCode] [nvarchar](50) NOT NULL,
	[Slag] [nvarchar](max) NULL,
	[HotelName] [nvarchar](50) NOT NULL,
	[ArrivalDate] [datetime] NOT NULL,
	[DepartureDate] [datetime] NOT NULL,
	[RoomType] [nvarchar](50) NOT NULL,
	[BookedBy] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_HotelReservations] PRIMARY KEY CLUSTERED 
(
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Locations]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[LocationCode] [nvarchar](50) NOT NULL,
	[Slug] [nvarchar](max) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Registrations]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrations](
	[RegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationCode] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[ContactNumber] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[EventId] [int] NOT NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subcribes]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subcribes](
	[EmailId] [int] IDENTITY(1,1) NOT NULL,
	[EmailCode] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Subcribes] PRIMARY KEY CLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 5/5/2018 4:15:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[PasswordStamp] [nvarchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [nvarchar](500) NULL,
	[CreatedFrom] [nvarchar](500) NULL,
	[UpdatedDate] [datetime] NULL,
	[UpdatedBy] [nvarchar](500) NULL,
	[UpdatedFrom] [nvarchar](500) NULL,
	[UserType] [nvarchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [QuaintTMSDB] SET  READ_WRITE 
GO
