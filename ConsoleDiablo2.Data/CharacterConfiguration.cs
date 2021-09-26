using ConsoleDiablo2.DataModels;
using ConsoleDiablo2.DataModels.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Reflection;

namespace ConsoleDiablo2.Data
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            
        }
    }
}


//public static void Configure<TEntity>(ModelBuilder modelBuilder) where TEntity : Model
//{
//    modelBuilder.Entity<TEntity>(builder =>
//    {
//        builder.Property(e => e.Id).ValueGeneratedOnAdd();
//    });
//}

//public static ModelBuilder ApplyBaseEntityConfiguration(this ModelBuilder modelBuilder)
//{
//    var method = typeof(CharacterConfiguration).GetTypeInfo().DeclaredMethods
//        .Single(m => m.Name == nameof(Configure));
//    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
//    {
//        if (entityType.ClrType.IsSubclassOf(typeof(Model)))
//            method.MakeGenericMethod(entityType.ClrType).Invoke(null, new[] { modelBuilder });
//    }
//    return modelBuilder;
//}
