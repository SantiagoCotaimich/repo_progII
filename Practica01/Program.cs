using Practica01.Datos;
using Practica01.Dominio;
using Practica01.Servicios;
using System;

namespace Practica01
{
    class Program
    {
        static void Main(string[] args)
        {
            ArticulosServicios articulosServicios = new ArticulosServicios();
            Formas_pagosServicios forma_pagoServicios = new Formas_pagosServicios();
            FacturasServicios facturasServicios = new FacturasServicios();
            Detalles_FacturasServicios detallesServicios = new Detalles_FacturasServicios();



            ////////////////////////
            


            // Obtener todos los artículos
            Console.WriteLine("Todos los artículos almacenados:");
            var todosArticulos = articulosServicios.GetAll();
            foreach (var articulo in todosArticulos)
            {
                Console.WriteLine($"Id: {articulo.Id_articulo}, Nombre: {articulo.Nombre}, Precio: {articulo.PrecioUnitario}");
            }

            // Obtener todas las formas de pago
            Console.WriteLine("\nTodas las formas de pago disponibles:");
            var todasFormasPagos = forma_pagoServicios.GetAll();
            foreach (var formaPago in todasFormasPagos)
            {
                Console.WriteLine($"Id: {formaPago.Id_forma_pago}, Tipo de pago: {formaPago.Nombre}");
            }

            // Obtener todas las facturas
            Console.WriteLine("\nTodas las facturas almacenadas:");
            var todasFacturas = facturasServicios.GetAll();
            foreach (var factura in todasFacturas)
            {
                Console.WriteLine($"Nro: {factura.NroFactura}, Fecha: {factura.Fecha.ToShortDateString()}, Id_forma_pago: {factura.Id_formaPago}, Cliente: {factura.Cliente}");
            }

            // Obtener todos los detalles de factura
            Console.WriteLine("\nTodos los detalles de factura almacenados:");
            var todosDetalles = detallesServicios.GetAll();
            foreach (var detalle in todosDetalles)
            {
                Console.WriteLine($"Id: {detalle.Id_detalle}, Id de Artículo: {detalle.Articulo}, Nro de Factura: {detalle.Id_factura}, Cantidad: {detalle.Cantidad}");
            }


            /////////////////////////


            //Añadir un artículo
            var nuevoArticulo = new Artículos(5, "Articulo prueba5", 45);
            bool articuloAñadido = articulosServicios.Guardar(nuevoArticulo);
            Console.WriteLine($"\nArtículo añadido: {articuloAñadido}");

            // Añadir una forma de pago
            var nuevoPago = new Formas_pagos(5, "Préstamo");
            bool pagoAñadido = forma_pagoServicios.Guardar(nuevoPago);
            Console.WriteLine($"Forma de pago añadida: {pagoAñadido}");

            // Añadir una factura
            DateTime fecha = DateTime.ParseExact("29/08/2024", "dd/MM/yyyy", null);
            var nuevaFactura = new Facturas(5, fecha, 2, "Rocío");
            bool facturaAñadida = facturasServicios.Guardar(nuevaFactura);
            Console.WriteLine($"Factura añadida: {facturaAñadida}");

            //Añadir detalles de factura
            var nuevoDetalle = new Detalles_Facturas(5, 5, 5, 11);
            bool detalleAñadido = detallesServicios.Guardar(nuevoDetalle);
            Console.WriteLine($"Detalles de facturas añadidos: {detalleAñadido}");



            /////////////////////////


            //Borrar un articulo
            bool articuloBorrado = articulosServicios.Borrar(5);
            if (articuloBorrado)
            {
                Console.WriteLine("Artículo borrado con éxito, junto con sus referencias en otras tablas.");
            }
            else
            {
                Console.WriteLine("No se pudo borrar el artículo");
            }

            //Borrar una forma de pago
            bool formaPagoBorrada = forma_pagoServicios.Borrar(5);
            if (formaPagoBorrada)
            {
                Console.WriteLine("Forma de pago borrada con éxito, junto con sus referencias en otras tablas.");
            }
            else
            {
                Console.WriteLine("No se pudo borrar la forma de pago");
            }

            //Borrar una factura
            bool facturaBorrada = facturasServicios.Borrar(5);
            if (facturaBorrada)
            {
                Console.WriteLine("Factura borrada con éxito, junto con sus referencias en otras tablas.");
            }
            else
            {
                Console.WriteLine("No se pudo borrar la factura");
            }

            //Borrar los detalles de factura
            bool detallesBorrados = detallesServicios.Borrar(5);
            if (detallesBorrados)
            {
                Console.WriteLine("Detalles de facturas borrados con éxito, junto con sus referencias en otras tablas.");
            }
            else
            {
                Console.WriteLine("No se pudo borrar la factura");
            }
        }
    }
}


