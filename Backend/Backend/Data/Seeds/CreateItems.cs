using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Seeds
{
    public static class CreateItems
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, Title = "Lâmpadas", Image = "lampadas.svg" },
                new Item { Id = 2, Title = "Pilhas e Baterias", Image = "baterias.svg" },
                new Item { Id = 3, Title = "Papéis e Papelão", Image = "papeis-papelao.svg" },
                new Item { Id = 4, Title = "Resíduos Eletrônicos", Image = "eletronicos.svg" },
                new Item { Id = 5, Title = "Resíduos Orgânicos", Image = "organicos.svg" },
                new Item { Id = 6, Title = "Óleo de Cozinha", Image = "oleo.svg" });
        }
    }
}
