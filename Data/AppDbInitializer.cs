using SoccerJerseyPass.Data.Enums;
using SoccerJerseyPass.Models;
using static System.Net.WebRequestMethods;

namespace SoccerJerseyPass.Data
{
    public class AppDbInitializer
    {
        public static void seed (IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService <AppDbContext> ();

                context.Database.EnsureCreated ();  

                // League
                if (!context.Leagues.Any ())
                {
                    context.Leagues.AddRange(new List<League>()

                    {
                        new League ()
                        {
                            Name = "Ligue 1",
                            Logo = "https://www.fifplay.com/img/public/ligue-1-logo.jpg",
                            Description = "This is the French professional league for men's association football clubs. " +
                            "At the top of the French football league system, it is the country's primary football competition."
                        },

                        new League ()
                        {
                            Name = "Premier League",
                            Logo = "https://cdn.thedesigninspiration.com/wp-content/uploads/sites/3/2021/04/Premier-League-logo.png",
                            Description = "This is the English professional football (soccer) league established in 1992. " +
                            "The league, which comprises 20 clubs, superseded the first division of the English Football League (EFL)" +
                            " as the top level of football in England."
                        },

                        new League ()
                        {
                            Name = "La Liga",
                            Logo = "https://cdn.dribbble.com/users/422205/screenshots/4025424/la_liga_logo_redesign.png",
                            Description = "Also called (Campeonato Nacional de Liga de Primera División) is" +
                            " the name of the Spanish football league" +
                            " and has existed since 1929."
                        },

                        new League ()
                        {
                            Name = "the Bundesliga",
                            Logo = "https://e7.pngegg.com/pngimages/489/415/png-clipart-bundesliga-logo-bundesliga-logo-icons-logos-emojis-football.png",
                            Description = "This is the Germany's premier football league is called the Bundesliga. " +
                            "The literal translation of the word Bundesliga is federal league. The league consists of 18 teams" +
                            " and they play in the home and away match format. The league operates on a system of promotion" +
                            " and relegation.."
                        },

                        new League ()
                        {
                            Name = "Serie A",
                            Logo = "https://1000logos.net/wp-content/uploads/2019/01/Italian-Serie-A-TIM-Logo-2021.png",
                            Description = "This is Italy's top domestic league is known as Serie A. It's comprised of professional " +
                            "football clubs (the for-profit teams like those in America's NFL, NBA, or Major League Baseball). " +
                            "Italy's national team is called La Squadra Azzura (The Blue Team, named for the uniforms)."
                        },


                    });


                    context.SaveChanges();

                }


                // Coach
                if (!context.Coaches.Any())
                {

                    context.Coaches.AddRange(new List<Coach>()
                    {
                        new Coach()
                        {
                            ProfilePictureURL = "https://cdn.punchng.com/wp-content/uploads/2022/07/05131726/Christophe-Galtier.jpg",
                            FullName = "Christophe Galtier",
                            Bio = "Christophe Galtier (born 23 August 1966) is a French professional football coach " +
                            "and former player who is the head coach of Ligue 1 club Paris Saint-Germain."
                        },

                        new Coach()
                        {
                            ProfilePictureURL = "https://cdn.vox-cdn.com/thumbor/MuKI3-k1OpA_BwGjHZlNB31lK50=/0x0:3200x4000/1200x800/filters:focal(1354x650:1866x1162)/cdn.vox-cdn.com/uploads/chorus_image/image/70115706/1352146429.0.jpg",
                            FullName = "Xavier Hernández Creus",
                            Bio = "Xavier Hernández Creus, commonly known as Xavi, is a Spanish professional football manager" +
                             " and former player who is the manager of La Liga club Barcelona. Widely considered one of the " +
                              "greatest midfielders of all time, Xavi was renowned for his passing, vision, ball retention, " +
                              "and positioning."
                        },

                        new Coach()
                        {
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/79/Julian_Nagelsmann_2020.jpg/220px-Julian_Nagelsmann_2020.jpg",
                            FullName = "Julian Nagelsmann",
                            Bio = "Julian Nagelsmann is a German professional football manager and former football player who" +
                               " is the head coach of Bayern Munich. Prior to managing Bayern, he managed 1899 Hoffenheim and" +
                               " RB Leipzig."
                        },

                        new Coach()
                        {
                            ProfilePictureURL = "https://www.footballtalk.org/wp-content/uploads/2020/07/Stefano-Pioli-ac-milan-manager.jpg",
                            FullName = "Stefano Pioli",
                            Bio = "Stefano Pioli is an Italian football manager and a former footballer who played as" +
                               " a defender. He is the head coach at Serie A club AC Milan, whom he led to the Serie A title " +
                                 "in 2022."
                        },


                        new Coach()
                        {
                             ProfilePictureURL = "https://static.independent.co.uk/2023/03/10/13/605f8fc172e1ab6c50c537710642f441Y29udGVudHNlYXJjaGFwaSwxNjc4NTQxNzc1-2.71253165.jpg",
                             FullName = "Jürgen Klopp",
                             Bio = " Jürgen Norbert Klopp is a German professional football manager and former player " +
                             "who is the manager of Premier League club Liverpool. He is widely regarded as one of the best managers" +
                             " in the world. Klopp spent most of his playing career at MainzJürgen Klopp made Liverpool champions " +
                             "of England, Europe and the world within five years" +
                             " of his appointment at Anfield in October 2015. "
                        },

                    });

                    context.SaveChanges();

                }

                //Player
                if (!context.Players.Any())
                {
                    context.Players.AddRange(new List<Player>()
                    {

                        new Player()
                        {
                            ProfilePictureURL= "https://icdn.psgtalk.com/wp-content/uploads/2021/10/lionel-messi-paris-saint-germain-v-rb-leipzig-group-a-uefa-champions-league-2021-2.jpg",
                            FullName = "Lionel Messi",
                            Bio = "Lionel Andrés Messi, also known as Leo Messi, is an Argentine professional footballer " +
                            "who plays as a forward for Ligue 1 club Paris Saint-Germain and captains the Argentina national team." +
                            "He is considered to be one of the best soccer player of all time."
                        },

                        new Player()
                        {
                            ProfilePictureURL= "https://www.fcbarcelona.com/photo-resources/2022/11/02/9b93a4c7-2ec5-4409-b08e-e551b1c983df/mini_09-ROBERT_LEWANDOWSKI.png?width=670&height=790",
                            FullName = "Robert Lewandowski",
                            Bio = "Robert Lewandowski is a Polish professional footballer who plays as a striker for La Liga club " +
                            "Barcelona and captains the Poland national team"
                        },

                        new Player()
                        {
                            ProfilePictureURL= "https://sportnewsafrica.com/wp-content/uploads/2023/03/71093864-49535635.jpg",
                            FullName = "Sadio Mané",
                            Bio = "Sadio Mané is a Senegalese professional footballer who plays as a forward for Bundesliga club" +
                            " Bayern Munich and the Senegal national team. Widely regarded as one of the best players in the world " +
                            "and amongst the greatest African players of all time, he is known for his pressing, dribbling, and speed."
                        },

                        new Player()
                        {
                            ProfilePictureURL = "https://phantom-marca.unidadeditorial.es/20aa6ea47e1cf5a870c13f1e7c37ed1b/resize/1320/f/jpg/assets/multimedia/imagenes/2021/10/18/16345576578909.jpg",
                            FullName = "Mohamed salah",
                            Bio = "Mohamed Salah Hamed Mahrous Ghaly, also known as Mo Salah, is an Egyptian professional " +
                            "footballer who plays as a forward for Premier League club Liverpool and captains the Egypt national " +
                            "team."
                        },


                        new Player()
                        {
                             ProfilePictureURL = "https://media.cnn.com/api/v1/images/stellar/prod/210423105137-01-zlatan-ibrahimovic-file.jpg?q=w_3000,h_2000,x_0,y_0,c_fill",
                             FullName = "Zlatan Ibrahimović",
                             Bio = "Zlatan Ibrahimović is a Swedish professional footballer who plays as a striker for Serie A " +
                             "club AC Milan and the Sweden national team. Ibrahimović is renowned for his acrobatic strikes and " +
                             "volleys, powerful long-range shots, and excellent technique and ball control."
                        },



                    });

                    context.SaveChanges();
                }

                // Player & Soccer_Player
                if (!context.Player_Jerseys.Any())
                {
                    context.Player_Jerseys.AddRange(new List<Player_Jersey>()
                    {

                        new Player_Jersey ()
                        {
                            Soccer_JerseyId = 1,
                            PlayerId = 1
                        },

                        new Player_Jersey ()
                        {
                            Soccer_JerseyId = 3,
                            PlayerId = 2
                        },

                        new Player_Jersey ()
                        {
                            Soccer_JerseyId = 2,
                            PlayerId = 3
                        },

                        new Player_Jersey ()
                        {
                            Soccer_JerseyId = 4,
                            PlayerId = 4
                        },

                        new Player_Jersey ()
                        {
                            Soccer_JerseyId = 5,
                            PlayerId = 5
                        },

                    });

                    context.SaveChanges();
                }

                // Soccer_Player
                if (!context.Soccer_Jerseys.Any())
                {
                    context.Soccer_Jerseys.AddRange(new List<Soccer_Jersey>()
                    {
                        new Soccer_Jersey()
                        {
                            Name = "Messi Jersey #30 ",
                            Description = "Men's Replica MESSI #30 PSG Fourth Away Soccer Jersey Shirt 2022/23 Jordan",
                            Price = 31.99,
                            ImageURL = "https://images.footballfanatics.com/paris-saint-germain/paris-saint-germain-x-jordan-fourth-stadium-shirt-2022-23-with-messi-30-printing_ss4_p-13371159+u-waguz5ph3cgzzq5tztrp+v-f5a0c3917bb14ecbb6988fb6e011fc3d.jpg?_hv=2&w=900",
                            Size = "Medium",
                            Sleeve = "Short",
                            LeagueId = 1    ,
                            CoachId= 1,
                            Club = Club.PSG
                        },

                        new Soccer_Jersey()
                        {

                            Name = "Sadio Mane #17 ",
                            Description = "Men's Replica SANÉ #17 Bayern Munich Third Away Soccer Jersey Shirt 2022/23 Adidas",
                            Price = 27.99,
                            ImageURL = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcS-Hu_QMIC5AjlC4H6VlMhb3-ksLsbQsbQl6ovxCraGuDB65bClmjIXV3Fs2eH7JH66C3jxww_7egxnBUwMBysZX8z6TyjdyrY8dEAnqKlTQxcKeXKrMf-M6g&usqp=CAE",
                            Size = "Medium",
                            Sleeve = "Short",
                            LeagueId = 4,
                            CoachId= 3,
                            Club = Club.Liverpool
                        },

                        new Soccer_Jersey()
                        {
                            Name = "Robert Lewandowski Jersey #9 ",
                            Description = "Men's Replica LEWANDOWSKI #9 Barcelona Home Soccer Jersey Shirt 2022/23 Nike",
                            Price = 33.99,
                            ImageURL = "https://images.footballfanatics.com/barcelona/mens-nike-robert-lewandowski-blue-barcelona-2022/23-home-replica-player-jersey_pi5080000_altimages_ff_5080188-8b10cc03ad56e7648c96alt1_full.jpg?_hv=2&w=900",
                            Size = "Long",
                            Sleeve = "Long",
                            LeagueId = 3,
                            CoachId= 2,
                            Club = Club.Barcelona
                        },

                        new Soccer_Jersey()
                        {
                            Name = "Mohamed Salah Jersey #11 ",
                            Description = "Men's Replica Mohamed Salah #11 Liverpool Home Soccer Jersey Shirt 2020/21 Nike",
                            Price = 25.99,
                            ImageURL = "https://i.ebayimg.com/images/g/t-QAAOSwFq1a-v2f/s-l500.jpg",
                            Size = "XLarge",
                            Sleeve = "Long",
                            LeagueId = 2,
                            CoachId= 5,
                            Club = Club.Liverpool
                        },

                        new Soccer_Jersey()
                        {
                            Name = "Ibrahimovic #11 ",
                            Description = "Men's Replica IBRAHIMOVIĆ #11 AC Milan Home Soccer Jersey Shirt 2022/23 Puma",
                            Price = 40.99,
                            ImageURL = "https://cdn1.uksoccershop.com/images/cache/re-2022-2023-ac-milan-home-shirt-ibrahimovic-11-1657017570-475x0.webp",
                            Size = "Large",
                            Sleeve = "Short",
                            LeagueId = 5,
                            CoachId= 4,
                            Club = Club.Liverpool
                        },

                        new Soccer_Jersey()
                        {
                            Name = "Messi PSG #30 ",
                            Description = "LIONEL MESSI PSG 22/23 LONG SLEEVE HOME JERSEY BY NIKE",
                            Price = 31.99,
                            ImageURL = "https://images.footballfanatics.com/paris-saint-germain/paris-saint-germain-ls-home-stadium-shirt-2022-23-with-messi-30-printing_ss4_p-13328406+u-75o6z1qfgrhbffnqv5ut+v-ee55c8865e2f427f9583e14915de657b.jpg?_hv=2&w=900",
                            Size = "Large",
                            Sleeve = "Long",
                            LeagueId = 1,
                            CoachId= 1,
                            Club = Club.PSG
                        },

                     
                    }) ;

                    context.SaveChanges();

                }
            }

        }
    }
}
