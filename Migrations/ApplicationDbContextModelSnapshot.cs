using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NotSpotifyAPI.Persistence;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Metadata;

namespace NotSpotifyAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210514120000_ApplicationDbContext")]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NotSpotifyAPI.Models.Song", b =>
            {
                b.Property<int>("Id")
                    .HasColumnType("int")
                    .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                b.Property<string>("Artist")
                    .HasColumnType("longtext");

                b.Property<string>("Name")
                    .HasColumnType("longtext");

                b.HasKey("Id");

                b.ToTable("Songs");
            });
#pragma warning restore 612, 618
        }
    }
}
