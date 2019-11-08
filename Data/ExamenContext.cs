using Data.MyConfigurations;
using Domaine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
  public  class ExamenContext : DbContext
    {
        public ExamenContext() :base("Name=alias")
        {
        }
        public DbSet<Candidat> Candidat { get; set; }
        public DbSet<Candidature> Candidature { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Entreprise> Entreprise { get; set; }
        public DbSet<subscribe> Subscribe { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Calendrier> Calendrier { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<EntretienEnLigne> EntretienEnLigne { get; set; }
        public DbSet<EntretienPhysique> EntretienPhysique { get; set; }
        public DbSet<Post> Post { get; set; }
   
        public DbSet<ReactComment> ReactComment { get; set; }
        public DbSet<ReactPost> ReactPost { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        

        /*  protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
              modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
              modelBuilder.Configurations.Add(new QuestionConfiguration());
              modelBuilder.Configurations.Add(new AnswerConfiguration());
          }*/
    }
}
