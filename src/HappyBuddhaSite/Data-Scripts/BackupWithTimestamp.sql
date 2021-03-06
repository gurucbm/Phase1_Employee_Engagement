Create	Schema	[System]
;

Go
;

Create	Procedure	[System].BackupDatabase
As	Begin


	Declare	@BackupName		Varchar(50)
	,	@BackupPath		Varchar(50)
	,	@BackupTimestamp	Varchar(50)
	;

	Select	@BackupTimestamp=	Convert(Varchar(26), GetDate(), 112)
				+	Replace(Convert(Varchar(26), GetDate(), 108), ':', '')
				;

	Select	@BackupName	=	N'HappyBuddha-Full Database Backup - '
				+	@BackupTimestamp
	,	@BackupPath	=	N'D:\Databases\Backup\HappyBuddha-' 
				+	@BackupTimestamp
				+	'.bak'
				;

	Backup	Database	[HappyBuddha]
		To	Disk	=	@BackupPath
		With	NoFormat
		,	NoInit
		,	Name	=	@BackupName
		,	Skip
		,	NoRewind
		,	NoUnload
		,	Stats	=	10
		;

End
;