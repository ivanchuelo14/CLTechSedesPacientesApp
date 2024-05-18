GO
-- =============================================
-- Author:		Ivan Julian Guerra
-- Create date: 18/05/2024
-- Description:	SP para obtener las sedes de acuerdo a configuracion
-- =============================================
CREATE OR ALTER  PROCEDURE [dbo].[Lab63_GetByLab62C1Sedes]
	
	--EXEC [Lab63_GetByLab62C1]  7
	@Lab62C1			Int
AS
BEGIN

   SET NOCOUNT ON
    SELECT	Lab63.Lab63C1,
		    Lab63.Lab63C2,
		    Lab63.Lab63C3,
		    Lab63.Lab63C4,
		    Lab63.Lab63C6,
		    Lab63.Lab63C7,
		    Lab63.Lab63C8,
		    Lab63.Lab62C1,
		    dbo.Labfn02(155,Lab63.lab63c6),
		    Lab63.Lab63C9,
		    Lab63.Lab63C10,
		    Lab63.Lab02C1
    FROM	Lab63 
    WHERE	Lab62C1 = @Lab62C1
	ORDER BY Lab63.Lab63C4
END
