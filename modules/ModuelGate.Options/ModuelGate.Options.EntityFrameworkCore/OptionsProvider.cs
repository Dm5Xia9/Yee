using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ModuelGate.Options.EntityFrameworkCore.Models;
using ModuleGate.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModuelGate.Options.EntityFrameworkCore
{
    public class OptionsProvider : IFlexOptionsProvider
    {
        //private readonly IGateDbContext _dbContext;

        //public OptionsProvider(IGateDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public T GetOptions<T>()
        {
            return Activator.CreateInstance<T>();
            //var typeName = typeof(T).Name;
            //var options = _dbContext.Set<ModuleOptions>()
            //    .FirstOrDefault(p => p.TypeName == typeName);

            //if(options == null || options.Value == null)
            //{
            //    var option = Activator.CreateInstance<T>();

            //    if (options == null)
            //    {
            //        _dbContext.Add<ModuleOptions>(new ModuleOptions
            //        {
            //            TypeName = typeName,
            //            Value = JsonConvert.SerializeObject(option)
            //        });
            //        _dbContext.SaveChanges();
            //        return option;
            //    }
            //    else
            //    {
            //        options.Value = JsonConvert.SerializeObject(option);
            //        _dbContext.Update(options);
            //        _dbContext.SaveChanges();

            //        return option;
            //    }
            //}
            //else
            //{
            //    return JsonConvert.DeserializeObject<T>(options.Value)
            //        ?? Activator.CreateInstance<T>();
            //}

        }
    }
}
