--
-- TOC entry 2979 (class 1262 OID 16384)
-- Name: cunor; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE cunor WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'en_US.utf8' LC_CTYPE = 'en_US.utf8';


ALTER DATABASE cunor OWNER TO postgres;

\connect cunor

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 2 (class 3079 OID 24593)
-- Name: uuid-ossp; Type: EXTENSION; Schema: -; Owner: -
--

CREATE EXTENSION IF NOT EXISTS "uuid-ossp" WITH SCHEMA public;


--
-- TOC entry 2980 (class 0 OID 0)
-- Dependencies: 2
-- Name: EXTENSION "uuid-ossp"; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION "uuid-ossp" IS 'generate universally unique identifiers (UUIDs)';


SET default_tablespace = '';

--
-- TOC entry 200 (class 1259 OID 24607)
-- Name: colaborador; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.colaborador (
    cod_colaborador uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    nombres character varying(150),
    apellidos character varying(150),
    direccion character varying(150),
    telefono character varying(30),
    correo character varying
);


ALTER TABLE public.colaborador OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 24618)
-- Name: curso; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.curso (
    cod_curso integer NOT NULL,
    nombre character varying(150),
    descripcion character varying(150),
    carrera character varying
);


ALTER TABLE public.curso OWNER TO postgres;

--
-- TOC entry 201 (class 1259 OID 24616)
-- Name: curso_cod_curso_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.curso_cod_curso_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.curso_cod_curso_seq OWNER TO postgres;

--
-- TOC entry 2981 (class 0 OID 0)
-- Dependencies: 201
-- Name: curso_cod_curso_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.curso_cod_curso_seq OWNED BY public.curso.cod_curso;


--
-- TOC entry 198 (class 1259 OID 24581)
-- Name: estudiante; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.estudiante (
    cod_estudiante integer NOT NULL,
    carne character varying(12),
    nombres character varying(150) NOT NULL,
    apellidos character varying(150) NOT NULL,
    correo_electronico character varying(150),
    tipo_vivienda character varying(75),
    no_celular character varying(15),
    carrera character varying(50)
);


ALTER TABLE public.estudiante OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 24579)
-- Name: estudiante_cod_estudiante_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.estudiante_cod_estudiante_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.estudiante_cod_estudiante_seq OWNER TO postgres;

--
-- TOC entry 2982 (class 0 OID 0)
-- Dependencies: 197
-- Name: estudiante_cod_estudiante_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.estudiante_cod_estudiante_seq OWNED BY public.estudiante.cod_estudiante;


--
-- TOC entry 199 (class 1259 OID 24590)
-- Name: puesto; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.puesto (
    cod_puesto uuid DEFAULT public.uuid_generate_v4() NOT NULL,
    nombre character varying(150),
    salario numeric(12,2)
);


ALTER TABLE public.puesto OWNER TO postgres;

--
-- TOC entry 2838 (class 2604 OID 24621)
-- Name: curso cod_curso; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.curso ALTER COLUMN cod_curso SET DEFAULT nextval('public.curso_cod_curso_seq'::regclass);


--
-- TOC entry 2835 (class 2604 OID 24584)
-- Name: estudiante cod_estudiante; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.estudiante ALTER COLUMN cod_estudiante SET DEFAULT nextval('public.estudiante_cod_estudiante_seq'::regclass);


--
-- TOC entry 2971 (class 0 OID 24607)
-- Dependencies: 200
-- Data for Name: colaborador; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2973 (class 0 OID 24618)
-- Dependencies: 202
-- Data for Name: curso; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2969 (class 0 OID 24581)
-- Dependencies: 198
-- Data for Name: estudiante; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2970 (class 0 OID 24590)
-- Dependencies: 199
-- Data for Name: puesto; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.puesto (cod_puesto, nombre, salario) VALUES ('159c898d-fdde-40bc-8773-333b4418403f', 'Profesor Interino', 4000.00);
INSERT INTO public.puesto (cod_puesto, nombre, salario) VALUES ('c7ce64fa-5939-4b38-90fd-2e2ba1d82a23', 'Administrativo (a)', 8520.00);
INSERT INTO public.puesto (cod_puesto, nombre, salario) VALUES ('41202b7c-3588-4a0b-85fb-2d177a82803a', 'Secretario (a)', 5000.00);


--
-- TOC entry 2983 (class 0 OID 0)
-- Dependencies: 201
-- Name: curso_cod_curso_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.curso_cod_curso_seq', 1, false);


--
-- TOC entry 2984 (class 0 OID 0)
-- Dependencies: 197
-- Name: estudiante_cod_estudiante_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.estudiante_cod_estudiante_seq', 1, false);


--
-- TOC entry 2844 (class 2606 OID 24615)
-- Name: colaborador colaborador_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.colaborador
    ADD CONSTRAINT colaborador_pkey PRIMARY KEY (cod_colaborador);


--
-- TOC entry 2846 (class 2606 OID 24626)
-- Name: curso curso_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.curso
    ADD CONSTRAINT curso_pkey PRIMARY KEY (cod_curso);


--
-- TOC entry 2840 (class 2606 OID 24589)
-- Name: estudiante estudiante_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.estudiante
    ADD CONSTRAINT estudiante_pkey PRIMARY KEY (cod_estudiante);


--
-- TOC entry 2842 (class 2606 OID 24606)
-- Name: puesto puesto_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.puesto
    ADD CONSTRAINT puesto_pkey PRIMARY KEY (cod_puesto);


-- Completed on 2022-02-09 00:22:27 UTC

--
-- PostgreSQL database dump complete
--

