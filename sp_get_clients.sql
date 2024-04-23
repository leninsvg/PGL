CREATE PROCEDURE dbo.getClients
(
    @Page int = 1,
    @PageSize int = 10
)
AS
BEGIN
    select * from Person
        ORDER BY (SELECT 1)
        OFFSET (@Page - 1) * @PageSize ROWS
        FETCH NEXT @PageSize ROWS ONLY
END
GO

exec  dbo.getClients 2, 1