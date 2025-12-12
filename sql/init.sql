IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'e_learning')
BEGIN
    CREATE DATABASE e_learning;
END
GO

USE e_learning;
GO

CREATE TABLE [users] (
  [id] integer PRIMARY KEY IDENTITY(1, 1),
  [username] nvarchar(255) NOT NULL,
  [password_hash] nvarchar(500) NOT NULL,
  [email] nvarchar(255) NOT NULL,
  [role] nvarchar(30) NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL,
  [delete_flag] bit NOT NULL
)
GO

CREATE TABLE [courses] (
  [id] integer PRIMARY KEY IDENTITY(1, 1),
  [title] nvarchar(255) NOT NULL,
  [subtitle] nvarchar(500),
  [description] nvarchar(3000),
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL,
  [delete_flag] bit NOT NULL
)
GO

CREATE TABLE [categories] (
  [id] integer PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(255) UNIQUE NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL,
  [delete_flag] bit NOT NULL
)
GO

CREATE TABLE [course_categories] (
  [id] integer PRIMARY KEY IDENTITY(1, 1),
  [course_id] integer NOT NULL,
  [category_id] integer NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL,
  [delete_flag] bit NOT NULL
)
GO

CREATE TABLE [lessons] (
  [id] integer PRIMARY KEY IDENTITY(1, 1),
  [course_id] integer NOT NULL,
  [title] nvarchar(255) NOT NULL,
  [description] nvarchar(2000),
  [order_index] integer NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL,
  [delete_flag] bit NOT NULL
)
GO

CREATE TABLE [lesson_contents] (
  [id] integer PRIMARY KEY IDENTITY(1, 1),
  [lesson_id] integer NOT NULL,
  [content_type] nvarchar(50) NOT NULL,
  [title] nvarchar(255) NOT NULL,
  [order_index] integer NOT NULL,
  [content_url] nvarchar(500) NOT NULL,
  [duration_seconds] integer NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL,
  [delete_flag] bit NOT NULL
)
GO

CREATE TABLE [enrollments] (
  [id] integer PRIMARY KEY IDENTITY(1, 1),
  [user_id] integer NOT NULL,
  [course_id] integer NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL,
  [delete_flag] bit NOT NULL
)
GO

CREATE TABLE [lesson_content_progress] (
  [id] integer PRIMARY KEY IDENTITY(1, 1),
  [user_id] integer NOT NULL,
  [lesson_content_id] integer NOT NULL,
  [seconds_watched] integer,
  [scroll_percentage] float,
  [status] tinyint NOT NULL,
  [is_current] bit NOT NULL,
  [created_at] datetime NOT NULL,
  [updated_at] datetime NOT NULL,
  [delete_flag] bit NOT NULL
)
GO

CREATE UNIQUE INDEX [course_categories_index_0] ON [course_categories] ("course_id", "category_id")
GO

CREATE UNIQUE INDEX [enrollments_index_1] ON [enrollments] ("user_id", "course_id")
GO

CREATE UNIQUE INDEX [lesson_content_progress_index_2] ON [lesson_content_progress] ("user_id", "lesson_content_id")
GO

ALTER TABLE [course_categories] ADD FOREIGN KEY ([course_id]) REFERENCES [courses] ([id])
GO

ALTER TABLE [course_categories] ADD FOREIGN KEY ([category_id]) REFERENCES [categories] ([id])
GO

ALTER TABLE [lessons] ADD FOREIGN KEY ([course_id]) REFERENCES [courses] ([id])
GO

ALTER TABLE [lesson_contents] ADD FOREIGN KEY ([lesson_id]) REFERENCES [lessons] ([id])
GO

ALTER TABLE [enrollments] ADD FOREIGN KEY ([user_id]) REFERENCES [users] ([id])
GO

ALTER TABLE [enrollments] ADD FOREIGN KEY ([course_id]) REFERENCES [courses] ([id])
GO

ALTER TABLE [lesson_content_progress] ADD FOREIGN KEY ([user_id]) REFERENCES [users] ([id])
GO

ALTER TABLE [lesson_content_progress] ADD FOREIGN KEY ([lesson_content_id]) REFERENCES [lesson_contents] ([id])
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[refresh_tokens](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[token_hash] [nvarchar](64) NOT NULL,
	[expires_at] [datetime2](7) NOT NULL,
	[is_revoked] [bit] NOT NULL,
	[revoked_at] [datetime2](7) NULL,
	[replaced_by] [nvarchar](64) NULL,
	[ip_address] [nvarchar](50) NULL,
	[user_agent] [nvarchar](500) NULL,
	[created_at] [datetime2](7) NOT NULL,
	[updated_at] [datetime2](7) NOT NULL,
	[delete_flag] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[refresh_tokens] ADD  DEFAULT ((0)) FOR [is_revoked]
GO
ALTER TABLE [dbo].[refresh_tokens] ADD  DEFAULT (getdate()) FOR [created_at]
GO
ALTER TABLE [dbo].[refresh_tokens] ADD  DEFAULT (getdate()) FOR [updated_at]
GO
ALTER TABLE [dbo].[refresh_tokens] ADD  DEFAULT ((0)) FOR [delete_flag]
GO
ALTER TABLE [dbo].[refresh_tokens]  WITH CHECK ADD  CONSTRAINT [FK__refresh_tokens_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[refresh_tokens] CHECK CONSTRAINT [FK__refresh_tokens_users]
GO
ALTER TABLE [dbo].[users] ADD [forgot_password_token] [nvarchar](255) NULL
GO
ALTER TABLE [dbo].[users] ADD [forgot_password_token_expire] [datetime2](7) NULL
GO
