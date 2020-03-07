CREATE DATABASE [CSharpAssignment]
GO
USE [CSharpAssignment]
GO
CREATE TABLE [Country] ([CountryId] INT PRIMARY KEY IDENTITY(1,1),
							[Name] NVARCHAR(56),
							[CreatedDate] DATETIME NOT NULL DEFAULT SYSDATETIME(),
							[UpdateDate] DATETIME NOT NULL)
GO
CREATE TABLE [State] ([StateId] INT PRIMARY KEY IDENTITY(1,1),
						[Name] NVARCHAR(56),
						[CountryId] INT FOREIGN KEY REFERENCES [Country]([CountryId]),
						[CreatedDate] DATETIME NOT NULL DEFAULT SYSDATETIME(),
						[UpdateDate] DATETIME NOT NULL)
GO
CREATE TABLE [City] ([CityId] INT PRIMARY KEY IDENTITY(1,1),
						[Name] NVARCHAR(56),						
						[StateId] INT FOREIGN KEY REFERENCES [State]([StateId]),
						[CreatedDate] DATETIME NOT NULL DEFAULT SYSDATETIME(),
						[UpdateDate] DATETIME NOT NULL)
GO
CREATE TABLE [Customer] ([CustomerId] INT PRIMARY KEY IDENTITY(1,1),
							[Name] NVARCHAR(56) NOT NULL,
							[EmailId] NVARCHAR(64) NOT NULL,
							[PhoneNo] NVARCHAR(10) NOT NULL,
							[DOB] DATE NOT NULL,
							[CityId] INT FOREIGN KEY REFERENCES [City]([CityId]),
							[IsActive] BIT DEFAULT 1,
							[CreatedDate] DATETIME NOT NULL DEFAULT SYSDATETIME(),
							[UpdatedDate] DATETIME)
GO
CREATE TABLE [Address] ([AddressId] INT PRIMARY KEY IDENTITY(1,1),
							[Value] NVARCHAR(256) NOT NULL,
							[CustomerId] INT FOREIGN KEY REFERENCES [Customer]([CustomerId]))
GO