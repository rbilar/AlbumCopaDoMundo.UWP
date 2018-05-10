using AlbumCopaDoMundo.Dados;
using AlbumCopaDoMundo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumCopaDoMundo.UWP.Repository
{
    public class EFFigurinhaRepository : Repository<Figurinha>
    {
        private static readonly Lazy<EFFigurinhaRepository> _instance =
                new Lazy<EFFigurinhaRepository>(() => new EFFigurinhaRepository());

        public static EFFigurinhaRepository Instance { get { return _instance.Value; } }

        public override async Task CarregarTodosAsync()
        {
            if (Items.Count > 0)
            {
                return;
            }

            using (var context = new FigurinhaDbContext())
            {
                var FigurinhaItems = context.Figurinhas.ToList();

                foreach (var Figurinha in FigurinhaItems)
                {
                    Items.Add(Figurinha);
                }
            }
        }

        public override async Task CriarAsync(Figurinha entity)
        {
            using (var context = new FigurinhaDbContext())
            {
                Items.Add(entity);
                context.Figurinhas.Add(entity);

                await context.SaveChangesAsync();
            }
        }

        public override async Task AtualizarAsync(Figurinha entity)
        {
            using (var context = new FigurinhaDbContext())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public override async Task ExcluirAsync(Figurinha entity)
        {
            var Figurinha = Items.SingleOrDefault(c => c.Id == entity.Id);

            if (Figurinha != null)
            {
                using (var context = new FigurinhaDbContext())
                {
                    Items.Remove(Figurinha);

                    context.Figurinhas.Remove(Figurinha);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
