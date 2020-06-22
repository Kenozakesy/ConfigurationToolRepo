using ConfigurationToolStructurePOC.Business.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationToolStructurePOC.DAL.Configurations
{
    public class OARecipeConfiguration : EntityTypeConfiguration<OARecipe>
    {
        public OARecipeConfiguration()
        {
            // Primary Key
            this.HasKey(t => new { t.oar_ProcedureId, t.oar_OAStateId });

            // Properties
            this.Property(t => t.oar_ProcedureId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.oar_OAStateId)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.oar_OARcpNM)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("oar_OARcps");
            this.Property(t => t.oar_ProcedureId).HasColumnName("oar_ProcedureId");
            this.Property(t => t.oar_OAStateId).HasColumnName("oar_OAStateId");
            this.Property(t => t.oar_OARcpNM).HasColumnName("oar_OARcpNM");

            // Relationships
            this.HasRequired(t => t.Procedure)
                .WithMany(t => t.OARecipes)
                .HasForeignKey(d => d.oar_ProcedureId);

        }
    }
}
