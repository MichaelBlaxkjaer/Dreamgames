using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DreamGamesAPI.Database.Context;
using DreamGamesAPI.Database.Scenarios;
using DreamGamesAPI.Repository;

namespace DreamGamesAPI.Database.DataControl
{
    public class ScenarioControl : IDataRepository<Scenario>
    {
        private readonly ContentContext _contentContext;

        public ScenarioControl(ContentContext context)
        {
            _contentContext = context;
        }


        public IEnumerable<Scenario> GetAll() 
        {

            return _contentContext.Scenarios.ToList();
        }

        public Scenario Get(int Id)
        {
            return _contentContext.Scenarios.FirstOrDefault(e => e.Id == Id);
        }

        public void Add(Scenario entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Scenario dbEntity, Scenario entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Scenario entity)
        {
            throw new NotImplementedException();
        }
    }
}
