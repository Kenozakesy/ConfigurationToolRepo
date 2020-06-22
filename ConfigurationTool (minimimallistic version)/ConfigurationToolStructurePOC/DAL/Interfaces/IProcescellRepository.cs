using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Interfaces
{
    public interface IProcescellRepository : IRepository<Procescell>
    {
        //examples from the transportplanning

        //////ProcescellDO GetById(string processCellId);
        //////IEnumerable<ProcescellDO> SelectProcessCellsForArticle(string destinationBinId, string articleId, IEnumerable<string> articleAliases);
        //////IEnumerable<ProcescellDO> SelectActiveProcessCells();
    }
}
