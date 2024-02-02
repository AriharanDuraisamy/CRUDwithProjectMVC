select * from StudDetail
go
CREATE procedure Insertdetail(@Name nvarchar(MAX) ,@DOB datetime2(7),@age int,@Gender nvarchar(MAX),@MobileNum bigint,@Emailid nvarchar(MAX),@Subject nvarchar(MAX))
AS
BEGIN
INSERT INTO StudDetail values(@Name,@DOB,@age,@Gender,@MobileNum,@Emailid,@Subject)
END
exec Insertdetail'madhan','05/05/2002',23,'Male',9994502360,'madhan@gmail.com','English'
drop table StudDetail

drop procedure Insertdetail