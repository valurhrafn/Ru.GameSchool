SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](215) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContentType](
	[ContentTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ContentType] PRIMARY KEY CLUSTERED 
(
	[ContentTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLog](
	[UserLogId] [int] IDENTITY(1,1) NOT NULL,
	[LoginTime] [datetime] NOT NULL,
	[IpAddress] [nvarchar](50) NOT NULL,
	[UserInfoId] [int] NOT NULL,
 CONSTRAINT [PK_UserLog] PRIMARY KEY CLUSTERED 
(
	[UserLogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserInfoId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[UserTypeId] [int] NOT NULL,
	[Fullname] [nvarchar](255) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[UserInfoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Identifier] [nvarchar](50) NOT NULL,
	[Start] [datetime] NOT NULL,
	[Stop] [datetime] NOT NULL,
	[CreditAmount] [int] NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Url] [nvarchar](512) NULL,
	[IsRead] [bit] NOT NULL,
	[UserInfoId] [int] NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[LevelId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Start] [datetime] NOT NULL,
	[Stop] [datetime] NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Level] PRIMARY KEY CLUSTERED 
(
	[LevelId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseGrade](
	[CourseId] [int] NOT NULL,
	[UserInfoId] [int] NOT NULL,
	[Grade] [float] NOT NULL,
	[Feedback] [nvarchar](max) NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_CourseGrade] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC,
	[UserInfoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserCourse](
	[UserInfoId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_UserCourse] PRIMARY KEY CLUSTERED 
(
	[UserInfoId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelProject](
	[LevelProjectId] [int] IDENTITY(1,1) NOT NULL,
	[LevelId] [int] NOT NULL,
	[Start] [datetime] NOT NULL,
	[Stop] [datetime] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[GradePercentageValue] [float] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_LevelProject] PRIMARY KEY CLUSTERED 
(
	[LevelProjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelMaterial](
	[LevelMaterialId] [int] IDENTITY(1,1) NOT NULL,
	[LevelId] [int] NOT NULL,
	[ContentId] [uniqueidentifier] NOT NULL,
	[ContentTypeId] [int] NOT NULL,
	[Url] [nvarchar](512) NULL,
	[Description] [nvarchar](max) NULL,
	[Title] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_LevelMaterial] PRIMARY KEY CLUSTERED 
(
	[LevelMaterialId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Points](
	[PointsId] [int] IDENTITY(1,1) NOT NULL,
	[UserInfoId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[LevelId] [int] NOT NULL,
	[Points] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Points] PRIMARY KEY CLUSTERED 
(
	[PointsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelExam](
	[LevelExamId] [int] IDENTITY(1,1) NOT NULL,
	[LevelId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[GradePercentageValue] [float] NOT NULL,
	[Name] [nvarchar](215) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LevelTest] PRIMARY KEY CLUSTERED 
(
	[LevelExamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelProjectResult](
	[LevelProjectId] [int] IDENTITY(1,1) NOT NULL,
	[UserInfoId] [int] NOT NULL,
	[Feedback] [nvarchar](max) NULL,
	[Grade] [float] NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LevelProjectResult] PRIMARY KEY CLUSTERED 
(
	[LevelProjectId] ASC,
	[UserInfoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[LevelMaterialId] [int] NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[UserInfoId] [int] NOT NULL,
	[Deleted] [bit] NOT NULL,
	[DeletedByUser] [nvarchar](255) NOT NULL,
	[CreateDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelExamResult](
	[LevelExamId] [int] NOT NULL,
	[UserInfoId] [int] NOT NULL,
	[Grade] [float] NOT NULL,
 CONSTRAINT [PK_LevelTestResult] PRIMARY KEY CLUSTERED 
(
	[LevelExamId] ASC,
	[UserInfoId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelExamQuestion](
	[LevelExamQuestionId] [int] IDENTITY(1,1) NOT NULL,
	[LevelExamId] [int] NOT NULL,
	[Question] [nvarchar](215) NOT NULL,
 CONSTRAINT [PK_LevelTestQuestion] PRIMARY KEY CLUSTERED 
(
	[LevelExamQuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LevelExamAnswer](
	[LevelExamAnswerId] [int] IDENTITY(1,1) NOT NULL,
	[LevelExamQuestionId] [int] NOT NULL,
	[Answer] [nvarchar](215) NULL,
	[Correct] [bit] NOT NULL,
 CONSTRAINT [PK_LevelTestAnswer] PRIMARY KEY CLUSTERED 
(
	[LevelExamAnswerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommentLike](
	[CommentLikeId] [int] NOT NULL,
	[CommentId] [int] NOT NULL,
	[UserInfoId] [int] NOT NULL,
 CONSTRAINT [PK_CommentLike] PRIMARY KEY CLUSTERED 
(
	[CommentLikeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Comment] ADD  CONSTRAINT [DF_Comment_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO
ALTER TABLE [dbo].[CourseGrade] ADD  CONSTRAINT [DF_CourseGrade_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO
ALTER TABLE [dbo].[Level] ADD  CONSTRAINT [DF_Level_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO
ALTER TABLE [dbo].[LevelExam] ADD  CONSTRAINT [DF_LevelTest_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO
ALTER TABLE [dbo].[LevelExamAnswer] ADD  CONSTRAINT [DF_LevelTestAnswer_Correct]  DEFAULT ((0)) FOR [Correct]
GO
ALTER TABLE [dbo].[LevelProjectResult] ADD  CONSTRAINT [DF_LevelProjectResult_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO
ALTER TABLE [dbo].[Notification] ADD  CONSTRAINT [DF_Notification_IsRead]  DEFAULT ((0)) FOR [IsRead]
GO
ALTER TABLE [dbo].[Notification] ADD  CONSTRAINT [DF_Notification_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO
ALTER TABLE [dbo].[Points] ADD  CONSTRAINT [DF_Points_Points]  DEFAULT ((0)) FOR [Points]
GO
ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_User_CreateDateTime]  DEFAULT (getdate()) FOR [CreateDateTime]
GO
ALTER TABLE [dbo].[UserLog] ADD  CONSTRAINT [DF_UserLog_LoginTime]  DEFAULT (getdate()) FOR [LoginTime]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_LevelMaterial] FOREIGN KEY([LevelMaterialId])
REFERENCES [dbo].[LevelMaterial] ([LevelMaterialId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_LevelMaterial]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_UserInfo1] FOREIGN KEY([UserInfoId])
REFERENCES [dbo].[UserInfo] ([UserInfoId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_UserInfo1]
GO
ALTER TABLE [dbo].[CommentLike]  WITH CHECK ADD  CONSTRAINT [FK_CommentLike_Comment] FOREIGN KEY([CommentId])
REFERENCES [dbo].[Comment] ([CommentId])
GO
ALTER TABLE [dbo].[CommentLike] CHECK CONSTRAINT [FK_CommentLike_Comment]
GO
ALTER TABLE [dbo].[CommentLike]  WITH CHECK ADD  CONSTRAINT [FK_CommentLike_UserInfo1] FOREIGN KEY([UserInfoId])
REFERENCES [dbo].[UserInfo] ([UserInfoId])
GO
ALTER TABLE [dbo].[CommentLike] CHECK CONSTRAINT [FK_CommentLike_UserInfo1]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department]
GO
ALTER TABLE [dbo].[CourseGrade]  WITH CHECK ADD  CONSTRAINT [FK_CourseGrade_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[CourseGrade] CHECK CONSTRAINT [FK_CourseGrade_Course]
GO
ALTER TABLE [dbo].[CourseGrade]  WITH CHECK ADD  CONSTRAINT [FK_CourseGrade_UserInfo1] FOREIGN KEY([UserInfoId])
REFERENCES [dbo].[UserInfo] ([UserInfoId])
GO
ALTER TABLE [dbo].[CourseGrade] CHECK CONSTRAINT [FK_CourseGrade_UserInfo1]
GO
ALTER TABLE [dbo].[Level]  WITH CHECK ADD  CONSTRAINT [FK_Level_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Level] CHECK CONSTRAINT [FK_Level_Course]
GO
ALTER TABLE [dbo].[LevelExam]  WITH CHECK ADD  CONSTRAINT [FK_LevelExam_Level] FOREIGN KEY([LevelId])
REFERENCES [dbo].[Level] ([LevelId])
GO
ALTER TABLE [dbo].[LevelExam] CHECK CONSTRAINT [FK_LevelExam_Level]
GO
ALTER TABLE [dbo].[LevelExamAnswer]  WITH CHECK ADD  CONSTRAINT [FK_LevelExamAnswer_LevelExamQuestion] FOREIGN KEY([LevelExamQuestionId])
REFERENCES [dbo].[LevelExamQuestion] ([LevelExamQuestionId])
GO
ALTER TABLE [dbo].[LevelExamAnswer] CHECK CONSTRAINT [FK_LevelExamAnswer_LevelExamQuestion]
GO
ALTER TABLE [dbo].[LevelExamQuestion]  WITH CHECK ADD  CONSTRAINT [FK_LevelExamQuestion_LevelExam] FOREIGN KEY([LevelExamId])
REFERENCES [dbo].[LevelExam] ([LevelExamId])
GO
ALTER TABLE [dbo].[LevelExamQuestion] CHECK CONSTRAINT [FK_LevelExamQuestion_LevelExam]
GO
ALTER TABLE [dbo].[LevelExamResult]  WITH CHECK ADD  CONSTRAINT [FK_LevelExamResult_LevelExam] FOREIGN KEY([LevelExamId])
REFERENCES [dbo].[LevelExam] ([LevelExamId])
GO
ALTER TABLE [dbo].[LevelExamResult] CHECK CONSTRAINT [FK_LevelExamResult_LevelExam]
GO
ALTER TABLE [dbo].[LevelExamResult]  WITH CHECK ADD  CONSTRAINT [FK_LevelExamResult_UserInfo1] FOREIGN KEY([UserInfoId])
REFERENCES [dbo].[UserInfo] ([UserInfoId])
GO
ALTER TABLE [dbo].[LevelExamResult] CHECK CONSTRAINT [FK_LevelExamResult_UserInfo1]
GO
ALTER TABLE [dbo].[LevelMaterial]  WITH CHECK ADD  CONSTRAINT [FK_LevelMaterial_ContentType] FOREIGN KEY([ContentTypeId])
REFERENCES [dbo].[ContentType] ([ContentTypeId])
GO
ALTER TABLE [dbo].[LevelMaterial] CHECK CONSTRAINT [FK_LevelMaterial_ContentType]
GO
ALTER TABLE [dbo].[LevelMaterial]  WITH CHECK ADD  CONSTRAINT [FK_LevelMaterial_Level] FOREIGN KEY([LevelId])
REFERENCES [dbo].[Level] ([LevelId])
GO
ALTER TABLE [dbo].[LevelMaterial] CHECK CONSTRAINT [FK_LevelMaterial_Level]
GO
ALTER TABLE [dbo].[LevelProject]  WITH CHECK ADD  CONSTRAINT [FK_LevelProject_Level] FOREIGN KEY([LevelId])
REFERENCES [dbo].[Level] ([LevelId])
GO
ALTER TABLE [dbo].[LevelProject] CHECK CONSTRAINT [FK_LevelProject_Level]
GO
ALTER TABLE [dbo].[LevelProjectResult]  WITH CHECK ADD  CONSTRAINT [FK_LevelProjectResult_LevelProject] FOREIGN KEY([LevelProjectId])
REFERENCES [dbo].[LevelProject] ([LevelProjectId])
GO
ALTER TABLE [dbo].[LevelProjectResult] CHECK CONSTRAINT [FK_LevelProjectResult_LevelProject]
GO
ALTER TABLE [dbo].[LevelProjectResult]  WITH CHECK ADD  CONSTRAINT [FK_LevelProjectResult_UserInfo1] FOREIGN KEY([UserInfoId])
REFERENCES [dbo].[UserInfo] ([UserInfoId])
GO
ALTER TABLE [dbo].[LevelProjectResult] CHECK CONSTRAINT [FK_LevelProjectResult_UserInfo1]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_UserInfo1] FOREIGN KEY([UserInfoId])
REFERENCES [dbo].[UserInfo] ([UserInfoId])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_UserInfo1]
GO
ALTER TABLE [dbo].[Points]  WITH CHECK ADD  CONSTRAINT [FK_Points_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[Points] CHECK CONSTRAINT [FK_Points_Course]
GO
ALTER TABLE [dbo].[Points]  WITH CHECK ADD  CONSTRAINT [FK_Points_Level] FOREIGN KEY([LevelId])
REFERENCES [dbo].[Level] ([LevelId])
GO
ALTER TABLE [dbo].[Points] CHECK CONSTRAINT [FK_Points_Level]
GO
ALTER TABLE [dbo].[Points]  WITH CHECK ADD  CONSTRAINT [FK_Points_UserInfo1] FOREIGN KEY([UserInfoId])
REFERENCES [dbo].[UserInfo] ([UserInfoId])
GO
ALTER TABLE [dbo].[Points] CHECK CONSTRAINT [FK_Points_UserInfo1]
GO
ALTER TABLE [dbo].[UserCourse]  WITH CHECK ADD  CONSTRAINT [FK_UserCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[UserCourse] CHECK CONSTRAINT [FK_UserCourse_Course]
GO
ALTER TABLE [dbo].[UserCourse]  WITH CHECK ADD  CONSTRAINT [FK_UserCourse_UserInfo1] FOREIGN KEY([UserInfoId])
REFERENCES [dbo].[UserInfo] ([UserInfoId])
GO
ALTER TABLE [dbo].[UserCourse] CHECK CONSTRAINT [FK_UserCourse_UserInfo1]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_User_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_User_Department]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_User_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_User_Status]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[UserType] ([UserTypeID])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_User_UserType]
GO
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_UserInfo_UserLog] FOREIGN KEY([UserInfoId])
REFERENCES [dbo].[UserLog] ([UserLogId])
GO
ALTER TABLE [dbo].[UserInfo] CHECK CONSTRAINT [FK_UserInfo_UserLog]
GO


CREATE UNIQUE NONCLUSTERED INDEX IX_UserInfo_Username ON dbo.UserInfo
	(
	Username
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX IX_UserInfo_Email ON dbo.UserInfo
	(
	Email
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO