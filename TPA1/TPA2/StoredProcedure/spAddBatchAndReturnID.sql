CREATE proc spAddBatchAndReturnID
@Policy int,
@CreationDate Date,
@empid int,
@receivingdate date,
@providername NVARCHAR(100)
as
Begin

INSERT INTO Batch
( ProviderID, PolicyID, CreationDate, EmpID,ReceivingDate)
 SELECT  Providers.ID, @Policy,@CreationDate,@empid,@receivingdate FROM Providers WHERE Providers.Name=@providername;

SELECT SCOPE_IDENTITY() As ID;

End