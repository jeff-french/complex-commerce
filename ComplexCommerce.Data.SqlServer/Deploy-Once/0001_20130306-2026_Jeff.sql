-- <Migration ID="6e1a3aa2-051d-46f8-9b8e-5339ad2f0b5a" />



SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[Album]'
GO
CREATE TABLE [dbo].[Album] (
		[AlbumId]      [int] IDENTITY(1, 1) NOT NULL,
		[Title]        [nvarchar](160) NOT NULL,
		[ArtistId]     [int] NOT NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_Album] to [dbo].[Album]'
GO
ALTER TABLE [dbo].[Album]
	ADD
	CONSTRAINT [PK_Album]
	PRIMARY KEY
	CLUSTERED
	([AlbumId])
	ON [PRIMARY]
GO


Print 'Create Index [IFK_AlbumArtistId] on [dbo].[Album]'
GO
CREATE NONCLUSTERED INDEX [IFK_AlbumArtistId]
	ON [dbo].[Album] ([ArtistId])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[Album] SET (LOCK_ESCALATION = TABLE)
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[Artist]'
GO
CREATE TABLE [dbo].[Artist] (
		[ArtistId]     [int] IDENTITY(1, 1) NOT NULL,
		[Name]         [nvarchar](120) NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_Artist] to [dbo].[Artist]'
GO
ALTER TABLE [dbo].[Artist]
	ADD
	CONSTRAINT [PK_Artist]
	PRIMARY KEY
	CLUSTERED
	([ArtistId])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[Artist] SET (LOCK_ESCALATION = TABLE)
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[Customer]'
GO
CREATE TABLE [dbo].[Customer] (
		[CustomerId]       [int] IDENTITY(1, 1) NOT NULL,
		[FirstName]        [nvarchar](40) NOT NULL,
		[LastName]         [nvarchar](20) NOT NULL,
		[Company]          [nvarchar](80) NULL,
		[Address]          [nvarchar](70) NULL,
		[City]             [nvarchar](40) NULL,
		[State]            [nvarchar](40) NULL,
		[Country]          [nvarchar](40) NULL,
		[PostalCode]       [nvarchar](10) NULL,
		[Phone]            [nvarchar](24) NULL,
		[Fax]              [nvarchar](24) NULL,
		[Email]            [nvarchar](60) NOT NULL,
		[SupportRepId]     [int] NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_Customer] to [dbo].[Customer]'
GO
ALTER TABLE [dbo].[Customer]
	ADD
	CONSTRAINT [PK_Customer]
	PRIMARY KEY
	CLUSTERED
	([CustomerId])
	ON [PRIMARY]
GO


Print 'Create Index [IFK_CustomerSupportRepId] on [dbo].[Customer]'
GO
CREATE NONCLUSTERED INDEX [IFK_CustomerSupportRepId]
	ON [dbo].[Customer] ([SupportRepId])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[Customer] SET (LOCK_ESCALATION = TABLE)
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[Employee]'
GO
CREATE TABLE [dbo].[Employee] (
		[EmployeeId]     [int] IDENTITY(1, 1) NOT NULL,
		[LastName]       [nvarchar](20) NOT NULL,
		[FirstName]      [nvarchar](20) NOT NULL,
		[Title]          [nvarchar](30) NULL,
		[ReportsTo]      [int] NULL,
		[BirthDate]      [datetime] NULL,
		[HireDate]       [datetime] NULL,
		[Address]        [nvarchar](70) NULL,
		[City]           [nvarchar](40) NULL,
		[State]          [nvarchar](40) NULL,
		[Country]        [nvarchar](40) NULL,
		[PostalCode]     [nvarchar](10) NULL,
		[Phone]          [nvarchar](24) NULL,
		[Fax]            [nvarchar](24) NULL,
		[Email]          [nvarchar](60) NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_Employee] to [dbo].[Employee]'
GO
ALTER TABLE [dbo].[Employee]
	ADD
	CONSTRAINT [PK_Employee]
	PRIMARY KEY
	CLUSTERED
	([EmployeeId])
	ON [PRIMARY]
GO


Print 'Create Index [IFK_EmployeeReportsTo] on [dbo].[Employee]'
GO
CREATE NONCLUSTERED INDEX [IFK_EmployeeReportsTo]
	ON [dbo].[Employee] ([ReportsTo])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[Employee] SET (LOCK_ESCALATION = TABLE)
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[Genre]'
GO
CREATE TABLE [dbo].[Genre] (
		[GenreId]     [int] IDENTITY(1, 1) NOT NULL,
		[Name]        [nvarchar](120) NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_Genre] to [dbo].[Genre]'
GO
ALTER TABLE [dbo].[Genre]
	ADD
	CONSTRAINT [PK_Genre]
	PRIMARY KEY
	CLUSTERED
	([GenreId])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[Genre] SET (LOCK_ESCALATION = TABLE)
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[Invoice]'
GO
CREATE TABLE [dbo].[Invoice] (
		[InvoiceId]             [int] IDENTITY(1, 1) NOT NULL,
		[CustomerId]            [int] NOT NULL,
		[InvoiceDate]           [datetime] NOT NULL,
		[BillingAddress]        [nvarchar](70) NULL,
		[BillingCity]           [nvarchar](40) NULL,
		[BillingState]          [nvarchar](40) NULL,
		[BillingCountry]        [nvarchar](40) NULL,
		[BillingPostalCode]     [nvarchar](10) NULL,
		[Total]                 [numeric](10, 2) NOT NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_Invoice] to [dbo].[Invoice]'
GO
ALTER TABLE [dbo].[Invoice]
	ADD
	CONSTRAINT [PK_Invoice]
	PRIMARY KEY
	CLUSTERED
	([InvoiceId])
	ON [PRIMARY]
GO


Print 'Create Index [IFK_InvoiceCustomerId] on [dbo].[Invoice]'
GO
CREATE NONCLUSTERED INDEX [IFK_InvoiceCustomerId]
	ON [dbo].[Invoice] ([CustomerId])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[Invoice] SET (LOCK_ESCALATION = TABLE)
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[InvoiceLine]'
GO
CREATE TABLE [dbo].[InvoiceLine] (
		[InvoiceLineId]     [int] IDENTITY(1, 1) NOT NULL,
		[InvoiceId]         [int] NOT NULL,
		[TrackId]           [int] NOT NULL,
		[UnitPrice]         [numeric](10, 2) NOT NULL,
		[Quantity]          [int] NOT NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_InvoiceLine] to [dbo].[InvoiceLine]'
GO
ALTER TABLE [dbo].[InvoiceLine]
	ADD
	CONSTRAINT [PK_InvoiceLine]
	PRIMARY KEY
	CLUSTERED
	([InvoiceLineId])
	ON [PRIMARY]
GO


Print 'Create Index [IFK_InvoiceLineInvoiceId] on [dbo].[InvoiceLine]'
GO
CREATE NONCLUSTERED INDEX [IFK_InvoiceLineInvoiceId]
	ON [dbo].[InvoiceLine] ([InvoiceId])
	ON [PRIMARY]
GO


Print 'Create Index [IFK_InvoiceLineTrackId] on [dbo].[InvoiceLine]'
GO
CREATE NONCLUSTERED INDEX [IFK_InvoiceLineTrackId]
	ON [dbo].[InvoiceLine] ([TrackId])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[InvoiceLine] SET (LOCK_ESCALATION = TABLE)
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[MediaType]'
GO
CREATE TABLE [dbo].[MediaType] (
		[MediaTypeId]     [int] IDENTITY(1, 1) NOT NULL,
		[Name]            [nvarchar](120) NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_MediaType] to [dbo].[MediaType]'
GO
ALTER TABLE [dbo].[MediaType]
	ADD
	CONSTRAINT [PK_MediaType]
	PRIMARY KEY
	CLUSTERED
	([MediaTypeId])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[MediaType] SET (LOCK_ESCALATION = TABLE)
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[Playlist]'
GO
CREATE TABLE [dbo].[Playlist] (
		[PlaylistId]     [int] IDENTITY(1, 1) NOT NULL,
		[Name]           [nvarchar](120) NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_Playlist] to [dbo].[Playlist]'
GO
ALTER TABLE [dbo].[Playlist]
	ADD
	CONSTRAINT [PK_Playlist]
	PRIMARY KEY
	CLUSTERED
	([PlaylistId])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[Playlist] SET (LOCK_ESCALATION = TABLE)
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[PlaylistTrack]'
GO
CREATE TABLE [dbo].[PlaylistTrack] (
		[PlaylistId]     [int] NOT NULL,
		[TrackId]        [int] NOT NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_PlaylistTrack] to [dbo].[PlaylistTrack]'
GO
ALTER TABLE [dbo].[PlaylistTrack]
	ADD
	CONSTRAINT [PK_PlaylistTrack]
	PRIMARY KEY
	NONCLUSTERED
	([PlaylistId], [TrackId])
	ON [PRIMARY]
GO


Print 'Create Index [IFK_PlaylistTrackTrackId] on [dbo].[PlaylistTrack]'
GO
CREATE NONCLUSTERED INDEX [IFK_PlaylistTrackTrackId]
	ON [dbo].[PlaylistTrack] ([TrackId])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[PlaylistTrack] SET (LOCK_ESCALATION = TABLE)
GO


SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO


Print 'Create Table [dbo].[Track]'
GO
CREATE TABLE [dbo].[Track] (
		[TrackId]          [int] IDENTITY(1, 1) NOT NULL,
		[Name]             [nvarchar](200) NOT NULL,
		[AlbumId]          [int] NULL,
		[MediaTypeId]      [int] NOT NULL,
		[GenreId]          [int] NULL,
		[Composer]         [nvarchar](220) NULL,
		[Milliseconds]     [int] NOT NULL,
		[Bytes]            [int] NULL,
		[UnitPrice]        [numeric](10, 2) NOT NULL
) ON [PRIMARY]
GO


Print 'Add Primary Key [PK_Track] to [dbo].[Track]'
GO
ALTER TABLE [dbo].[Track]
	ADD
	CONSTRAINT [PK_Track]
	PRIMARY KEY
	CLUSTERED
	([TrackId])
	ON [PRIMARY]
GO


Print 'Create Index [IFK_TrackAlbumId] on [dbo].[Track]'
GO
CREATE NONCLUSTERED INDEX [IFK_TrackAlbumId]
	ON [dbo].[Track] ([AlbumId])
	ON [PRIMARY]
GO


Print 'Create Index [IFK_TrackGenreId] on [dbo].[Track]'
GO
CREATE NONCLUSTERED INDEX [IFK_TrackGenreId]
	ON [dbo].[Track] ([GenreId])
	ON [PRIMARY]
GO


Print 'Create Index [IFK_TrackMediaTypeId] on [dbo].[Track]'
GO
CREATE NONCLUSTERED INDEX [IFK_TrackMediaTypeId]
	ON [dbo].[Track] ([MediaTypeId])
	ON [PRIMARY]
GO


ALTER TABLE [dbo].[Track] SET (LOCK_ESCALATION = TABLE)
GO


Print 'Create Foreign Key [FK_AlbumArtistId] on [dbo].[Album]'
GO
ALTER TABLE [dbo].[Album]
	WITH CHECK
	ADD CONSTRAINT [FK_AlbumArtistId]
	FOREIGN KEY ([ArtistId]) REFERENCES [dbo].[Artist] ([ArtistId])
ALTER TABLE [dbo].[Album]
	CHECK CONSTRAINT [FK_AlbumArtistId]

GO


Print 'Create Foreign Key [FK_CustomerSupportRepId] on [dbo].[Customer]'
GO
ALTER TABLE [dbo].[Customer]
	WITH CHECK
	ADD CONSTRAINT [FK_CustomerSupportRepId]
	FOREIGN KEY ([SupportRepId]) REFERENCES [dbo].[Employee] ([EmployeeId])
ALTER TABLE [dbo].[Customer]
	CHECK CONSTRAINT [FK_CustomerSupportRepId]

GO


Print 'Create Foreign Key [FK_EmployeeReportsTo] on [dbo].[Employee]'
GO
ALTER TABLE [dbo].[Employee]
	WITH CHECK
	ADD CONSTRAINT [FK_EmployeeReportsTo]
	FOREIGN KEY ([ReportsTo]) REFERENCES [dbo].[Employee] ([EmployeeId])
ALTER TABLE [dbo].[Employee]
	CHECK CONSTRAINT [FK_EmployeeReportsTo]

GO


Print 'Create Foreign Key [FK_InvoiceCustomerId] on [dbo].[Invoice]'
GO
ALTER TABLE [dbo].[Invoice]
	WITH CHECK
	ADD CONSTRAINT [FK_InvoiceCustomerId]
	FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([CustomerId])
ALTER TABLE [dbo].[Invoice]
	CHECK CONSTRAINT [FK_InvoiceCustomerId]

GO


Print 'Create Foreign Key [FK_InvoiceLineInvoiceId] on [dbo].[InvoiceLine]'
GO
ALTER TABLE [dbo].[InvoiceLine]
	WITH CHECK
	ADD CONSTRAINT [FK_InvoiceLineInvoiceId]
	FOREIGN KEY ([InvoiceId]) REFERENCES [dbo].[Invoice] ([InvoiceId])
ALTER TABLE [dbo].[InvoiceLine]
	CHECK CONSTRAINT [FK_InvoiceLineInvoiceId]

GO


Print 'Create Foreign Key [FK_InvoiceLineTrackId] on [dbo].[InvoiceLine]'
GO
ALTER TABLE [dbo].[InvoiceLine]
	WITH CHECK
	ADD CONSTRAINT [FK_InvoiceLineTrackId]
	FOREIGN KEY ([TrackId]) REFERENCES [dbo].[Track] ([TrackId])
ALTER TABLE [dbo].[InvoiceLine]
	CHECK CONSTRAINT [FK_InvoiceLineTrackId]

GO


Print 'Create Foreign Key [FK_PlaylistTrackPlaylistId] on [dbo].[PlaylistTrack]'
GO
ALTER TABLE [dbo].[PlaylistTrack]
	WITH CHECK
	ADD CONSTRAINT [FK_PlaylistTrackPlaylistId]
	FOREIGN KEY ([PlaylistId]) REFERENCES [dbo].[Playlist] ([PlaylistId])
ALTER TABLE [dbo].[PlaylistTrack]
	CHECK CONSTRAINT [FK_PlaylistTrackPlaylistId]

GO


Print 'Create Foreign Key [FK_PlaylistTrackTrackId] on [dbo].[PlaylistTrack]'
GO
ALTER TABLE [dbo].[PlaylistTrack]
	WITH CHECK
	ADD CONSTRAINT [FK_PlaylistTrackTrackId]
	FOREIGN KEY ([TrackId]) REFERENCES [dbo].[Track] ([TrackId])
ALTER TABLE [dbo].[PlaylistTrack]
	CHECK CONSTRAINT [FK_PlaylistTrackTrackId]

GO


Print 'Create Foreign Key [FK_TrackAlbumId] on [dbo].[Track]'
GO
ALTER TABLE [dbo].[Track]
	WITH CHECK
	ADD CONSTRAINT [FK_TrackAlbumId]
	FOREIGN KEY ([AlbumId]) REFERENCES [dbo].[Album] ([AlbumId])
ALTER TABLE [dbo].[Track]
	CHECK CONSTRAINT [FK_TrackAlbumId]

GO


Print 'Create Foreign Key [FK_TrackGenreId] on [dbo].[Track]'
GO
ALTER TABLE [dbo].[Track]
	WITH CHECK
	ADD CONSTRAINT [FK_TrackGenreId]
	FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genre] ([GenreId])
ALTER TABLE [dbo].[Track]
	CHECK CONSTRAINT [FK_TrackGenreId]

GO


Print 'Create Foreign Key [FK_TrackMediaTypeId] on [dbo].[Track]'
GO
ALTER TABLE [dbo].[Track]
	WITH CHECK
	ADD CONSTRAINT [FK_TrackMediaTypeId]
	FOREIGN KEY ([MediaTypeId]) REFERENCES [dbo].[MediaType] ([MediaTypeId])
ALTER TABLE [dbo].[Track]
	CHECK CONSTRAINT [FK_TrackMediaTypeId]

GO


