--还原数据库

USE [master]
GO

ALTER DATABASE [数据库] SET OFFLINE WITH ROLLBACK IMMEDIATE;
GO

RESTORE DATABASE [数据库]
FROM DISK='E:\***.bak'
WITH
	NOUNLOAD,
	REPLACE,
	STATS=10,
	MOVE '***'
	TO 'E:\***.mdf',
	MOVE '***_log'
	TO 'E:\***_log.ldf';
GO

ALTER DATABASE [数据库] SET ONLINE;
GO