CREATE DATABASE [CSharpAssignment]
GO
USE [CSharpAssignment]
GO
CREATE TABLE [Country] ([CountryId] INT PRIMARY KEY IDENTITY(1,1),
							[Name] NVARCHAR(56),
							[CreatedDate] DATETIME NOT NULL DEFAULT SYSDATETIME(),
							[UpdateDate] DATETIME)
GO
CREATE TABLE [State] ([StateId] INT PRIMARY KEY IDENTITY(1,1),
						[Name] NVARCHAR(56),
						[CountryId] INT FOREIGN KEY REFERENCES [Country]([CountryId]),
						[CreatedDate] DATETIME NOT NULL DEFAULT SYSDATETIME(),
						[UpdateDate] DATETIME)
GO
CREATE TABLE [City] ([CityId] INT PRIMARY KEY IDENTITY(1,1),
						[Name] NVARCHAR(56),						
						[StateId] INT FOREIGN KEY REFERENCES [State]([StateId]),
						[CreatedDate] DATETIME NOT NULL DEFAULT SYSDATETIME(),
						[UpdateDate] DATETIME)
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
INSERT INTO [Country] ([Name]) VALUES('India'),
										('Pakistan'),
										('United States'),
										('England'),
										('China'),
										('Russia')
GO
INSERT INTO [State] ([Name],[CountryId]) VALUES ('Gujarat',1),
													('U.P.',1),
													('M.P.',1),
													('J.K.',1),
													('Assam',1),
													('Punjab',1),
													('Rajasthan',1),
													('Khyber Pakhtunkhw',2),
													('Sindh',2),
													('Balochistan',2),
													('Gilgit Baltistan',2),
													('Punjab',2)
GO
INSERT INTO [City] ([Name],[StateId]) VALUES ('Ahmedabad',1),
												('Surat',1),
												('Baroda',1),
												('Junagadh',1),
												('Porbandar',1),
												('Nadiyad',1),
												('Lucknow',2),
												('Prayagraj',2),
												('Kanpur',2),
												('Varansi',2),
												('Agra',2)
GO
INSERT INTO Customer VALUES('Raj Thakkar','Iamthakkarraj@gmail.com','9726080715',GETDATE(),2,1,SYSDATETIME(),NULL),
							('Dev Channiyara','Dev.Channiyara@thegatewaycorp.co.in','0000000000',GETDATE(),2,1,SYSDATETIME(),NULL)
GO