BEGIN TRY
  
  BEGIN TRAN
  SET NOCOUNT ON
  PRINT 'INICIO DE ACTUALIZACIÓN'

  IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'USUARIO' )
    Drop TABLE USUARIO

  CREATE TABLE USUARIO (Id        INT IDENTITY NOT NULL,
                        Nombre    VARCHAR(40) NOT NULL,
                        Apellido  VARCHAR(40) NOT NULL,
                        Email     VARCHAR(50) NOT NULL,
                        Password  VARCHAR(30) NOT NULL)

  ALTER TABLE USUARIO ADD PRIMARY KEY (Id)

  INSERT INTO dbo.Usuario (Nombre ,Apellido ,Email ,Password) VALUES ('Federico'  , 'Urrutia'  , 'fede.urrutia@hotmail.com'  , 'Password')
  INSERT INTO dbo.Usuario (Nombre ,Apellido ,Email ,Password) VALUES ('Federico1' , 'Urrutia1' , 'fede.urrutia1@hotmail.com' , 'Password1')
  INSERT INTO dbo.Usuario (Nombre ,Apellido ,Email ,Password) VALUES ('Federico2' , 'Urrutia2' , 'fede.urrutia2@hotmail.com' , 'Password2')
  INSERT INTO dbo.Usuario (Nombre ,Apellido ,Email ,Password) VALUES ('Federico3' , 'Urrutia3' , 'fede.urrutia3@hotmail.com' , 'Password3')
  INSERT INTO dbo.Usuario (Nombre ,Apellido ,Email ,Password) VALUES ('Federico4' , 'Urrutia4' , 'fede.urrutia4@hotmail.com' , 'Password4')
  
  PRINT 'FIN DE ACTUALIZACIÓN OK'
  COMMIT
  SET NOCOUNT OFF

END TRY

BEGIN CATCH
  PRINT 'ACTUALIZACION CANCELADA POR ERROR'
  SELECT ERROR_NUMBER()     'ERROR_NUMBER' , 
         ERROR_MESSAGE()    'ERROR_MESSAGE', 
         ERROR_LINE()       'ERROR_LINE', 
         ERROR_PROCEDURE()  'ERROR_PROCEDURE', 
         ERROR_SEVERITY ()  'ERROR_SEVERITY',   
         ERROR_STATE()      'ERROR_STATE'
  ROLLBACK
  SET NOCOUNT OFF
END CATCH

