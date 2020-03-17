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

        public virtual DbSet<location> locations { get; set; }
        public virtual DbSet<route> routes { get; set; }
        public virtual DbSet<hop> hops { get; set; }
        public virtual DbSet<placestovisit> Placestovisits { get; set; }
        public virtual DbSet<rating> ratings { get; set; }
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
    public class rating
    {
        public int ratingid { get; set; }
        public int itemid { get; set; }
        public string itemtype { get; set; }
        public int ratedby { get; set; }
        public int Rating { get; set; }
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