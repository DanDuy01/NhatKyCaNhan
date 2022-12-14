USE [Project_PRN]
GO
/****** Object:  Table [dbo].[Diaries]    Script Date: 14-Nov-22 01:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diaries](
	[DiaryId] [int] IDENTITY(1,1) NOT NULL,
	[Mood] [nvarchar](20) NULL,
	[Time] [date] NOT NULL,
	[Note] [nvarchar](max) NULL,
	[Favourite] [bit] NULL,
 CONSTRAINT [PK_Diaries] PRIMARY KEY CLUSTERED 
(
	[DiaryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 14-Nov-22 01:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Account] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Diaries] ON 

INSERT [dbo].[Diaries] ([DiaryId], [Mood], [Time], [Note], [Favourite]) VALUES (1, N'Vui', CAST(N'2022-11-14' AS Date), N'Ko co gi', 0)
INSERT [dbo].[Diaries] ([DiaryId], [Mood], [Time], [Note], [Favourite]) VALUES (2, N'Ko vui', CAST(N'2022-11-15' AS Date), N'No', 1)
SET IDENTITY_INSERT [dbo].[Diaries] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [Account], [Password]) VALUES (1, N'admin', N'123')
INSERT [dbo].[Users] ([UserId], [Account], [Password]) VALUES (2, N'ad', N'123')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
