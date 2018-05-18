namespace MessengerServiceHost.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MessengerContext : DbContext
    {
        public MessengerContext()
            : base("name=MessengerContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageContent> MessageContents { get; set; }
    }
}