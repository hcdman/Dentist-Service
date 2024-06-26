USE [DentalClinicManagement]
GO
/****** Object:  StoredProcedure [dbo].[SP_ReadAppointmentsOfCustomerUncommitted]    Script Date: 15/01/2024 6:18:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--read appointment by dentist id and date
ALTER PROCEDURE [dbo].[SP_ReadAppointmentsOfCustomerUncommitted]
    @CustomerID INT
AS
BEGIN
    BEGIN TRANSACTION;
	SET TRAN ISOLATION LEVEL READ UNCOMMITTED
    BEGIN TRY
        SELECT
			AppointmentID,
            AppointmentDate,
            StartTime,
            EndTime,
            CustomerID,
            DentistId
        FROM
            appointment
        WHERE
            CustomerID = @CustomerID

        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK;

        THROW;
    END CATCH;
END;

