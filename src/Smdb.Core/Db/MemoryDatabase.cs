using Smdb.Core.Movies;
using Smdb.Core.Users;

namespace Smdb.Core.Db;

public class MemoryDatabase
{
    private static MemoryDatabase? _instance;
    public static MemoryDatabase Instance => _instance ??= new MemoryDatabase();

    public List<Movie> Movies { get; private set; }
    public List<User> Users { get; private set; }

    private int _nextMovieId = 1;
    private int _nextUserId = 1;

    private MemoryDatabase()
    {
        Movies = new List<Movie>();
        Users = new List<User>();

        SeedMovies();
        SeedUsers();
    }

    public int NextMovieId() => ++_nextMovieId;
    public int NextUserId() => ++_nextUserId;

    private void SeedMovies()
    {
        Movies.AddRange(new Movie[]
        {
            new Movie(1, "The Godfather", 1972, "A mafia patriarch hands the family empire to his reluctant son."),
            new Movie(2, "The Godfather Part II", 1974, "Michael consolidates power as flashbacks trace Vito Corleone's rise."),
            new Movie(3, "The Dark Knight", 2008, "Batman faces the Joker, who pushes Gotham into chaos."),
            new Movie(4, "The Shawshank Redemption", 1994, "An innocent banker forms a life-saving friendship in prison."),
            new Movie(5, "Pulp Fiction", 1994, "Interlocking LA crime stories unfold with dark humor."),
            new Movie(6, "Schindler's List", 1993, "A businessman saves Jewish workers during the Holocaust."),
            new Movie(7, "The Lord of the Rings: The Return of the King", 2003, "The final push to destroy the One Ring decides Middle-earth's fate."),
            new Movie(8, "Fight Club", 1999, "An insomnia-plagued worker joins a charismatic anarchist's secret club."),
            new Movie(9, "Forrest Gump", 1994, "A kind man unwittingly drifts through historic American moments."),
            new Movie(10, "Inception", 2010, "A thief enters dreams to plant an idea in a target's mind."),
            new Movie(11, "The Matrix", 1999, "A hacker learns reality is a simulated prison for humanity."),
            new Movie(12, "Se7en", 1995, "Two detectives hunt a killer using the seven deadly sins."),
            new Movie(13, "Goodfellas", 1990, "Henry Hill's rise and fall inside the New York mob."),
            new Movie(14, "The Silence of the Lambs", 1991, "An FBI trainee consults Hannibal Lecter to catch a serial killer."),
            new Movie(15, "Star Wars: Episode IV – A New Hope", 1977, "A farm boy joins rebels to destroy the Empire's Death Star."),
            new Movie(16, "The Empire Strikes Back", 1980, "The Rebels scatter as Luke confronts Darth Vader."),
            new Movie(17, "Interstellar", 2014, "Astronauts travel through a wormhole to save a dying Earth."),
            new Movie(18, "Parasite", 2019, "A poor family infiltrates a wealthy household with unforeseen fallout."),
            new Movie(19, "Spirited Away", 2001, "A girl navigates a spirit bathhouse to free her parents."),
            new Movie(20, "City of God", 2002, "Two boys take diverging paths amid Rio's gang wars."),
            new Movie(21, "Saving Private Ryan", 1998, "A squad risks everything to bring a paratrooper home."),
            new Movie(22, "The Green Mile", 1999, "Death-row guards encounter a prisoner with miraculous gifts."),
            new Movie(23, "Gladiator", 2000, "A betrayed general becomes Rome's fiercest arena fighter."),
            new Movie(24, "The Lion King", 1994, "An exiled lion cub returns to claim his destiny."),
            new Movie(25, "Back to the Future", 1985, "A teen time-travels and risks erasing his own existence."),
            new Movie(26, "The Departed", 2006, "An infiltrator and a mole play cat-and-mouse in Boston."),
            new Movie(27, "Whiplash", 2014, "A jazz drummer endures a brutal mentor in pursuit of greatness."),
            new Movie(28, "The Prestige", 2006, "Rival magicians wage a dangerous war of one-upmanship."),
            new Movie(29, "The Usual Suspects", 1995, "A survivors' tale hints at the legend of Keyser Söze."),
            new Movie(30, "Terminator 2: Judgment Day", 1991, "A reprogrammed cyborg protects the future leader of humanity."),
            new Movie(31, "Alien", 1979, "A crew is stalked by a lethal lifeform aboard a spaceship."),
            new Movie(32, "Aliens", 1986, "Ripley returns to face a hive of xenomorphs on LV-426."),
            new Movie(33, "Blade Runner", 1982, "A detective hunts rogue androids in a neon-soaked future."),
            new Movie(34, "Apocalypse Now", 1979, "A captain journeys upriver to terminate a renegade officer."),
            new Movie(35, "One Flew Over the Cuckoo's Nest", 1975, "A rebel patient challenges a tyrannical nurse in a psych ward."),
            new Movie(36, "Taxi Driver", 1976, "A disturbed NYC cabbie spirals toward violence."),
            new Movie(37, "Oldboy", 2003, "A man seeks answers after 15 years of inexplicable captivity."),
            new Movie(38, "Amélie", 2001, "A shy Parisian decides to secretly improve others' lives."),
            new Movie(39, "The Pianist", 2002, "A Jewish pianist struggles to survive Warsaw's ghetto."),
            new Movie(40, "American Beauty", 1999, "A suburban man's midlife crisis upends his family."),
            new Movie(41, "No Country for Old Men", 2007, "A stolen briefcase triggers relentless pursuit across Texas."),
            new Movie(42, "There Will Be Blood", 2007, "An oilman's ambition consumes everything around him."),
            new Movie(43, "Mad Max: Fury Road", 2015, "A desert chase pits a warlord against a defiant road warrior."),
            new Movie(44, "La La Land", 2016, "A musician and an actress chase dreams in modern LA."),
            new Movie(45, "Joker", 2019, "A marginalized comedian's breakdown sparks violent unrest."),
            new Movie(46, "Avengers: Infinity War", 2018, "Earth's heroes battle Thanos for the fate of half the universe."),
            new Movie(47, "Avengers: Endgame", 2019, "Survivors attempt a time-heist to undo cosmic devastation."),
            new Movie(48, "Toy Story", 1995, "Rivalry between a cowboy doll and a space ranger turns to friendship."),
            new Movie(49, "Inside Out", 2015, "A girl's emotions guide her through a difficult move."),
            new Movie(50, "The Social Network", 2010, "Facebook's founding sparks friendship and legal battles."),
            new Movie(51, "WALL-E", 2008, "A lonely robot finds love while cleaning a deserted Earth."),
            new Movie(52, "The Truman Show", 1998, "A man discovers his life is a reality TV show."),
            new Movie(53, "Eternal Sunshine of the Spotless Mind", 2004, "A couple erases memories of each other."),
            new Movie(54, "Memento", 2000, "A man with memory loss hunts his wife's killer."),
            new Movie(55, "The Grand Budapest Hotel", 2014, "A concierge and his protégé embark on an adventure."),
            new Movie(56, "Moonlight", 2016, "A young Black man grapples with identity and sexuality."),
            new Movie(57, "12 Years a Slave", 2013, "A free man is kidnapped and sold into slavery."),
            new Movie(58, "The Revenant", 2015, "A frontiersman seeks revenge after a brutal bear attack."),
            new Movie(59, "Birdman", 2014, "An actor struggles to mount a Broadway comeback."),
            new Movie(60, "Get Out", 2017, "A Black man uncovers a disturbing secret at his girlfriend's estate."),
            new Movie(61, "Us", 2019, "A family is terrorized by their twisted doppelgängers."),
            new Movie(62, "Hereditary", 2018, "A family unravels after a tragic loss reveals dark secrets."),
            new Movie(63, "The Witch", 2015, "A Puritan family encounters evil in the New England wilderness."),
            new Movie(64, "It Follows", 2014, "A teen is haunted by a supernatural entity after a tryst."),
            new Movie(65, "A Quiet Place", 2018, "A family survives in silence to avoid deadly creatures."),
            new Movie(66, "Arrival", 2016, "A linguist deciphers alien messages as humanity faces crisis."),
            new Movie(67, "Blade Runner 2049", 2017, "A replicant uncovers a secret that could destabilize society."),
            new Movie(68, "Ex Machina", 2014, "A programmer evaluates a humanoid AI's consciousness."),
            new Movie(69, "Her", 2013, "A lonely writer falls for an operating system."),
            new Movie(70, "Drive", 2011, "A getaway driver becomes entangled in a heist gone wrong."),
            new Movie(71, "Nightcrawler", 2014, "A man exploits crime journalism in Los Angeles."),
            new Movie(72, "The Wolf of Wall Street", 2013, "A stockbroker's rise fueled by corruption and excess."),
            new Movie(73, "Django Unchained", 2012, "A freed slave hunts bounties and rescues his wife."),
            new Movie(74, "Inglourious Basterds", 2009, "Soldiers plot to assassinate Nazi leaders in occupied France."),
            new Movie(75, "Kill Bill: Vol. 1", 2003, "An assassin seeks revenge on her former colleagues."),
            new Movie(76, "Reservoir Dogs", 1992, "A heist gone wrong leads to paranoia among thieves."),
            new Movie(77, "The Big Lebowski", 1998, "A slacker is mistaken for a millionaire and drawn into chaos."),
            new Movie(78, "Fargo", 1996, "A pregnant sheriff investigates a kidnapping gone awry."),
            new Movie(79, "A Beautiful Mind", 2001, "A mathematician battles schizophrenia while solving equations."),
            new Movie(80, "The Theory of Everything", 2014, "Stephen Hawking's romance and scientific achievements."),
            new Movie(81, "The Imitation Game", 2014, "Alan Turing cracks Nazi codes during World War II."),
            new Movie(82, "Hidden Figures", 2016, "Black women mathematicians help NASA reach space."),
            new Movie(83, "First Man", 2018, "Neil Armstrong's journey to the moon."),
            new Movie(84, "Apollo 13", 1995, "Astronauts fight to survive a crippled spacecraft."),
            new Movie(85, "Gravity", 2013, "Astronauts struggle to survive after debris strikes their shuttle."),
            new Movie(86, "The Martian", 2015, "An astronaut survives alone on Mars using science and wit."),
            new Movie(87, "Edge of Tomorrow", 2014, "A soldier relives the same battle day to defeat aliens."),
            new Movie(88, "District 9", 2009, "Aliens are quarantined in Johannesburg slums."),
            new Movie(89, "Children of Men", 2006, "Humanity faces extinction as women become infertile."),
            new Movie(90, "V for Vendetta", 2005, "A masked vigilante fights a totalitarian regime."),
            new Movie(91, "The Bourne Identity", 2002, "An amnesiac discovers he's a trained assassin."),
            new Movie(92, "Casino Royale", 2006, "James Bond earns his 00 status in a poker showdown."),
            new Movie(93, "Skyfall", 2012, "Bond confronts his past when MI6 is attacked."),
            new Movie(94, "Mission: Impossible – Fallout", 2018, "Ethan Hunt races to prevent nuclear catastrophe."),
            new Movie(95, "John Wick", 2014, "A retired hitman seeks vengeance for his slain dog."),
            new Movie(96, "The Raid", 2011, "A SWAT team fights through a crime lord's apartment tower."),
            new Movie(97, "Crouching Tiger, Hidden Dragon", 2000, "Warriors pursue a stolen sword in ancient China."),
            new Movie(98, "Hero", 2002, "An assassin recounts his mission to a Chinese king."),
            new Movie(99, "Ip Man", 2008, "A martial arts master defends his country during war."),
            new Movie(100, "Kung Fu Hustle", 2004, "A gangster wannabe discovers hidden martial arts prowess.")
        });

        _nextMovieId = 100;
    }

    private void SeedUsers()
    {
        Users.Add(new User
        {
            Id = NextUserId(),
            Username = "admin",
            PasswordHash = SimpleHash("admin123"),
            Role = UserRole.Admin
        });

        Users.Add(new User
        {
            Id = NextUserId(),
            Username = "user",
            PasswordHash = SimpleHash("user123"),
            Role = UserRole.Regular
        });
    }

    private static string SimpleHash(string password)
    {
        using var sha = System.Security.Cryptography.SHA256.Create();
        var hash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hash);
    }
}
