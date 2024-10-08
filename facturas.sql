USE [master]
GO
/****** Object:  Database [Facturación]    Script Date: 3/9/2024 09:20:30 ******/
CREATE DATABASE [Facturación]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Facturación', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Facturación.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Facturación_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Facturación_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Facturación] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Facturación].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Facturación] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Facturación] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Facturación] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Facturación] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Facturación] SET ARITHABORT OFF 
GO
ALTER DATABASE [Facturación] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Facturación] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Facturación] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Facturación] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Facturación] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Facturación] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Facturación] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Facturación] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Facturación] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Facturación] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Facturación] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Facturación] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Facturación] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Facturación] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Facturación] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Facturación] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Facturación] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Facturación] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Facturación] SET  MULTI_USER 
GO
ALTER DATABASE [Facturación] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Facturación] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Facturación] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Facturación] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Facturación] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Facturación]
GO
/****** Object:  Table [dbo].[ARTICULOS]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ARTICULOS](
	[id_articulo] [int] NOT NULL,
	[nombre] [varchar](20) NULL,
	[precio_Unitario] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_articulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DETALLES_FACTURAS]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DETALLES_FACTURAS](
	[id_detalle_factura] [int] NOT NULL,
	[id_articulo] [int] NULL,
	[nro_factura] [int] NULL,
	[cantidad] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_detalle_factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FACTURAS]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FACTURAS](
	[nro_Factura] [int] NOT NULL,
	[fecha] [datetime] NULL,
	[id_forma_pago] [int] NULL,
	[cliente] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[nro_Factura] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FORMAS_PAGOS]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FORMAS_PAGOS](
	[id_forma_pago] [int] NOT NULL,
	[forma_pago] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[id_forma_pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DETALLES_FACTURAS]  WITH CHECK ADD  CONSTRAINT [id_articulo] FOREIGN KEY([id_articulo])
REFERENCES [dbo].[ARTICULOS] ([id_articulo])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DETALLES_FACTURAS] CHECK CONSTRAINT [id_articulo]
GO
ALTER TABLE [dbo].[DETALLES_FACTURAS]  WITH CHECK ADD  CONSTRAINT [nro_factura] FOREIGN KEY([nro_factura])
REFERENCES [dbo].[FACTURAS] ([nro_Factura])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DETALLES_FACTURAS] CHECK CONSTRAINT [nro_factura]
GO
ALTER TABLE [dbo].[FACTURAS]  WITH CHECK ADD  CONSTRAINT [forma_pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[FORMAS_PAGOS] ([id_forma_pago])
GO
ALTER TABLE [dbo].[FACTURAS] CHECK CONSTRAINT [forma_pago]
GO
ALTER TABLE [dbo].[FACTURAS]  WITH CHECK ADD  CONSTRAINT [id_forma_pago] FOREIGN KEY([id_forma_pago])
REFERENCES [dbo].[FORMAS_PAGOS] ([id_forma_pago])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FACTURAS] CHECK CONSTRAINT [id_forma_pago]
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Articulos]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualizar_Articulos]
    @id_articulo INT,
    @nombre VARCHAR(20),
    @precio_Unitario DECIMAL(20, 2)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM ARTICULOS WHERE Id_articulo = @id_articulo)
    BEGIN
        UPDATE ARTICULOS
        SET Nombre = @nombre,
            Precio_Unitario = @precio_Unitario
        WHERE Id_articulo = @id_articulo;
    END
    ELSE
    BEGIN
        INSERT INTO ARTICULOS (Id_articulo, Nombre, Precio_Unitario)
        VALUES (@id_articulo, @nombre, @precio_Unitario);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Detalles_Facturas]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualizar_Detalles_Facturas]
      @id_detalle_factura INT,
	  @id_articulo INT,
	  @nro_factura INT,
	  @cantidad INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM DETALLES_FACTURAS WHERE Id_detalle_factura = @id_detalle_factura)
    BEGIN
        UPDATE DETALLES_FACTURAS
        SET Id_articulo = @id_articulo,
            Nro_factura = @nro_factura,
            Cantidad = @cantidad
        WHERE Id_detalle_factura = @id_detalle_factura;
    END
    ELSE
    BEGIN
        INSERT INTO DETALLES_FACTURAS (id_detalle_factura, id_articulo, nro_factura, cantidad)
        VALUES (@id_detalle_factura, @id_articulo, @nro_factura, @cantidad);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Facturas]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualizar_Facturas]
    @nro_factura INT,
	@fecha DATETIME,
	@id_forma_pago INT,
	@cliente VARCHAR (20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM FACTURAS WHERE Nro_factura = @nro_factura)
BEGIN
    UPDATE Facturas
	SET Fecha = @fecha,
	    Id_forma_pago = @id_forma_pago,
		Cliente = @cliente
    WHERE Nro_factura = @nro_factura;
END
ELSE
BEGIN
     INSERT INTO FACTURAS(nro_Factura, fecha, id_forma_pago, cliente)
	 VALUES(@nro_factura, @fecha, @id_forma_pago, @cliente);
	 END
	 END
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Formas_Pagos]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Actualizar_Formas_Pagos]
    @id_forma_pago INT,
    @forma_pago VARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM FORMAS_PAGOS WHERE Id_forma_pago = @id_forma_pago)
    BEGIN
        UPDATE FORMAS_PAGOS
        SET Forma_pago = @forma_pago
        WHERE Id_forma_pago = @id_forma_pago;
    END
    ELSE
    BEGIN
        INSERT INTO FORMAS_PAGOS(Id_forma_pago, Forma_pago)
        VALUES (@id_forma_pago, @forma_pago);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Borrar_Articulos]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Borrar_Articulos]
	@id_articulo INT
AS
BEGIN
	DELETE FROM ARTICULOS WHERE Id_articulo = @id_articulo;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Borrar_Detalles_Facturas]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Borrar_Detalles_Facturas]
@id_detalle_factura INT
AS
BEGIN
      DELETE FROM DETALLES_FACTURAS WHERE Id_detalle_factura = @id_detalle_factura

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Borrar_Facturas]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Borrar_Facturas]
@nro_factura INT
AS
BEGIN
     DELETE FROM FACTURAS WHERE Nro_factura = @nro_factura;

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Borrar_Formas_Pagos]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Borrar_Formas_Pagos]
@id_forma_pago INT
AS
BEGIN
      DELETE FROM FORMAS_PAGOS WHERE Id_forma_pago = @id_forma_pago;

END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Articulos_ID]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Articulos_ID]
      @id_articulo INT
AS
BEGIN
     select * from ARTICULOS where id_articulo = @id_articulo
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Detalles_Facturas_ID]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Detalles_Facturas_ID]
      @id_detalle_factura INT
AS
BEGIN
     select * from DETALLES_FACTURAS where Id_Detalle_Factura = @id_detalle_factura
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Facturas_Nro]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Facturas_Nro]
    @nro_factura INT
AS
BEGIN
    SELECT *
    FROM Facturas
    WHERE nro_factura = @nro_factura;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Formas_Pagos_ID]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Formas_Pagos_ID]
      @id_forma_pago INT
AS
BEGIN
     select * from FORMAS_PAGOS where Id_Forma_Pago = @id_forma_pago
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Todas_Facturas]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Todas_Facturas]
AS
BEGIN
     select * from FACTURAS;
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Todos_Articulos]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Todos_Articulos]
AS
BEGIN
     select * from ARTICULOS
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Todos_Detalles_Facturas]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Todos_Detalles_Facturas]
AS
BEGIN
     select * from DETALLES_FACTURAS
END

GO
/****** Object:  StoredProcedure [dbo].[SP_Obtener_Todos_Formas_Pagos]    Script Date: 3/9/2024 09:20:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Obtener_Todos_Formas_Pagos]
AS
BEGIN
     select * from FORMAS_PAGOS
END
GO
USE [master]
GO
ALTER DATABASE [Facturación] SET  READ_WRITE 
GO
