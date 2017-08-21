CREATE PROCEDURE Usr_Login @nombreUsuario VARCHAR(100), @passw VARCHAR (50) AS
BEGIN
	SELECT 
		1
	FROM 
		Usuario u
	WHERE
		u.nombreUsuario = @nombreUsuario
		AND u.passw = @passw
END