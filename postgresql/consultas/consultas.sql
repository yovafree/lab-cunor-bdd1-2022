-- Consulta para obtener todos los productos.

SELECT * FROM producto

-- Consulta para obtener todos los productos y mostrar el nombre y precio de venta.

SELECT nombre, precio_venta FROM producto

-- Consulta para obtener todos los productos que ingresaron en el último mes.

SELECT * FROM producto WHERE fec_ingreso >= '2022-03-01'
SELECT * FROM producto WHERE fec_ingreso >= CURRENT_DATE - interval '30 day'

-- Consulta para obtener todos los productos y mostrar cuanto representan en cantidad monetaria.

SELECT nombre, (cantidad * precio_compra) costo FROM producto

-- Obtener los primeros 5 caracteres del nombre de un producto

SELECT SUBSTRING(nombre,0,5) FROM producto

-- Obtener el número de productos diferentes que tenemos.

SELECT COUNT(*) FROM producto
SELECT COUNT(cod_producto) FROM producto

-- Obtener el total que representa el inventario monetario de productos.
SELECT SUM(cantidad * precio_compra) costo FROM producto

-- Obtener el promedio de precio de venta de los productos.

SELECT AVG(precio_venta) FROM producto

-- Obtener el de precio de venta máximo de los productos.

SELECT MAX(precio_venta) FROM producto

-- Obtener el de precio de venta mínimo de los productos.

SELECT MIN(precio_venta) FROM producto

-- Obtener los productos y su categoría.

SELECT cp.nombre categoria, p.nombre producto
FROM cat_producto cp 
INNER JOIN producto p ON cp.cod_cat_producto = p.cod_cat_producto

-- Obtener las categorías que no tengan relacionado un producto.

SELECT cp.nombre categoria
FROM cat_producto cp 
LEFT JOIN producto p ON cp.cod_cat_producto = p.cod_cat_producto
WHERE p.cod_cat_producto IS NULL

-- Obtener las categorías que tengan o no tengan relacionado un producto.

SELECT cp.nombre categoria, p.nombre producto
FROM cat_producto cp 
LEFT JOIN producto p ON cp.cod_cat_producto = p.cod_cat_producto

-- Cantidad de productos por categoría
SELECT cp.nombre categoria, COUNT(p.nombre) cantidad
FROM cat_producto cp 
INNER JOIN producto p ON cp.cod_cat_producto = p.cod_cat_producto
GROUP BY cp.nombre

-- Total monetario de producto comprado por categoría que ingreso en último mes.

SELECT cp.nombre categoria, SUM(p.cantidad * p.precio_compra) total
FROM cat_producto cp 
INNER JOIN producto p ON cp.cod_cat_producto = p.cod_cat_producto
WHERE p.fec_ingreso >= CURRENT_DATE - interval '30 day'
GROUP BY cp.nombre