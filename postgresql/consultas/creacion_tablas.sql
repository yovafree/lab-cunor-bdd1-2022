--
-- ER/Studio 8.0 SQL Code Generation
-- Company :      CUNOR
-- Project :      DATA MODEL
-- Author :       erwingeo1021@gmail.com
--
-- Date Created : Wednesday, March 30, 2022 19:29:44
-- Target DBMS : PostgreSQL 8.0
--

-- 
-- TABLE: cat_producto 
--

CREATE TABLE cat_producto(
    cod_cat_producto    serial    NOT NULL,
    nombre              text,
    descripcion         text,
    estado              boolean,
    CONSTRAINT "pk_cat_producto" PRIMARY KEY (cod_cat_producto)
)
;



-- 
-- TABLE: producto 
--

CREATE TABLE producto(
    cod_producto        serial           NOT NULL,
    nombre              text,
    marca               text,
    fec_ingreso         timestamp,
    cantidad            integer,
    precio_compra       numeric(12, 2),
    precio_venta        numeric(12, 2),
    estado              boolean,
    cod_cat_producto    integer              NOT NULL,
    CONSTRAINT "pk_producto" PRIMARY KEY (cod_producto)
)
;



-- 
-- TABLE: producto 
--

ALTER TABLE producto ADD CONSTRAINT "fk_cat_producto_producto" 
    FOREIGN KEY (cod_cat_producto)
    REFERENCES cat_producto(cod_cat_producto)
;


