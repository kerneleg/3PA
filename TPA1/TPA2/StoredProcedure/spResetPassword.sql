Create proc spResetPassword
@UserName nvarchar(100)
as
Begin
Declare @UserId int
Declare @Email nvarchar(100)

Select @UserId = EmpID
from Users
where UserName = @UserName

Select @Email = Email
from Employees
where ID=@UserId

if(@UserId IS NOT NULL)
Begin
--If username exists
Declare @GUID UniqueIdentifier
Set @GUID = NEWID()

Insert into tblResetPasswordRequests
(Id, UserId, ResetRequestDateTime)
Values(@GUID, @UserId, GETDATE())

Select 1 as ReturnCode, @GUID as UniqueId, @Email as Email
End
Else
Begin
--If username does not exist
SELECT 0 as ReturnCode, NULL as UniqueId, NULL as Email
End
End