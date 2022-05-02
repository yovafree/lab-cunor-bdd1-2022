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