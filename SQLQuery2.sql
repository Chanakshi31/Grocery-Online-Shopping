Select * from dbo.CategoryTbl

EXEC sp_rename 'CategoryTbl.CusID', 'CatId', 'COLUMN';
EXEC sp_rename 'CategoryTbl.CusName', 'CatName', 'COLUMN';
EXEC sp_rename 'CategoryTbl.CusDescription', 'CatDescription', 'COLUMN';