using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using SmartBankCore.domain;

namespace SmartBankCore.adapters.persistence
{
    public class SmartBankDataModel : DbContext
    {
        public SmartBankDataModel()
            : base("name=SmartBankDataModel")
        {
            //Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<BankAccount> BANK_ACCOUNTS { get; set; }
        public virtual DbSet<BankUser> BANK_USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // *** BANK_ACCOUNTS *** config

            modelBuilder.Entity<BankAccount>()
                .Property(e => e.Owner)
                .IsRequired()
                .HasMaxLength(12)
                .HasColumnName("OWNER")
                .IsUnicode(false);

            modelBuilder.Entity<BankAccount>()
                .Property(e => e.Balance)
                .IsRequired()
                .HasColumnName("BALANCE");

            modelBuilder.Entity<BankAccount>()
                .Property(e => e.CreatedDate)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("CREATED_DATE");

            modelBuilder.Entity<BankAccount>()
                .Property(e => e.AccountNumber)
                .IsRequired()
                .HasColumnName("ACCOUNT_NUMBER")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<BankAccount>()
                .ToTable("BANK_ACCOUNT")
                .HasKey(e => e.AccountNumber);

            // *** BANK_USERS config ***

            modelBuilder.Entity<BankUser>()
                .Property(e => e.Name)
                .HasColumnName("NAME")
                .IsRequired()
                .HasMaxLength(128);

            modelBuilder.Entity<BankUser>()
                .Property(e => e.Username)
                .HasColumnName("USERNAME")
                .IsRequired()
                .HasMaxLength(16);

            modelBuilder.Entity<BankUser>()
                .Property(e => e.Password)
                .HasColumnName("PASSWORD")
                .IsRequired()
                .HasMaxLength(128);

            modelBuilder.Entity<BankUser>()
                .Property(e => e.Pin)
                .HasColumnName("PIN")
                .IsRequired();

            modelBuilder.Entity<BankUser>()
                .Property(e => e.Salt)
                .HasColumnName("SALT")
                .HasMaxLength(32)
                .IsRequired();

            modelBuilder.Entity<BankUser>()
                .ToTable("BANK_USERS")
                .HasKey(e => e.Username)
                .HasMany(e => e.BankAccounts)
                .WithRequired(e => e.BankUser)
                .HasForeignKey(e => e.Owner)
                .WillCascadeOnDelete(true);
        }
    }
}