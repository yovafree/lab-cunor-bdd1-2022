--
-- ER/Studio 8.0 SQL Code Generation
-- Company :      CUNOR
-- Project :      modelo_ejercicio_1.DM1
-- Author :       erwingeo1021@gmail.com
--
-- Date Created : Tuesday, March 08, 2022 19:08:50
-- Target DBMS : PostgreSQL 8.0
--

-- DDL - Data Definition Language
-- DML - Data Manipulation Language
-- DCL - Data Control Language

-- 
-- TABLE: actor 
--

CREATE TABLE actor(
    cod_actor           serial     NOT NULL,
    nombre              character varying(75),
    sexo                character varying(75),
    cod_nacionalidad    integer        NOT NULL,
    CONSTRAINT "pk_actor" PRIMARY KEY (cod_actor)
)
;



-- 
-- TABLE: alquiler 
--

CREATE TABLE alquiler(
    cod_alquiler      serial     NOT NULL,
    fec_alquiler      character varying(75),
    fec_devolucion    character varying(75),
    cod_ejemplar      integer        NOT NULL,
    cod_cliente       integer        NOT NULL,
    cod_pelicula      integer        NOT NULL,
    CONSTRAINT "pk_alquiler" PRIMARY KEY (cod_alquiler)
)
;



-- 
-- TABLE: cliente 
--

CREATE TABLE cliente(
    cod_cliente         serial     NOT NULL,
    cod_cliente_aval    integer        NOT NULL,
    nombre              character varying(75),
    dni                 character varying(75),
    direccion           character varying(75),
    telefono            character varying(75),
    CONSTRAINT "pk_cliente" PRIMARY KEY (cod_cliente)
)
;



-- 
-- TABLE: director 
--

CREATE TABLE director(
    cod_director         serial         NOT NULL,
    nombre               varchar(150),
    cod_nacionalidad     integer            NOT NULL,
    fec_creacion         timestamp,
    fec_actualizacion    timestamp,
    usuario              varchar(75),
    estado               integer,
    CONSTRAINT "pk_director" PRIMARY KEY (cod_director)
)
;



-- 
-- TABLE: ejemplar 
--

CREATE TABLE ejemplar(
    cod_ejemplar           serial    NOT NULL,
    cod_pelicula           integer       NOT NULL,
    cod_estado_ejemplar    integer       NOT NULL,
    CONSTRAINT "pk_ejemplar" PRIMARY KEY (cod_ejemplar, cod_pelicula)
)
;



-- 
-- TABLE: estado_ejemplar 
--

CREATE TABLE estado_ejemplar(
    cod_estado_ejemplar    serial     NOT NULL,
    nombre                 character varying(75),
    CONSTRAINT "pk_estado_ejemplar" PRIMARY KEY (cod_estado_ejemplar)
)
;



-- 
-- TABLE: nacionalidad 
--

CREATE TABLE nacionalidad(
    cod_nacionalidad    serial         NOT NULL,
    nombre              varchar(150),
    CONSTRAINT "pk_nacionalidad" PRIMARY KEY (cod_nacionalidad)
)
;



-- 
-- TABLE: pelicula 
--

CREATE TABLE pelicula(
    cod_pelicula        serial     NOT NULL,
    titulo              character varying(75),
    fec_estreno         character varying(75),
    cod_director        integer        NOT NULL,
    cod_nacionalidad    integer        NOT NULL,
    cod_productora      integer        NOT NULL,
    CONSTRAINT "pk_pelicula" PRIMARY KEY (cod_pelicula)
)
;



-- 
-- TABLE: productora 
--

CREATE TABLE productora(
    cod_productora    serial         NOT NULL,
    nombre            varchar(150),
    CONSTRAINT "pk_productora" PRIMARY KEY (cod_productora)
)
;



-- 
-- TABLE: reparto 
--

CREATE TABLE reparto(
    cod_reparto       serial    NOT NULL,
    cod_pelicula      integer       NOT NULL,
    cod_actor         integer       NOT NULL,
    cod_tipo_actor    integer       NOT NULL,
    CONSTRAINT "pk_reparto" PRIMARY KEY (cod_reparto, cod_pelicula, cod_actor, cod_tipo_actor)
)
;



-- 
-- TABLE: tipo_actor 
--

CREATE TABLE tipo_actor(
    cod_tipo_actor    serial     NOT NULL,
    nombre            character varying(75),
    CONSTRAINT "pk_tipo_actor" PRIMARY KEY (cod_tipo_actor)
)
;



-- 
-- TABLE: actor 
--

ALTER TABLE actor ADD CONSTRAINT "Refnacionalidad131" 
    FOREIGN KEY (cod_nacionalidad)
    REFERENCES nacionalidad(cod_nacionalidad)
;


-- 
-- TABLE: alquiler 
--

ALTER TABLE alquiler ADD CONSTRAINT "Refejemplar91" 
    FOREIGN KEY (cod_ejemplar, cod_pelicula)
    REFERENCES ejemplar(cod_ejemplar, cod_pelicula)
;

ALTER TABLE alquiler ADD CONSTRAINT "Refcliente101" 
    FOREIGN KEY (cod_cliente)
    REFERENCES cliente(cod_cliente)
;


-- 
-- TABLE: cliente 
--

ALTER TABLE cliente ADD CONSTRAINT "Refcliente111" 
    FOREIGN KEY (cod_cliente_aval)
    REFERENCES cliente(cod_cliente)
;


-- 
-- TABLE: director 
--

ALTER TABLE director ADD CONSTRAINT "Refnacionalidad121" 
    FOREIGN KEY (cod_nacionalidad)
    REFERENCES nacionalidad(cod_nacionalidad)
;


-- 
-- TABLE: ejemplar 
--

ALTER TABLE ejemplar ADD CONSTRAINT "Refpelicula171" 
    FOREIGN KEY (cod_pelicula)
    REFERENCES pelicula(cod_pelicula)
;

ALTER TABLE ejemplar ADD CONSTRAINT "Refestado_ejemplar181" 
    FOREIGN KEY (cod_estado_ejemplar)
    REFERENCES estado_ejemplar(cod_estado_ejemplar)
;


-- 
-- TABLE: pelicula 
--

ALTER TABLE pelicula ADD CONSTRAINT "Refdirector51" 
    FOREIGN KEY (cod_director)
    REFERENCES director(cod_director)
;

ALTER TABLE pelicula ADD CONSTRAINT "Refnacionalidad141" 
    FOREIGN KEY (cod_nacionalidad)
    REFERENCES nacionalidad(cod_nacionalidad)
;

ALTER TABLE pelicula ADD CONSTRAINT "Refproductora151" 
    FOREIGN KEY (cod_productora)
    REFERENCES productora(cod_productora)
;


-- 
-- TABLE: reparto 
--

ALTER TABLE reparto ADD CONSTRAINT "Refpelicula21" 
    FOREIGN KEY (cod_pelicula)
    REFERENCES pelicula(cod_pelicula)
;

ALTER TABLE reparto ADD CONSTRAINT "Refactor31" 
    FOREIGN KEY (cod_actor)
    REFERENCES actor(cod_actor)
;

ALTER TABLE reparto ADD CONSTRAINT "Reftipo_actor41" 
    FOREIGN KEY (cod_tipo_actor)
    REFERENCES tipo_actor(cod_tipo_actor)
;


