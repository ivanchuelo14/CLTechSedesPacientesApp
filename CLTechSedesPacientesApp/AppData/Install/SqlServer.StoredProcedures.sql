GO
-- =============================================
-- Author:		Ivan Julian Guerra
-- Create date: 18/05/2024
-- Description:	SP para obtener las sedes de acuerdo a configuracion
-- =============================================
CREATE OR ALTER  PROCEDURE [dbo].[Lab63_GetByLab62C1Sedes]
	
	--EXEC [Lab63_GetByLab62C1Sedes]  7
	@Lab62C1			Int
AS
BEGIN

   SET NOCOUNT ON
	  SELECT	
		Lab63.Lab63C1 AS Id,
	    Lab63.Lab63C2 As Codigo,
	    Lab63.Lab63C3 AS CodigoCentral,
	    Lab63.Lab63C4 AS NombreSede,
	    Lab63.Lab63C6 AS Estado,
	    Lab63.Lab63C8 AS FechaRegistro,
	    Lab63.Lab62C1 AS IdDemo62   		   
	FROM	Lab63 
    WHERE	Lab62C1 = @Lab62C1
	ORDER BY Lab63.Lab63C4
END
