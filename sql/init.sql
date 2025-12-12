IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'e_learning')
BEGIN
    CREATE DATABASE e_learning;
END
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'e_learning')
BEGIN
    USE e_learning;
END
GO

/****** Object:  Table [dbo].[categories]    Script Date: 12/12/2025 20:13:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[delete_flag] [bit] NOT NULL,
 CONSTRAINT [PK__categori__3213E83F65FC07C4] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__categori__72E12F1BDDE291ED] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[course_categories]    Script Date: 12/12/2025 20:13:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[course_categories]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[course_categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[course_id] [int] NOT NULL,
	[category_id] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[delete_flag] [bit] NOT NULL,
 CONSTRAINT [PK__course_c__3213E83F345A3232] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[courses]    Script Date: 12/12/2025 20:13:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[courses]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[courses](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[subtitle] [nvarchar](500) NULL,
	[description] [nvarchar](3000) NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[delete_flag] [bit] NOT NULL,
 CONSTRAINT [PK__courses__3213E83FF6A285DC] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[enrollments]    Script Date: 12/12/2025 20:13:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[enrollments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[enrollments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[course_id] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[delete_flag] [bit] NOT NULL,
 CONSTRAINT [PK__enrollme__3213E83F04DC0418] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[lesson_content_progress]    Script Date: 12/12/2025 20:13:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[lesson_content_progress]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[lesson_content_progress](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[lesson_content_id] [int] NOT NULL,
	[seconds_watched] [int] NULL,
	[scroll_percentage] [float] NULL,
	[status] [tinyint] NOT NULL,
	[is_current] [bit] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[delete_flag] [bit] NOT NULL,
 CONSTRAINT [PK__lesson_c__3213E83F3D80A97A] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[lesson_contents]    Script Date: 12/12/2025 20:13:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[lesson_contents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[lesson_contents](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[lesson_id] [int] NOT NULL,
	[content_type] [nvarchar](50) NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[order_index] [int] NOT NULL,
	[content_url] [nvarchar](500) NOT NULL,
	[duration_seconds] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[delete_flag] [bit] NOT NULL,
 CONSTRAINT [PK__lesson_c__3213E83F033FCB5B] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[lessons]    Script Date: 12/12/2025 20:13:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[lessons]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[lessons](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[course_id] [int] NOT NULL,
	[title] [nvarchar](255) NOT NULL,
	[description] [nvarchar](2000) NULL,
	[order_index] [int] NOT NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[delete_flag] [bit] NOT NULL,
 CONSTRAINT [PK__lessons__3213E83F6C7D5C04] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[refresh_tokens]    Script Date: 12/12/2025 20:13:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[refresh_tokens]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[refresh_tokens](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[token_hash] [nvarchar](64) NOT NULL,
	[expires_at] [datetime] NOT NULL,
	[is_revoked] [bit] NOT NULL,
	[revoked_at] [datetime] NULL,
	[replaced_by] [nvarchar](64) NULL,
	[ip_address] [nvarchar](50) NULL,
	[user_agent] [nvarchar](500) NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[delete_flag] [bit] NOT NULL,
 CONSTRAINT [PK__refresh___3213E83F9500A583] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[users]    Script Date: 12/12/2025 20:13:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NOT NULL,
	[password_hash] [nvarchar](500) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[role] [nvarchar](30) NOT NULL,
	[forgot_password_token] [nvarchar](255) NULL,
	[forgot_password_token_expire] [datetime] NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
	[delete_flag] [bit] NOT NULL,
 CONSTRAINT [PK__users__3213E83FB1D7DE57] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__course_ca__categ__35BCFE0A]') AND parent_object_id = OBJECT_ID(N'[dbo].[course_categories]'))
ALTER TABLE [dbo].[course_categories]  WITH CHECK ADD  CONSTRAINT [FK__course_ca__categ__35BCFE0A] FOREIGN KEY([category_id])
REFERENCES [dbo].[categories] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__course_ca__categ__35BCFE0A]') AND parent_object_id = OBJECT_ID(N'[dbo].[course_categories]'))
ALTER TABLE [dbo].[course_categories] CHECK CONSTRAINT [FK__course_ca__categ__35BCFE0A]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__course_ca__cours__34C8D9D1]') AND parent_object_id = OBJECT_ID(N'[dbo].[course_categories]'))
ALTER TABLE [dbo].[course_categories]  WITH CHECK ADD  CONSTRAINT [FK__course_ca__cours__34C8D9D1] FOREIGN KEY([course_id])
REFERENCES [dbo].[courses] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__course_ca__cours__34C8D9D1]') AND parent_object_id = OBJECT_ID(N'[dbo].[course_categories]'))
ALTER TABLE [dbo].[course_categories] CHECK CONSTRAINT [FK__course_ca__cours__34C8D9D1]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__enrollmen__cours__398D8EEE]') AND parent_object_id = OBJECT_ID(N'[dbo].[enrollments]'))
ALTER TABLE [dbo].[enrollments]  WITH CHECK ADD  CONSTRAINT [FK__enrollmen__cours__398D8EEE] FOREIGN KEY([course_id])
REFERENCES [dbo].[courses] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__enrollmen__cours__398D8EEE]') AND parent_object_id = OBJECT_ID(N'[dbo].[enrollments]'))
ALTER TABLE [dbo].[enrollments] CHECK CONSTRAINT [FK__enrollmen__cours__398D8EEE]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__enrollmen__user___38996AB5]') AND parent_object_id = OBJECT_ID(N'[dbo].[enrollments]'))
ALTER TABLE [dbo].[enrollments]  WITH CHECK ADD  CONSTRAINT [FK__enrollmen__user___38996AB5] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__enrollmen__user___38996AB5]') AND parent_object_id = OBJECT_ID(N'[dbo].[enrollments]'))
ALTER TABLE [dbo].[enrollments] CHECK CONSTRAINT [FK__enrollmen__user___38996AB5]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__lesson_co__lesso__3B75D760]') AND parent_object_id = OBJECT_ID(N'[dbo].[lesson_content_progress]'))
ALTER TABLE [dbo].[lesson_content_progress]  WITH CHECK ADD  CONSTRAINT [FK__lesson_co__lesso__3B75D760] FOREIGN KEY([lesson_content_id])
REFERENCES [dbo].[lesson_contents] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__lesson_co__lesso__3B75D760]') AND parent_object_id = OBJECT_ID(N'[dbo].[lesson_content_progress]'))
ALTER TABLE [dbo].[lesson_content_progress] CHECK CONSTRAINT [FK__lesson_co__lesso__3B75D760]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__lesson_co__user___3A81B327]') AND parent_object_id = OBJECT_ID(N'[dbo].[lesson_content_progress]'))
ALTER TABLE [dbo].[lesson_content_progress]  WITH CHECK ADD  CONSTRAINT [FK__lesson_co__user___3A81B327] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__lesson_co__user___3A81B327]') AND parent_object_id = OBJECT_ID(N'[dbo].[lesson_content_progress]'))
ALTER TABLE [dbo].[lesson_content_progress] CHECK CONSTRAINT [FK__lesson_co__user___3A81B327]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__lesson_co__lesso__37A5467C]') AND parent_object_id = OBJECT_ID(N'[dbo].[lesson_contents]'))
ALTER TABLE [dbo].[lesson_contents]  WITH CHECK ADD  CONSTRAINT [FK__lesson_co__lesso__37A5467C] FOREIGN KEY([lesson_id])
REFERENCES [dbo].[lessons] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__lesson_co__lesso__37A5467C]') AND parent_object_id = OBJECT_ID(N'[dbo].[lesson_contents]'))
ALTER TABLE [dbo].[lesson_contents] CHECK CONSTRAINT [FK__lesson_co__lesso__37A5467C]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__lessons__course___36B12243]') AND parent_object_id = OBJECT_ID(N'[dbo].[lessons]'))
ALTER TABLE [dbo].[lessons]  WITH CHECK ADD  CONSTRAINT [FK__lessons__course___36B12243] FOREIGN KEY([course_id])
REFERENCES [dbo].[courses] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__lessons__course___36B12243]') AND parent_object_id = OBJECT_ID(N'[dbo].[lessons]'))
ALTER TABLE [dbo].[lessons] CHECK CONSTRAINT [FK__lessons__course___36B12243]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__refresh_t__user___3C69FB99]') AND parent_object_id = OBJECT_ID(N'[dbo].[refresh_tokens]'))
ALTER TABLE [dbo].[refresh_tokens]  WITH CHECK ADD  CONSTRAINT [FK__refresh_t__user___3C69FB99] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__refresh_t__user___3C69FB99]') AND parent_object_id = OBJECT_ID(N'[dbo].[refresh_tokens]'))
ALTER TABLE [dbo].[refresh_tokens] CHECK CONSTRAINT [FK__refresh_t__user___3C69FB99]
GO
