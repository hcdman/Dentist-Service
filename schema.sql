USE [DentalClinicManagement]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[AdminID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[AdminPassword] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[AppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[AppointmentDate] [date] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[CustomerID] [int] NULL,
	[DentistID] [int] NULL,
	[CreatedByDentist] [bit] NULL,
	[Status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](255) NULL,
	[CustomerAddress] [varchar](255) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Birthday] [date] NULL,
	[CustomerPassword] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DentalService]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DentalService](
	[DentalServiceID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceName] [varchar](255) NULL,
	[Price] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DentalServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dentist]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dentist](
	[DentistID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](255) NULL,
	[DentistAddress] [varchar](255) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[BirthDay] [date] NULL,
	[DentistPassword] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DentistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DentistSchedule]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DentistSchedule](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[DentistID] [int] NULL,
	[WorkingDay] [date] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](255) NULL,
	[EmployeeAddress] [varchar](255) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[Birthday] [date] NULL,
	[EmployeePassword] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[PhoneNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[MedicalRecord] [int] NULL,
	[EmployeeID] [int] NULL,
	[PayState] [bit] NULL,
	[PayDate] [date] NULL,
	[TotalCost] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalRecord]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalRecord](
	[MRecordID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NULL,
	[DentistID] [int] NULL,
	[MedicalRecordDate] [date] NULL,
	[Description] [text] NULL,
	[ExaminationFee] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MRecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalRecord_DentalService]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalRecord_DentalService](
	[MRecordID] [int] NOT NULL,
	[DentalServiceID] [int] NOT NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_MRDS] PRIMARY KEY CLUSTERED 
(
	[MRecordID] ASC,
	[DentalServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicalRecord_Medicine]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicalRecord_Medicine](
	[MRecordID] [int] NOT NULL,
	[MedicineID] [int] NOT NULL,
	[Price] [int] NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_MRM] PRIMARY KEY CLUSTERED 
(
	[MRecordID] ASC,
	[MedicineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicine]    Script Date: 12/21/2023 1:00:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicine](
	[MedicineID] [int] IDENTITY(1,1) NOT NULL,
	[ExpirationDate] [date] NULL,
	[QuantityOnStock] [int] NULL,
	[Prescription] [varchar](255) NULL,
	[Unit] [varchar](50) NULL,
	[MedicineName] [varchar](255) NULL,
	[Price] [int] NULL,
	[Description] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[MedicineID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD FOREIGN KEY([DentistID])
REFERENCES [dbo].[Dentist] ([DentistID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DentistSchedule]  WITH CHECK ADD FOREIGN KEY([DentistID])
REFERENCES [dbo].[Dentist] ([DentistID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([MedicalRecord])
REFERENCES [dbo].[MedicalRecord] ([MRecordID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalRecord]  WITH CHECK ADD FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([CustomerID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalRecord]  WITH CHECK ADD FOREIGN KEY([DentistID])
REFERENCES [dbo].[Dentist] ([DentistID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalRecord_DentalService]  WITH CHECK ADD FOREIGN KEY([DentalServiceID])
REFERENCES [dbo].[DentalService] ([DentalServiceID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalRecord_DentalService]  WITH CHECK ADD FOREIGN KEY([MRecordID])
REFERENCES [dbo].[MedicalRecord] ([MRecordID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalRecord_Medicine]  WITH CHECK ADD FOREIGN KEY([MedicineID])
REFERENCES [dbo].[Medicine] ([MedicineID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MedicalRecord_Medicine]  WITH CHECK ADD FOREIGN KEY([MRecordID])
REFERENCES [dbo].[MedicalRecord] ([MRecordID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Administrator]  WITH CHECK ADD CHECK  ((len([AdminPassword])>=(8)))
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD CHECK  (([Status]='Completed' OR [Status]='Cancelled' OR [Status]='Pending'))
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD CHECK  ((len([CustomerPassword])>=(8)))
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD CHECK  ((len([PhoneNumber])=(10)))
GO
ALTER TABLE [dbo].[DentalService]  WITH CHECK ADD CHECK  (([Price]>=(0)))
GO
ALTER TABLE [dbo].[Dentist]  WITH CHECK ADD CHECK  ((len([DentistPassword])>=(8)))
GO
ALTER TABLE [dbo].[Dentist]  WITH CHECK ADD CHECK  ((len([PhoneNumber])=(10)))
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD CHECK  ((len([EmployeePassword])>=(8)))
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD CHECK  ((len([PhoneNumber])=(10)))
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD CHECK  (([TotalCost]>=(0)))
GO
ALTER TABLE [dbo].[MedicalRecord]  WITH CHECK ADD CHECK  (([ExaminationFee]>=(0)))
GO
ALTER TABLE [dbo].[MedicalRecord_DentalService]  WITH CHECK ADD CHECK  (([Price]>=(0)))
GO
ALTER TABLE [dbo].[MedicalRecord_Medicine]  WITH CHECK ADD CHECK  (([Price]>=(0)))
GO
ALTER TABLE [dbo].[MedicalRecord_Medicine]  WITH CHECK ADD CHECK  (([Quantity]>=(0)))
GO
ALTER TABLE [dbo].[Medicine]  WITH CHECK ADD CHECK  (([Price]>=(0)))
GO
ALTER TABLE [dbo].[Medicine]  WITH CHECK ADD CHECK  (([QuantityOnStock]>=(0)))
GO
