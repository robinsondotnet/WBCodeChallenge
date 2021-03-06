USE [master]
GO

CREATE DATABASE [Wonderbox]
GO

USE [Wonderbox]
GO


CREATE TABLE [dbo].[Course](
	[CourseID] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Credits] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseInstructor]    Script Date: 27/03/2018 5:28:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseInstructor](
	[CourseID] [int] NOT NULL,
	[InstructorID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.CourseInstructor] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[InstructorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 27/03/2018 5:28:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Budget] [money] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[InstructorID] [int] NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_dbo.Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 27/03/2018 5:28:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NOT NULL,
	[StudentID] [int] NOT NULL,
	[Grade] [int] NULL,
 CONSTRAINT [PK_dbo.Enrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OfficeAssignment]    Script Date: 27/03/2018 5:28:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OfficeAssignment](
	[InstructorID] [int] NOT NULL,
	[Location] [nvarchar](50) NULL,
 CONSTRAINT [PK_dbo.OfficeAssignment] PRIMARY KEY CLUSTERED 
(
	[InstructorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 27/03/2018 5:28:22 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[HireDate] [datetime] NULL,
	[EnrollmentDate] [datetime] NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Person] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (1045, N'Calculus', 4, 3)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (1050, N'Chemistry', 3, 4)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (2021, N'Composition', 3, 2)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (2042, N'Literature', 4, 2)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (3141, N'Trigonometry', 4, 3)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (4022, N'Microeconomics', 3, 5)
GO
INSERT [dbo].[Course] ([CourseID], [Title], [Credits], [DepartmentID]) VALUES (4041, N'Macroeconomics', 3, 5)
GO
INSERT [dbo].[CourseInstructor] ([CourseID], [InstructorID]) VALUES (2021, 9)
GO
INSERT [dbo].[CourseInstructor] ([CourseID], [InstructorID]) VALUES (2042, 9)
GO
INSERT [dbo].[CourseInstructor] ([CourseID], [InstructorID]) VALUES (1045, 10)
GO
INSERT [dbo].[CourseInstructor] ([CourseID], [InstructorID]) VALUES (1050, 11)
GO
INSERT [dbo].[CourseInstructor] ([CourseID], [InstructorID]) VALUES (3141, 11)
GO
INSERT [dbo].[CourseInstructor] ([CourseID], [InstructorID]) VALUES (1050, 12)
GO
INSERT [dbo].[CourseInstructor] ([CourseID], [InstructorID]) VALUES (4022, 13)
GO
INSERT [dbo].[CourseInstructor] ([CourseID], [InstructorID]) VALUES (4041, 13)
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([DepartmentID], [Name], [Budget], [StartDate], [InstructorID]) VALUES (1, N'Temp', 0.0000, CAST(N'2018-03-27T17:22:03.540' AS DateTime), NULL)
GO
INSERT [dbo].[Department] ([DepartmentID], [Name], [Budget], [StartDate], [InstructorID]) VALUES (2, N'English', 350000.0000, CAST(N'2007-09-01T00:00:00.000' AS DateTime), 9)
GO
INSERT [dbo].[Department] ([DepartmentID], [Name], [Budget], [StartDate], [InstructorID]) VALUES (3, N'Mathematics', 100000.0000, CAST(N'2007-09-01T00:00:00.000' AS DateTime), 10)
GO
INSERT [dbo].[Department] ([DepartmentID], [Name], [Budget], [StartDate], [InstructorID]) VALUES (4, N'Engineering', 350000.0000, CAST(N'2007-09-01T00:00:00.000' AS DateTime), 11)
GO
INSERT [dbo].[Department] ([DepartmentID], [Name], [Budget], [StartDate], [InstructorID]) VALUES (5, N'Economics', 100000.0000, CAST(N'2007-09-01T00:00:00.000' AS DateTime), 12)
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Enrollment] ON 
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (1, 1050, 1, 0)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (2, 4022, 1, 2)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (3, 4041, 1, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (4, 1045, 2, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (5, 3141, 2, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (6, 2021, 2, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (7, 1050, 3, NULL)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (8, 4022, 3, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (9, 1050, 4, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (10, 2021, 5, 1)
GO
INSERT [dbo].[Enrollment] ([EnrollmentID], [CourseID], [StudentID], [Grade]) VALUES (11, 2042, 6, 1)
GO
SET IDENTITY_INSERT [dbo].[Enrollment] OFF
GO
INSERT [dbo].[OfficeAssignment] ([InstructorID], [Location]) VALUES (10, N'Smith 17')
GO
INSERT [dbo].[OfficeAssignment] ([InstructorID], [Location]) VALUES (11, N'Gowan 27')
GO
INSERT [dbo].[OfficeAssignment] ([InstructorID], [Location]) VALUES (12, N'Thompson 304')
GO
SET IDENTITY_INSERT [dbo].[Person] ON 
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (1, N'Alexander', N'Carson', NULL, CAST(N'2010-09-01T00:00:00.000' AS DateTime), N'Student')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (2, N'Alonso', N'Meredith', NULL, CAST(N'2012-09-01T00:00:00.000' AS DateTime), N'Student')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (3, N'Anand', N'Arturo', NULL, CAST(N'2013-09-01T00:00:00.000' AS DateTime), N'Student')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (4, N'Barzdukas', N'Gytis', NULL, CAST(N'2012-09-01T00:00:00.000' AS DateTime), N'Student')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (5, N'Li', N'Yan', NULL, CAST(N'2012-09-01T00:00:00.000' AS DateTime), N'Student')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (6, N'Justice', N'Peggy', NULL, CAST(N'2011-09-01T00:00:00.000' AS DateTime), N'Student')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (7, N'Norman', N'Laura', NULL, CAST(N'2013-09-01T00:00:00.000' AS DateTime), N'Student')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (8, N'Olivetto', N'Nino', NULL, CAST(N'2005-09-01T00:00:00.000' AS DateTime), N'Student')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (9, N'Abercrombie', N'Kim', CAST(N'1995-03-11T00:00:00.000' AS DateTime), NULL, N'Instructor')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (10, N'Fakhouri', N'Fadi', CAST(N'2002-07-06T00:00:00.000' AS DateTime), NULL, N'Instructor')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (11, N'Harui', N'Roger', CAST(N'1998-07-01T00:00:00.000' AS DateTime), NULL, N'Instructor')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (12, N'Kapoor', N'Candace', CAST(N'2001-01-15T00:00:00.000' AS DateTime), NULL, N'Instructor')
GO
INSERT [dbo].[Person] ([ID], [LastName], [FirstName], [HireDate], [EnrollmentDate], [Discriminator]) VALUES (13, N'Zheng', N'Roger', CAST(N'2004-02-12T00:00:00.000' AS DateTime), NULL, N'Instructor')
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
ALTER TABLE [dbo].[Course] ADD  DEFAULT ((1)) FOR [DepartmentID]
GO
ALTER TABLE [dbo].[Person] ADD  DEFAULT ('Instructor') FOR [Discriminator]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Course_dbo.Department_DepartmentID] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_dbo.Course_dbo.Department_DepartmentID]
GO
ALTER TABLE [dbo].[CourseInstructor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CourseInstructor_dbo.Course_CourseID] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseInstructor] CHECK CONSTRAINT [FK_dbo.CourseInstructor_dbo.Course_CourseID]
GO
ALTER TABLE [dbo].[CourseInstructor]  WITH CHECK ADD  CONSTRAINT [FK_dbo.CourseInstructor_dbo.Instructor_InstructorID] FOREIGN KEY([InstructorID])
REFERENCES [dbo].[Person] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseInstructor] CHECK CONSTRAINT [FK_dbo.CourseInstructor_dbo.Instructor_InstructorID]
GO
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Department_dbo.Instructor_InstructorID] FOREIGN KEY([InstructorID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_dbo.Department_dbo.Instructor_InstructorID]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enrollment_dbo.Course_CourseID] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_dbo.Enrollment_dbo.Course_CourseID]
GO
ALTER TABLE [dbo].[Enrollment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Enrollment_dbo.Person_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Person] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Enrollment] CHECK CONSTRAINT [FK_dbo.Enrollment_dbo.Person_StudentID]
GO
ALTER TABLE [dbo].[OfficeAssignment]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID] FOREIGN KEY([InstructorID])
REFERENCES [dbo].[Person] ([ID])
GO
ALTER TABLE [dbo].[OfficeAssignment] CHECK CONSTRAINT [FK_dbo.OfficeAssignment_dbo.Instructor_InstructorID]
GO
