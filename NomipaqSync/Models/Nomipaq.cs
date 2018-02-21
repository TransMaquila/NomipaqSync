using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using NomipaqSync;

namespace NomipaqSync.Models
{
    static class Nomipaq
    {
        public async static Task<string> Syncronize(string sourceDB = "NOM_TRANSMAQUILA_SA", string targetDB = "NOM_TRANSMAQUILA_MAN")
        {

            string queryString = $@"
                -- --------------------------------------------------------------------------------
                -- Copia la tabla de Empleados [nom10001]
                -- --------------------------------------------------------------------------------


                IF (OBJECT_ID('[{targetDB}].[dbo].[nom10001]') IS NOT NULL)
                BEGIN
                    DROP TABLE [{targetDB}].[dbo].[nom10001]
                END
          
                SELECT * INTO [{targetDB}].[dbo].[nom10001]
                FROM  [{sourceDB}].[dbo].[nom10001] 

                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD CONSTRAINT [PK_nom10001] PRIMARY KEY CLUSTERED  ([idempleado] ASC)
                CREATE NONCLUSTERED INDEX [IDXCODIGOEMPLEADO] ON [{targetDB}].[dbo].[nom10001] ([codigoempleado] ASC)
                CREATE NONCLUSTERED INDEX [IDXDEPTOTIPOPER] ON [{targetDB}].[dbo].[nom10001] ([iddepartamento] ASC,[idtipoperiodo] ASC)
                CREATE NONCLUSTERED INDEX [IDXIDDEPTO] ON [{targetDB}].[dbo].[nom10001] ([iddepartamento] ASC)
                CREATE NONCLUSTERED INDEX [IDXIDDEPTOCODIGO] ON [{targetDB}].[dbo].[nom10001] ([iddepartamento] ASC,[codigoempleado] ASC)
                CREATE NONCLUSTERED INDEX [IDXIDEMPLEADOTIPOPERIODO] ON [{targetDB}].[dbo].[nom10001] ([idempleado] ASC,[idtipoperiodo] ASC)
                CREATE NONCLUSTERED INDEX [IDXNOMBRE] ON [{targetDB}].[dbo].[nom10001] ([nombrelargo] ASC)
                CREATE NONCLUSTERED INDEX [IDXTIPOPERIODO] ON [{targetDB}].[dbo].[nom10001] ([idtipoperiodo] ASC)
                CREATE NONCLUSTERED INDEX [IDXTIPOPERIODOCODIGO] ON [{targetDB}].[dbo].[nom10001] ([idtipoperiodo] ASC,[codigoempleado] ASC)
                CREATE NONCLUSTERED INDEX [IDXTIPOPERIODODEPTO] ON [{targetDB}].[dbo].[nom10001] ([idtipoperiodo] ASC,[iddepartamento] ASC)

                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_calculado]  DEFAULT ((0)) FOR [calculado]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_afectado]  DEFAULT ((0)) FOR [afectado]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_calculadoextraordinario]  DEFAULT ((0)) FOR [calculadoextraordinario]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_afectadoextraordinario]  DEFAULT ((0)) FOR [afectadoextraordinario]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_interfazcheqpaqw]  DEFAULT ((0)) FOR [interfazcheqpaqw]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_modificacionneto]  DEFAULT ((0)) FOR [modificacionneto]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_calculoptu]  DEFAULT ((0)) FOR [calculoptu]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_calculoaguinaldo]  DEFAULT ((0)) FOR [calculoaguinaldo]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_modificacionsalarioimss]  DEFAULT ((0)) FOR [modificacionsalarioimss]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_altaimss]  DEFAULT ((0)) FOR [altaimss]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_bajaimss]  DEFAULT ((0)) FOR [bajaimss]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  CONSTRAINT [DF_nom10001_cambiocotizacionimss]  DEFAULT ((0)) FOR [cambiocotizacionimss]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  DEFAULT ('') FOR [EntidadFederativa]
                ALTER TABLE [{targetDB}].[dbo].[nom10001] ADD  DEFAULT ('0') FOR [Subcontratacion]
            -- GO
  
                -- --------------------------------------------------------------------------------
                -- Copia la tabla de Vacaciones [nom10014]
                -- --------------------------------------------------------------------------------


                IF (OBJECT_ID('[{targetDB}].[dbo].[nom10014]') IS NOT NULL)
                BEGIN
                    DROP TABLE [{targetDB}].[dbo].[nom10014]
                END
                SELECT * INTO [{targetDB}].[dbo].[nom10014]
                FROM  [{sourceDB}].[dbo].[nom10014]


                ALTER TABLE [{targetDB}].[dbo].[nom10014] ADD CONSTRAINT [PK_nom10014] PRIMARY KEY CLUSTERED  ([idtcontrolvacaciones] ASC)
                CREATE NONCLUSTERED INDEX [IDXEJERCICIOEMPLEADO] ON [{targetDB}].[dbo].[nom10014] ([ejercicio] ASC,[idempleado] ASC)
                CREATE NONCLUSTERED INDEX [IDXEMPLEADO] ON [{targetDB}].[dbo].[nom10014] ([idempleado] ASC)
                CREATE NONCLUSTERED INDEX [IDXEMPLEADOFECHAINICIO] ON [{targetDB}].[dbo].[nom10014] ([idempleado] ASC,[fechainicio] ASC)
                CREATE NONCLUSTERED INDEX [IDXFECHAINICIO] ON [{targetDB}].[dbo].[nom10014] ([fechainicio] ASC)

               

            -- GO

                -- --------------------------------------------------------------------------------
                -- Copia la tabla de Control de Incapacidades [nom10018]
                -- --------------------------------------------------------------------------------


                IF (OBJECT_ID('[{targetDB}].[dbo].[nom10018]') IS NOT NULL)
                BEGIN
                    DROP TABLE [{targetDB}].[dbo].[nom10018]
             
                END
                SELECT * INTO [{targetDB}].[dbo].[nom10018]
                FROM  [{sourceDB}].[dbo].[nom10018]

                CREATE NONCLUSTERED INDEX [IDXEMPLEADO] ON [{targetDB}].[dbo].[nom10018] ([idempleado] ASC)
                CREATE NONCLUSTERED INDEX [IDXEMPLEADOFOLIO] ON [{targetDB}].[dbo].[nom10018] ([idempleado] ASC,[folio] ASC)
                CREATE NONCLUSTERED INDEX [IDXEMPLEADONUMEROCASO] ON [{targetDB}].[dbo].[nom10018] ([idempleado] ASC,[numerocaso] ASC)
                CREATE NONCLUSTERED INDEX [IDXFOLIO] ON [{targetDB}].[dbo].[nom10018] ([folio] ASC)

                ALTER TABLE [{targetDB}].[dbo].[nom10018] ADD  CONSTRAINT [DF_nom10018_fincaso]  DEFAULT ((0)) FOR [fincaso]
                ALTER TABLE [{targetDB}].[dbo].[nom10018] ADD  CONSTRAINT [DF_nom10018_controlmaternidad]  DEFAULT ((0)) FOR [controlmaternidad]
          
            -- GO

                -- --------------------------------------------------------------------------------
                -- Copia la tabla de Tipos de Incidencias [nom10001]
                -- --------------------------------------------------------------------------------

                IF (OBJECT_ID('[{targetDB}].[dbo].[nom10022]') IS NOT NULL)
                BEGIN
                    DROP TABLE [{targetDB}].[dbo].[nom10022]
                END
                SELECT * INTO [{targetDB}].[dbo].[nom10022]
                FROM  [{sourceDB}].[dbo].[nom10022]

                ALTER TABLE [{targetDB}].[dbo].[nom10022] ADD CONSTRAINT [PK_nom10022] PRIMARY KEY CLUSTERED  ([idtipoincidencia] ASC)
                CREATE NONCLUSTERED INDEX [IDXDESCRIPCION] ON [{targetDB}].[dbo].[nom10022] ([descripcion] ASC)
                CREATE NONCLUSTERED INDEX [IDXMNEMONICO] ON [{targetDB}].[dbo].[nom10022] ([mnemonico] ASC)
                CREATE NONCLUSTERED INDEX [IDXTIPOINCIDENCIA] ON [{targetDB}].[dbo].[nom10022] ([tipoincidencia] ASC)
                ALTER TABLE [{targetDB}].[dbo].[nom10022] ADD  CONSTRAINT [DF_nom10022_derechosueldo]  DEFAULT ((0)) FOR [derechosueldo]
                ALTER TABLE [{targetDB}].[dbo].[nom10022] ADD  CONSTRAINT [DF_nom10022_derechoseptimodia]  DEFAULT ((0)) FOR [derechoseptimodia]
   
            -- GO

                -- --------------------------------------------------------------------------------
                -- Copia la tabla de Incidencias [nom10001]
                -- --------------------------------------------------------------------------------

                IF (OBJECT_ID('[{targetDB}].[dbo].[nom10010]') IS NOT NULL)
                BEGIN
                    DROP TABLE [{targetDB}].[dbo].[nom10010]
                END
                SELECT * INTO [{targetDB}].[dbo].[nom10010]
                FROM  [{sourceDB}].[dbo].[nom10010]

                ALTER TABLE [{targetDB}].[dbo].[nom10010] ADD CONSTRAINT [PK_nom10010] PRIMARY KEY CLUSTERED  ([idmovtodyh] ASC)
                CREATE NONCLUSTERED INDEX [IDXEMPLEADO] ON [{targetDB}].[dbo].[nom10010] ([idempleado] ASC)
                CREATE NONCLUSTERED INDEX [IDXEMPLEADOFECHA] ON [{targetDB}].[dbo].[nom10010] ([idempleado] ASC,[fecha] ASC)
                CREATE NONCLUSTERED INDEX [IDXEMPLEADOFECHADESC] ON [{targetDB}].[dbo].[nom10010] ([idempleado] DESC,[fecha] DESC)
                CREATE NONCLUSTERED INDEX [IDXEMPLEADOPERIODO] ON [{targetDB}].[dbo].[nom10010] ([idperiodo] ASC,[idempleado] ASC)
                CREATE NONCLUSTERED INDEX [IDXIDFECHA] ON [{targetDB}].[dbo].[nom10010] ([idperiodo] ASC,[fecha] ASC)
                CREATE NONCLUSTERED INDEX [IDXIDPERIODO] ON [{targetDB}].[dbo].[nom10010] ([idperiodo] ASC)
                CREATE NONCLUSTERED INDEX [IDXIDTARJETAINCAPACIDAD] ON [{targetDB}].[dbo].[nom10010] ([idtarjetaincapacidad] ASC)
                CREATE NONCLUSTERED INDEX [IDXIDTCONTROLVACACIONES] ON [{targetDB}].[dbo].[nom10010] ([idtcontrolvacaciones] ASC)
                CREATE NONCLUSTERED INDEX [IDXPEREMPINC] ON [{targetDB}].[dbo].[nom10010] ([idperiodo] ASC,[idempleado] ASC,[idtipoincidencia] ASC)
                CREATE NONCLUSTERED INDEX [IDXPEREMPINCFEC] ON [{targetDB}].[dbo].[nom10010] ([idperiodo] ASC,[idempleado] ASC,[idtipoincidencia] ASC,[fecha] ASC)

            -- GO";

            string totalRecords =  await DAL.Execute(queryString);

            return totalRecords;
        }

        public async static Task<string> Transfer(string sourceDB = "NOM_TRANSMAQUILA_SA", string targetDB = "NOM_TRANSMAQUILA_MAN")
        {

            string queryString = $@"
                DECLARE @numeroperiodoTmp   INT = ( SELECT posicionpagonomina FROM [{targetDB}].[dbo].[nom10023] where nombretipoperiodo='Semanal' )
                DECLARE @Ejercicio          INT = ( SELECT ejercicio FROM [{targetDB}].[dbo].[nom10023] where nombretipoperiodo='Semanal' )
                DECLARE @IdPeriodo          INT = ( SELECT TOP 1 [idperiodo] FROM [{sourceDB}].[dbo].[nom10002] WHERE numeroperiodo=@numeroperiodoTmp and ejercicio=@Ejercicio ORDER BY timestamp desc )
                DECLARE @DebitChargeAccount INT = ( SELECT TOP 1 [idconcepto] FROM [{targetDB}].[dbo].[nom10004] WHERE descripcion='Neto Nomina Fiscal' )
                DECLARE @NetPayIdAccount    INT = ( SELECT TOP 1 [idconcepto] FROM [{sourceDB}].[dbo].[nom10004] WHERE descripcion='Neto' )

                DELETE [{targetDB}].[dbo].[nom10008]
                WHERE idperiodo=@IdPeriodo and idconcepto=@DebitChargeAccount
                -- SELECT * from [{targetDB}].[dbo].[nom10008]
                INSERT INTO [{targetDB}].[dbo].[nom10008] (
                    [idperiodo],[idempleado],[idconcepto],[idmovtopermanente],[importetotal],[valor],[importe1],[importe2]
                      ,[importe3],[importe4],[importetotalreportado],[importe1reportado],[importe2reportado],[importe3reportado]
                      ,[importe4reportado],[timestamp]
                      )
                SELECT   a.[idperiodo], a.[idempleado],  @DebitChargeAccount [idconcepto], 0, a.[importetotal],0,0,0,0,0,1,0,0,0,0,CURRENT_TIMESTAMP
                FROM [{sourceDB}].[dbo].[nom10008] a
	                INNER JOIN [{sourceDB}].[dbo].[nom10001] b on a.[idempleado]=b.[idempleado] 
                WHERE a.idperiodo =@IdPeriodo AND a.idconcepto = @NetPayIdAccount AND b.estadoempleado <> 'B'
                ";

            string totalRecords = await DAL.Execute(queryString);
            return totalRecords.ToString();
        }

    }
}
