using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Infrastructure.Data.Mapping
{
    public class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(contato => contato.Id);

            builder.OwnsOne(contato => contato.Regiao, regiao =>
            {
                regiao.Property(regiao => regiao.Estado)
                    .IsRequired()
                    .HasColumnType("VARCHAR(2)")
                    .HasColumnName("Estado");

                regiao.Property(regiao => regiao.DDD)
                    .IsRequired()
                    .HasColumnName("DDD");
            });

            builder.OwnsOne(contato => contato.Telefone, telefone =>
            {
                telefone.Property(telefone => telefone.Numero)
                    .IsRequired()
                    .HasColumnType("VARCHAR(9)")
                    .HasColumnName("Telefone");
            });

            builder.OwnsOne(contato => contato.Email, email =>
            {
                email.Property(email => email.EnderecoDeEmail)
                    .IsRequired()
                    .HasColumnType("VARCHAR(100)")
                    .HasColumnName("Email");
            });

            builder.ToTable("Contatos");
        }
    }
}
