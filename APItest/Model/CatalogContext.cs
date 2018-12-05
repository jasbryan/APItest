using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APItest.Model
{
    public class CatalogContext : DbContext
    { 
    
        public CatalogContext(DbContextOptions options) : base(options)
        {

        }



        public virtual DbSet<CatalogBrand> CatalogBrands { get; set; }

        public virtual DbSet<CatalogType> CatalogTypes { get; set; }

        public virtual DbSet<CatalogItem> CatalogItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>(ConfigureCatalogBrand);

            modelBuilder.Entity<CatalogType>(ConfigureCatalogType);

            modelBuilder.Entity<CatalogItem>(ConfigureCatalogItem);

        }

        private void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("CatalogItems");
            builder.HasKey(c => c.ItemId);
            builder.Property(c => c.ItemId)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_hilo");
            builder.Property(c => c.ItemName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(c => c.Price)
                .IsRequired();
            builder.HasOne(c => c.ItemBrand)
                .WithMany()
                .HasForeignKey(c => c.BrandId);
            builder.HasOne(c => c.ItemType)
                .WithMany()
                .HasForeignKey(c => c.TypeId);
        }

        private void ConfigureCatalogType(EntityTypeBuilder<CatalogType> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("CatalogTypes");
            builder.HasKey(b => b.TypeId);
            builder.Property(b => b.TypeId)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_type_hilo");
            builder.Property(b => b.TypeName)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigureCatalogBrand(EntityTypeBuilder<CatalogBrand> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("CatalogBrands");
            builder.HasKey(b => b.BrandId);
            builder.Property(b => b.BrandId)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_brand_hilo");
            builder.Property(b => b.BrandName)
                .IsRequired()
                .HasMaxLength(100);
            
        }
    }


    public class CatalogContextFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ItemCatalogDB;Integrated Security=True;Connect Timeout=30;");

            return new CatalogContext(optionsBuilder.Options);
        }
    }
}
