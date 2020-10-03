
IF (NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'FileUpload'))
BEGIN
		CREATE TABLE [dbo].[FileUpload](
		[ID] [int] IDENTITY(1,1) NOT NULL,
		[TransactionId] [varchar](50) NOT NULL,
		[Amount] [decimal](10, 2) NOT NULL,
		[CurrencyCode] [varchar](3) NOT NULL,
		[TransactionDate] [datetime] NULL,
		[Status] [varchar](8) NOT NULL,
		[CreatedDate] [datetime] NOT NULL,
		[FileType] [varchar](3) NULL,
	 CONSTRAINT [PK_T_FileUpload] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

END


