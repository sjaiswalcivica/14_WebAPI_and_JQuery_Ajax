
CREATE TABLE [dbo].[Department](
	[PKDeptId] [int] IDENTITY(1,1) NOT NULL,
	[DeptName] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PKDeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 6/11/2018 12:27:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[PKEmpId] [int] IDENTITY(1,1) NOT NULL,
	[EmpName] [varchar](50) NOT NULL,
	[Salary] [money] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[FKDeptId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[PKEmpId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 
GO
INSERT [dbo].[Department] ([PKDeptId], [DeptName], [IsActive]) VALUES (1, N'Finance', 1)
GO
INSERT [dbo].[Department] ([PKDeptId], [DeptName], [IsActive]) VALUES (2, N'Sales', 1)
GO
INSERT [dbo].[Department] ([PKDeptId], [DeptName], [IsActive]) VALUES (3, N'Support', 1)
GO
INSERT [dbo].[Department] ([PKDeptId], [DeptName], [IsActive]) VALUES (4, N'Marketing', 0)
GO
INSERT [dbo].[Department] ([PKDeptId], [DeptName], [IsActive]) VALUES (5, N'Research', 1)
GO
INSERT [dbo].[Department] ([PKDeptId], [DeptName], [IsActive]) VALUES (6, N'Development', 1)
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([PKEmpId], [EmpName], [Salary], [IsActive], [FKDeptId]) VALUES (1, N'sid1', 21000.0000, 0, 1)
GO
INSERT [dbo].[Employee] ([PKEmpId], [EmpName], [Salary], [IsActive], [FKDeptId]) VALUES (2, N'Ashish1', 100.0000, 1, 2)
GO
INSERT [dbo].[Employee] ([PKEmpId], [EmpName], [Salary], [IsActive], [FKDeptId]) VALUES (3, N'sanjay', 1000.0000, 1, 4)
GO
INSERT [dbo].[Employee] ([PKEmpId], [EmpName], [Salary], [IsActive], [FKDeptId]) VALUES (1002, N'sid2', 21000.0000, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Department] FOREIGN KEY([FKDeptId])
REFERENCES [dbo].[Department] ([PKDeptId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Department]
GO
USE [master]
GO
ALTER DATABASE [Organization] SET  READ_WRITE 
GO
