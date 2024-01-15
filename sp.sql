--
CREATE PROCEDURE DeleteRecordByRoleAndID
    @UserRole VARCHAR(50),
    @RecordID INT
AS
BEGIN
    IF @UserRole = 'Dentist'
    BEGIN
        DELETE FROM [dbo].[Dentist] WHERE DentistID = @RecordID;
    END
    ELSE IF @UserRole = 'Customer'
    BEGIN
        DELETE FROM [dbo].[Customer] WHERE CustomerID = @RecordID;
    END
    ELSE IF @UserRole = 'Employee'
    BEGIN
        DELETE FROM [dbo].[Employee] WHERE EmployeeID = @RecordID;
    END
    ELSE
    BEGIN
        PRINT 'Vai trò không hợp lệ.';
    END
END

--
CREATE PROCEDURE SelectUserRoleInformation
    @UserRole VARCHAR(50)
AS
BEGIN
    IF @UserRole = 'Dentist'
    BEGIN
        SELECT * FROM [dbo].[Dentist];
    END
    ELSE IF @UserRole = 'Customer'
    BEGIN
        SELECT * FROM [dbo].[Customer];
    END
    ELSE IF @UserRole = 'Employee'
    BEGIN
        SELECT * FROM [dbo].[Employee];
    END
    ELSE
    BEGIN
        -- Nếu Role không hợp lệ, có thể xử lý thêm tùy ý
        PRINT 'Vai trò không hợp lệ.';
    END
END

-- Thêm Thuốc Mới
CREATE PROCEDURE spAddMedicine
    @MedicineName varchar(255),
    @ExpirationDate date,
    @QuantityOnStock int,
    @Prescription varchar(255),
    @Unit varchar(50),
    @Price int,
    @Description text
AS
BEGIN
    -- Kiểm tra tính hợp lệ của tên thuốc
    IF LEN(@MedicineName) = 0 OR @MedicineName IS NULL
        THROW 50001, 'The medicine name is required and cannot be empty.', 1;

    -- Kiểm tra ngày hết hạn
    IF @ExpirationDate IS NULL OR @ExpirationDate < GETDATE()
        THROW 50002, 'The expiration date is invalid or has already passed.', 1;

    -- Kiểm tra số lượng tồn kho
    IF @QuantityOnStock IS NULL OR @QuantityOnStock < 0
        THROW 50003, 'The quantity on stock must be a non-negative number.', 1;

    -- Kiểm tra đơn vị
    IF LEN(@Unit) = 0 OR @Unit IS NULL
        THROW 50004, 'The unit is required and cannot be empty.', 1;

    -- Kiểm tra giá
    IF @Price IS NULL OR @Price < 0
        THROW 50005, 'The price must be a non-negative number.', 1;

    INSERT INTO Medicine 
        (MedicineName, ExpirationDate, QuantityOnStock, Prescription, Unit, Price, Description)
    VALUES 
        (@MedicineName, @ExpirationDate, @QuantityOnStock, @Prescription, @Unit, @Price, @Description)
END



-- Cập Nhật Thuốc
USE [DentalClinicManagement]
GO

CREATE PROCEDURE [dbo].[spUpdateMedicine]
    @MedicineID int,
    @ExpirationDate date,
    @QuantityOnStock int,
    @Prescription varchar(255),
    @Unit varchar(50),
    @MedicineName varchar(255),
    @Price int,
    @Description text
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF NOT EXISTS (SELECT 1 FROM [dbo].[Medicine] WHERE [MedicineID] = @MedicineID)
        BEGIN
            RAISERROR('No medicine found with the specified ID.', 16, 1);
            RETURN;
        END

        UPDATE [dbo].[Medicine]
        SET 
            [ExpirationDate] = @ExpirationDate,
            [QuantityOnStock] = @QuantityOnStock,
            [Prescription] = @Prescription,
            [Unit] = @Unit,
            [MedicineName] = @MedicineName,
            [Price] = @Price,
            [Description] = @Description
        WHERE [MedicineID] = @MedicineID;
    END TRY
    BEGIN CATCH
        -- Handle any errors that occur during the update
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO


-- Xóa Thuốc Hết Hạn
CREATE PROCEDURE spAllDeleteExpiredMedicine
AS
BEGIN
    DELETE FROM Medicine
    WHERE ExpirationDate < GETDATE()
END

-- 
CREATE PROCEDURE spGetAllMedicines
AS
BEGIN
    SELECT * FROM Medicine
END

-- 
CREATE PROCEDURE spGetExpiredMedicines
AS
BEGIN
    SELECT * FROM Medicine
    WHERE ExpirationDate < GETDATE()
END

--
CREATE PROCEDURE spDeleteMedicine
    @MedicineID int
AS
BEGIN
    DELETE FROM Medicine
    WHERE MedicineID = @MedicineID
END

--

CREATE PROCEDURE GetMedicineById
    @MedicineID int
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF EXISTS (SELECT 1 FROM Medicine WHERE MedicineID = @MedicineID)
        BEGIN
            SELECT * FROM Medicine WHERE MedicineID = @MedicineID;
        END
        ELSE
        BEGIN
            RAISERROR('No medicine found with the specified ID.', 16, 1);
        END
    END TRY
    BEGIN CATCH
        -- Handle any errors that occur
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO

--- Tình huống 1
---- sp 1
CREATE PROCEDURE sp_ReadAppointments
    @DentistID int
AS
BEGIN
    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;
        BEGIN TRANSACTION;

        -- Đọc danh sách lịch hẹn
        SELECT * 
		FROM Appointment
		WHERE DentistID = @DentistID 
		AND AppointmentDate = CONVERT(date, GETDATE());

        WAITFOR DELAY '00:00:10'; -- Chờ 10 giây

        -- Đọc lại danh sách lịch hẹn
        SELECT * 
		FROM Appointment
		WHERE DentistID = @DentistID 
		AND AppointmentDate = CONVERT(date, GETDATE());

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END
GO

--- sp2

ALTER PROCEDURE sp_AddAppointment
    @DentistID int,
    @CustomerID int,
    @AppointmentDate date,
    @StartTime time,
    @EndTime time
AS
BEGIN
    BEGIN TRY
        SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
        BEGIN TRANSACTION;

        -- Thêm lịch hẹn mới
		INSERT INTO Appointment (AppointmentDate, StartTime, EndTime, DentistID, CustomerID, Status)
		VALUES (@AppointmentDate, @StartTime, @EndTime, @DentistID, @CustomerID, 'Pending');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END
GO
 
-- Tình huống 2
-- sp 1
CREATE PROCEDURE sp_SelectMedicineQuantity
AS
BEGIN
    SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Lần truy vấn thứ nhất
        SELECT MedicineName, QuantityOnStock FROM Medicine;

        -- Khoảng thời gian chờ (ví dụ: 5 giây)
        WAITFOR DELAY '00:00:15';

        -- Lần truy vấn thứ hai
        SELECT MedicineName, QuantityOnStock FROM Medicine;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO

EXEC sp_SelectMedicineQuantity

-- sp 2
ALTER PROCEDURE sp_AddMedicine
    @MedicineName varchar(255),
    @ExpirationDate date,
    @QuantityOnStock int,
    @Prescription varchar(255),
    @Unit varchar(50),
    @Price int,
    @Description text
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Kiểm tra tính hợp lệ của tên thuốc
        IF LEN(@MedicineName) = 0 OR @MedicineName IS NULL
            THROW 50001, 'The medicine name is required and cannot be empty.', 1;

        -- Kiểm tra ngày hết hạn
        IF @ExpirationDate IS NULL OR @ExpirationDate < GETDATE()
            THROW 50002, 'The expiration date is invalid or has already passed.', 1;

        -- Kiểm tra số lượng tồn kho
        IF @QuantityOnStock IS NULL OR @QuantityOnStock < 0
            THROW 50003, 'The quantity on stock must be a non-negative number.', 1;

        -- Kiểm tra đơn vị
        IF LEN(@Unit) = 0 OR @Unit IS NULL
            THROW 50004, 'The unit is required and cannot be empty.', 1;

        -- Kiểm tra giá
        IF @Price IS NULL OR @Price < 0
            THROW 50005, 'The price must be a non-negative number.', 1;

        -- Thực hiện thêm thuốc vào cơ sở dữ liệu
        INSERT INTO Medicine 
            (MedicineName, ExpirationDate, QuantityOnStock, Prescription, Unit, Price, Description)
        VALUES 
            (@MedicineName, @ExpirationDate, @QuantityOnStock, @Prescription, @Unit, @Price, @Description);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
        DECLARE @ErrorState INT = ERROR_STATE();

        THROW @ErrorSeverity, @ErrorMessage, @ErrorState;
    END CATCH
END
GO


EXEC sp_AddMedicine
    @MedicineName = 'Paracetamol',
    @ExpirationDate = '2021-12-31',
    @QuantityOnStock = 100,
    @Prescription = 'Take 1 tablet every 6 hours',
    @Unit = 'Tablet',
    @Price = 1000,
    @Description = 'Paracetamol is a painkiller.'
