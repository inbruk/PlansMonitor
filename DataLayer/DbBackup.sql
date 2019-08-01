--
-- PostgreSQL database dump
--

-- Dumped from database version 11.4
-- Dumped by pg_dump version 11.4

-- Started on 2019-08-01 23:38:31

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

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 196 (class 1259 OID 16394)
-- Name: tblAuditLog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblAuditLog" (
    "Id" integer NOT NULL,
    "Time" timestamp with time zone NOT NULL,
    "User" integer NOT NULL,
    "Screen" integer NOT NULL,
    "Action" integer NOT NULL,
    "Description" character varying(2048) NOT NULL
);


ALTER TABLE public."tblAuditLog" OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 16400)
-- Name: tblDictionaryValue; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblDictionaryValue" (
    "Name" character varying(128) NOT NULL,
    "EngName4Code" character varying(1024),
    "Position" integer NOT NULL,
    "Dictionary" integer NOT NULL,
    "Id" integer NOT NULL,
    "Description" character varying(2048)
);


ALTER TABLE public."tblDictionaryValue" OWNER TO postgres;

--
-- TOC entry 2983 (class 0 OID 0)
-- Dependencies: 197
-- Name: COLUMN "tblDictionaryValue"."Description"; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public."tblDictionaryValue"."Description" IS 'Описание элемента, используется далеко не во всех словарях';


--
-- TOC entry 198 (class 1259 OID 16406)
-- Name: tblUser; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblUser" (
    "Id" integer NOT NULL,
    "FirstName" character varying(64) NOT NULL,
    "LastName" character varying(64) NOT NULL,
    "Patronymic" character varying(64) NOT NULL,
    "Login" character varying(32) NOT NULL,
    "PasswordSalt" character varying(32) NOT NULL,
    "PasswordHash" character varying(32),
    "AccessGranted" boolean NOT NULL,
    "EMail" character varying(254) NOT NULL,
    "Role" integer NOT NULL,
    "VerificationObject" integer
);


ALTER TABLE public."tblUser" OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 16412)
-- Name: vwAuditLog; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public."vwAuditLog" AS
 SELECT tal."Id",
    tal."Time",
    tu."Id" AS "UserId",
    tu."FirstName" AS "UserFirstName",
    tu."LastName" AS "UserLastName",
    tu."Patronymic" AS "UserPatronymic",
    tsc."Position" AS "ScreenPos",
    tsc."Name" AS "ScreenName",
    tac."Position" AS "ActionPos",
    tac."Name" AS "ActionName",
    tal."Description"
   FROM (((public."tblAuditLog" tal
     LEFT JOIN public."tblUser" tu ON ((tal."User" = tu."Id")))
     LEFT JOIN public."tblDictionaryValue" tsc ON (((tal."Screen" = tsc."Position") AND (tsc."Dictionary" = 2))))
     LEFT JOIN public."tblDictionaryValue" tac ON (((tal."Action" = tac."Position") AND (tac."Dictionary" = 1))));


ALTER TABLE public."vwAuditLog" OWNER TO postgres;

--
-- TOC entry 220 (class 1255 OID 16417)
-- Name: fnAuditLogList(integer, integer, character varying, timestamp with time zone, timestamp with time zone); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fnAuditLogList"("pageStartRow" integer, "pageRowsCount" integer, "argName" character varying, "startTime" timestamp with time zone, "endTime" timestamp with time zone) RETURNS SETOF public."vwAuditLog"
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN QUERY SELECT VA.*
  FROM "vwAuditLog" VA
  WHERE ( "argName" IS NULL OR CONCAT( VA."UserFirstName", VA."UserLastName", VA."UserPatronymic") ILIKE CONCAT('%', "argName", '%') )
        and ( "startTime" IS NULL or "startTime" <= VA."Time" )
        and ( "endTime" IS NULL or "endTime" >= VA."Time" )
  offset "pageStartRow"
  LIMIT "pageRowsCount";              
END;$$;


ALTER FUNCTION public."fnAuditLogList"("pageStartRow" integer, "pageRowsCount" integer, "argName" character varying, "startTime" timestamp with time zone, "endTime" timestamp with time zone) OWNER TO postgres;

--
-- TOC entry 221 (class 1255 OID 16418)
-- Name: fnDictionaryValueCount(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fnDictionaryValueCount"(integer, integer) RETURNS integer
    LANGUAGE plpgsql
    AS $_$
DECLARE 
  cnt integer := 0;
BEGIN
  SELECT COUNT(*) INTO cnt 
  FROM "tblDictionaryValue" AS TDV
  WHERE TDV."Dictionary" = $1 AND TDV."Position" = $2;

  RETURN cnt; 
END;
$_$;


ALTER FUNCTION public."fnDictionaryValueCount"(integer, integer) OWNER TO postgres;

--
-- TOC entry 200 (class 1259 OID 16419)
-- Name: tblFileStorage; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblFileStorage" (
    "Id" integer NOT NULL,
    "Name" character varying(256) NOT NULL,
    "Extention" character varying(16) NOT NULL,
    "LoadingTime" timestamp with time zone NOT NULL,
    "User" integer NOT NULL,
    "PathToPreview" character varying(256),
    "PathToFile" character varying(256) NOT NULL,
    "Audit" integer NOT NULL
);


ALTER TABLE public."tblFileStorage" OWNER TO postgres;

--
-- TOC entry 201 (class 1259 OID 16425)
-- Name: tblUserRole; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblUserRole" (
    "Id" integer NOT NULL,
    "Name" character varying(64) NOT NULL,
    "Comment" character varying(256) NOT NULL,
    "IsAuditOjectRestricted" boolean
);


ALTER TABLE public."tblUserRole" OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 16428)
-- Name: vwUser; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public."vwUser" AS
 SELECT "tblUser"."Id",
    "tblUser"."FirstName",
    "tblUser"."LastName",
    "tblUser"."Patronymic",
    "tblUser"."Login",
    "tblUser"."PasswordSalt",
    "tblUser"."PasswordHash",
    "tblUser"."AccessGranted",
    "tblUser"."EMail",
    "tblUser"."VerificationObject",
    "tblUserRole"."Id" AS "RoleId",
    "tblUserRole"."Name" AS "RoleName"
   FROM (public."tblUser"
     LEFT JOIN public."tblUserRole" ON (("tblUser"."Role" = "tblUserRole"."Id")));


ALTER TABLE public."vwUser" OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 16432)
-- Name: vwFileStorage; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public."vwFileStorage" AS
 SELECT tfs."Id",
    tfs."Name",
    tfs."Extention",
    tfs."LoadingTime",
    tfs."PathToPreview",
    tfs."PathToFile",
    tfs."Audit",
    vu."Id" AS "UserId",
    vu."FirstName" AS "UserFirstName",
    vu."LastName" AS "UserLastName",
    vu."Patronymic" AS "UserPatronymic"
   FROM (public."tblFileStorage" tfs
     LEFT JOIN public."vwUser" vu ON ((tfs."User" = vu."Id")));


ALTER TABLE public."vwFileStorage" OWNER TO postgres;

--
-- TOC entry 222 (class 1255 OID 16436)
-- Name: fnFileStorage(integer, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fnFileStorage"(audit integer, "argName" character varying) RETURNS SETOF public."vwFileStorage"
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN QUERY SELECT VA.*
  FROM "vwFileStorage" VA
  WHERE "audit" = VA."Audit" AND
  		( "argName" IS NULL OR CONCAT( VA."Name", VA."Extention") ILIKE CONCAT('%', "argName", '%') );          
END;$$;


ALTER FUNCTION public."fnFileStorage"(audit integer, "argName" character varying) OWNER TO postgres;

--
-- TOC entry 235 (class 1255 OID 16437)
-- Name: fnTriInsUpd_tblAudit(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fnTriInsUpd_tblAudit"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
    DECLARE 
      cnt integer;
    BEGIN

        -- Проверяем субъект аудита в аудите

        cnt := "fnDictionaryValueCount"( 
            3, -- Внимание !!! Это ид словаря - Субъект аудита
            NEW."AuditObject" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с не существующим ид-ом cубъекта аудита';
            RETURN NULL;
        END IF;

        IF cnt > 1 THEN
            RAISE EXCEPTION 'Словарь с cубъектами аудита поврежден - неуникальные записи';
            RETURN NULL;
        END IF;

        -- Проверяем статус проведения мониторинга

        cnt := "fnDictionaryValueCount"( 
            4, -- Внимание !!! Это ид словаря - Статус проведения мониторинга
            NEW."MonitoringProgressStatus" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с не существующим ид-ом cубъекта аудита';
            RETURN NULL;
        END IF;

        IF cnt > 1 THEN
            RAISE EXCEPTION 'Словарь с cубъектами аудита поврежден - неуникальные записи';
            RETURN NULL;
        END IF;

        RETURN NEW;
    END;
$$;


ALTER FUNCTION public."fnTriInsUpd_tblAudit"() OWNER TO postgres;

--
-- TOC entry 236 (class 1255 OID 16438)
-- Name: fnTriInsUpd_tblAuditLog_Action(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fnTriInsUpd_tblAuditLog_Action"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
    DECLARE 
      cnt integer;
    BEGIN

        -- Проверяем действие в аудите лога

        cnt := "fnDictionaryValueCount"( 
            1, -- Внимание !!! Это ид словаря - Действие в логе аудита.
            NEW."Action" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с не существующим ид-ом действия лога аудита';
            RETURN NULL;
        END IF;

        IF cnt > 1 THEN
            RAISE EXCEPTION 'Словарь с действиями лога аудита поврежден - неуникальные записи';
            RETURN NULL;
        END IF;

        -- Проверяем экран в аудите лога

        cnt := "fnDictionaryValueCount"( 
            2, -- Внимание !!! Это ид словаря - Экран в логе аудита.
            NEW."Screen" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с не существующим ид-ом экрана лога аудита';
            RETURN NULL;
        END IF;

        IF cnt > 1 THEN
            RAISE EXCEPTION 'Словарь с экранами лога аудита поврежден - неуникальные записи';
            RETURN NULL;
        END IF;

        RETURN NEW;
    END;
$$;


ALTER FUNCTION public."fnTriInsUpd_tblAuditLog_Action"() OWNER TO postgres;

--
-- TOC entry 237 (class 1255 OID 16439)
-- Name: fnTriInsUpd_tblCorrectiveAction(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fnTriInsUpd_tblCorrectiveAction"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
    DECLARE 
      cnt integer;
    BEGIN

        -- Проверяем Отметка Объекта проверки о выполнении мероприятия

        cnt := "fnDictionaryValueCount"( 
            8, -- Внимание !!! Это ид словаря - Отметка Объекта проверки о выполнении мероприятия
            NEW."EvaluationCheckMarkOnCA" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с не существующим ид-ом отметки объекта проверки о выполнении в корр. мероприятии';
            RETURN NULL;
        END IF;

        -- Проверяем оценки эффективности выполнения мероприятия 

        cnt := "fnDictionaryValueCount"( 
            9, -- Внимание !!! Это ид словаря - Оценка эффективности выполнения мероприятия
            NEW."CorrectiveActionEffectEvaluation" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с не существующим ид-ом оценки эффективности выполнения в корр. мероприятии';
            RETURN NULL;
        END IF;

        -- Проверяем Статус выполнения корректирующего мероприятия

        cnt := "fnDictionaryValueCount"( 
            10, -- Внимание !!! Это ид словаря -  Статус выполнения корректирующего мероприятия
            NEW."CorrectiveActionState" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с не существующим ид-ом статуса выполнения корр. мероприятия';
            RETURN NULL;
        END IF;

        RETURN NEW;
    END;
$$;


ALTER FUNCTION public."fnTriInsUpd_tblCorrectiveAction"() OWNER TO postgres;

--
-- TOC entry 238 (class 1255 OID 16440)
-- Name: fnTriInsUpd_tblEmailTemplate(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fnTriInsUpd_tblEmailTemplate"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
    DECLARE 
      cnt integer;
    BEGIN

        -- Проверяем Отметка Объекта проверки о выполнении мероприятия

        cnt := "fnDictionaryValueCount"( 
            11, -- Внимание !!! Это ид словаря - Отметка Объекта проверки о выполнении мероприятия
            NEW."Type" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с не существующим ид-ом отметки объекта проверки о выполнении в корр. мероприятии';
            RETURN NULL;
        END IF;

        RETURN NEW;
    END;
$$;


ALTER FUNCTION public."fnTriInsUpd_tblEmailTemplate"() OWNER TO postgres;

--
-- TOC entry 239 (class 1255 OID 16441)
-- Name: fnTriInsUpd_tblRemark(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fnTriInsUpd_tblRemark"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
    DECLARE 
      cnt integer;
    BEGIN

        -- Проверяем бизнес процесс в замечании

        cnt := "fnDictionaryValueCount"( 
            5, -- Внимание !!! Это ид словаря - Бизнес процесс
            NEW."BusinessProcess" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с не существующим ид-ом бизнес процесса';
            RETURN NULL;
        END IF;

        -- Проверяем итоговый уровень оценки в замечании

        cnt := "fnDictionaryValueCount"( 
            6, -- Внимание !!! Это ид словаря - Итоговый уровень оценки замечания
            NEW."TotalAssessmentLevel" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с несуществующим итоговым уровнем оценки замечания';
            RETURN NULL;
        END IF;

        -- Проверяем тип замечания

        cnt := "fnDictionaryValueCount"( 
            7, -- Внимание !!! Это ид словаря - Тип замечания
            NEW."RemarkType" -- Внимание !!! Это ид элемента словаря 
        );

        IF cnt = 0 THEN
            RAISE EXCEPTION 'Попытка создать запись с несуществующим типом замечания';
            RETURN NULL;
        END IF;

        RETURN NEW;
    END;
$$;


ALTER FUNCTION public."fnTriInsUpd_tblRemark"() OWNER TO postgres;

--
-- TOC entry 240 (class 1255 OID 16442)
-- Name: fnUserList(integer, integer, character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fnUserList"("pageStartRow" integer, "pageRowsCount" integer, "argName" character varying) RETURNS SETOF public."vwUser"
    LANGUAGE plpgsql
    AS $$
BEGIN
  RETURN QUERY 
    SELECT VU.*
    FROM "vwUser" VU
    WHERE "argName" IS NULL
      OR CONCAT( VU."FirstName", VU."LastName", VU."Patronymic") 
	   ILIKE CONCAT('%', "argName", '%')
    offset "pageStartRow"
	LIMIT "pageRowsCount";
	
END;$$;


ALTER FUNCTION public."fnUserList"("pageStartRow" integer, "pageRowsCount" integer, "argName" character varying) OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 16443)
-- Name: tblAudit; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblAudit" (
    "Id" integer NOT NULL,
    "Name" character varying(256) NOT NULL,
    "AuditObject" integer,
    "VerificationPeriodStart" timestamp with time zone NOT NULL,
    "VerificationPeriodStop" timestamp with time zone NOT NULL,
    "GroundForVerification" character varying(4192) NOT NULL,
    "parPlanScheduleOfControlEvent" character varying(16) NOT NULL,
    "filePlanScheduleOfControlEvent	" character varying(256),
    "numLocalRegulatory" character varying(256) NOT NULL,
    "fileLocalRegulatory" character varying(256),
    "VerificationPeriod" character varying(16) NOT NULL,
    "VerificationTermStart" timestamp with time zone NOT NULL,
    "VerficationTermEnd" character varying NOT NULL,
    "ResponsibleEmployee" integer NOT NULL,
    "NumberAndDateLocRegPrepare" character varying(128),
    "NumberAndDateLocRegAcceptance" character varying(128),
    "CAPMonitoringCompletedOnDate" timestamp with time zone,
    "NextCAPMonitoringDate" timestamp with time zone,
    "AuditSubject" integer NOT NULL,
    "MonitoringProgressStatus" integer NOT NULL,
    "CAPMonitoringCompleteDate" timestamp with time zone,
    "AuditSuperviser" integer,
    "BusinessProcess" integer NOT NULL
);


ALTER TABLE public."tblAudit" OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 16449)
-- Name: tblAuditObject; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblAuditObject" (
    "Id" integer NOT NULL,
    "Name" character varying(256) NOT NULL
);


ALTER TABLE public."tblAuditObject" OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 16452)
-- Name: tblCorrectiveAction; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblCorrectiveAction" (
    "Id" integer NOT NULL,
    "Audit" integer NOT NULL,
    "Name" character varying(128) NOT NULL,
    "ExecutiveOfficerFirstName" character varying(64) NOT NULL,
    "ExecutiveOfficerLastName" character varying(64) NOT NULL,
    "ExecutiveOfficerPatronymic" character varying(64) NOT NULL,
    "PlannedResultOfCorrectiveAction" character varying(256) NOT NULL,
    "CADevelopmentEvaluation" character varying(2048),
    "NotDevelopmentCAComment" character varying(4096),
    "EvaluationAccordRecomForPrepOfCA" character varying(4096),
    "EvalAccordRecomForPrepOfCAComment" character varying(4096),
    "CAInAccordOrderOfVerifObject" character varying(4096),
    "FactPeriodOfCAExecution" character varying(64),
    "EvaluationCheckMarkOnCA" integer,
    "ReportImplementOfTheApprovedCA" character varying(4096),
    "CorrectiveActionState" integer,
    "CorrectiveActionStateComment" character varying(2048),
    "ConclusionCorrectiveActionEffectEvaluation" character varying(2048),
    "CorrectiveActionEffectEvaluation" integer,
    "UsedRecommendationInPCA" boolean,
    "CommentOnUsedRecommendationInPCA" character varying(2048),
    "EvaluationOfPostControlNeed" character varying(2048),
    "MonitoringOfficerFirstName" character varying(64),
    "MonitoringOfficerLastName" character varying(64),
    "MonitoringOfficerPatronymic" character varying(64),
    "Note" character varying(4096),
    "PlannedExecutionDate" timestamp with time zone NOT NULL,
    "CorrectiveActionType" integer NOT NULL
);


ALTER TABLE public."tblCorrectiveAction" OWNER TO postgres;

--
-- TOC entry 207 (class 1259 OID 16458)
-- Name: tblDictionary; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblDictionary" (
    "Id" integer NOT NULL,
    "Name" character varying(128) NOT NULL,
    "EngName4Code" character varying(1024),
    "Description" character varying(2048)
);


ALTER TABLE public."tblDictionary" OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 16464)
-- Name: tblDictionaryValue_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."tblDictionaryValue" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."tblDictionaryValue_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 209 (class 1259 OID 16466)
-- Name: tblEmailTemplate; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblEmailTemplate" (
    "Id" integer NOT NULL,
    "Type" integer NOT NULL,
    "Template" character varying(8192) NOT NULL,
    "Description" character varying(8192)
);


ALTER TABLE public."tblEmailTemplate" OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 16472)
-- Name: tblRemark; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."tblRemark" (
    "Id" integer NOT NULL,
    "ReportSubsectionNumber" integer,
    "BusinessProcess" integer NOT NULL,
    "RemarkType" integer NOT NULL,
    "RemarkDescription" character varying,
    "RevealedRemarkReason" character varying,
    "RevealedRemarkConsequences" character varying,
    "QuantitativeAssessmentLossesRealized" bigint,
    "QuantitativeAssessmentPotentialLosses" bigint,
    "QuantitativeAssessmentTotalLoss" bigint,
    "QualitativeAssessment" character varying(4192),
    "ResponsibleAuditor" integer,
    "TotalAssessmentLevel" integer,
    "PersonCMRecommendations" character varying(4192),
    "PageNumber" integer,
    "SectionAttachment" integer,
    "ViolationContent" character varying,
    "ViolationValuation" integer,
    "ResponsibleController" integer,
    "AuditObjectComments" character varying(2048),
    "AuditObjectFinalAssessment" character varying,
    "ViolationsAndDeficienciesCauses" character varying
);


ALTER TABLE public."tblRemark" OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 16478)
-- Name: tbl_audit_log_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."tblAuditLog" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."tbl_audit_log_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 212 (class 1259 OID 16480)
-- Name: tbl_controlled_society_Id_seq1; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."tblAuditObject" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."tbl_controlled_society_Id_seq1"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 213 (class 1259 OID 16482)
-- Name: tbl_email_template_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."tblEmailTemplate" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."tbl_email_template_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 214 (class 1259 OID 16484)
-- Name: tbl_user_Id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."tblUser" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."tbl_user_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 215 (class 1259 OID 16486)
-- Name: tbl_user_role_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."tblUserRole" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public.tbl_user_role_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 219 (class 1259 OID 16604)
-- Name: vwAudit; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public."vwAudit" AS
 SELECT tau."Id",
    tau."BusinessProcess",
    tau."Name",
    tau."VerificationPeriodStart",
    tau."VerificationPeriodStop",
    tau."GroundForVerification",
    tau."parPlanScheduleOfControlEvent" AS "ParPlanScheduleOfControlEvent",
    tau."filePlanScheduleOfControlEvent	" AS "FilePlanScheduleOfControlEvent",
    tau."numLocalRegulatory" AS "NumLocalRegulatory",
    tau."fileLocalRegulatory" AS "FileLocalRegulatory",
    tau."VerificationPeriod",
    tau."VerificationTermStart",
    tau."VerficationTermEnd",
    tau."NumberAndDateLocRegPrepare",
    tau."NumberAndDateLocRegAcceptance",
    tau."CAPMonitoringCompletedOnDate",
    tau."NextCAPMonitoringDate",
    tau."CAPMonitoringCompleteDate",
    tas."Position" AS "AuditSubjectPos",
    tas."Name" AS "AuditSubjectName",
    tmp."Position" AS "MonitoringProgressStatusPos",
    tmp."Name" AS "MonitoringProgressStatusName",
    tao."Id" AS "AuditObjectId",
    tao."Name" AS "AuditObjectName",
    tre."Id" AS "ResponsibleEmployeeId",
    tre."FirstName" AS "ResponsibleEmployeeFirstName",
    tre."LastName" AS "ResponsibleEmployeeLastName",
    tre."Patronymic" AS "ResponsibleEmployeePatronymic",
    tre."EMail" AS "ResponsibleEmployeeEmail",
    tsp."Id" AS "AuditSuperviserId",
    tsp."FirstName" AS "AuditSuperviserFirstName",
    tsp."LastName" AS "AuditSuperviserLastName",
    tsp."Patronymic" AS "AuditSuperviserPatronymic",
    tsp."EMail" AS "AuditSuperviserEmail"
   FROM (((((public."tblAudit" tau
     LEFT JOIN public."tblDictionaryValue" tas ON (((tau."AuditSubject" = tas."Position") AND (tas."Dictionary" = 3))))
     LEFT JOIN public."tblDictionaryValue" tmp ON (((tau."MonitoringProgressStatus" = tmp."Position") AND (tmp."Dictionary" = 4))))
     LEFT JOIN public."tblAuditObject" tao ON ((tau."AuditObject" = tao."Id")))
     LEFT JOIN public."tblUser" tre ON ((tau."ResponsibleEmployee" = tre."Id")))
     LEFT JOIN public."tblUser" tsp ON ((tau."AuditSuperviser" = tsp."Id")));


ALTER TABLE public."vwAudit" OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16493)
-- Name: vwCorrectiveAction; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public."vwCorrectiveAction" AS
 SELECT tca."Id",
    tca."Audit",
    tca."Name",
    tca."ExecutiveOfficerFirstName",
    tca."ExecutiveOfficerLastName",
    tca."ExecutiveOfficerPatronymic",
    tca."PlannedResultOfCorrectiveAction",
    tca."CADevelopmentEvaluation",
    tca."NotDevelopmentCAComment",
    tca."EvaluationAccordRecomForPrepOfCA",
    tca."EvalAccordRecomForPrepOfCAComment",
    tca."CAInAccordOrderOfVerifObject",
    tca."FactPeriodOfCAExecution",
    tca."EvaluationCheckMarkOnCA",
    tca."ReportImplementOfTheApprovedCA",
    tca."CorrectiveActionState",
    tca."CorrectiveActionStateComment",
    tca."ConclusionCorrectiveActionEffectEvaluation",
    tca."CorrectiveActionEffectEvaluation",
    tca."UsedRecommendationInPCA",
    tca."CommentOnUsedRecommendationInPCA",
    tca."EvaluationOfPostControlNeed",
    tca."MonitoringOfficerFirstName",
    tca."MonitoringOfficerLastName",
    tca."MonitoringOfficerPatronymic",
    tca."Note",
    tca."PlannedExecutionDate",
    tca."CorrectiveActionType"
   FROM (((public."tblCorrectiveAction" tca
     LEFT JOIN public."tblDictionaryValue" tec ON (((tca."EvaluationCheckMarkOnCA" = tec."Position") AND (tec."Dictionary" = 8))))
     LEFT JOIN public."tblDictionaryValue" tce ON (((tca."CorrectiveActionEffectEvaluation" = tce."Position") AND (tce."Dictionary" = 9))))
     LEFT JOIN public."tblDictionaryValue" tas ON (((tca."CorrectiveActionState" = tas."Position") AND (tas."Dictionary" = 10))));


ALTER TABLE public."vwCorrectiveAction" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16498)
-- Name: vwEmailTemplate; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public."vwEmailTemplate" AS
 SELECT tet."Id",
    tet."Template",
    tet."Description",
    ttt."Position" AS "TypePos",
    ttt."Name" AS "TypeName"
   FROM (public."tblEmailTemplate" tet
     LEFT JOIN public."tblDictionaryValue" ttt ON (((tet."Type" = ttt."Position") AND (ttt."Dictionary" = 11))));


ALTER TABLE public."vwEmailTemplate" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16502)
-- Name: vwRemark; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public."vwRemark" WITH (security_barrier='false') AS
 SELECT tr."Id",
    tr."ReportSubsectionNumber",
    tr."RemarkType",
    tr."RemarkDescription",
    tr."RevealedRemarkReason",
    tr."RevealedRemarkConsequences",
    tr."QuantitativeAssessmentLossesRealized",
    tr."QuantitativeAssessmentPotentialLosses",
    tr."QuantitativeAssessmentTotalLoss",
    tr."QualitativeAssessment",
    tr."ResponsibleAuditor",
    tr."TotalAssessmentLevel",
    tr."PersonCMRecommendations",
    tr."PageNumber",
    tr."SectionAttachment",
    tr."ViolationContent",
    tr."ViolationValuation",
    tr."AuditObjectComments",
    tr."AuditObjectFinalAssessment",
    tr."ViolationsAndDeficienciesCauses",
    ta."Id" AS "ResponsibleAuditorId",
    ta."FirstName" AS "ResponsibleAuditorFirstName",
    ta."LastName" AS "ResponsibleAuditorLastName",
    ta."Patronymic" AS "ResponsibleAuditorPatronymic",
    tc."Id" AS "ResponsibleControllerId",
    tc."FirstName" AS "ResponsibleControllerFirstName",
    tc."LastName" AS "ResponsibleControllerLastName",
    tc."Patronymic" AS "ResponsibleControllerPatronymic",
    tbp."Position" AS "BusinessProcessPos",
    tbp."Name" AS "BusinessProcessName",
    tbp."Position" AS "TotalAssessmentLevelPos",
    tbp."Name" AS "TotalAssessmentLevelName",
    tbp."Position" AS "RemarkTypePos",
    tbp."Name" AS "RemarkTypeName"
   FROM (((((public."tblRemark" tr
     LEFT JOIN public."tblUser" ta ON ((tr."ResponsibleAuditor" = ta."Id")))
     LEFT JOIN public."tblUser" tc ON ((tr."ResponsibleController" = tc."Id")))
     LEFT JOIN public."tblDictionaryValue" tbp ON (((tr."BusinessProcess" = tbp."Position") AND (tbp."Dictionary" = 5))))
     LEFT JOIN public."tblDictionaryValue" tav ON (((tr."TotalAssessmentLevel" = tav."Position") AND (tav."Dictionary" = 6))))
     LEFT JOIN public."tblDictionaryValue" trt ON (((tr."RemarkType" = trt."Position") AND (trt."Dictionary" = 7))));


ALTER TABLE public."vwRemark" OWNER TO postgres;

--
-- TOC entry 2966 (class 0 OID 16443)
-- Dependencies: 204
-- Data for Name: tblAudit; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblAudit" ("Id", "Name", "AuditObject", "VerificationPeriodStart", "VerificationPeriodStop", "GroundForVerification", "parPlanScheduleOfControlEvent", "filePlanScheduleOfControlEvent	", "numLocalRegulatory", "fileLocalRegulatory", "VerificationPeriod", "VerificationTermStart", "VerficationTermEnd", "ResponsibleEmployee", "NumberAndDateLocRegPrepare", "NumberAndDateLocRegAcceptance", "CAPMonitoringCompletedOnDate", "NextCAPMonitoringDate", "AuditSubject", "MonitoringProgressStatus", "CAPMonitoringCompleteDate", "AuditSuperviser", "BusinessProcess") FROM stdin;
1	Тестовый аудит 1	1	2019-07-01 00:00:00+03	2019-07-31 00:00:00+03	Тут обоснование почему начали проверку	11.3	\N	10.3	\N	2019	2019-07-01 00:00:00+03	01.07.2019	2	10 и  10.07.2019	20 и 20.07.2019	2019-07-31 00:00:00+03	2019-10-30 00:00:00+03	1	1	2019-07-30 00:00:00+03	3	1
\.


--
-- TOC entry 2961 (class 0 OID 16394)
-- Dependencies: 196
-- Data for Name: tblAuditLog; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblAuditLog" ("Id", "Time", "User", "Screen", "Action", "Description") FROM stdin;
2	2019-07-03 00:00:00+03	1	1	1	фвыаафав
1	2019-07-04 03:00:00+03	1	1	1	ipugpiupi
3	2019-07-04 23:00:00+03	1	1	1	во
\.


--
-- TOC entry 2967 (class 0 OID 16449)
-- Dependencies: 205
-- Data for Name: tblAuditObject; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblAuditObject" ("Id", "Name") FROM stdin;
2	ФГУП Микро
1	ООО Тест
\.


--
-- TOC entry 2968 (class 0 OID 16452)
-- Dependencies: 206
-- Data for Name: tblCorrectiveAction; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblCorrectiveAction" ("Id", "Audit", "Name", "ExecutiveOfficerFirstName", "ExecutiveOfficerLastName", "ExecutiveOfficerPatronymic", "PlannedResultOfCorrectiveAction", "CADevelopmentEvaluation", "NotDevelopmentCAComment", "EvaluationAccordRecomForPrepOfCA", "EvalAccordRecomForPrepOfCAComment", "CAInAccordOrderOfVerifObject", "FactPeriodOfCAExecution", "EvaluationCheckMarkOnCA", "ReportImplementOfTheApprovedCA", "CorrectiveActionState", "CorrectiveActionStateComment", "ConclusionCorrectiveActionEffectEvaluation", "CorrectiveActionEffectEvaluation", "UsedRecommendationInPCA", "CommentOnUsedRecommendationInPCA", "EvaluationOfPostControlNeed", "MonitoringOfficerFirstName", "MonitoringOfficerLastName", "MonitoringOfficerPatronymic", "Note", "PlannedExecutionDate", "CorrectiveActionType") FROM stdin;
1	1	Замена токарных станков ХХХ	Валентин	Странный	Петрович	замена всех станков xxx на yyy	тут оценка выполнения корр мер	тут некий коммент не производственный	рекомендации к подготовке	комментарий по рекомендации к подготовке	корр мер в порядке соотв проверямому объекту	2019	2	тут отчет по примененному корр мер	4	комментарий к состоянию корр мер	заключение по эффективности корр мер	2	t	да корр мер полезен	оценка необходимости последующего контроля	Артур	Другов	Евгеньевич	тут какой-то текст	2019-07-31 00:00:00+03	2
\.


--
-- TOC entry 2969 (class 0 OID 16458)
-- Dependencies: 207
-- Data for Name: tblDictionary; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblDictionary" ("Id", "Name", "EngName4Code", "Description") FROM stdin;
2	Экран	Screen4AuditLog	\N
1	Действие в логе аудита	Action4AuditLog	\N
3	Субъект аудита	AuditSubject	\N
4	Статус проведения мониторинга	MonitoringProgressStatus	\N
5	Бизнес процесс	BusinessProcess	\N
6	Итоговый уровень оценки замечания	TotalAssessmentLevel	\N
7	Тип замечания	RemarkType	\N
8	Отметка объекта проверки о выполнении мероприятия	EvaluationCheckMarkOnCA	\N
9	Оценка эффективности выполнения мероприятия	CorrectiveActionEffectEvaluation	\N
10	Статус выполнения корректирующего мероприятия 	CorrectiveActionState	\N
11	Тип шаблона почты	EMailTemplateType	\N
12	Тег шаблона E-Mail	EMailTemplateTag	\N
13	Ошибки преобразования шаблона в письмо	EMailConvertingError	\N
\.


--
-- TOC entry 2962 (class 0 OID 16400)
-- Dependencies: 197
-- Data for Name: tblDictionaryValue; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblDictionaryValue" ("Name", "EngName4Code", "Position", "Dictionary", "Id", "Description") FROM stdin;
СВА	SVA	1	3	1	\N
Пост-контроль для внешних проверок	PostControl4ExternalAudits	2	5	2	\N
Пост-контроль для внутренних проверок	PostControl4InternalAudits	1	5	3	\N
Умеренная	Moderate	1	6	4	\N
Значимая	Significant	2	6	5	\N
Нарушение	Violation	1	7	6	\N
Выполнено	Done	1	8	7	\N
Уведомление об истечении срока исполнения мероприятия	NotificationExpirationTermOfCAPreformance	5	11	8	\N
Уведомление  о  загрузке  ежеквартального Отчета об исполнении ПКМ	NotificationAboutDnldQuarterlyReportOnPCAPerform	6	11	9	\N
Загрузка данных	DataLoading	9	1	10	\N
Отмена загрузки данных	CancelDataLoading	10	1	11	\N
Отправка	Send	12	1	12	\N
Блокировка	Lock	13	1	13	\N
Разблокировка	Unlock	14	1	14	\N
Восстановление	Restore	15	1	15	\N
Выгрузка	Unload	16	1	16	\N
Карточка замечания	RemarkForm	11	2	17	\N
Главная страница Системы\\ История изменений	MainScreenHistoryOfChanges	3	2	18	\N
Карточка проверки\\ Общая информация	CAFormCommonInfo	6	2	19	\N
Карточка проверки \\ логирование отправки уведомлений	AuditFormNotificationSendLogging	5	2	20	\N
Карточка проверки\\ Основной рабочий экран\\ Статистика	AuditFormStatistics	10	2	21	\N
Карточка проверки\\ Основной рабочий экран	AuditFormMainScreen	9	2	22	\N
Карточка проверки\\ Хранилище файлов по проверке\\ Превью	AuditFormFileStoragePreview	8	2	23	\N
Карточка проверки\\ Хранилище файлов по проверке	AuditFormFileStorage	7	2	24	\N
Страница авторизации 	AuthorizationScreen	1	2	25	\N
Главная страница Системы	MainScreen	2	2	26	\N
Просмотр истории	ViewHistory	6	1	27	\N
Создание	Create	1	1	28	\N
Просмотр карточки	Read	2	1	29	\N
Редактирование	Update	3	1	30	\N
Просмотр файла	FileView	17	1	31	\N
Неэффективно	Inefficient	2	9	33	\N
Вторичная верификация	SecondaryVerification	4	4	34	\N
Исполнение	Execution	1	10	35	\N
ДКиУР	DkIUr	2	3	36	\N
Импортирование	Import	11	1	37	\N
Критическая	Critical	3	6	38	\N
Недостаток	Disadvantage	2	7	39	\N
В стадии исполнения	InProgress	3	8	40	\N
Не выполнено	NotDone	2	8	41	\N
Запрос РП на внесение замечаний	Request4AddRemarks	1	11	42	\N
Эффективно	Effectively	1	9	43	\N
Запрос ответственному  сотруднику  Объекта проверки на внесение 	Req2RespPersonSubjectAuditor	2	11	44	\N
Уведомление о приближении срока исполнения мероприятия	NotificationApproachingDateOfCAPreformance	3	11	45	\N
Уведомление о наступлении срока исполнения мероприятия	NotificationAboutMaturityDateOfCAPreformance	4	11	46	\N
Удаление	Delete	4	1	47	\N
Формирование	Formation	1	4	48	\N
ПКМ сформирован	PCAIsFormed	2	4	49	\N
Первичная верификация	PrimaryVerification	3	4	50	\N
Загрузка рабочего экрана	List	5	1	51	\N
Экспортирование отчета	Export	7	1	52	\N
Изменение пароля	ChangePassword	8	1	53	\N
Поиск	Find	18	1	54	\N
Просмотр файлов	ViewingFiles	19	1	55	\N
Создание новой учетной записи	CreateNewAccount	20	1	56	\N
Глобальный поиск	GlobalSearch	4	2	57	\N
Карточка мероприятия	CorrectiveActionForm	12	2	58	\N
Доработка	Revision	5	4	59	\N
Карточка мероприятия\\ Список файлов	CAFormFileList	14	2	60	\N
Карточка мероприятия\\ Комментарии	CAFormComments	13	2	61	\N
Администрирование\\ Настройка шаблонов	AdminTemplateTuning	17	2	62	\N
Администрирование\\ Журнал аудита	AdminAuditLog	16	2	63	\N
Администрирование\\ Управление пользователями	AdminUserManagement	15	2	64	\N
Просрочено	Expired	2	10	65	\N
Первичная верификация	PrimaryVerification	3	10	66	\N
Вторичная верификация	SecondaryVerification	4	10	67	\N
Доработка	Revision	5	10	68	\N
Исполнено в срок	ExecutedOnTime	6	10	69	\N
Исполнено с нарушением срока	ExecutedInDeadlineViolation	7	10	70	\N
Отсутствует	Missing	8	10	71	\N
Не выполнено	NotPerformed	9	10	72	\N
Завершен	Completed	6	4	32	\N
Аудит.Основание	EMailTemplateTag4Audit_Ground	4	12	76	Основание для проверки
Аудит.Период	EMailTemplateTag4Audit_Period	3	12	75	Проверяемый период
Аудит.Объект	EMailTemplateTag4Audit_Object	2	12	74	Объект проверки
Аудит.Наименование	EMailTemplateTag4Audit_Name	1	12	73	Наименование проверки
ЗамечаниеВнуП.ПодраздОтчета	EMailTemplateTag4RemarkInternalAudit_ReportSubsNum	5	12	77	№ подраздела отчета
ЗамечаниеВнуП.Описание	EMailTemplateTag4RemarkInternalAudit_Description	6	12	79	Описание замечания
ЗамечаниеВнеП.РазделПрил	EMailTemplateTag4RemarkExternalAudit_SectAttach	7	12	80	Раздел/приложение
ЗамечаниеВнеП.СодНаруш	EMailTemplateTag4RemarkExternalAudit_ViolaContent	8	12	81	Содержание нарушения
МероприятиеВнуП.КоррМер	EMailTemplateTag4CAInternalAudit_CA	9	12	82	Корректирующее мероприятие
МероприятиеВнуП.ПланСрок	EMailTemplateTag4CAInternalAudit_PlanExeDate	10	12	83	Плановый срок исполнения мероприятия
МероприятиеВнуП.ОтвИспФИО	EMailTemplateTag4CAInternalAudit_ExecOfficer	11	12	84	Ответственный исполнитель(ФИО)
МероприятиеВнуП.ФактСрокИсп	EMailTemplateTag4CAInternalAudit_FactExePeriod	12	12	85	Фактический срок исполнения мероприятия
МероприятиеВнеП.КоррМер	EMailTemplateTag4CAExternalAudit_CA	13	12	87	Корректирующее мероприятие
МероприятиеВнеП.УстСрок	EMailTemplateTag4CAExternalAudit_PlanExeDate	14	12	88	Установленные сроки реализации мероприятий
МероприятиеВнеП.ОтвИспФИО	EMailTemplateTag4CAExternalAudit_ExecOfficer	15	12	89	Ответственный исполнитель(ФИО)
МероприятиеВнеП.ФактСрокИсп	EMailTemplateTag4CAExternalAudit_FactExePeriod	16	12	90	Фактический срок исполнения мероприятия
Тег не найден	EMailConverterError_TagNotFound	1	13	91	
Тег не был завершен правильно	EMailConverterError_TagNotFinishedProperly	2	13	92	
Тег был прерван пробелом, концом строки, концом сообщения	EMailConverterError_TagTerminatedBySpaceOrEof	3	13	93	
\.


--
-- TOC entry 2971 (class 0 OID 16466)
-- Dependencies: 209
-- Data for Name: tblEmailTemplate; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblEmailTemplate" ("Id", "Type", "Template", "Description") FROM stdin;
\.


--
-- TOC entry 2964 (class 0 OID 16419)
-- Dependencies: 200
-- Data for Name: tblFileStorage; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblFileStorage" ("Id", "Name", "Extention", "LoadingTime", "User", "PathToPreview", "PathToFile", "Audit") FROM stdin;
\.


--
-- TOC entry 2972 (class 0 OID 16472)
-- Dependencies: 210
-- Data for Name: tblRemark; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblRemark" ("Id", "ReportSubsectionNumber", "BusinessProcess", "RemarkType", "RemarkDescription", "RevealedRemarkReason", "RevealedRemarkConsequences", "QuantitativeAssessmentLossesRealized", "QuantitativeAssessmentPotentialLosses", "QuantitativeAssessmentTotalLoss", "QualitativeAssessment", "ResponsibleAuditor", "TotalAssessmentLevel", "PersonCMRecommendations", "PageNumber", "SectionAttachment", "ViolationContent", "ViolationValuation", "ResponsibleController", "AuditObjectComments", "AuditObjectFinalAssessment", "ViolationsAndDeficienciesCauses") FROM stdin;
1	10	1	2	описание замечания	причина	последствия	300000	500000	700000	количественная оценка - 800000	4	2	щшгнпнпгн	3	5	ущерб случился из-за ...	300000	5	комментарии к объекуту аудита	финальная оценка: удовлетворительно	причина проблем...
\.


--
-- TOC entry 2963 (class 0 OID 16406)
-- Dependencies: 198
-- Data for Name: tblUser; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblUser" ("Id", "FirstName", "LastName", "Patronymic", "Login", "PasswordSalt", "PasswordHash", "AccessGranted", "EMail", "Role", "VerificationObject") FROM stdin;
1	Иван	Иванов	Иванович	ivan	87326321	23082368326	t	some@mail.ru	1	\N
2	Иван	Мосько	Игнатьевич	mosko	8347326321	2354082425368326	t	mosko_iv@mail.ru	7	1
3	Валера	Желейный	Потапович	valera	254623	4584789314643	t	jm_valera@mail.ru	4	1
5	Лизавета	Утубная	Федоровна	liza	4536556	52625757457	t	uf_liza@mail.ru	6	1
4	Соня	Медийная	Мартыновна	sonja	9814	14987413487	t	mm_sonja@mail.ru	5	1
\.


--
-- TOC entry 2965 (class 0 OID 16425)
-- Dependencies: 201
-- Data for Name: tblUserRole; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."tblUserRole" ("Id", "Name", "Comment", "IsAuditOjectRestricted") FROM stdin;
7	Ответственный сотрудник объекта проверки	Имеет доступ к сущностям только своего объекта проверки	t
1	Администратор	Имеет доступ ко всему в системе. Обычно нужен, чтобы управлять пользователями	f
2	Оператор внутренней проверки	Имеет доступ к необходимым по БП сущностям всех объектов проверки	f
3	Оператор внешней проверки	Имеет доступ к необходимым по БП сущностям всех объектов проверки	f
4	Руководитель проверки	Имеет доступ к необходимым по БП сущностям всех объектов проверки	f
5	Аудитор	Имеет доступ к необходимым по БП сущностям всех объектов проверки	f
6	Контролер	Имеет доступ к необходимым по БП сущностям всех объектов проверки	f
\.


--
-- TOC entry 2984 (class 0 OID 0)
-- Dependencies: 208
-- Name: tblDictionaryValue_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."tblDictionaryValue_Id_seq"', 93, true);


--
-- TOC entry 2985 (class 0 OID 0)
-- Dependencies: 211
-- Name: tbl_audit_log_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."tbl_audit_log_Id_seq"', 95, true);


--
-- TOC entry 2986 (class 0 OID 0)
-- Dependencies: 212
-- Name: tbl_controlled_society_Id_seq1; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."tbl_controlled_society_Id_seq1"', 1, false);


--
-- TOC entry 2987 (class 0 OID 0)
-- Dependencies: 213
-- Name: tbl_email_template_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."tbl_email_template_Id_seq"', 1, false);


--
-- TOC entry 2988 (class 0 OID 0)
-- Dependencies: 214
-- Name: tbl_user_Id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."tbl_user_Id_seq"', 1, false);


--
-- TOC entry 2989 (class 0 OID 0)
-- Dependencies: 215
-- Name: tbl_user_role_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tbl_user_role_id_seq', 1, false);


--
-- TOC entry 2789 (class 2606 OID 16508)
-- Name: tblDictionaryValue pk_id; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblDictionaryValue"
    ADD CONSTRAINT pk_id PRIMARY KEY ("Id");


--
-- TOC entry 2804 (class 2606 OID 16510)
-- Name: tblUserRole pk_tbl_user_role_id; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblUserRole"
    ADD CONSTRAINT pk_tbl_user_role_id PRIMARY KEY ("Id");


--
-- TOC entry 2810 (class 2606 OID 16512)
-- Name: tblCorrectiveAction tblCorrectiveAction _pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblCorrectiveAction"
    ADD CONSTRAINT "tblCorrectiveAction _pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2812 (class 2606 OID 16514)
-- Name: tblDictionary tblDictionary_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblDictionary"
    ADD CONSTRAINT "tblDictionary_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2814 (class 2606 OID 16516)
-- Name: tblEmailTemplate tblEmailTemplate_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblEmailTemplate"
    ADD CONSTRAINT "tblEmailTemplate_pkey" PRIMARY KEY ("Id");


--
-- TOC entry 2782 (class 2606 OID 16518)
-- Name: tblAuditLog tbl_audit_log_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblAuditLog"
    ADD CONSTRAINT tbl_audit_log_pkey PRIMARY KEY ("Id");


--
-- TOC entry 2806 (class 2606 OID 16520)
-- Name: tblAudit tbl_audit_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblAudit"
    ADD CONSTRAINT tbl_audit_pkey PRIMARY KEY ("Id");


--
-- TOC entry 2808 (class 2606 OID 16522)
-- Name: tblAuditObject tbl_controlled_society_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblAuditObject"
    ADD CONSTRAINT tbl_controlled_society_pkey PRIMARY KEY ("Id");


--
-- TOC entry 2796 (class 2606 OID 16524)
-- Name: tblFileStorage tbl_file_storage_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblFileStorage"
    ADD CONSTRAINT tbl_file_storage_pkey PRIMARY KEY ("Id");


--
-- TOC entry 2816 (class 2606 OID 16526)
-- Name: tblRemark tbl_remark_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblRemark"
    ADD CONSTRAINT tbl_remark_pkey PRIMARY KEY ("Id");


--
-- TOC entry 2793 (class 2606 OID 16528)
-- Name: tblUser tbl_user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblUser"
    ADD CONSTRAINT tbl_user_pkey PRIMARY KEY ("Id");


--
-- TOC entry 2791 (class 2606 OID 16530)
-- Name: tblDictionaryValue uk_Dictionary_Position; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblDictionaryValue"
    ADD CONSTRAINT "uk_Dictionary_Position" UNIQUE ("Dictionary", "Position");


--
-- TOC entry 2783 (class 1259 OID 16531)
-- Name: tblauditlog_action_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblauditlog_action_idx ON public."tblAuditLog" USING btree ("Action");


--
-- TOC entry 2784 (class 1259 OID 16532)
-- Name: tblauditlog_screen_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblauditlog_screen_idx ON public."tblAuditLog" USING btree ("Screen");


--
-- TOC entry 2785 (class 1259 OID 16533)
-- Name: tblauditlog_time_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblauditlog_time_idx ON public."tblAuditLog" USING btree ("Time");


--
-- TOC entry 2786 (class 1259 OID 16534)
-- Name: tblauditlog_user_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblauditlog_user_idx ON public."tblAuditLog" USING btree ("User");


--
-- TOC entry 2787 (class 1259 OID 16535)
-- Name: tblauditlog_usertime_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblauditlog_usertime_idx ON public."tblAuditLog" USING btree ("User", "Time");


--
-- TOC entry 2797 (class 1259 OID 16536)
-- Name: tblfilestorage_aextention_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblfilestorage_aextention_idx ON public."tblFileStorage" USING btree ("Audit", "Extention");


--
-- TOC entry 2798 (class 1259 OID 16537)
-- Name: tblfilestorage_altime_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblfilestorage_altime_idx ON public."tblFileStorage" USING btree ("Audit", "LoadingTime");


--
-- TOC entry 2799 (class 1259 OID 16538)
-- Name: tblfilestorage_aname_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblfilestorage_aname_idx ON public."tblFileStorage" USING btree ("Audit", "Name");


--
-- TOC entry 2800 (class 1259 OID 16539)
-- Name: tblfilestorage_anamext_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblfilestorage_anamext_idx ON public."tblFileStorage" USING btree ("Audit", "Name", "Extention");


--
-- TOC entry 2801 (class 1259 OID 16540)
-- Name: tblfilestorage_audit_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblfilestorage_audit_idx ON public."tblFileStorage" USING btree ("Audit");


--
-- TOC entry 2802 (class 1259 OID 16541)
-- Name: tblfilestorage_auser_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX tblfilestorage_auser_idx ON public."tblFileStorage" USING btree ("Audit", "User");


--
-- TOC entry 2794 (class 1259 OID 16542)
-- Name: tbluser_firstname_idx; Type: INDEX; Schema: public; Owner: postgres
--

CREATE UNIQUE INDEX tbluser_firstname_idx ON public."tblUser" USING btree ("FirstName", "LastName", "Patronymic");


--
-- TOC entry 2829 (class 2620 OID 16543)
-- Name: tblAudit triInsUpd_tblAudit; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "triInsUpd_tblAudit" BEFORE INSERT OR UPDATE ON public."tblAudit" FOR EACH ROW EXECUTE PROCEDURE public."fnTriInsUpd_tblAudit"();


--
-- TOC entry 2828 (class 2620 OID 16544)
-- Name: tblAuditLog triInsUpd_tblAuditLog_Action; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "triInsUpd_tblAuditLog_Action" BEFORE INSERT OR UPDATE ON public."tblAuditLog" FOR EACH ROW EXECUTE PROCEDURE public."fnTriInsUpd_tblAuditLog_Action"();


--
-- TOC entry 2830 (class 2620 OID 16545)
-- Name: tblCorrectiveAction triInsUpd_tblCorrectiveAction; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "triInsUpd_tblCorrectiveAction" BEFORE INSERT OR UPDATE ON public."tblCorrectiveAction" FOR EACH ROW EXECUTE PROCEDURE public."fnTriInsUpd_tblCorrectiveAction"();


--
-- TOC entry 2831 (class 2620 OID 16546)
-- Name: tblEmailTemplate triInsUpd_tblEmailTemplate; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "triInsUpd_tblEmailTemplate" BEFORE INSERT OR UPDATE ON public."tblEmailTemplate" FOR EACH ROW EXECUTE PROCEDURE public."fnTriInsUpd_tblEmailTemplate"();


--
-- TOC entry 2832 (class 2620 OID 16547)
-- Name: tblRemark triInsUpd_tblRemark; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "triInsUpd_tblRemark" BEFORE INSERT OR UPDATE ON public."tblRemark" FOR EACH ROW EXECUTE PROCEDURE public."fnTriInsUpd_tblRemark"();


--
-- TOC entry 2825 (class 2606 OID 16548)
-- Name: tblCorrectiveAction fk_CorrAction_Audit; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblCorrectiveAction"
    ADD CONSTRAINT "fk_CorrAction_Audit" FOREIGN KEY ("Audit") REFERENCES public."tblAudit"("Id");


--
-- TOC entry 2822 (class 2606 OID 16553)
-- Name: tblAudit fk_audit_audit_object; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblAudit"
    ADD CONSTRAINT fk_audit_audit_object FOREIGN KEY ("AuditObject") REFERENCES public."tblAuditObject"("Id");


--
-- TOC entry 2817 (class 2606 OID 16558)
-- Name: tblAuditLog fk_audit_log_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblAuditLog"
    ADD CONSTRAINT fk_audit_log_user FOREIGN KEY ("User") REFERENCES public."tblUser"("Id");


--
-- TOC entry 2823 (class 2606 OID 16563)
-- Name: tblAudit fk_audit_resp_employee; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblAudit"
    ADD CONSTRAINT fk_audit_resp_employee FOREIGN KEY ("ResponsibleEmployee") REFERENCES public."tblUser"("Id");


--
-- TOC entry 2824 (class 2606 OID 16568)
-- Name: tblAudit fk_audit_superviser; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblAudit"
    ADD CONSTRAINT fk_audit_superviser FOREIGN KEY ("AuditSuperviser") REFERENCES public."tblUser"("Id");


--
-- TOC entry 2818 (class 2606 OID 16573)
-- Name: tblDictionaryValue fk_dicvalue_dic; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblDictionaryValue"
    ADD CONSTRAINT fk_dicvalue_dic FOREIGN KEY ("Dictionary") REFERENCES public."tblDictionary"("Id");


--
-- TOC entry 2821 (class 2606 OID 16578)
-- Name: tblFileStorage fk_fileStorage_audit; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblFileStorage"
    ADD CONSTRAINT "fk_fileStorage_audit" FOREIGN KEY ("Audit") REFERENCES public."tblAudit"("Id");


--
-- TOC entry 2826 (class 2606 OID 16583)
-- Name: tblRemark fk_remark_resp_contr; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblRemark"
    ADD CONSTRAINT fk_remark_resp_contr FOREIGN KEY ("ResponsibleController") REFERENCES public."tblUser"("Id");


--
-- TOC entry 2827 (class 2606 OID 16588)
-- Name: tblRemark fk_remark_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblRemark"
    ADD CONSTRAINT fk_remark_user FOREIGN KEY ("ResponsibleAuditor") REFERENCES public."tblUser"("Id");


--
-- TOC entry 2819 (class 2606 OID 16593)
-- Name: tblUser fk_tbl_user_role; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblUser"
    ADD CONSTRAINT fk_tbl_user_role FOREIGN KEY ("Role") REFERENCES public."tblUserRole"("Id");


--
-- TOC entry 2820 (class 2606 OID 16598)
-- Name: tblUser fk_tbl_verification_object; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."tblUser"
    ADD CONSTRAINT fk_tbl_verification_object FOREIGN KEY ("VerificationObject") REFERENCES public."tblAuditObject"("Id");


-- Completed on 2019-08-01 23:38:33

--
-- PostgreSQL database dump complete
--

