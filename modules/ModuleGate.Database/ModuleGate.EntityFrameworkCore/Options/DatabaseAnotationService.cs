using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.EntityFrameworkCore.Options
{
    public class DatabaseAnotationService
    {
        private readonly DatabaseAnotation _anotration;

        public DatabaseAnotationService(DatabaseAnotation anotration)
        {
            _anotration = anotration;
        }

        public DatabaseAnotationService AddModel<TEntity>()
        {
            _anotration.Add(typeof(TEntity));

            return this;
        }

        public DatabaseAnotationService AddBuilder(Action<ModelBuilder> action)
        {
            _anotration.ModelCreatingActions.Add(action);
            return this;
        }


    }
}
