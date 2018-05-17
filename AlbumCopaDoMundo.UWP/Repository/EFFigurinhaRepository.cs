using AlbumCopaDoMundo.Dados;
using AlbumCopaDoMundo.Models;
using AlbumCopaDoMundo.UWP.Services;
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
        public static int TotalColadas { get; set; }

        public override async Task AtualizarAsync(Figurinha entity)
        {
            using (var context = new AlbumCopaDoMundoDbContext())
            {
                context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public override async Task BuscarFigurinhas(string grupo)
        {
            Items.Clear();

            using (var context = new AlbumCopaDoMundoDbContext())
            {
                // Quais mostrar?
                var figurinhas = context.Figurinhas.Where(f => f.Grupo == grupo);

                // Que ordem mostrar?
                if (StorageService.LerConfiguracao(StorageService.Configuracoes.OrdernarPorNumeroConfiguracao, 0) == 0)
                {
                    foreach (var figurinha in figurinhas.OrderBy(x => x.Numero))
                    {
                        Items.Add(figurinha);
                    }
                }
                else
                {
                    foreach (var figurinha in figurinhas.OrderByDescending(x => x.Colada).ThenBy(x => x.Numero))
                    {
                        Items.Add(figurinha);
                    }
                }
            }
        }
        
        public override async Task ConfigurarAlbum()
        {
            using (var context = new AlbumCopaDoMundoDbContext())
            {
                if (context.Figurinhas.Count() == 0)
                {
                    #region Figurinhas

                    context.Figurinhas.RemoveRange(context.Figurinhas);

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Introdução", Nacionalidade = "Introdução", Numero = 0, Nome = "Panini" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Introdução", Nacionalidade = "Introdução", Numero = 1, Nome = "FIFA Fair Play" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Introdução", Nacionalidade = "Introdução", Numero = 2, Nome = "FIFA World Cup Trophy" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Introdução", Nacionalidade = "Introdução", Numero = 3, Nome = "Style Guide (Puzzle 1)" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Introdução", Nacionalidade = "Introdução", Numero = 4, Nome = "Style Guide (Puzzle 2)" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Introdução", Nacionalidade = "Introdução", Numero = 5, Nome = "FIFA World Cup Logo (Puzzle 1)" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Introdução", Nacionalidade = "Introdução", Numero = 6, Nome = "FIFA World Cup Logo (Puzzle 2)" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Introdução", Nacionalidade = "Introdução", Numero = 7, Nome = "Bola Oficial" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 8, Nome = "Ekaterinburg Arena" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 9, Nome = "Kaliningrad Stadium" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 10, Nome = "Kazan Arena" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 11, Nome = "Spartak Stadium" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 12, Nome = "Nizhny Novgorod Stadium" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 13, Nome = "Luzhniki Stadium" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 14, Nome = "Rostov Arena" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 15, Nome = "Saint Petersburg Stadium" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 16, Nome = "Samara Arena" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 17, Nome = "Mordovia Arena" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 18, Nome = "Fisht Stadium" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Estádios", Nacionalidade = "Estádios", Numero = 19, Nome = "Volgograd Arena" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 20, Nome = "MOSCOW (PUZZLE 1)" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 21, Nome = "MOSCOW (PUZZLE 2)" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 22, Nome = "KALININGRAD" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 23, Nome = "SAINT PETERSBURG" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 24, Nome = "SOCHI" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 25, Nome = "ROSTOV-ON-DON" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 26, Nome = "VOLGOGARAD" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 27, Nome = "KAZAN" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 28, Nome = "NIZHNY NOVGOROD" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 29, Nome = "SAMARA" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 30, Nome = "EKATERINBURG" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "Cidades Sede", Nacionalidade = "Cidades Sede", Numero = 31, Nome = "SARANSK" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 32, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 33, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 34, Nome = "Igor Akinfeev" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 35, Nome = "Igor Smolnikov" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 36, Nome = "Viktor Vasin" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 37, Nome = "Mário Fernandes" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 38, Nome = "Fedor Kudrayashov" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 39, Nome = "Ilya Kutepov" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 40, Nome = "Dmitri Kombarov" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 41, Nome = "Aleksei Miranchuk" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 42, Nome = "Denis Glushakov" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 43, Nome = "Aleksandr Golovin" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 44, Nome = "Yuri Zhirkov" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 45, Nome = "Aleksandr Erokhin" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 46, Nome = "Alan Dzagoev" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 47, Nome = "Daler Kuzyayev" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 48, Nome = "Daler Kuzyayev" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 49, Nome = "Dmitry Poloz" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 50, Nome = "Fedor Smolov" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Rússia", Numero = 51, Nome = "Aleksandr Kokorin" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 52, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 53, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 54, Nome = "Abdullah Al - Mayouf" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 55, Nome = "Osama Hawsawi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 56, Nome = "Abdullah Al - Zori" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 57, Nome = "Mansour Al - Harbi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 58, Nome = "Omar Hawsawi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 59, Nome = "Yasser Al - Shahrani" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 60, Nome = "Motaz Hawsawi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 61, Nome = "Mohammed Al - Beraik" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 62, Nome = "Taisir Al - Jassim" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 63, Nome = "Salman Al - Faraj" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 64, Nome = "Abdulmalek Al - Khaibri" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 65, Nome = "Salman Al - Moasher" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 66, Nome = "Yahya Al - Shehri" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 67, Nome = "Salem Al - Dosari" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 68, Nome = "Nawaf Al - Abed" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 69, Nome = "Mohammad Al - Sahlawi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 70, Nome = "Nasser Al - Shamrani" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Arábia Saudita", Numero = 71, Nome = "Fahad Al - Muwallad" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 72, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 73, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 74, Nome = "Essam El Hadary" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 75, Nome = "Ali Gabr" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 76, Nome = "Ahmed Elmohamady" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 77, Nome = "Omar Gaber" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 78, Nome = "Ramy Rabia" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 79, Nome = "Ahmed Hegazi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 80, Nome = "Ahmed Abdelmonem Fathy" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 81, Nome = "Mohamed Abdel Shaly" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 82, Nome = "Saad El - Din Samir" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 83, Nome = "Tarek Hamed" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 84, Nome = "Mahmoud Kahraba" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 85, Nome = "Mohamed Elneny" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 86, Nome = "Trezeguet" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 87, Nome = "Abdallah El Said" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 88, Nome = "Ramadan Sobhi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 89, Nome = "Ahmed Hassan" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 90, Nome = "Mohamed Salah" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Egito", Numero = 91, Nome = "Amr Gamal" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 92, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 93, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 94, Nome = "Fernando Muslera" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 95, Nome = "Maxi Pereira" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 96, Nome = "Diego Godín" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 97, Nome = "Martín Cáceres" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 98, Nome = "José Giménez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 99, Nome = "Sebastián Coates" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 100, Nome = "Gastón Silva" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 101, Nome = "Mathías Corujo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 102, Nome = "Egidio Arévalo Ríos" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 103, Nome = "Álvaro González" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 104, Nome = "Nicolás Lodeiro" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 105, Nome = "Carlos Sánchez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 106, Nome = "Cristian Rodríguez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 107, Nome = "Matías Vecino" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 108, Nome = "Edinson Cavani" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 109, Nome = "Luis Suárez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 110, Nome = "Cristhian Stuani" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "A", Nacionalidade = "Uruguai", Numero = 111, Nome = "Diego Rolán" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 112, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 113, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 114, Nome = "Rui Patrício" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 115, Nome = "Bruno Alves" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 116, Nome = "Pepe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 117, Nome = "José Fonte" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 118, Nome = "Eliseu" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 119, Nome = "Cédric" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 120, Nome = "Raphaël Guerreiro" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 121, Nome = "João Moutinho" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 122, Nome = "João Mário" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 123, Nome = "Danilo Pereira" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 124, Nome = "William Carvalho" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 125, Nome = "André Gomes" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 126, Nome = "Ricardo Quaresma" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 127, Nome = "Bernardo Silva" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 128, Nome = "André Silva" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 129, Nome = "Gelson Martins" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 130, Nome = "Cristiano Ronaldo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Portugual", Numero = 131, Nome = "Nani" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 132, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 133, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 134, Nome = "David de Gea" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 135, Nome = "Jordi Alba" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 136, Nome = "Nacho" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 137, Nome = "Nacho Monreal" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 138, Nome = "Gerard Piqué" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 139, Nome = "Sergio Ramos" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 140, Nome = "Daniel Carvajal" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 141, Nome = "Sergio Buesquets" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 142, Nome = "Thiago" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 143, Nome = "Isco" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 144, Nome = "Koke" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 145, Nome = "Marco Asensio" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 146, Nome = "Andrés Iniesta" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 147, Nome = "David Silva" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 148, Nome = "Saúl Ñíguez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 149, Nome = "Álvaro Morata" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 150, Nome = "Vitolo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Espanha", Numero = 151, Nome = "Diego Costa" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 152, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 153, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 154, Nome = "Munir Mohamedi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 155, Nome = "Medhi Benatia" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 156, Nome = "Nabil Dirar" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 157, Nome = "Romain Saïss" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 158, Nome = "Fouad Chafik" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 159, Nome = "Hamza Mendyl" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 160, Nome = "Achraf Hakimi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 161, Nome = "Mbark Boussoufa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 162, Nome = "Karim El Ahmadi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 163, Nome = "Younès Belhanda" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 164, Nome = "Nordin Amrabat" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 165, Nome = "Fayçal Fajr" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 166, Nome = "Hakim Ziyech" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 167, Nome = "Youssef Aït Bennasser" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 168, Nome = "Khalid Boutaib" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 169, Nome = "Rachid Alioui" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 170, Nome = "Aziz Bouhaddouz" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Marrocos", Numero = 171, Nome = "Youssef En - Nesyri" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 172, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 173, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 174, Nome = "Alireza Beiranvand" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 175, Nome = "Pejman Montazeri" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 176, Nome = "Vouria Ghafouri" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 177, Nome = "Jalal Hosseini" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 178, Nome = "Milad Mohammadi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 179, Nome = "Morteza Pouraliganji" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 180, Nome = "Ramin Rezaeian" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 181, Nome = "Ehsan Hajsafi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 182, Nome = "Omid Ebrahimi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 183, Nome = "Saeid Ezatolahi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 184, Nome = "Vahid Amiri" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 185, Nome = "Alireza Jahanbakhsh" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 186, Nome = "Ashkan Dejagah" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 187, Nome = "Saman Ghoddos" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 188, Nome = "Mehdi Taremi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 189, Nome = "Karim Ansarifard" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 190, Nome = "Reza Ghoochannejhad" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "B", Nacionalidade = "Irã", Numero = 191, Nome = "Sardar Azmoun" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 192, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 193, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 194, Nome = "Hugo Lloris" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 195, Nome = "Raphaël Varane" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 196, Nome = "Lucas Digne" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 197, Nome = "Djibril Sidibé" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 198, Nome = "Samuel Umtiti" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 199, Nome = "Layvin Kurzawa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 200, Nome = "Laurent Koscielny" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 201, Nome = "Balise Matuidi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 202, Nome = "N’Golo Kanté" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 203, Nome = "Thomas Lemar" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 204, Nome = "Adrien Rabiot" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 205, Nome = "Paul Pogba" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 206, Nome = "Olivier Giroud" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 207, Nome = "Antoine Griezmann" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 208, Nome = "Alexandre Lacazette" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 209, Nome = "Kylian Mbappé" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 210, Nome = "Ousmane Dembélé" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "França", Numero = 211, Nome = "Anthony Martial" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 212, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 213, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 214, Nome = "Mathew Ryan" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 215, Nome = "Mitchell Langerak" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 216, Nome = "Milos Degenek" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 217, Nome = "Bailey Wright" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 218, Nome = "Aziz Behich" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 219, Nome = "Trent Sainsbury" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 220, Nome = "Ryan McGowan" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 221, Nome = "Mark Milligan" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 222, Nome = "Aaron Mooy" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 223, Nome = "James Troisi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 224, Nome = "Mile Jedinak" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 225, Nome = "Massimo Luongo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 226, Nome = "Jackson Irvine" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 227, Nome = "Tom Rogic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 228, Nome = "Tim Cahill" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 229, Nome = "Mathew Leckie" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 230, Nome = "Tomi Juric" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Austrália", Numero = 231, Nome = "Robbie Kruse" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 232, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 233, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 234, Nome = "Pedro Gallese" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 235, Nome = "Carlos Cáceda" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 236, Nome = "Aldo Corzo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 237, Nome = "Miguel Trauco" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 238, Nome = "Christian Ramos" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 239, Nome = "Luis Advincula" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 240, Nome = "Alberto Rodríguez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 241, Nome = "Miguel Araujo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 242, Nome = "Christian Cueva" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 243, Nome = "Renato Tapia" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 244, Nome = "Andy Polo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 245, Nome = "Yoshimar Yotún" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 246, Nome = "Edison Flores" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 247, Nome = "Paolo Hurtado" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 248, Nome = "Paolo Guerrero" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 249, Nome = "Jefferson Farfán" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 250, Nome = "Raúl Ruidíaz" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Peru", Numero = 251, Nome = "André Carrillo" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 252, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 253, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 254, Nome = "Kasper Schmeichel" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 255, Nome = "Kannik Vestergaard" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 256, Nome = "Simon Kjaer" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 257, Nome = "Andreas Christensen" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 258, Nome = "Andreas Bjelland" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 259, Nome = "Mathias Jorgensen" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 260, Nome = "Jens Stryger Larsen" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 261, Nome = "Peter Ankersen" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 262, Nome = "Riza Durmisi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 263, Nome = "William Kvist" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 264, Nome = "Thomas Delaney" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 265, Nome = "Christian Eriksen" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 266, Nome = "Lasse Schöne" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 267, Nome = "Pione Sisto" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 268, Nome = "Nicklas Bendtner" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 269, Nome = "Nicolai Jorgensen" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 270, Nome = "Yussuf Poulsen" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "C", Nacionalidade = "Dinamarca", Numero = 271, Nome = "Andreas Cornelius" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 272, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 273, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 274, Nome = "Sergio Romero" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 275, Nome = "Gabriel Mercado" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 276, Nome = "Federico Fazio" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 277, Nome = "Javier Mascherano" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 278, Nome = "Nicolás Otamendi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 279, Nome = "Marcos Rojo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 280, Nome = "Ramiro Funes Mori" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 281, Nome = "Lucas Biglia" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 282, Nome = "Enzo Pérez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 283, Nome = "Ángel Di Maria" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 284, Nome = "Marcos Acuña" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 285, Nome = "Éver Banega" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 286, Nome = "Eduardo Salvio" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 287, Nome = "Mauro Icardi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 288, Nome = "Lionel Messi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 289, Nome = "Paulo Dybala" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 290, Nome = "Sergio Agüero" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Argentina", Numero = 291, Nome = "Gonzalo Higuaín" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 292, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 293, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 294, Nome = "Hannes Halldórsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 295, Nome = "Birkir Saevarsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 296, Nome = "Ragnar Sigurdsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 297, Nome = "Kári Árnason" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 298, Nome = "Ari Skúlason" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 299, Nome = "Sverrir Ingason" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 300, Nome = "Hordur Magnússon" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 301, Nome = "Aron Gunnarsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 302, Nome = "Birkir Bjarnason" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 303, Nome = "Emil Hallfredsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 304, Nome = "Gylfi Sigurdsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 305, Nome = "Arnór Ingvi Traustason" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 306, Nome = "Rúrik Gíslason" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 307, Nome = "Johann Gudmundsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 308, Nome = "Alfred Finnbogason" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 309, Nome = "Jón Dadi Bödvarsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 310, Nome = "Vidar Örn Kjartansson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Islândia", Numero = 311, Nome = "Björn Sigurdarson" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 312, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 313, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 314, Nome = "Danijel Subasic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 315, Nome = "Sime Vrsaljko" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 316, Nome = "Ivan Strinic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 317, Nome = "Dejan Lovren" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 318, Nome = "Domagoj Vida" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 319, Nome = "Josip Pivaric" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 320, Nome = "Vedran Corluka" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 321, Nome = "Ivan Rakitic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 322, Nome = "Luka Modric" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 323, Nome = "Marcelo Brozovic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 324, Nome = "Marko Rog" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 325, Nome = "Mario Pasalic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 326, Nome = "Milan Badelj" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 327, Nome = "Mateo Kovacic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 328, Nome = "Andrej Kramaric" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 329, Nome = "Nikola Kalinic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 330, Nome = "Mario Mandzukic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Croácia", Numero = 331, Nome = "Ivan Perisic" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 332, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 333, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 334, Nome = "Ikechukwu Ezenwa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 335, Nome = "Elderson Echiejilé" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 336, Nome = "Shehu Abdullahi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 337, Nome = "William Troost - Ekong" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 338, Nome = "Leon Balogun" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 339, Nome = "Kenneth Omeruo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 340, Nome = "Ola Aina" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 341, Nome = "John Obi Mikel" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 342, Nome = "Ogenyi Onazi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 343, Nome = "Etebo Oghenekaro" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 344, Nome = "Wilfred Ndidi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 345, Nome = "Mikel Agu" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 346, Nome = "Ahmed Musa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 347, Nome = "Victor Musa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 348, Nome = "Moses Simon" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 349, Nome = "Odion Ighalo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 350, Nome = "Alex Iwobi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "D", Nacionalidade = "Nigéria", Numero = 351, Nome = "Kelechi Iheanacho" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 352, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 353, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 354, Nome = "Alisson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 355, Nome = "Dani Alves" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 356, Nome = "Thiago Silva" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 357, Nome = "Miranda" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 358, Nome = "Filipe Luís" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 359, Nome = "Marquinhos" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 360, Nome = "Marcelo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 361, Nome = "Willian" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 362, Nome = "Paulinho" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 363, Nome = "Fernandinho" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 364, Nome = "Casemiro" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 365, Nome = "Renato Augusto" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 366, Nome = "Giuliano" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 367, Nome = "Philippe Coutinho" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 368, Nome = "Douglas Costa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 369, Nome = "Roberto Firmino" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 370, Nome = "Gabriel Jesus" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Brasil", Numero = 371, Nome = "Neymar Jr" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 372, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 373, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 374, Nome = "Yann Sommer" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 375, Nome = "Stephan Lichtsteiner" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 376, Nome = "Manuel Akanji" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 377, Nome = "Michael Lang" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 378, Nome = "Ricardo Rodríguez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 379, Nome = "Johan Djourou" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 380, Nome = "Fabian Schär" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 381, Nome = "Granit Xhaka" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 382, Nome = "Steven Zuber" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 383, Nome = "Blerim Dzemaili" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 384, Nome = "Denis Zakaria" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 385, Nome = "Xherdan Shaqiri" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 386, Nome = "Valon Behrami" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 387, Nome = "Gerson Fernandes" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 388, Nome = "Breel Embolo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 389, Nome = "Haris Seferovic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 390, Nome = "Admir Mehmedi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Suiça", Numero = 391, Nome = "Eren Derdiyok" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 392, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 393, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 394, Nome = "Keylor Navas" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 395, Nome = "Giancarlo González" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 396, Nome = "Cristian Gamboa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 397, Nome = "Bryan Oviedo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 398, Nome = "Francisco Calvo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 399, Nome = "Kendall Waston" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 400, Nome = "Rónald Matarrita" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 401, Nome = "Michael Umaña" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 402, Nome = "Johnny Acosta" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 403, Nome = "Bryan Ruiz" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 404, Nome = "Celso Borges" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 405, Nome = "Christian Bolaños" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 406, Nome = "Randall Azofeifa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 407, Nome = "David Guzmán" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 408, Nome = "Rodney Wallace" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 409, Nome = "Joel Campbell" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 410, Nome = "Marco Ureña" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Costa Rica", Numero = 411, Nome = "Johan Venegas" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 412, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 413, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 414, Nome = "Vladimir Stojkovic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 415, Nome = "Branislav Ivanovic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 416, Nome = "Aleksandar Kolarov" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 417, Nome = "Antonio Rukavina" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 418, Nome = "Matija Nastasic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 419, Nome = "Dusko Tosic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 420, Nome = "Nikola Maksimovic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 421, Nome = "Jagos Vukovic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 422, Nome = "Dusan Tadic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 423, Nome = "Sergej Milinkovic - Savic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 424, Nome = "Nemanja Matic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 425, Nome = "Luka Milivojevic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 426, Nome = "Adem Ljajic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 427, Nome = "Nemanja Gudelj" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 428, Nome = "Mijat Gacinovic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 429, Nome = "Filip Kostic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 430, Nome = "Aleksandar Mitrovic" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "E", Nacionalidade = "Sérvia", Numero = 431, Nome = "Aleksandar Prijovic" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 432, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 433, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 434, Nome = "Manuel Neuer" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 435, Nome = "Mats Hummels" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 436, Nome = "Antonio Rüdiger" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 437, Nome = "Jérôme Boateng" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 438, Nome = "Joshua Kimmich" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 439, Nome = "Jonas Hector" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 440, Nome = "Julian Draxler" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 441, Nome = "Toni Kroos" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 442, Nome = "Emre Can" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 443, Nome = "Leon Goretzka" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 444, Nome = "Julian Brandt" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 445, Nome = "Sebastian Rudy" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 446, Nome = "Leroy Sané" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 447, Nome = "Mesut Özil" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 448, Nome = "Sami Khedira" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 449, Nome = "Mario Götze" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 450, Nome = "Thomas Müller" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Alemanha", Numero = 451, Nome = "Timo Werner" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 452, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 453, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 454, Nome = "Guillermo Ochoa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 455, Nome = "Hugo Ayala" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 456, Nome = "Diego Reyes" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 457, Nome = "Héctor Moreno" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 458, Nome = "Jesús Gallardo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 459, Nome = "Miguel Layún" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 460, Nome = "Carlos Salcedo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 461, Nome = "Jonathan dos Santos" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 462, Nome = "Giovani dos Santos" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 463, Nome = "Andrés Guardado" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 464, Nome = "Héctor Herrera" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 465, Nome = "Javier Aquino" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 466, Nome = "Jesús Corona" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 467, Nome = "Hirving Lozano" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 468, Nome = "Raúl Jiménez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 469, Nome = "Carlos Vela" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 470, Nome = "Javier Hernández" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "México", Numero = 471, Nome = "Oribe Peralta" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 472, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 473, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 474, Nome = "Robin Olsen" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 475, Nome = "Mikel Lustig" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 476, Nome = "Victor Nilsson Lindelöf" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 477, Nome = "Andreas Granqvist" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 478, Nome = "Martin Olsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 479, Nome = "Ludwig Augustinsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 480, Nome = "Emil Krafth" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 481, Nome = "Pontus Jansson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 482, Nome = "Sebastian Larsson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 483, Nome = "Emil Forsberg" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 484, Nome = "Gustav Svensson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 485, Nome = "Viktor Claesson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 486, Nome = "Jimmy Durmaz" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 487, Nome = "Albin Ekdal" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 488, Nome = "Isaac Kiese Thelin" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 489, Nome = "Marcus Berg" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 490, Nome = "John Guidetti" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Suécia", Numero = 491, Nome = "Ola Toivonen" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 492, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 493, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 494, Nome = "Kim Seunggyu" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 495, Nome = "Kim Younggwon" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 496, Nome = "Kim Jinsu" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 497, Nome = "Kwak Taehwi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 498, Nome = "Hong Jeongho" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 499, Nome = "Jang Hyunsoo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 500, Nome = "Koo Jacheol" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 501, Nome = "Kwon Changhoon" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 502, Nome = "Ki Sungyueng" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 503, Nome = "Nam Taehee" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 504, Nome = "Han Kookyoung" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 505, Nome = "Lee Chungyoung" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 506, Nome = "Jung Wooyoung" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 507, Nome = "Lee Jaesung" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 508, Nome = "Son Heungmin" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 509, Nome = "Ji Dongwon" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 510, Nome = "Kim Shinwook" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "F", Nacionalidade = "Coréia do Sul", Numero = 511, Nome = "Hwang Heechan" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 512, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 513, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 514, Nome = "Thibaut Courtois" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 515, Nome = "Toby Alderweireld" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 516, Nome = "Thomas Vermaelen" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 517, Nome = "Jan Vertonghen" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 518, Nome = "Vincent Kompany" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 519, Nome = "Thomas Meunier" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 520, Nome = "Axel Witsel" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 521, Nome = "Radja Nainggolan" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 522, Nome = "Kevin De Bruyne" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 523, Nome = "Marouane Fellaini" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 524, Nome = "Youri Tielemans" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 525, Nome = "Mousa Dembélé" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 526, Nome = "Nacer Chadli" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 527, Nome = "Eden Hazard" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 528, Nome = "Yannick Carrasco" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 529, Nome = "Dries Mertens" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 530, Nome = "Michy Batshuayi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Bélgica", Numero = 531, Nome = "Romelu Lukaku" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 532, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 533, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 534, Nome = "Jaime Penedo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 535, Nome = "José Calderón" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 536, Nome = "Michael Murillo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 537, Nome = "Fidel Escobar" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 538, Nome = "Román Torres" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 539, Nome = "Adolfo Machado" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 540, Nome = "Éric Davis" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 541, Nome = "Luis Ovalle" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 542, Nome = "Felipe Baloy" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 543, Nome = "Gabriel Gómez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 544, Nome = "Édgar Bárcenas" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 545, Nome = "Armando Cooper" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 546, Nome = "Alberto Quintero" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 547, Nome = "Aníbal Godoy" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 548, Nome = "Blas Pérez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 549, Nome = "Gabriel Torres" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 550, Nome = "Luis Tejada" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Panamá", Numero = 551, Nome = "Abdiel Arroyo" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 552, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 553, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 554, Nome = "Aymen Mathlouthi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 555, Nome = "Ali Maâloul" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 556, Nome = "Syam Ben Youssef" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 557, Nome = "Aymen Abdennour" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 558, Nome = "Hamdi Naguez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 559, Nome = "Yassine Meriah" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 560, Nome = "Oussama Haddadi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 561, Nome = "Ferjani Sassi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 562, Nome = "Wahbi Khazri" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 563, Nome = "Mohamed Amine Ben Amor" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 564, Nome = "Ghaylène Chaalali" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 565, Nome = "Naïm Sliti" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 566, Nome = "Youssef Msakni" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 567, Nome = "Fakhreddine Ben Youssef" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 568, Nome = "Taha Yassine Khenissi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 569, Nome = "Yoann Touzghar" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 570, Nome = "Anice Bradi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Tunísia", Numero = 571, Nome = "Ahmed Akaïchi" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 572, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 573, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 574, Nome = "Joe Hart" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 575, Nome = "Jordan Pickford" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 576, Nome = "Gary Cahill" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 577, Nome = "Kyle Walker" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 578, Nome = "John Stones" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 579, Nome = "Ryan Bertrand" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 580, Nome = "Danny Rose" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 581, Nome = "Phil Jones" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 582, Nome = "Jordan Henderson" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 583, Nome = "Alex Oxlade - Chamberlain" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 584, Nome = "Dele Alli" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 585, Nome = "Eric Dier" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 586, Nome = "Adam Lallana" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 587, Nome = "Jesse Lingard" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 588, Nome = "Raheem Sterling" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 589, Nome = "Harry Kane" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 590, Nome = "Marcus Rashford" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "G", Nacionalidade = "Inglaterra", Numero = 591, Nome = "Jamie Vardy" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 592, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 593, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 594, Nome = "Lukasz Fabianski" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 595, Nome = "Wojciech Szczesny" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 596, Nome = "Lukasz Piszczek" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 597, Nome = "Kamil Glik" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 598, Nome = "Michal Pazdan" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 599, Nome = "Thiago Cionek" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 600, Nome = "Bartosz Bereszynski" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 601, Nome = "Artur Jedrzejczyk" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 602, Nome = "Maciej Rybus" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 603, Nome = "Jakub Blaszczykowski" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 604, Nome = "Kamil Grosicki" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 605, Nome = "Grzegorz Krychowiak" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 606, Nome = "Krzysztof Maczynski" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 607, Nome = "Piotr Zielinski" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 608, Nome = "Karol Linetty" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 609, Nome = "Robert Lewandowski" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 610, Nome = "Lukasz Teodorczyk" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Polônia", Numero = 611, Nome = "Arkadiusz Milik" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 612, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 613, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 614, Nome = "Khadim N’Diaye" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 615, Nome = "Kara Mbodj" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 616, Nome = "Lamine Gassama" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 617, Nome = "Kalidou Koulibaly" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 618, Nome = "Salif Sané" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 619, Nome = "Saliou Ciss" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 620, Nome = "Moussa Wagué" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 621, Nome = "Idrissa Gueye" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 622, Nome = "Cheikhou Kouyaté" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 623, Nome = "Cheikh Ndoye" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 624, Nome = "Papa Alioune N’Diaye" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 625, Nome = "Sadio Mané" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 626, Nome = "Moussa Sow" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 627, Nome = "Moussa Konaté" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 628, Nome = "Keita Baldé" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 629, Nome = "M’Baye Niang" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 630, Nome = "Ismaïla Sarr" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Senegal", Numero = 631, Nome = "Mame Diouf" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 632, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 633, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 634, Nome = "David Ospina" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 635, Nome = "Cristian Zapata" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 636, Nome = "Santiago Arias" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 637, Nome = "Frank Fabra" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 638, Nome = "Dávinson Sánchez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 639, Nome = "Yerry Mina" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 640, Nome = "Carlos Sánchez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 641, Nome = "Juan Guillermo Cuadrado" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 642, Nome = "Abel Aguilar" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 643, Nome = "James Rodríguez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 644, Nome = "Giovanni Moreno" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 645, Nome = "Wílmar Barrios" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 646, Nome = "Radamel Falcao García" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 647, Nome = "Teófilo Gutiérrez" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 648, Nome = "Carlos Bacca" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 649, Nome = "Edwin Cardona" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 650, Nome = "Yimmi Chará" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Colômbia", Numero = 651, Nome = "Duván Zapata" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 652, Nome = "Escudo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 653, Nome = "Equipe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 654, Nome = "Eiji Kawashima" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 655, Nome = "Shusaku Nishikawa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 656, Nome = "Masato Morishige" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 657, Nome = "Yuto Nagatomo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 658, Nome = "Hiroki Sakai" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 659, Nome = "Tomoaki Makino" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 660, Nome = "Gotoku Sakai" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 661, Nome = "Maya Yoshida" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 662, Nome = "Hotaru Yamaguchi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 663, Nome = "Shinji Kagawa" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 664, Nome = "Makoto Hasebe" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 665, Nome = "Hiroshi Kiyotake" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 666, Nome = "Keisuke Honda" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 667, Nome = "Takashi Usami" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 668, Nome = "Genki Haraguchi" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 669, Nome = "Shinji Okazaki" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 670, Nome = "Yuya Kubo" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "H", Nacionalidade = "Japão", Numero = 671, Nome = "Yuya Osako" });

                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "FIFA World Cup Legends", Nacionalidade = "FIFA World Cup Legends", Numero = 672, Nome = "Brasil" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "FIFA World Cup Legends", Nacionalidade = "FIFA World Cup Legends", Numero = 673, Nome = "Alemanha" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "FIFA World Cup Legends", Nacionalidade = "FIFA World Cup Legends", Numero = 674, Nome = "Itália" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "FIFA World Cup Legends", Nacionalidade = "FIFA World Cup Legends", Numero = 675, Nome = "Uruguai" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "FIFA World Cup Legends", Nacionalidade = "FIFA World Cup Legends", Numero = 676, Nome = "Argentina" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "FIFA World Cup Legends", Nacionalidade = "FIFA World Cup Legends", Numero = 677, Nome = "Inglaterra" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "FIFA World Cup Legends", Nacionalidade = "FIFA World Cup Legends", Numero = 678, Nome = "França" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "FIFA World Cup Legends", Nacionalidade = "FIFA World Cup Legends", Numero = 679, Nome = "Espanha" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "FIFA World Cup Legends", Nacionalidade = "FIFA World Cup Legends", Numero = 680, Nome = "Pelé" });
                    context.Add(new Models.Figurinha() { Colada = false, Grupo = "FIFA World Cup Legends", Nacionalidade = "FIFA World Cup Legends", Numero = 681, Nome = "Miroslav Klose" });

                    #endregion

                    context.SaveChangesAsync();

                }

                TotalColadas = context.Figurinhas.Where(f => f.Colada).Count();
            }
        }
    }
}
