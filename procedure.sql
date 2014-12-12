CREATE PROCEDURE [GetPictureById] (@PictureId INT)
AS SELECT
 E.PictureId,
 E.PictureName,
 E.PictureGenreId,
 E.PicturePainterId,
 E.PictureDepartamentId
FROM
 [dbo].[Pictures] E
WHERE
 E.PictureId = @PictureId
RETURN