using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(1000);
            builder.Property(x => x.CreatedByName).IsRequired();
            builder.Property(x => x.CreatedByName).HasMaxLength(50);
            builder.Property(x => x.MotifiedByName).IsRequired();
            builder.Property(x => x.MotifiedByName).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.MotifiedByName).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.HasOne<Article>(x => x.Article).WithMany(y => y.Comments).HasForeignKey(z => z.ArticleId);
            builder.ToTable("Comments");

            builder.HasData(new Comment
            {
                Id = 1,
                ArticleId = 1,
                Text = "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                MotifiedByName = "InitialCreate",
                MotifiedDate = DateTime.Now,
                Note = "C# Makale Yorumu"
            },
            new Comment
            {
                Id = 2,
                ArticleId = 2,
                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                MotifiedByName = "InitialCreate",
                MotifiedDate = DateTime.Now,
                Note = "C++ Makale Yorumu"
            },
            new Comment
            {
                Id = 3,
                ArticleId = 3,
                Text = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                MotifiedByName = "InitialCreate",
                MotifiedDate = DateTime.Now,
                Note = "JavaScript Makale Yorumu"
            });
        }
    }
}
