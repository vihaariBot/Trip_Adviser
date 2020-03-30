namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class TAmodel : DbContext
    {
        // Your context has been configured to use a 'TAmodel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataAccessLayer.TAmodel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TAmodel' 
        // connection string in the application configuration file.
        public TAmodel()
             : base("constr")
        {
        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<location> locations { get; set; }
        public virtual DbSet<route> routes { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<hop> hops { get; set; }
        public virtual DbSet<placestovisit> Placestovisits { get; set; }
        public virtual DbSet<rating> ratings { get; set; }
        public virtual DbSet<Lodge> Lodges { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    public class location
    {
        [Key]
        public int locationid { get; set; }
        public string locationname { get; set; }
        public string description { get; set; }

    }
    public class Restaurant
    {
        [Key]
        public int RESTAURANT_ID { get; set; }
        [Required]
        public string RESTAURANT_NAME { get; set; }
        [Required]
        public int LOCATION_ID { get; set; }
        [Required]
        public string ADRESS { get; set; }
        [Required]
        public int PRICE { get; set; }

        [ForeignKey("LOCATION_ID")]
        public location ildd { get; set; }
    }

    public class rating
    {
        public int ratingid { get; set; }
        public int itemid { get; set; }
        public string itemtype { get; set; }
        public int ratedby { get; set; }
        public int Rating { get; set; }
    }
    public class Lodge
    {
        [Key]

        public int LODGE_ID { get; set; }


        public int LOCATION_ID { get; set; }

        public string LODGE_NAME { get; set; }

        public string LODGE_ADD { get; set; }

        public int PRICE { get; set; }
        [ForeignKey("LOCATION_ID")]
        public location Lidd { get; set; }


    }
    public class route
    {
        [Key]
        public int routeid { get; set; }
        public location fromloc { get; set; }
        [ForeignKey("fromloc")]
        public int fromlocation { get; set; }

        public location toloc { get; set; }
        [ForeignKey("toloc")]
        public int tolocation { get; set; }
        public string modeoftravel { get; set; }
    }
    public class Registration
    {
        [Key]
        [Required]
        public int USER_ID { get; set; }
        [Required]
        public string USER_NAME { get; set; }
        [Required]
        public string PASSWORD { get; set; }
        [Required]
        public string EMAILID { get; set; }
    }
    public class hop
    {
        [Key]
        public int hopid { get; set; }
        public int routeid { get; set; }
        public int hoplocation { get; set; }
    }
    public class placestovisit
    {
        [Key]
        public int ptvid { get; set; }
        public string placename { get; set; }
        public location locid { get; set; }
        [ForeignKey("locid")]
        public int locationid { get; set; }
        public string address { get; set; }
    }
}