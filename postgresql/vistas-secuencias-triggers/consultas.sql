-----------------------
--- View

CREATE VIEW vw_prod_by_cat AS 
SELECT cp.nombre cat_producto, COUNT(p.nombre) cant_productos
FROM cat_producto cp
INNER JOIN producto p ON p.cod_cat_producto = cp.cod_cat_producto
GROUP BY cp.nombre;

SELECT * FROM vw_prod_by_cat WHERE cat_producto like '%Knife Plastic%';

-------------------------
--- Materialized View
CREATE MATERIALIZED VIEW vw_mat_prod_by_cat AS 
SELECT cp.nombre cat_producto, COUNT(p.nombre) cant_productos
FROM cat_producto cp
INNER JOIN producto p ON p.cod_cat_producto = cp.cod_cat_producto
GROUP BY cp.nombre;

SELECT * FROM vw_mat_prod_by_cat WHERE cat_producto like '%Knife Plastic%';

SELECT * FROM cat_producto WHERE nombre like '%Knife Plastic%';

REFRESH MATERIALIZED VIEW vw_mat_prod_by_cat;


-------------------
--- Secuencias

CREATE SEQUENCE seq_proveedor START 1;

CREATE SEQUENCE seq_proveedor2 
START 1
INCREMENT 5
MINVALUE 1
MAXVALUE 100
;

SELECT nextval('seq_proveedor');

SELECT nextval('seq_proveedor2');

DROP SEQUENCE seq_proveedor2;


--- FUNCIÓN QUE RETORNA EL TOTAL DE PRODUCTOS
CREATE FUNCTION total_products() RETURNS bigint AS $$
DECLARE
	total integer;
BEGIN
	SELECT COUNT(*) INTO total FROM producto;
	RETURN total;
END;
$$ LANGUAGE plpgsql;

SELECT total_products();
SELECT COUNT(*) FROM producto;

--- FUNCIÓN QUE RETORNA EL TOTAL DE PRODUCTOS POR FECHA DE INGRESO
CREATE OR REPLACE FUNCTION total_productos_por_fecha(fecIni date, fecFin date) RETURNS bigint AS $$
DECLARE
	total integer;
BEGIN
	SELECT COUNT(*) INTO total FROM producto WHERE date(fec_ingreso) BETWEEN date(fecIni) AND date(fecFin);
	total := total -9;
	RETURN total;
END;
$$ LANGUAGE plpgsql;


SELECT total_productos_por_fecha('2022-01-01', '2022-03-05');

SELECT * FROM producto

--- FUNCIÓN QUE RETORNA UNA ESTRUCTURA DE INFORMACIÓN Y VARIOS REGISTROS

CREATE OR REPLACE FUNCTION productos_por_fecha(fecIni date, fecFin date) RETURNS SETOF producto AS 
$BODY$
DECLARE
	r producto%rowtype;
BEGIN
	FOR r IN
		SELECT * FROM producto WHERE date(fec_ingreso) BETWEEN date(fecIni) AND date(fecFin)
	LOOP
		RETURN NEXT r;
	END LOOP;
	RETURN;
END;
$BODY$ LANGUAGE plpgsql;

SELECT * FROM productos_por_fecha('2022-01-01', '2022-03-05');


----------- FUNCIÓN PARA UN REPORTE DE PRODUCTOS POR FECHA DE INGRESO

CREATE TYPE public."tipoProducto" AS
(
	cod_producto integer,
	nombre text,
	marca text,
	precio_venta numeric(12, 2)
);

DROP TYPE public."tipoProducto"

drop function productos_por_fecha_ingreso(date,date);

CREATE OR REPLACE FUNCTION productos_por_fecha_ingreso(fecIni date, fecFin date) RETURNS SETOF "tipoProducto" AS 
$BODY$
DECLARE
	r RECORD;
BEGIN
	FOR r IN
		SELECT cod_producto, nombre, marca, precio_venta FROM producto WHERE date(fec_ingreso) BETWEEN date(fecIni) AND date(fecFin)
	LOOP
		RETURN NEXT r;
	END LOOP;
	RETURN;
END;
$BODY$ LANGUAGE plpgsql;

SELECT * FROM productos_por_fecha_ingreso('2022-01-01', '2022-03-05');