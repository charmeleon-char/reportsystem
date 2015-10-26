﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class ReportSupEntities1 : DbContext
    {
        public ReportSupEntities1()
            : base("name=ReportSupEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Checkinout> Checkinouts { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Userinfo> Userinfoes { get; set; }
        public DbSet<AddTimeSet> AddTimeSets { get; set; }
        public DbSet<BasePara> BaseParas { get; set; }
        public DbSet<CheckLog> CheckLogs { get; set; }
        public DbSet<DefineField> DefineFields { get; set; }
        public DbSet<Dept> Depts { get; set; }
        public DbSet<FingerClient> FingerClients { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<LeaveClass> LeaveClasses { get; set; }
        public DbSet<MemStat> MemStats { get; set; }
        public DbSet<OPinfo> OPinfoes { get; set; }
        public DbSet<OPLog> OPLogs { get; set; }
        public DbSet<OutProg> OutProgs { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<StatItem> StatItems { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<T_Checkinout> T_Checkinout { get; set; }
        public DbSet<T_UpdateClient> T_UpdateClient { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<UserCtrlLog> UserCtrlLogs { get; set; }
        public DbSet<UserLeave> UserLeaves { get; set; }
        public DbSet<UserPower> UserPowers { get; set; }
        public DbSet<UserTempShift> UserTempShifts { get; set; }
        public DbSet<V_Class> V_Class { get; set; }
        public DbSet<V_Record> V_Record { get; set; }
        public DbSet<V_UserClient> V_UserClient { get; set; }
    
        public virtual ObjectResult<EmployesUnleash_Result> EmployesUnleash(string fecha, string deptid)
        {
            var fechaParameter = fecha != null ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(string));
    
            var deptidParameter = deptid != null ?
                new ObjectParameter("deptid", deptid) :
                new ObjectParameter("deptid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmployesUnleash_Result>("EmployesUnleash", fechaParameter, deptidParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual ObjectResult<sp_dateRange_Result> sp_dateRange(string fechaInicio, string fechaFinal, string deptid)
        {
            var fechaInicioParameter = fechaInicio != null ?
                new ObjectParameter("FechaInicio", fechaInicio) :
                new ObjectParameter("FechaInicio", typeof(string));
    
            var fechaFinalParameter = fechaFinal != null ?
                new ObjectParameter("FechaFinal", fechaFinal) :
                new ObjectParameter("FechaFinal", typeof(string));
    
            var deptidParameter = deptid != null ?
                new ObjectParameter("deptid", deptid) :
                new ObjectParameter("deptid", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_dateRange_Result>("sp_dateRange", fechaInicioParameter, fechaFinalParameter, deptidParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_matrix_weekdays_Result> sp_matrix_weekdays(Nullable<int> idDepto, string begindate)
        {
            var idDeptoParameter = idDepto.HasValue ?
                new ObjectParameter("idDepto", idDepto) :
                new ObjectParameter("idDepto", typeof(int));
    
            var begindateParameter = begindate != null ?
                new ObjectParameter("begindate", begindate) :
                new ObjectParameter("begindate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_matrix_weekdays_Result>("sp_matrix_weekdays", idDeptoParameter, begindateParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<TB_Info_Result> TB_Info()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TB_Info_Result>("TB_Info");
        }
    
        public virtual ObjectResult<sp_GetWorkingHoursPerDay_Result> sp_GetWorkingHoursPerDay(Nullable<int> departmentId, Nullable<System.DateTime> day)
        {
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("departmentId", departmentId) :
                new ObjectParameter("departmentId", typeof(int));
    
            var dayParameter = day.HasValue ?
                new ObjectParameter("day", day) :
                new ObjectParameter("day", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetWorkingHoursPerDay_Result>("sp_GetWorkingHoursPerDay", departmentIdParameter, dayParameter);
        }
    }
}
