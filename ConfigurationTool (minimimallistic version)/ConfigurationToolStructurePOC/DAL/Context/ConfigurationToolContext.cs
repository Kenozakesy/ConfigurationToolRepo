using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using ConfigurationToolStructurePOC.Business.Model.Parameters;
using ConfigurationToolStructurePOC.DAL.Configurations;
using System.Collections.Generic;
using System.Data.Entity;

namespace ConfigurationToolStructurePOC.DAL.Context
{
    public class ConfigurationToolContext : DbContext, IConfigurationToolContext
    {
        static ConfigurationToolContext()
        {
            Database.SetInitializer<ConfigurationToolContext>(null);
        }

        public ConfigurationToolContext() : base("connectionstring")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ConfigurationToolContext>());
        }

        public IDbSet<Procedure> Procedure { get; set; }
        public IDbSet<Procescell> Procescell { get; set; }
        public IDbSet<Route> Route { get; set; }
        public IDbSet<Subroute> Subroute { get; set; }
        public IDbSet<Bin> Bin { get; set; }
        public IDbSet<ParameterDefinition> ParameterDefinition { get; set; }
        public IDbSet<ProcessCellParameter> ProcessCellParameter { get; set; }
        public IDbSet<BinParameter> BinParameter { get; set; }
        public IDbSet<RouteParameter> RouteParameter { get; set; }
        public IDbSet<OAProcessCellDefinition> OAProcessCellDefinition { get; set; }
        public IDbSet<ProcessCellParameterMapping> ProcessCellParameterMapping { get; set; }
        public IDbSet<UnitsInSubRoute> UnitsInSubRoute { get; set; }
        public IDbSet<BinsInSubRoute> BinsInSubRoute { get; set; }
        public IDbSet<SubroutesInRoute> SubrouteInRoute { get; set; }
        public IDbSet<OARecipe> OARecipe { get; set; }
        public IDbSet<OAUnitDefinition> Unit { get; set; }
        public IDbSet<BinStock> BinStock { get; set; }
        public IDbSet<TableParameterMapping> TableParameterMapping { get; set; }
        public IDbSet<ParameterTable> ParameterTable { get; set; }
        public IDbSet<ParameterDefinitionProcessCellType> ParameterDefinitionProcessCellType { get; set; }
        public IDbSet<LocType> LocType { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ProcedureConfiguration());
            modelBuilder.Configurations.Add(new ProcescellConfiguration());
            modelBuilder.Configurations.Add(new RouteConfiguration());
            modelBuilder.Configurations.Add(new SubrouteConfiguration());
            modelBuilder.Configurations.Add(new BinConfiguration());
            modelBuilder.Configurations.Add(new ParameterDefinitionConfiguration());
            modelBuilder.Configurations.Add(new ProcessCellParameterConfiguration());
            modelBuilder.Configurations.Add(new BinParameterConfiguration());
            modelBuilder.Configurations.Add(new RouteParameterConfiguration());
            modelBuilder.Configurations.Add(new OAProcessCellDefinitionConfiguration());
            modelBuilder.Configurations.Add(new ProcessCellParameterMappingConfiguration());
            modelBuilder.Configurations.Add(new UnitsInSubRouteConfiguration());
            modelBuilder.Configurations.Add(new BinsInSubRouteConfiguration());
            modelBuilder.Configurations.Add(new SubroutesInRouteConfiguration());
            modelBuilder.Configurations.Add(new OARecipeConfiguration());
            modelBuilder.Configurations.Add(new OAUnitDefinitionConfiguration());
            modelBuilder.Configurations.Add(new BinStockConfiguration());
            modelBuilder.Configurations.Add(new TableParameterMappingConfiguration());
            modelBuilder.Configurations.Add(new ParameterTableConfiguration());
            modelBuilder.Configurations.Add(new ParameterDefinitionProcessCellTypeConfiguration());
            modelBuilder.Configurations.Add(new LocTypeConfiguration());
        }

        public void SetDeleted(object entity)
        {
            Entry(entity).State = EntityState.Deleted;
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> ExecuteQuery<T>(string sql)
        {
            return Database.SqlQuery<T>(sql);
        }
    }
}
