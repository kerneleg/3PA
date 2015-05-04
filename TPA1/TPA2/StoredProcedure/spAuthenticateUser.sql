CREATE proc spAuthenticateUser
@UserName nvarchar(100),
@Password nvarchar(200)
as
Begin
Declare @AccountLocked bit
Declare @Count int
Declare @RetryCount int

Select @AccountLocked = Lock
from Users where UserName = @UserName

--If the account is already locked
if(@AccountLocked = 1)
Begin
Select 1 as AccountLocked, 0 as Authenticated, 0 as RetryAttempts
End
Else
Begin
-- Check if the username and password match
Select @Count = COUNT(UserName) from Users
where [UserName] = @UserName and [Password] = @Password

-- If match found
if(@Count = 1)
Begin
-- Reset RetryAttempts 
Update Users set NoOfAttempts = 0
where UserName = @UserName

Select 0 as AccountLocked, 1 as Authenticated, 0 as RetryAttempts
End
Else
Begin
-- If a match is not found
Select @RetryCount = IsNULL(NoOfAttempts, 0)
from Users
where UserName = @UserName

Set @RetryCount = @RetryCount + 1

if(@RetryCount <= 3)
Begin
-- If re-try attempts are not completed
Update Users set NoOfAttempts = @RetryCount
where UserName = @UserName 

Select 0 as AccountLocked, 0 as Authenticated, @RetryCount as RetryAttempts
End
Else
Begin
-- If re-try attempts are completed
Update Users set NoOfAttempts = @RetryCount,
Lock = 1, LockTime = GETDATE()
where UserName = @UserName

Select 1 as AccountLocked, 0 as Authenticated, 0 as RetryAttempts
End
End
End
End