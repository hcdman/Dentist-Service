USE [DentalClinicManagement]
GO
/****** Object:  StoredProcedure [dbo].[SP_ReadAppointmentsOfCustomerCommitted]    Script Date: 15/01/2024 6:16:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--read appointment by dentist id and date
ALTER PROCEDURE [dbo].[SP_ReadAppointmentsOfCustomerCommitted]
     @CustomerID INT
AS
BEGIN
    BEGIN TRANSACTION;
	--SET TRAN ISOLATION LEVEL READ COMMITTED		--this is default
    BEGIN TRY
        SELECT
			AppointmentId,
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



