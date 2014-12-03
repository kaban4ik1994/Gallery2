CREATE TRIGGER trg_UpdateTimeEntry
ON dbo.Comments
AFTER INSERT
AS
    UPDATE dbo.Comments
    SET CreatedDate = GETDATE()
    WHERE CommentId IN (SELECT DISTINCT CommentId FROM Inserted)