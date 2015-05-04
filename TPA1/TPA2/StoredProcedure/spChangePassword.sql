Create Proc spChangePassword
@GUID uniqueidentifier,
@Password nvarchar(100)
as
Begin
Declare @UserId int

Select @UserId = UserId 
from tblResetPasswordRequests
where Id= @GUID

if(@UserId is null)
Begin
-- If UserId does not exist
Select 0 as IsPasswordChanged
End
Else
Begin
-- If UserId exists, Update with new password
Update Users set
[Password] = @Password
where EmpID = @UserId

-- Delete the password reset request row 
Delete from tblResetPasswordRequests
where Id = @GUID

Select 1 as IsPasswordChanged
End
End