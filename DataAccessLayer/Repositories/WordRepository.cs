using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class WordRepository : IRepositoryWords
    {
        WebDictionaryContext _context;
        public WordRepository(WebDictionaryContext context)
        {
            _context = context;
        }
        public void AddOrUpdate(Words words)
        {
            if(words.Id<=0)
            _context.Set<Words>().Add(words);
            else
            {
                var updateEdilecek = _context.Set<Words>().FirstOrDefault(c => c.Id == words.Id);
                updateEdilecek.Kelime = words.Kelime;
                updateEdilecek.KelimeAnlami = words.KelimeAnlami;
            }
            SaveChanges();
        }

        public void Delete(Words words)
        {
            _context.Set<Words>().Remove(words);
            SaveChanges();
        }

        public void Delete(int id)
        {
            Words silinecek = _context.Set<Words>().First(c => c.Id == id);
            Delete(silinecek);
        }

        public List<Words> List()
        {
            return _context.Set<Words>().ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
