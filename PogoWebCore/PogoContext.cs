using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PogoWebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogoWebCore
{
    public class PogoRole: IdentityRole<int>
    {
        
    }
    public class PogoUser: IdentityUser<int>//made keys as int, for easier seeding
    {   
    }
    public class PogoUserRole: IdentityUserRole<int>
    {

    }
    public class PogoContext: IdentityDbContext<PogoUser, PogoRole, int>
    {
        public virtual DbSet<LandmarkType> LandmarkTypes { get; set; }
        public virtual DbSet<Landmark> Landmarks { get; set; }

        public PogoContext(DbContextOptions<PogoContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PogoRole>().HasData(
                new PogoRole
                {
                    Id = 1,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new PogoRole
                {
                    Id = 2,
                    Name = "Editorial",
                    NormalizedName = "EDITORIAL"
                }
            );
            
            var hasher = new PasswordHasher<PogoUser>();
            modelBuilder.Entity<PogoUser>().HasData(
                new PogoUser
                {
                    Id = 1,
                    UserName = "eenemail@ergens.nl",//necessary for login-process?!
                    NormalizedUserName = "EENEMAIL@ERGENS.NL",//necessary for login-process?!
                    Email = "eenemail@ergens.nl",
                    NormalizedEmail = "EENEMAIL@ERGENS.NL",
                    PasswordHash = hasher.HashPassword(null, "temporarypass"),
                    LockoutEnabled = false,
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                }
                /*
                new PogoUser
                {
                    Id = 2,
                    UserName = "Editor",
                    NormalizedUserName = "EDITOR",
                    Email = null,
                    NormalizedEmail = null,
                    PasswordHash = hasher.HashPassword(null, "temporarypass"),
                    EmailConfirmed = true
                }
                */
            );


            modelBuilder.Entity<PogoUserRole>().HasData(
                new List<PogoUserRole>
                {
                    new PogoUserRole
                    {
                        RoleId = 1, // for admin username
                        UserId = 1  // for admin role
                    },
                    /*
                    new PogoUserRole
                    {
                        RoleId = 2, // for staff username
                        UserId = 2  // for staff role
                    }
                    */
                }
            );

            modelBuilder.Entity<LandmarkType>().ToTable("LandmarkTypes");
            modelBuilder.Entity<Landmark>().ToTable("Landmarks");
            modelBuilder.Entity<Landmark>()
                .HasOne<LandmarkType>()
                .WithMany().HasForeignKey(l => l.TypeId)
                .IsRequired();

            modelBuilder.Entity<LandmarkType>().HasData(
new LandmarkType { Id = 1, Name = "Gyms", ImageFileName = "gym.png" },
new LandmarkType { Id = 2, Name = "EX Gyms", ImageFileName = "gymex.png" },
new LandmarkType { Id = 3, Name = "Pokestops", ImageFileName = "stop.png" }
                );

            modelBuilder.Entity<Landmark>().HasData(
new Landmark { Id = 1, TypeId = 1, Name = "Stone benches playground", Longitude = 51.57105, Lattitude = 4.999653 },
new Landmark { Id = 2, TypeId = 1, Name = "Tilburg Landmerk", Longitude = 51.593227, Lattitude = 4.997713 },
new Landmark { Id = 3, TypeId = 1, Name = "Dragon Eating Fish", Longitude = 51.584331, Lattitude = 4.981893 },
new Landmark { Id = 4, TypeId = 1, Name = "Make it Count", Longitude = 51.580279, Lattitude = 4.984198 },
new Landmark { Id = 5, TypeId = 1, Name = "Zwaaiend Mannetje", Longitude = 51.572661, Lattitude = 4.996369 },
new Landmark { Id = 6, TypeId = 1, Name = "Station Tilburg Reeshof", Longitude = 51.573772, Lattitude = 4.993592 },
new Landmark { Id = 7, TypeId = 1, Name = "Social Sofa Heyhoef", Longitude = 51.577547, Lattitude = 5.004373 },
new Landmark { Id = 8, TypeId = 1, Name = "Feestornament Bij Winkelcentrum Heijhoef", Longitude = 51.57784, Lattitude = 5.006211 },
new Landmark { Id = 9, TypeId = 1, Name = "Caterpillar Climbing Structure", Longitude = 51.586196, Lattitude = 5.015391 },
new Landmark { Id = 10, TypeId = 1, Name = "Midwolde playground", Longitude = 51.58979, Lattitude = 4.997072 },
new Landmark { Id = 11, TypeId = 1, Name = "Peerkes Hoeve", Longitude = 51.585734, Lattitude = 4.997185 },
new Landmark { Id = 12, TypeId = 1, Name = "Hoops for 2", Longitude = 51.583528, Lattitude = 5.021307 },
new Landmark { Id = 13, TypeId = 1, Name = "Social Sofa Buurmalsenplein", Longitude = 51.58211, Lattitude = 5.019341 },
new Landmark { Id = 14, TypeId = 1, Name = "Voetbalveld SV Reeshof", Longitude = 51.572761, Lattitude = 5.001855 },
new Landmark { Id = 15, TypeId = 1, Name = "Art stones suburb Witbrand Oost", Longitude = 51.570308, Lattitude = 5.010837 },
new Landmark { Id = 16, TypeId = 1, Name = "Round And Round", Longitude = 51.581468, Lattitude = 4.979233 },
new Landmark { Id = 17, TypeId = 1, Name = "Skatepark Soerendonklaan", Longitude = 51.584361, Lattitude = 4.975831 },
new Landmark { Id = 18, TypeId = 1, Name = "Mini soccerfield Middelharnisstraat", Longitude = 51.592115, Lattitude = 4.998011 },
new Landmark { Id = 19, TypeId = 1, Name = "Basketbal Bijsterveldenlaan", Longitude = 51.587993, Lattitude = 5.006593 },
new Landmark { Id = 20, TypeId = 1, Name = "Sitting Room", Longitude = 51.586467, Lattitude = 5.014508 },
new Landmark { Id = 21, TypeId = 1, Name = "St. Antonius van Paduakerk - Emmausparochie Tilburg", Longitude = 51.581321, Lattitude = 5.014152 },
new Landmark { Id = 22, TypeId = 1, Name = "walking around", Longitude = 51.580924, Lattitude = 5.02348 },
new Landmark { Id = 23, TypeId = 1, Name = "Plekgedicht fietserbrug", Longitude = 51.577503, Lattitude = 4.987057 },
new Landmark { Id = 24, TypeId = 1, Name = "Playground Reeswoude", Longitude = 51.591195, Lattitude = 4.979477 },
new Landmark { Id = 25, TypeId = 1, Name = "Sluis Wilhelminakanaal", Longitude = 51.595889, Lattitude = 4.991992 },
new Landmark { Id = 26, TypeId = 1, Name = "historische kanaalbrug reeshof", Longitude = 51.587898, Lattitude = 5.015182 },

new Landmark { Id = 27, TypeId = 2, Name = "Loosduinenhof playground", Longitude = 51.589204, Lattitude = 5.000623 },
new Landmark { Id = 28, TypeId = 2, Name = "Up Mushroom", Longitude = 51.585992, Lattitude = 5.005582 },
new Landmark { Id = 29, TypeId = 2, Name = "Playground Hoevelaken", Longitude = 51.58447, Lattitude = 5.000339 },
new Landmark { Id = 30, TypeId = 2, Name = "Social Sofa Schipluidenlaan", Longitude = 51.582931, Lattitude = 4.979177 },
new Landmark { Id = 31, TypeId = 2, Name = "JOP Dalemdreef", Longitude = 51.583696, Lattitude = 4.975715 },
new Landmark { Id = 32, TypeId = 2, Name = "Speeltuin Munnikeburenstraat", Longitude = 51.594621, Lattitude = 4.988068 },
new Landmark { Id = 33, TypeId = 2, Name = "Speeltuin Varsseveldstraat", Longitude = 51.573764, Lattitude = 4.976948 },
new Landmark { Id = 34, TypeId = 2, Name = "Reeshofpark West", Longitude = 51.582295, Lattitude = 4.990077 },
new Landmark { Id = 35, TypeId = 2, Name = "Reeshofpark Oost Ingang", Longitude = 51.578598, Lattitude = 5.001672 },
new Landmark { Id = 36, TypeId = 2, Name = "Speeltuin Kortgenestraat", Longitude = 51.575617, Lattitude = 5.005046 },
new Landmark { Id = 37, TypeId = 2, Name = "Play Area Fountain", Longitude = 51.580835, Lattitude = 5.019147 },
new Landmark { Id = 38, TypeId = 2, Name = "Artpiece Around The World", Longitude = 51.59195, Lattitude = 4.988751 },
new Landmark { Id = 39, TypeId = 2, Name = "Speeltuin Metslawierstraat", Longitude = 51.593154, Lattitude = 4.983733 },
new Landmark { Id = 40, TypeId = 2, Name = "Reeshofbos Speelbos", Longitude = 51.573016, Lattitude = 5.020632 },
new Landmark { Id = 41, TypeId = 2, Name = "Climbstone", Longitude = 51.56981, Lattitude = 5.00192 },
new Landmark { Id = 42, TypeId = 2, Name = "Fietsersbrug Mariaradevonder", Longitude = 51.588607, Lattitude = 4.984253 },
new Landmark { Id = 43, TypeId = 2, Name = "Rode Olifant Wip Op Speelplein", Longitude = 51.587265, Lattitude = 4.98298 },
new Landmark { Id = 44, TypeId = 2, Name = "Wall Mural", Longitude = 51.578778, Lattitude = 5.021758 },
new Landmark { Id = 45, TypeId = 2, Name = "Wooden Owl", Longitude = 51.575765, Lattitude = 5.009752 },
new Landmark { Id = 46, TypeId = 2, Name = "Torenvalk Dongevallei", Longitude = 51.577442, Lattitude = 4.986301 },
new Landmark { Id = 47, TypeId = 2, Name = "Rectangular Panoramic Window Art", Longitude = 51.576573, Lattitude = 4.980839 },
new Landmark { Id = 48, TypeId = 2, Name = "Gudok", Longitude = 51.577924, Lattitude = 4.974657 },
new Landmark { Id = 49, TypeId = 2, Name = "Geef Om Een Ander", Longitude = 51.579977, Lattitude = 4.995587 },
new Landmark { Id = 50, TypeId = 2, Name = "Social Sofa Winnen doen we samen", Longitude = 51.585421, Lattitude = 5.003224 },
new Landmark { Id = 51, TypeId = 2, Name = "Artpiece into the Sky", Longitude = 51.579651, Lattitude = 5.013834 },
new Landmark { Id = 52, TypeId = 2, Name = "Sleepy Social Sofa", Longitude = 51.576716, Lattitude = 4.994346 },
new Landmark { Id = 53, TypeId = 2, Name = "Social Sofa Beatrix College", Longitude = 51.577863, Lattitude = 4.994897 },
new Landmark { Id = 54, TypeId = 2, Name = "Referee", Longitude = 51.571268, Lattitude = 4.975853 },
new Landmark { Id = 55, TypeId = 2, Name = "Portrait Mural", Longitude = 51.584276, Lattitude = 4.987918 },
new Landmark { Id = 56, TypeId = 2, Name = "Speeltuin Zelhemstraat", Longitude = 51.571213, Lattitude = 4.98312 },
new Landmark { Id = 57, TypeId = 2, Name = "De Dongevallei", Longitude = 51.594066, Lattitude = 4.980898 },
new Landmark { Id = 58, TypeId = 2, Name = "Charles Rey de Carle", Longitude = 51.579218, Lattitude = 4.998746 },
new Landmark { Id = 59, TypeId = 2, Name = "Minispeeltuin In Vlagtwedde", Longitude = 51.5692899, Lattitude = 4.979325 },
new Landmark { Id = 60, TypeId = 2, Name = "Social Sofa Abcoudestraat", Longitude = 51.567764, Lattitude = 5.01285 },
new Landmark { Id = 61, TypeId = 2, Name = "Blue Puppet", Longitude = 51.593249, Lattitude = 4.991179 },
new Landmark { Id = 62, TypeId = 2, Name = "Burgemeester Letscherbrug", Longitude = 51.601769, Lattitude = 4.976936 },
new Landmark { Id = 63, TypeId = 2, Name = "Up and Down Structure", Longitude = 51.583277, Lattitude = 4.97809 },
new Landmark { Id = 64, TypeId = 3, Name = "De Gaas", Longitude = 51.567833, Lattitude = 5.0048 },
new Landmark { Id = 65, TypeId = 3, Name = "Mozaïc Bankje", Longitude = 51.568917, Lattitude = 5.005279 },
new Landmark { Id = 66, TypeId = 3, Name = "Fietskaart Oude Rielse Baan", Longitude = 51.564747, Lattitude = 4.99312 },
new Landmark { Id = 67, TypeId = 3, Name = "Men In Glass", Longitude = 51.572658, Lattitude = 4.996742 },
new Landmark { Id = 68, TypeId = 3, Name = "Vlinder Sociaal Sofa", Longitude = 51.573432, Lattitude = 4.993208 },
new Landmark { Id = 69, TypeId = 3, Name = "Social Sofa Stadsplein", Longitude = 51.574131, Lattitude = 4.993452 },
new Landmark { Id = 70, TypeId = 3, Name = "Social Sofa I Love Holland", Longitude = 51.574183, Lattitude = 4.993855 },
new Landmark { Id = 71, TypeId = 3, Name = "Wandelbord F -Koolhoven Buiten", Longitude = 51.57343, Lattitude = 4.989553 },
new Landmark { Id = 72, TypeId = 3, Name = "Wandelbord C Koolhoven Buiten", Longitude = 51.571456, Lattitude = 4.986217 },
new Landmark { Id = 73, TypeId = 3, Name = "Zaltbommelse Lange Klimtuin", Longitude = 51.573509, Lattitude = 4.984356 },
new Landmark { Id = 74, TypeId = 3, Name = "Speeltuin Koolhovenlaan", Longitude = 51.572036, Lattitude = 4.981789 },
new Landmark { Id = 75, TypeId = 3, Name = "Living Colors Playground", Longitude = 51.574821, Lattitude = 4.980721 },
new Landmark { Id = 76, TypeId = 3, Name = "Zonnewijzer", Longitude = 51.574874, Lattitude = 4.979432 },
new Landmark { Id = 77, TypeId = 3, Name = "Fluit Stoeltje", Longitude = 51.571588, Lattitude = 4.975593 },
new Landmark { Id = 78, TypeId = 3, Name = "Speeltuin Valkenswaard Vierhouten", Longitude = 51.575761, Lattitude = 4.974634 },
new Landmark { Id = 79, TypeId = 3, Name = "Speeltuin Camping Vlagtwedde", Longitude = 51.570232, Lattitude = 4.971408 },
new Landmark { Id = 80, TypeId = 3, Name = "Sporthal Dongewijk", Longitude = 51.577358, Lattitude = 4.993688 },
new Landmark { Id = 81, TypeId = 3, Name = "Minaret", Longitude = 51.577732, Lattitude = 4.993749 },
new Landmark { Id = 82, TypeId = 3, Name = "Playground Kralingenstraat", Longitude = 51.576907, Lattitude = 4.997374 },
new Landmark { Id = 83, TypeId = 3, Name = "Playground Kalkwijk", Longitude = 51.575976, Lattitude = 5.000216 },
new Landmark { Id = 84, TypeId = 3, Name = "Library Heyhoef", Longitude = 51.578254, Lattitude = 5.006089 },
new Landmark { Id = 85, TypeId = 3, Name = "Honing-Etende Beer Standbeeldje", Longitude = 51.577186, Lattitude = 5.009482 },
new Landmark { Id = 86, TypeId = 3, Name = "Eekhoorn", Longitude = 51.574677, Lattitude = 5.008165 },
new Landmark { Id = 87, TypeId = 3, Name = "Specht poeky", Longitude = 51.573611, Lattitude = 5.009166 },
new Landmark { Id = 88, TypeId = 3, Name = "Konijnen HOST", Longitude = 51.574288, Lattitude = 5.01216 },
new Landmark { Id = 89, TypeId = 3, Name = "vos poeky", Longitude = 51.573333, Lattitude = 5.013333 },
new Landmark { Id = 90, TypeId = 3, Name = "Reeshofbos Noord", Longitude = 51.574619, Lattitude = 5.014209 },
new Landmark { Id = 91, TypeId = 3, Name = "Reeshofbos Oost", Longitude = 51.573054, Lattitude = 5.019399 },
new Landmark { Id = 92, TypeId = 3, Name = "Kwiek Beweegroute (Heerenveldendreef)", Longitude = 51.580352, Lattitude = 5.005684 },
new Landmark { Id = 93, TypeId = 3, Name = "Sportcentrum Tilburg Reeshof", Longitude = 51.579053, Lattitude = 5.006022 },
new Landmark { Id = 94, TypeId = 3, Name = "Reeshof Huibeven", Longitude = 51.581089, Lattitude = 5.006653 },
new Landmark { Id = 95, TypeId = 3, Name = "Zinloos", Longitude = 51.584384, Lattitude = 5.009231 },
new Landmark { Id = 96, TypeId = 3, Name = "Speeltuintje Aan Biervlietplein", Longitude = 51.585058, Lattitude = 5.011673 },
new Landmark { Id = 97, TypeId = 3, Name = "historische kanaalbrug reeshof", Longitude = 51.587898, Lattitude = 5.015182 },
new Landmark { Id = 98, TypeId = 3, Name = "Playground Groenlo", Longitude = 51.581683, Lattitude = 5.0127 },
new Landmark { Id = 99, TypeId = 3, Name = "Playground Huibeven", Longitude = 51.579199, Lattitude = 5.013053 },
new Landmark { Id = 100, TypeId = 3, Name = "Batenburg Playground", Longitude = 51.583465, Lattitude = 5.014754 },
new Landmark { Id = 101, TypeId = 3, Name = "Social Sofa Helen Parkhurst", Longitude = 51.580726, Lattitude = 5.014914 },
new Landmark { Id = 102, TypeId = 3, Name = "Playground Besoijenstraat", Longitude = 51.584711, Lattitude = 5.017424 },
new Landmark { Id = 103, TypeId = 3, Name = "Gedenksteen Plan Reeshof", Longitude = 51.583251, Lattitude = 5.019935 },
new Landmark { Id = 104, TypeId = 3, Name = "Smile", Longitude = 51.582746, Lattitude = 5.020071 },
new Landmark { Id = 105, TypeId = 3, Name = "Colorful Caterpillar Portal Buurmalsenplein", Longitude = 51.58246, Lattitude = 5.019324 },
new Landmark { Id = 106, TypeId = 3, Name = "Children Times Ten Portal", Longitude = 51.58115, Lattitude = 5.01875 },
new Landmark { Id = 107, TypeId = 3, Name = "Bloemenbankje", Longitude = 51.580401, Lattitude = 5.018033 },
new Landmark { Id = 108, TypeId = 3, Name = "Playground Dwingelo", Longitude = 51.578484, Lattitude = 5.018141 },
new Landmark { Id = 109, TypeId = 3, Name = "Totem Palen", Longitude = 51.577096, Lattitude = 5.0196 },
new Landmark { Id = 110, TypeId = 3, Name = "R'hof Beam Bridge for Bikes", Longitude = 51.582899, Lattitude = 5.027767 },
new Landmark { Id = 111, TypeId = 3, Name = "Playground Mijnden", Longitude = 51.597409, Lattitude = 4.984477 },
new Landmark { Id = 112, TypeId = 3, Name = "Voldijkbrug", Longitude = 51.597162, Lattitude = 4.989306 },
new Landmark { Id = 113, TypeId = 3, Name = "Pole Art Menaldumstraat", Longitude = 51.595949, Lattitude = 4.989577 },
new Landmark { Id = 114, TypeId = 3, Name = "Pole Art Mosselhoekplein", Longitude = 51.593144, Lattitude = 4.991849 },
new Landmark { Id = 115, TypeId = 3, Name = "Poles 2", Longitude = 51.594756, Lattitude = 4.994742 },
new Landmark { Id = 116, TypeId = 3, Name = "Rivier Brug", Longitude = 51.593877, Lattitude = 4.9978 },
new Landmark { Id = 117, TypeId = 3, Name = "Kids Delight", Longitude = 51.5916, Lattitude = 4.997831 },
new Landmark { Id = 118, TypeId = 3, Name = "Playground Randwijkstraat", Longitude = 51.585491, Lattitude = 4.977462 },
new Landmark { Id = 119, TypeId = 3, Name = "Playground Ruimelsingel", Longitude = 51.587897, Lattitude = 4.978295 },
new Landmark { Id = 120, TypeId = 3, Name = "Heart Statue", Longitude = 51.585265, Lattitude = 4.978234 },
new Landmark { Id = 121, TypeId = 3, Name = "Speeltuin Ridderkerkerf", Longitude = 51.585315, Lattitude = 4.981014 },
new Landmark { Id = 122, TypeId = 3, Name = "Playground Ruitenveenstraat", Longitude = 51.590315, Lattitude = 4.982053 },
new Landmark { Id = 123, TypeId = 3, Name = "Puzzle Play", Longitude = 51.590962, Lattitude = 4.984301 },
new Landmark { Id = 124, TypeId = 3, Name = "Slinger De Slurf", Longitude = 51.591608, Lattitude = 4.985709 },
new Landmark { Id = 125, TypeId = 3, Name = "Informatiebord Natuurgebied De Dongevallei", Longitude = 51.589005, Lattitude = 4.983711 },
new Landmark { Id = 126, TypeId = 3, Name = "Diving duck plate", Longitude = 51.589082, Lattitude = 4.984846 },
new Landmark { Id = 127, TypeId = 3, Name = "Little Playground Bijsterveldenlaan", Longitude = 51.588795, Lattitude = 4.98695 },
new Landmark { Id = 128, TypeId = 3, Name = "Sprinkhanen", Longitude = 51.587298, Lattitude = 4.983963 },
new Landmark { Id = 129, TypeId = 3, Name = "Informatiebord: Brandnetel", Longitude = 51.586278, Lattitude = 4.983531 },
new Landmark { Id = 130, TypeId = 3, Name = "Informatiebord: Distel Bloem", Longitude = 51.585685, Lattitude = 4.984162 },
new Landmark { Id = 131, TypeId = 3, Name = "Dongevallei Ridderkerksingel", Longitude = 51.585178, Lattitude = 4.984354 },
new Landmark { Id = 132, TypeId = 3, Name = "Informatiebord: Watervogels", Longitude = 51.584398, Lattitude = 4.984302 },
new Landmark { Id = 133, TypeId = 3, Name = "Playground Schipluidenlaan", Longitude = 51.583413, Lattitude = 4.980318 },
new Landmark { Id = 134, TypeId = 3, Name = "Four Ribs", Longitude = 51.579218, Lattitude = 4.978156 },
new Landmark { Id = 135, TypeId = 3, Name = "Stengels", Longitude = 51.583113, Lattitude = 4.984474 },
new Landmark { Id = 136, TypeId = 3, Name = "Color Playground", Longitude = 51.581426, Lattitude = 4.988705 },
new Landmark { Id = 137, TypeId = 3, Name = "Nature Graffiti", Longitude = 51.579936, Lattitude = 4.98401 },
new Landmark { Id = 138, TypeId = 3, Name = "Vierteenschildpad", Longitude = 51.579666, Lattitude = 4.984901 },
new Landmark { Id = 139, TypeId = 3, Name = "Fietsersbrug Sneekpad", Longitude = 51.579474, Lattitude = 4.98768 },
new Landmark { Id = 140, TypeId = 3, Name = "Speeltuin Ossendrechtstraat", Longitude = 51.57892, Lattitude = 4.990202 },
new Landmark { Id = 141, TypeId = 3, Name = "Playground Reeshof Krajicek", Longitude = 51.576032, Lattitude = 4.982187 },
new Landmark { Id = 142, TypeId = 3, Name = "Hulky Face Mural", Longitude = 51.576399, Lattitude = 4.982922 },
new Landmark { Id = 143, TypeId = 3, Name = "Verlanding", Longitude = 51.576121, Lattitude = 4.985526 },
new Landmark { Id = 144, TypeId = 3, Name = "Speeltuin Margratenplein", Longitude = 51.590229, Lattitude = 4.993526 },
new Landmark { Id = 145, TypeId = 3, Name = "Playground On Hill", Longitude = 51.58909, Lattitude = 4.991449 },
new Landmark { Id = 146, TypeId = 3, Name = "Sun is Time", Longitude = 51.588015, Lattitude = 4.990358 },
new Landmark { Id = 147, TypeId = 3, Name = "Playground Nieuwkoopplein", Longitude = 51.586033, Lattitude = 4.989813 },
new Landmark { Id = 148, TypeId = 3, Name = "Peerkes Playground", Longitude = 51.585521, Lattitude = 4.997019 },
new Landmark { Id = 149, TypeId = 3, Name = "Playground Heteren", Longitude = 51.582983, Lattitude = 4.997967 },
new Landmark { Id = 150, TypeId = 3, Name = "Luijkgestel playground", Longitude = 51.587917, Lattitude = 4.999111 },
new Landmark { Id = 151, TypeId = 3, Name = "Lothumse playground", Longitude = 51.588255, Lattitude = 5.002622 },
new Landmark { Id = 152, TypeId = 3, Name = "Speeltuin Lochemstraat", Longitude = 51.586473, Lattitude = 5.003745 },
new Landmark { Id = 153, TypeId = 3, Name = "The Jagged Wall", Longitude = 51.585681, Lattitude = 5.003661 },
new Landmark { Id = 154, TypeId = 3, Name = "Playground Holten", Longitude = 51.583984, Lattitude = 5.002991 },
new Landmark { Id = 155, TypeId = 3, Name = "Playground Hulsberg", Longitude = 51.583404, Lattitude = 5.005304 },
new Landmark { Id = 156, TypeId = 3, Name = "Playground Hontenisse", Longitude = 51.582373, Lattitude = 5.003197 },
new Landmark { Id = 157, TypeId = 3, Name = "Playground Horn", Longitude = 51.580175, Lattitude = 5.003827 },
new Landmark { Id = 158, TypeId = 3, Name = "Move Your Body", Longitude = 51.582487, Lattitude = 4.991772 },
new Landmark { Id = 159, TypeId = 3, Name = "Skate Park", Longitude = 51.582084, Lattitude = 4.995348 },
new Landmark { Id = 160, TypeId = 3, Name = "Reeshofpark Noord ingang", Longitude = 51.582203, Lattitude = 4.996103 },
new Landmark { Id = 161, TypeId = 3, Name = "Stop De Bende art", Longitude = 51.581264, Lattitude = 4.99622 },
new Landmark { Id = 162, TypeId = 3, Name = "The Big Circle", Longitude = 51.580224, Lattitude = 4.998361 },
new Landmark { Id = 163, TypeId = 3, Name = "Cruyff Court", Longitude = 51.579176, Lattitude = 4.999629 },
new Landmark { Id = 164, TypeId = 3, Name = "Basketbalveld", Longitude = 51.579018, Lattitude = 5.000336 },
new Landmark { Id = 165, TypeId = 3, Name = "Reeshofpark Zuid", Longitude = 51.579012, Lattitude = 4.997166 },
new Landmark { Id = 166, TypeId = 3, Name = "Speeltuin Reeshofpark", Longitude = 51.579021, Lattitude = 4.996142 },
new Landmark { Id = 167, TypeId = 3, Name = "Fietsroutenetwerk midden Brabant Knooppunt 56", Longitude = 51.579201, Lattitude = 4.995208 },
new Landmark { Id = 168, TypeId = 3, Name = "Playground koewachtpad", Longitude = 51.571721, Lattitude = 5.00148 },
new Landmark { Id = 169, TypeId = 3, Name = "Playground Wijboschstraat", Longitude = 51.571887, Lattitude = 4.99706 },
new Landmark { Id = 170, TypeId = 3, Name = "Speeltuin Obdamstraat", Longitude = 51.575216, Lattitude = 4.992529 },
new Landmark { Id = 171, TypeId = 3, Name = "Speeltuin Ockenburg", Longitude = 51.575681, Lattitude = 4.989648 },
new Landmark { Id = 172, TypeId = 3, Name = "Wip en hobbelpaard", Longitude = 51.577061, Lattitude = 4.977906 },
new Landmark { Id = 173, TypeId = 3, Name = "Betonnen tafeltennistafel", Longitude = 51.579949, Lattitude = 4.976001 },
new Landmark { Id = 174, TypeId = 3, Name = "Wooden Playground", Longitude = 51.583273, Lattitude = 4.982675 },
new Landmark { Id = 175, TypeId = 3, Name = "Playground Mingersbergstraat", Longitude = 51.593374, Lattitude = 4.987205 },
new Landmark { Id = 176, TypeId = 3, Name = "Speeltuin Midslandstraat", Longitude = 51.595096, Lattitude = 4.985766 },
new Landmark { Id = 177, TypeId = 3, Name = "Three Tol Playground", Longitude = 51.579021, Lattitude = 4.996142 },
new Landmark { Id = 178, TypeId = 3, Name = "Hangaround", Longitude = 51.596153, Lattitude = 4.986827 },
new Landmark { Id = 179, TypeId = 3, Name = "Speeltuin Reeshofpark", Longitude = 51.579021, Lattitude = 4.996142 },
new Landmark { Id = 180, TypeId = 3, Name = "Kabelbaan Witbrand", Longitude = 51.571434, Lattitude = 4.999605 },
new Landmark { Id = 181, TypeId = 3, Name = "Minibieb Vlodropstraat", Longitude = 51.570639, Lattitude = 4.970402 },
new Landmark { Id = 182, TypeId = 3, Name = "Plattegrond Reeshof", Longitude = 51.573785, Lattitude = 4.971201 },
new Landmark { Id = 183, TypeId = 3, Name = "Wip en hobbelpaard", Longitude = 51.577061, Lattitude = 4.977906 },
new Landmark { Id = 184, TypeId = 3, Name = "Goals!!!!", Longitude = 51.582214, Lattitude = 4.976821 },
new Landmark { Id = 185, TypeId = 3, Name = "Kids playground", Longitude = 51.582544, Lattitude = 4.982361 },
new Landmark { Id = 186, TypeId = 3, Name = "Gele wipkip.", Longitude = 51.592044, Lattitude = 4.982904 },
new Landmark { Id = 187, TypeId = 3, Name = "Playground Marlestraat", Longitude = 51.593058, Lattitude = 4.981566 },
new Landmark { Id = 188, TypeId = 3, Name = "3 red Puppets", Longitude = 51.594917, Lattitude = 4.983353 },
new Landmark { Id = 189, TypeId = 3, Name = "Heerevelden", Longitude = 51.583715, Lattitude = 4.999136 },
new Landmark { Id = 190, TypeId = 3, Name = "Wandelbord C Koolhoven Buiten", Longitude = 51.568954, Lattitude = 4.986304 },
new Landmark { Id = 191, TypeId = 3, Name = "Jeu de boules Witbrant West", Longitude = 51.570478, Lattitude = 4.996646 },
new Landmark { Id = 192, TypeId = 3, Name = "Stone Pingpong Table Witbrant West", Longitude = 51.570585, Lattitude = 5.002324 },
new Landmark { Id = 193, TypeId = 3, Name = "Natural Soccer Playground", Longitude = 51.569203, Lattitude = 5.006945 },
new Landmark { Id = 194, TypeId = 3, Name = "Kabelbaan Witbrant Oost", Longitude = 51.56982, Lattitude = 5.008732 },
new Landmark { Id = 195, TypeId = 3, Name = "Jeux de Boule Witbrant Oost", Longitude = 51.569142, Lattitude = 5.010785 },
new Landmark { Id = 196, TypeId = 3, Name = "Playground Witbrant Oost", Longitude = 51.568627, Lattitude = 5.011452 },
new Landmark { Id = 197, TypeId = 3, Name = "Stone PingPong Table Witbrant Oost", Longitude = 51.568587, Lattitude = 5.013424 },
new Landmark { Id = 198, TypeId = 3, Name = "Wooden Play Structure", Longitude = 51.568734, Lattitude = 5.013771 },
new Landmark { Id = 199, TypeId = 3, Name = "Playground Knegselstraat", Longitude = 51.574781, Lattitude = 4.997187 },
new Landmark { Id = 200, TypeId = 3, Name = "Playground Kalkwijkstraat", Longitude = 51.574323, Lattitude = 5.000119 },
new Landmark { Id = 201, TypeId = 3, Name = "Playground Overlangelstraat", Longitude = 51.577824, Lattitude = 4.992885 },
new Landmark { Id = 202, TypeId = 3, Name = "Fietskaart Tilburg", Longitude = 51.576553, Lattitude = 4.977568 },
new Landmark { Id = 203, TypeId = 3, Name = "Klimtoestel", Longitude = 51.579008, Lattitude = 4.979299 },
new Landmark { Id = 204, TypeId = 3, Name = "De 3 rekstokjes", Longitude = 51.579246, Lattitude = 4.975937 },
new Landmark { Id = 205, TypeId = 3, Name = "Lets play football", Longitude = 51.583317, Lattitude = 4.981119 },
new Landmark { Id = 206, TypeId = 3, Name = "Schommelding Ruimelplein", Longitude = 51.585925, Lattitude = 4.978531 },
new Landmark { Id = 207, TypeId = 3, Name = "Spying Man", Longitude = 51.59522, Lattitude = 4.991473 },
new Landmark { Id = 208, TypeId = 3, Name = "Playground Moerdijkerf", Longitude = 51.589413, Lattitude = 4.995002 },
new Landmark { Id = 209, TypeId = 3, Name = "Voetbalveldje Maalbergenpad", Longitude = 51.588161, Lattitude = 4.99441 },
new Landmark { Id = 210, TypeId = 3, Name = "Voetbalveldje Nootdorpstraat", Longitude = 51.584968, Lattitude = 4.996101 },
new Landmark { Id = 211, TypeId = 3, Name = "Voetbalveld Bijsterveldenlaan", Longitude = 51.588275, Lattitude = 5.005894 },
new Landmark { Id = 212, TypeId = 3, Name = "Playground Besoijenpad", Longitude = 51.586226, Lattitude = 5.013568 },
new Landmark { Id = 213, TypeId = 3, Name = "Voetbalveld Besoijenpad", Longitude = 51.585743, Lattitude = 5.014984 },
new Landmark { Id = 214, TypeId = 3, Name = "Voetbalveld Huibenvenpark", Longitude = 51.578273, Lattitude = 5.012451 },
new Landmark { Id = 215, TypeId = 3, Name = "insectenhotel", Longitude = 51.580472, Lattitude = 5.024175 },
new Landmark { Id = 216, TypeId = 3, Name = "Social Sofa Hipo", Longitude = 51.580417, Lattitude = 5.006565 },
new Landmark { Id = 217, TypeId = 3, Name = "De roestuil", Longitude = 51.576075, Lattitude = 4.998967 },
new Landmark { Id = 218, TypeId = 3, Name = "Playground Voerendaalstraat", Longitude = 51.575354, Lattitude = 4.978168 },
new Landmark { Id = 219, TypeId = 3, Name = "Playground Krommeniestraat", Longitude = 51.573928, Lattitude = 5.002984 },
new Landmark { Id = 220, TypeId = 3, Name = "Reeshofbos map", Longitude = 51.574394, Lattitude = 5.006322 },
new Landmark { Id = 221, TypeId = 3, Name = "Kwiek Beweegroute (Gendringenlaan)", Longitude = 51.582393, Lattitude = 5.007127 },
new Landmark { Id = 222, TypeId = 3, Name = "Zwembad Reeshof", Longitude = 51.57946, Lattitude = 5.007133 },
new Landmark { Id = 223, TypeId = 3, Name = "CA bridge.", Longitude = 51.592856, Lattitude = 5.001417 },
new Landmark { Id = 224, TypeId = 3, Name = "Zoek de Beer!", Longitude = 51.573861, Lattitude = 4.986245 },
new Landmark { Id = 225, TypeId = 3, Name = "Speelhoek Koolhovenlaan", Longitude = 51.573048, Lattitude = 4.97473 },
new Landmark { Id = 226, TypeId = 3, Name = "Klimmen en klauteren", Longitude = 51.58129, Lattitude = 4.979945 },
new Landmark { Id = 227, TypeId = 3, Name = "Glijbaan in het park", Longitude = 51.583455, Lattitude = 4.973944 },
new Landmark { Id = 228, TypeId = 3, Name = "Playground Ravensteinerf", Longitude = 51.591513, Lattitude = 4.978253 },
new Landmark { Id = 229, TypeId = 3, Name = "Rustplaats Wilhelminakanaal", Longitude = 51.599911, Lattitude = 4.979389 },
new Landmark { Id = 230, TypeId = 3, Name = "Rode Maanwippert", Longitude = 51.583753, Lattitude = 4.991934 },
new Landmark { Id = 231, TypeId = 3, Name = "Voetbalveld Ossendrecht", Longitude = 51.578288, Lattitude = 4.990242 },
new Landmark { Id = 232, TypeId = 3, Name = "Mini soccerfield menaldumstraat", Longitude = 51.595931, Lattitude = 4.990559 },
new Landmark { Id = 233, TypeId = 3, Name = "Mini soccerfield menaldumstraat", Longitude = 51.595931, Lattitude = 4.990559 },
new Landmark { Id = 234, TypeId = 3, Name = "Wipstoel Pacman", Longitude = 51.58389, Lattitude = 5.016571 }
               );

            //Identity-seeding



            base.OnModelCreating(modelBuilder);
        }
    }
}
