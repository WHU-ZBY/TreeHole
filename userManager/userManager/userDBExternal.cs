namespace userManager
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class userDBExternal : DbContext
    {
        public userDBExternal()
            : base("name=userDBExternal")
        {
        }

        public virtual DbSet<messages> messages { get; set; }
        public virtual DbSet<replies> replies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<messages>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<messages>()
                .Property(e => e.wxid)
                .IsUnicode(false);

            modelBuilder.Entity<messages>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<messages>()
                .Property(e => e.time)
                .IsUnicode(false);

            modelBuilder.Entity<messages>()
                .Property(e => e.region)
                .IsUnicode(false);

            modelBuilder.Entity<messages>()
                .Property(e => e.imageid)
                .IsUnicode(false);

            modelBuilder.Entity<replies>()
                .Property(e => e.imageid)
                .IsUnicode(false);

            modelBuilder.Entity<replies>()
                .Property(e => e.wxid)
                .IsUnicode(false);

            modelBuilder.Entity<replies>()
                .Property(e => e.content)
                .IsUnicode(false);

            modelBuilder.Entity<replies>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<replies>()
                .Property(e => e.time)
                .IsUnicode(false);

            modelBuilder.Entity<replies>()
                .Property(e => e.replyto)
                .IsUnicode(false);
        }
    }
}
