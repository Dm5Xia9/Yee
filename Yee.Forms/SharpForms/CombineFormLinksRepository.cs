using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Forms.Abstractions;

namespace Yee.Forms.SharpForms
{
    public class CombineFormLinksRepository : ISharpFormLinksRepository
    {
        private readonly IEnumerable<ISharpFormLinksRepository> _sharpFormLinksRepositories;
        private readonly ISharpFormLinksRepository _rootRepository; 
        public CombineFormLinksRepository(IEnumerable<ISharpFormLinksRepository> sharpFormLinksRepositories)
        {
            _sharpFormLinksRepositories = sharpFormLinksRepositories
                .Where(p => p.GetType() != typeof(RootSharpFormLinksRepository));

            _rootRepository = sharpFormLinksRepositories
                .First(p => p.GetType() == typeof(RootSharpFormLinksRepository));
        }

        public void AddOrUpdate(SharpFormLink form)
        {
            foreach(var repository in _sharpFormLinksRepositories)
            {
                try
                {
                    repository.AddOrUpdate(form);
                }
                catch
                {
                    continue;
                }
            }

            _rootRepository.AddOrUpdate(form);
        }

        public Dictionary<Type, SharpFormLink> GetAllForms()
        {
            foreach(var repository in _sharpFormLinksRepositories)
            {
                try
                {
                    return repository.GetAllForms();
                }
                catch
                {
                    continue;
                }
            }

            return _rootRepository.GetAllForms();
        }
    }
}
