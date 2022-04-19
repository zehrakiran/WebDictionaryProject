using DataAccessLayer;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionaryProject.Helpers
{
    public class RepositoryFactory
    {
        static IRepositoryWords _repoWords;
        public static IRepositoryWords CreateRepo(string tip)
        {
            if (_repoWords == null)
            {
                if (tip == "WORD")
                {
                    lock (new object())
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<WebDictionaryContext>();
                        optionsBuilder.UseSqlServer("Server=DESKTOP-V8MI9KV\\SQLEXPRESS;Database=WebDictionaryDb;Trusted_Connection=True;MultipleActiveResultSets=true");

                        // _repoWords = new WordsRepositoryJson();
                        WebDictionaryContext context = new WebDictionaryContext(optionsBuilder.Options);
                        _repoWords = new WordRepository(context);
                    }
                    return _repoWords;
                }
                else
                    return null;
            }
            else
                return _repoWords;
        }
    }
}
