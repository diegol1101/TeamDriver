using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;

namespace Infraestructura.Configuration;
public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("team");

        builder.HasIndex(e => e.Name, "team_name_IDX").IsUnique();

        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");

        builder
           .HasMany(p => p.Drivers)
           .WithMany(r => r.Teams)
           .UsingEntity<TeamDriver>(

               j => j
               .HasOne(pt => pt.Driver)
               .WithMany(t => t.TeamDrivers)
               .HasForeignKey(ut => ut.idDriver),

               j => j
               .HasOne(et => et.Team)
               .WithMany(et => et.TeamDrivers)
               .HasForeignKey(el => el.IdTeam),

               j =>
               {
                   j.ToTable("team_driver");
                   j.HasKey(t => new { t.IdTeam, t.idDriver });

               });
    }
}