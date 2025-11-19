### SQL Shortcuts
- SSMS > Tool > Options > Environment > Query Shortcuts > Ctrl + 3
```sql
ALTER PROCEDURE sp_SelectDesc
    @TableName SYSNAME
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX) =
		N'SELECT TOP(100) * FROM ' + QUOTENAME(@TableName) + 'WHERE IsDeleted = 0 ORDER BY ModifiedAt DESC;';
    EXEC sp_executesql @SQL;
END
GO
```