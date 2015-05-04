Create Proc spIsPasswordResetLinkValid 
@GUID uniqueidentifier
as
Begin
Declare @UserId int

If(Exists(Select UserId from tblResetPasswordRequests where Id = @GUID))
Begin
Select 1 as IsValidPasswordResetLink
End
Else
Begin
Select 0 as IsValidPasswordResetLink
End
End