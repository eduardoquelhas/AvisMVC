USE [AvisTesteMVC]
GO

/****** Object:  StoredProcedure [dbo].[SPObterCliente]    Script Date: 06/11/2017 09:18:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPObterCliente]( @ClienteId int = null)
AS
Begin

 IF(@ClienteId = 0)
 begin 
     Select ClienteId , Nome , Logradouro , Cpf 
       from Cliente
 end 
 else
 begin 
     Select ClienteId , Nome , Logradouro , Cpf 
       from Cliente
      Where ClienteId = @ClienteId
 end 

end

GO

USE [AvisTesteMVC]
GO

/****** Object:  StoredProcedure [dbo].[SPIncluirCliente]    Script Date: 06/11/2017 09:18:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPIncluirCliente] (  @Nome nvarchar(50)
									 ,@Logradouro nvarchar(50)
									 ,@Cpf nvarchar(50) )
AS
Begin


INSERT INTO Cliente (
            Nome
           ,Logradouro
           ,Cpf )
     VALUES (
           @Nome
           ,@Logradouro
           ,@Cpf )
end



GO


USE [AvisTesteMVC]
GO

/****** Object:  StoredProcedure [dbo].[SPExcluirCliente]    Script Date: 06/11/2017 09:18:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[SPExcluirCliente] ( @ClienteID int )
as
begin 
  Delete from dbo.Cliente 
  where ClienteID = @ClienteID
end
GO


USE [AvisTesteMVC]
GO

/****** Object:  StoredProcedure [dbo].[SPAtualizaCliente]    Script Date: 06/11/2017 09:18:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SPAtualizaCliente] ( @clienteID int 
                                     ,@Nome nvarchar(50)
									 ,@Logradouro nvarchar(50)
									 ,@Cpf nvarchar(50) )
AS
Begin

update Cliente SET
           Nome = @Nome , Logradouro = @Logradouro , Cpf = @Cpf
     Where 
	 clienteID = @clienteID
end



GO


