USE [DentalClinicManagement]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateAppointment]    Script Date: 15/01/2024 6:20:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--create an appointment
ALTER   PROC [dbo].[SP_CreateAppointment]
    @AppointmentDate DATE,
    @StartTime TIME,
    @EndTime TIME,
    @CustomerID INT,
    @DentistID INT
AS 
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        INSERT INTO Appointment (AppointmentDate, StartTime, EndTime, CustomerID, DentistID, CreatedByDentist, Status)
        VALUES (@AppointmentDate, @StartTime, @EndTime, @CustomerID, @DentistID, 0, 'Pending')

        COMMIT TRANSACTION
    END TRY 
    BEGIN CATCH
        IF @@TRANCOUNT > 0
		BEGIN
			WAITFOR DELAY '00:00:10';
            ROLLBACK;
		END;
        THROW
    END CATCH
END

