using ConfigurationToolStructurePOC.Business.Model;
using ConfigurationToolStructurePOC.Business.Model.DataBaseModels;
using ConfigurationToolStructurePOC.Business.Model.Parameters;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ConfigurationToolStructurePOC.DAL.Context
{
    public interface IConfigurationToolContext : IDisposable
    {
        IEnumerable<T> ExecuteQuery<T>(string sql);
        void SetDeleted(object entity);
        void SetModified(object entity);
        int SaveChanges();

        IDbSet<Procescell> Procescell { get; set; }
        IDbSet<Route> Route { get; set; }
        IDbSet<Subroute> Subroute { get; set; }
        IDbSet<SubroutesInRoute> SubrouteInRoute { get; set; }
        IDbSet<Bin> Bin { get; set; }
        IDbSet<ParameterDefinition> ParameterDefinition { get; set; }
        IDbSet<ProcessCellParameter> ProcessCellParameter { get; set; }
        IDbSet<BinParameter> BinParameter { get; set; }
        IDbSet<RouteParameter> RouteParameter { get; set; }
        IDbSet<OAProcessCellDefinition> OAProcessCellDefinition { get; set; }
        IDbSet<ProcessCellParameterMapping> ProcessCellParameterMapping { get; set; }
        IDbSet<Procedure> Procedure { get; set; }
        IDbSet<BinsInSubRoute> BinsInSubRoute { get; set; }
        IDbSet<UnitsInSubRoute> UnitsInSubRoute { get; set; }
        IDbSet<OARecipe> OARecipe { get; set; }
        IDbSet<OAUnitDefinition> Unit { get; set; }
        IDbSet<BinStock> BinStock { get; set; }
        IDbSet<TableParameterMapping> TableParameterMapping { get; set; }  //tpm
        IDbSet<ParameterTable> ParameterTable { get; set; }  //pat
        IDbSet<ParameterDefinitionProcessCellType> ParameterDefinitionProcessCellType { get; set; } //pac
        IDbSet<LocType> LocType { get; set; } 
    }
}
