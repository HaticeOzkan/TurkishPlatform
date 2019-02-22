using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace TurkishPlatform.Models
{
    public class PlatformContext : DbContext
    {
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Advice> Advices { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<ForumComment> ForumComments { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Tourism> Tourisms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AdviceTopic> AdviceTopics { get; set; }
        public virtual DbSet<ForumCommentCategory> ForumCommentCategories { get; set; }
        public virtual DbSet<ForumCommentTopic> ForumCommentTopics { get; set; }
        public virtual DbSet<RestaurantComment> RestaurantComments { get; set; }
        public virtual DbSet<RestaurantImage> RestaurantImages { get; set; }
        public virtual DbSet<LocationImage> LocationImages { get; set; }
        public virtual DbSet<LocationComment> LocationComments { get; set; }
        public virtual DbSet<AdminProfil> AdminProfils { get; set; }
        public virtual DbSet<ForumTopicTitle> ForumTopicTitles { get; set; }
		public virtual DbSet<Contact> Contacts { get; set; }
        
       
    }
}