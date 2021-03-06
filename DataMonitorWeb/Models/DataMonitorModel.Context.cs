﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataMonitorWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Validation;
    using System.Linq;

    public partial class DataMonitorEntities : DbContext
    {
        public DataMonitorEntities()
            : base("name=DataMonitorEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Metric> Metrics { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<Threashold> Threasholds { get; set; }
        public virtual DbSet<Watcher> Watchers { get; set; }

        private static readonly Dictionary<int, string> _sqlErrorTextDict =
            new Dictionary<int, string>
        {
        {547,
         "This operation failed because another data entry uses this entry."},
        {2601,
         "One of the properties is marked as Unique index and there is already an entry with that value."}
        };

        /// <summary>
        /// This decodes the DbUpdateException. If there are any errors it can
        /// handle then it returns a list of errors. Otherwise it returns null
        /// which means rethrow the error as it has not been handled
        /// </summary>
        /// <param id="ex""></param>
        /// <returns>null if cannot handle errors, otherwise a list of errors</returns>
        IEnumerable<ValidationResult> TryDecodeDbUpdateException(DbUpdateException ex)
        {
            if (!(ex.InnerException is System.Data.Entity.Core.UpdateException) ||
                !(ex.InnerException.InnerException is System.Data.SqlClient.SqlException))
                return null;
            var sqlException =
                (System.Data.SqlClient.SqlException)ex.InnerException.InnerException;
            var result = new List<ValidationResult>();
            for (int i = 0; i < sqlException.Errors.Count; i++)
            {
                var errorNum = sqlException.Errors[i].Number;
                string errorText;
                if (_sqlErrorTextDict.TryGetValue(errorNum, out errorText))
                    result.Add(new ValidationResult(errorText));
            }
            return result.Any() ? result : null;
        }

        public EfStatus SaveChangesWithValidation()
        {
            var status = new EfStatus();
            try
            {
                SaveChanges(); //then update it
            }
            catch (DbEntityValidationException ex)
            {
                return status.SetErrors(ex.EntityValidationErrors);
            }

            catch (DbUpdateException ex)
            {
                var decodedErrors = TryDecodeDbUpdateException(ex);
                if (decodedErrors == null)
                    throw;  //it isn't something we understand so rethrow
                return status.SetErrors(decodedErrors);
            }
            //else it isn't an exception we understand so it throws in the normal way

            return status;
        }
    }
}
