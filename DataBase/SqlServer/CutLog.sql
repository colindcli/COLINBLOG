-- 截断数据库日志


-- Sqlserver2012 截断日记
ALTER DATABASE DbName SET RECOVERY SIMPLE WITH NO_WAIT
ALTER DATABASE DbName SET RECOVERY SIMPLE   --简单模式
DBCC SHRINKFILE (N'DbName_Log' , 1, TRUNCATEONLY)   --数据库文件逻辑名称；1是大小1M
ALTER DATABASE DbName SET RECOVERY FULL WITH NO_WAIT
ALTER DATABASE DbName SET RECOVERY FULL  --还原为完全模式


--查询数据库大小：SizeSplace.sql
--TRUNCATE TABLE后数据库空间不释放：收缩数据库：任务 -> 收缩 -> 数据库