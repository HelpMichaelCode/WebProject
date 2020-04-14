CREATE TABLE PlotValidation(
VehicleTrackingId INT IDENTITY(1,2000) PRIMARY KEY,
IMEI bigint,
ThingType INT,
TotalPlotsReviewed INT,
Missing decimal(5,2),
LastUpdateTime datetime2,
PayloadId VARCHAR(50),
FeedProvider VARCHAR(60),
LastMessagedReceived VARCHAR(70));

select * from PlotValidation

drop table PlotValidation

ALTER TABLE PlotValidation 
ALTER COLUMN LastUpdateTime datetime2;

-- Deletes all rows from the table
DELETE FROM PlotValidation