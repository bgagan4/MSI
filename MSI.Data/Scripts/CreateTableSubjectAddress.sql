USE [Contact]
GO

/****** Object:  Table [dbo].[SubjectAddress]    Script Date: 09-03-2021 23:43:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SubjectAddress](
	[SubjectAddressId] [int] IDENTITY(1,1) NOT NULL,
	[SubjectId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_SubjectAddress] PRIMARY KEY CLUSTERED 
(
	[SubjectAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SubjectAddress]  WITH CHECK ADD  CONSTRAINT [FK_SubjectAddress_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO

ALTER TABLE [dbo].[SubjectAddress] CHECK CONSTRAINT [FK_SubjectAddress_Address]
GO

ALTER TABLE [dbo].[SubjectAddress]  WITH CHECK ADD  CONSTRAINT [FK_SubjectAddress_Name] FOREIGN KEY([SubjectId])
REFERENCES [dbo].[Name] ([SubjectId])
GO

ALTER TABLE [dbo].[SubjectAddress] CHECK CONSTRAINT [FK_SubjectAddress_Name]
GO


