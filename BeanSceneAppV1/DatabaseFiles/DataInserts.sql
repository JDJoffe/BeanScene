--aspnet-BeanSceneAppV1-9C630276-3EA6-4CA3-964E-C2E60D7E37A4
INSERT INTO [Area] (Name)VALUES
('Main'),
('Balcony'),
('Outside')

GO

INSERT INTO [Table] (Table_Name,Table_Seats,AreaId)VALUES
('M1',4,1),
('M2',4,1),
('M3',4,1),
('M4',4,1),
('M5',4,1),
('M6',4,1),
('M7',4,1),
('M8',4,1),
('M9',4,1),
('M10',4,1),
('B1',4,2),
('B2',4,2),
('B3',4,2),
('B4',4,2),
('B5',4,2),
('B6',4,2),
('B7',4,2),
('B8',4,2),
('B9',4,2),
('B10',4,2),
('O1',4,3),
('O2',4,3),
('O3',4,3),
('O4',4,3),
('O5',4,3),
('O6',4,3),
('O7',4,3),
('O8',4,3),
('O9',4,3),
('O10',4,3)

GO

INSERT INTO [TimeSlot] (Time)VALUES
('01:00:00'),
('02:00:00'),
('03:00:00'),
('04:00:00'),
('05:00:00'),
('06:00:00'),
('07:00:00'),
('08:00:00'),
('09:00:00'),
('10:00:00'),
('11:00:00'),
('12:00:00'),
('13:00:00'),
('14:00:00'),
('15:00:00'),
('16:00:00'),
('17:00:00'),
('18:00:00'),
('19:00:00'),
('20:00:00'),
('21:00:00'),
('22:00:00'),
('23:00:00'),
('00:00:00')

GO

INSERT INTO [Sitting] (Sitting_Type, Capacity, Guest_Total, Tables_Available, Start_Date, End_Date, Start_Time, End_Time) VALUES
(0,120,16,26,'2022-10-01','2022-12-31','09:00:00','10:59:00'),
(0,120,0,30,'2023-01-01','2023-03-31','08:00:00','10:59:00'),
(1,120,16,26,'2022-10-01','2022-12-31','11:00:00','15:59:00'),
(1,120,0,30,'2023-01-01','2023-03-31','11:00:00','15:59:00'),
(2,120,16,26,'2022-10-01','2022-12-31','16:00:00','19:59:00'),
(2,120,0,30,'2023-01-01','2023-03-31','16:00:00','19:59:00')

GO


SET DATEFORMAT DMY
INSERT INTO Reservation ([Date], TimeSlotId,SittingId, GuestAmount, FirstName, LastName, Phone, Email, SeatingRequest, [Status] ) VALUES
('2022-11-24',9,1,6,'Allen','Bates','04100','Allen@Gmail.com','Main By the window',4),
('2022-11-24',12,3,12,'Joe','Taylor','04100','Joe@Gmail.com','Balcony',4),
('2022-11-24',12,3,4,'Gary','Faulkner','04100','GaryFaulkner1@Gmail.com','Outside',4)

GO

INSERT INTO TableReservation (TableId,ReservationId) VALUES
(1,1),(2,1),
(11,2),(12,2),(13,2),
(21,3),(22,3),(23,3)


GO

INSERT INTO TableAvailability (TableId, [Date], TimeSlotId) VALUES
(1,'2022-11-24',9 ),
(2,'2022-11-24',9 ),
(11,'2022-11-24',12 ),
(12,'2022-11-24',12 ),
(13,'2022-11-24',12 ),
(21,'2022-11-24',12 ),
(22,'2022-11-24',12 ),
(23,'2022-11-24',12 )

GO
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE USP_GetTime
	-- Add the parameters for the stored procedure here
	@TimeSlotId int,
	@TimeResult TIME(7) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
    -- Insert statements for procedure here
	SELECT @TimeResult =(
	SELECT [Time] 
	FROM TIMESLOT t
    WHERE @TimeSlotId = t.Id
	)
END
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE  USP_AssignSitting
	-- Add the parameters for the stored procedure here
	@TimeSlotId int ,
	@Date date
	 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Time TIME(7) 
	DECLARE @TimeResult TIME(7)
	
	EXEC USP_GetTime @TimeSlotId,   @Time OUTPUT;
	SET DATEFORMAT DMY
	SELECT Id 
	FROM SITTING s 
    WHERE (@Date BETWEEN s.Start_Date AND s.End_Date) AND 
          (@Time BETWEEN s.Start_Time AND s.End_Time)
END
GO
-- using ssms add tableId to TableAvailability alternate key