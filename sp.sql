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
CREATE PROCEDURE spUpdateMedicine
    @MedicineID int,
    @MedicineName varchar(255),
    @ExpirationDate date,
    @QuantityOnStock int,
    @Prescription varchar(255),
    @Unit varchar(50),
    @Price int,
    @Description text
AS
BEGIN
    UPDATE Medicine
    SET MedicineName = @MedicineName,
        ExpirationDate = @ExpirationDate,
        QuantityOnStock = @QuantityOnStock,
        Prescription = @Prescription,
        Unit = @Unit,
        Price = @Price,
        Description = @Description
    WHERE MedicineID = @MedicineID
END

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
