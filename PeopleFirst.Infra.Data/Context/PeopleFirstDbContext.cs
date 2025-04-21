using Microsoft.EntityFrameworkCore;
using PeopleFirst.Domain.Entities;

namespace PeopleFirst.Infra.Data.Context
{
    public class PeopleFirstDbContext : DbContext
    {
        public PeopleFirstDbContext(DbContextOptions<PeopleFirstDbContext> options) : base(options) { }

        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<TipoCompetencia> TiposCompetencia { get; set; }
        public DbSet<AvaliacaoColaborador> AvaliacoesColaborador { get; set; }
        public DbSet<PilarCompetencia> PilaresCompetencia { get; set; }
        public DbSet<ItemPilar> ItensPilar { get; set; }
        public DbSet<AvaliacaoColaboradorItemPilar> AvaliacoesItensPilar { get; set; }
        public DbSet<TipoFeedback> TiposFeedback { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<TimeColaborador> TimesColaboradores { get; set; }
        public DbSet<Happiness> Happinesses { get; set; }
        public DbSet<PilarHappiness> PilaresHappiness { get; set; }
        public DbSet<OpiniaoPilarHappiness> OpinioesPilarHappiness { get; set; }
        public DbSet<DominioAgilidade> DominioAgilidade { get; set; }
        public DbSet<PilarDominio> PilarDominio { get; set; }
        public DbSet<QuestaoPilar> QuestaoPilar { get; set; }
        public DbSet<HealthCheck> HealthCheck { get; set; }
        public DbSet<AvaliacaoHealthCheck> AvaliacaoHealthCheck { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configurações de tabelas (iremos adicionar conforme criamos as entidades)
            modelBuilder.Entity<Perfil>(entity =>
                {
                    entity.ToTable("perfil");
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.PerfilNome).HasColumnName("perfil");
                });

            modelBuilder.Entity<Colaborador>(entity =>
            {
                entity.ToTable("colaborador");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nome).HasColumnName("nome");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.DataNascimento).HasColumnName("datanascimento");
                entity.Property(e => e.Cargo).HasColumnName("cargo");
                entity.Property(e => e.Ativo).HasColumnName("ativo");
                entity.Property(e => e.Foto).HasColumnName("foto");
                entity.Property(e => e.PerfilId).HasColumnName("idPerfil");

                entity.HasOne(e => e.Perfil)
                    .WithMany()
                    .HasForeignKey(e => e.PerfilId);
            });   

            modelBuilder.Entity<AvaliacaoColaborador>(entity =>
            {
                entity.ToTable("avaliacaocolaborador");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdColaborador).HasColumnName("idColaborador");
                entity.Property(e => e.IdLider).HasColumnName("idLider");
                entity.Property(e => e.Data).HasColumnName("data");
                entity.Property(e => e.Percepcao).HasColumnName("percepcao");
                entity.Property(e => e.ComentarioGeral).HasColumnName("comentarioGeral");
                entity.Property(e => e.PlanoAcao).HasColumnName("planoAcao");
                entity.Property(e => e.AvaliacaoColaboradorCol).HasColumnName("avaliacaoColaboradorcol");
                entity.Property(e => e.Finalizada).HasColumnName("finalizada");
                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");

                entity.HasOne(e => e.Colaborador)
                    .WithMany()
                    .HasForeignKey(e => e.ColaboradorId);
            });

            modelBuilder.Entity<TipoCompetencia>(entity =>
            {
                entity.ToTable("tipoCompetencia");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            modelBuilder.Entity<ItemPilar>(entity =>
            {
                entity.ToTable("itempilar");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Item).HasColumnName("item");
                entity.Property(e => e.Descricao).HasColumnName("descricao");
                entity.Property(e => e.PilarCompetenciaId).HasColumnName("pilarCompetencia_id");

                entity.HasOne(e => e.PilarCompetencia)
                    .WithMany()
                    .HasForeignKey(e => e.PilarCompetenciaId);
            });

            modelBuilder.Entity<AvaliacaoColaboradorItemPilar>(entity =>
            {
                entity.ToTable("avalicaocolaboradoritempilar");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdAvaliacaoColaborador).HasColumnName("idAvaliacaoColaborador");
                entity.Property(e => e.IdItemPilar).HasColumnName("idItemPilar");
                entity.Property(e => e.Nota).HasColumnName("nota");
                entity.Property(e => e.ItemPilarId).HasColumnName("itemPilar_id");
                entity.Property(e => e.AvaliacaoColaboradorId).HasColumnName("avaliacaoColaborador_id");

                entity.HasOne(e => e.AvaliacaoColaborador)
                    .WithMany()
                    .HasForeignKey(e => e.AvaliacaoColaboradorId);

                entity.HasOne(e => e.ItemPilar)
                    .WithMany()
                    .HasForeignKey(e => e.ItemPilarId);
            });

            modelBuilder.Entity<TipoFeedback>(entity =>
            {
                entity.ToTable("tipofeedback");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Tipo).HasColumnName("tipo").IsRequired();
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdColaborador).HasColumnName("idColaborador");
                entity.Property(e => e.IdLider).HasColumnName("idLider");
                entity.Property(e => e.IdTipoFeedback).HasColumnName("idTipoFeedback");
                entity.Property(e => e.Observacoes).HasColumnName("observacoes");
                entity.Property(e => e.Data).HasColumnName("data");
                entity.Property(e => e.Percepcao).HasColumnName("percepcao");
                entity.Property(e => e.PlanoAcao).HasColumnName("planoAcao");
                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");
                entity.Property(e => e.TipoFeedbackId).HasColumnName("tipoFeedback_id");

                entity.HasOne(e => e.Colaborador)
                    .WithMany()
                    .HasForeignKey(e => e.ColaboradorId);

                entity.HasOne(e => e.TipoFeedback)
                    .WithMany()
                    .HasForeignKey(e => e.TipoFeedbackId);
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.ToTable("time");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nome).HasColumnName("nome");
                entity.Property(e => e.Ativo).HasColumnName("ativo");
            });

            modelBuilder.Entity<TimeColaborador>(entity =>
            {
                entity.ToTable("timecolaborador");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdTime).HasColumnName("idTime");
                entity.Property(e => e.IdColaborador).HasColumnName("idColaborador");
                entity.Property(e => e.TimeId).HasColumnName("time_id");
                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");

                entity.HasOne(e => e.Time)
                    .WithMany()
                    .HasForeignKey(e => e.TimeId);

                entity.HasOne(e => e.Colaborador)
                    .WithMany()
                    .HasForeignKey(e => e.ColaboradorId);
            });

            modelBuilder.Entity<Happiness>(entity =>
            {
                entity.ToTable("happiness");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdColaborador).HasColumnName("idColaborador");
                entity.Property(e => e.Data).HasColumnName("data");
                entity.Property(e => e.NotaGeral).HasColumnName("NotaGeral");
                entity.Property(e => e.AvaliacaoGeral).HasColumnName("avaliacaoGeral");
                entity.Property(e => e.ColaboradorId).HasColumnName("colaborador_id");
                entity.Property(e => e.ColaboradorPerfilId).HasColumnName("colaborador_perfil_id");

                entity.HasOne(e => e.Colaborador)
                    .WithMany()
                    .HasForeignKey(e => e.ColaboradorId);
            });

            modelBuilder.Entity<PilarHappiness>(entity =>
            {
                entity.ToTable("pilarhappiness");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Pilar).HasColumnName("pilar");
                entity.Property(e => e.DescricaoPilar).HasColumnName("descricaoPilar");
                entity.Property(e => e.Ativo).HasColumnName("ativo");
            });

            modelBuilder.Entity<OpiniaoPilarHappiness>(entity =>
            {
                entity.ToTable("OpiniaoPilarHappiness");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IdHappiness).HasColumnName("idHappiness");
                entity.Property(e => e.IdPilarHappiness).HasColumnName("idPilarHappiness");
                entity.Property(e => e.Nota).HasColumnName("nota");
                entity.Property(e => e.Comentario).HasColumnName("comentario");
                entity.Property(e => e.HappinessId).HasColumnName("happiness_id");
                entity.Property(e => e.PilarHappinessId).HasColumnName("pilarHappiness_id");

                entity.HasOne(e => e.Happiness)
                    .WithMany()
                    .HasForeignKey(e => e.HappinessId);

                entity.HasOne(e => e.PilarHappiness)
                    .WithMany()
                    .HasForeignKey(e => e.PilarHappinessId);
            });
        
                    modelBuilder.Entity<PilarCompetencia>(entity =>
            {
                entity.ToTable("PilarCompetencia");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Pilar).HasColumnName("Pilar");
                entity.Property(e => e.Descricao).HasColumnName("Descricao");
                entity.Property(e => e.PerfilId).HasColumnName("PerfilId");
                entity.Property(e => e.TipoCompetenciaId).HasColumnName("TipoCompetenciaId");

                entity.HasOne(e => e.Perfil)
                    .WithMany()
                    .HasForeignKey(e => e.PerfilId);

                entity.HasOne(e => e.TipoCompetencia)
                    .WithMany()
                    .HasForeignKey(e => e.TipoCompetenciaId);
            });	

        }
    }
}