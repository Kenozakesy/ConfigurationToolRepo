using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConfigurationToolStructurePOC.DAL.Repositories;
using ConfigurationToolStructurePOC.DAL.Context;
using System.Collections.Generic;
using ConfigurationToolStructurePOC.Business.Model;

namespace ConfigurationTool_TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ProcescellGetTest()
        {
            //ProcescellRepository repository = new ProcescellRepository(new ConfigurationToolContext());
            //IEnumerable<Procescell> procescells = repository.GetAll();

            //List<Procescell> celllist = new List<Procescell>(procescells);

            //Assert.AreEqual(celllist.Count, 18);

        }
    }                                    
}
