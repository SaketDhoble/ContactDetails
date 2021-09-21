# ContactDetails
Evolent Project


API folder for .net code
GUI folder for angular code

Technolody Stack.

Database - SQL Server 2014.
Execute Below script.
CREATE TABLE [dbo].[tblContactDetails](
	[idContactDetails] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](50) NULL,
	[lastName] [nvarchar](50) NULL,
	[phoneNo] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[isActive] [int] NULL,
	[createdBy] [int] NULL,
	[createdOn] [datetime] NULL,
	[updatedBy] [int] NULL,
	[updatedOn] [datetime] NULL,
 CONSTRAINT [PK_tblContactDetails] PRIMARY KEY CLUSTERED 
(
	[idContactDetails] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


Front End - Angular 9 (Open project in VS code. Add api URL in global.ts file as gnBaseUrl.ng serve to run project)

Backend - .Net Core 2.0.1  (Open project is VS 2017. Add connection of DB in appSettings.json as DefaultConnection. start the project) 
