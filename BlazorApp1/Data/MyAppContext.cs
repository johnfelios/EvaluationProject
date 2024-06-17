using BlazorApp1.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options)
        : base(options)
        { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<BoardingMember> BoardingMembers { get; set; }
        public DbSet<Cleaner> Cleaners { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }
        public DbSet<TimeSlot> TimeSlots {  get; set; }
        public DbSet<CourseTimeSlot> CourseTimeSlots { get; set; }
        public DbSet<CleanerTimeSlot> CleanerTimeSlots { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=UniDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseTimeSlot>()
           .HasKey(cts => new { cts.CourseId, cts.TimeSlotId });

            modelBuilder.Entity<CourseTimeSlot>()
             .HasOne(cts => cts.Course)
             .WithMany(c => c.CourseTimeSlots)
             .HasForeignKey(cts => cts.CourseId);


            modelBuilder.Entity<CleanerTimeSlot>()
            .HasKey(clts => new { clts.CleanerAccountId, clts.TimeSlotId });

            modelBuilder.Entity<CleanerTimeSlot>()
                .HasOne(clts => clts.Cleaner)
                .WithMany(c => c.WorkingTimeSlots)
                .HasForeignKey(clts => clts.CleanerAccountId);

            //modelBuilder.Entity<CleanerTimeSlot>()
            //    .HasOne(clts => clts.TimeSlot)
            //    .WithMany()
            //    .HasForeignKey(clts => clts.TimeSlotId);


            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Cleaner>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.CourseId);

            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => sc.Id);

            //modelBuilder.Entity<StudentCourse>()
            //  .HasOne(sc => sc.Course)
            //  .WithMany() 
            //  .HasForeignKey(sc => sc.CourseId);
            
            
            base.OnModelCreating(modelBuilder);

        }
    }
   
}
