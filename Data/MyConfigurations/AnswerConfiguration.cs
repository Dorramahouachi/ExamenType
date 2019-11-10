using Domaine;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.MyConfigurations
{
    public class AnswerConfiguration: EntityTypeConfiguration<Answer>
    {
        public AnswerConfiguration()
        {
            HasRequired(p => p.Question)
           .WithMany(c => c.Answers)
           .HasForeignKey(p => p.QuestionID)
           .WillCascadeOnDelete(true);
        }
    }
}
