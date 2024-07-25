using BlogEf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEf.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //Tabela
            builder.ToTable("Post");

            //Chave Primaria
            builder.HasKey(x => x.Id);

            //Identity
            builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn(); //PRIMARY KEY IDENTITY (1 , 1)

            builder.Property(x => x.LastUpdateDate)
                .IsRequired() // NOT NULL
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasMaxLength(60)
                //CasoQueira usar funcao SQL, usar abaixo
                //.HasDefaultValueSql("GETDATE()");
                //Caso queira usar default value em dotnet usar abaixo
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            //Índices
            builder.HasIndex(x => x.Slug, "IX_Post_Slug")
                .IsUnique();

            //Relacionamentos
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Author")
                .OnDelete(DeleteBehavior.Cascade);

            //Relacionamento Um para muitos
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade);

            //Relacionamento Um para um Exemplo
            //builder.HasOne(x => x.Category);
            //builder.OwnsOne(x => x.Category);

            //Relacionamento Muitos para Muitos
            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    post => post.HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("PostId")
                    .HasConstraintName("FK_PostTag_PostId")
                    .OnDelete(DeleteBehavior.Cascade),

                    tag => tag.HasOne<Post>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .HasConstraintName("FK_PostTag_TagId")
                    .OnDelete(DeleteBehavior.Cascade));
        }
    }
}