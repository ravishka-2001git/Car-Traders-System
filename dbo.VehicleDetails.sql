CREATE TABLE [dbo].[VehicleDetails] (
    [ID]             VARCHAR (10)    NULL,
    [Brand]          VARCHAR (100)   NOT NULL,
    [Model]          VARCHAR (100)   NOT NULL,
    [Year]           INT             NOT NULL,
    [Price]          DECIMAL (10, 2) NOT NULL,
    [Color]          VARCHAR (50)    NOT NULL,
    [EnergyCapacity] VARCHAR(50) NOT NULL,
    [Status]         VARCHAR (20)    NOT NULL,
    [MileageKmh]     INT             NULL,
    [Stokes]         INT             NULL,
    [Transmission]   VARCHAR (50)    NOT NULL,
    [Fuel]           VARCHAR (50)    NOT NULL,
    [VehicleImage]   VARBINARY (MAX) NULL,
    [Description]    VARCHAR (500)   NULL
);


GO
CREATE TRIGGER trg_VehicleID
ON VehicleDetails
AFTER INSERT
AS
BEGIN
    DECLARE @NextID INT;
    DECLARE @Prefix NVARCHAR(1) = 'V';

    SELECT @NextID = ISNULL(MAX(CAST(SUBSTRING(ID, 2, LEN(ID)) AS INT)), 0) + 1
    FROM VehicleDetails;

    UPDATE VehicleDetails
    SET ID = @Prefix + RIGHT('000' + CAST(@NextID AS VARCHAR(3)), 3)
    WHERE ID IS NULL;
END