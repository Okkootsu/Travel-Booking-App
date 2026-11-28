using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;
using TravelApp.Domain.ValueObjects;

namespace TravelApp.Infrastructure.Persistence.Seed;

internal static class AccommodationSeedData
{
    private sealed record DestinationSeed(
        string Name,
        string Country,
        string CountryCode,
        string Slug,
        double Latitude,
        double Longitude,
        string Description,
        string ImageUrl,
        bool IsFeatured);

    private sealed record HotelSeed(
        string DestinationSlug,
        string Name,
        string Slug,
        string Description,
        PropertyType PropertyType,
        int StarRating,
        string District,
        string Street,
        string PostalCode,
        double LatOffset,
        double LonOffset,
        decimal BasePriceUsd,
        decimal AverageRating,
        int ReviewCount,
        string[] HotelAmenityCodes,
        string[] ImageUrls);

    private static readonly string[] HotelGalleryPool =
    [
        "https://images.unsplash.com/photo-1566073771259-6a8506099945?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1582719508461-905c673771fd?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1542314831-068cd1dbfeeb?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1551882547-ff40c63fe5fa?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1571896349842-33c89424de2d?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1564501049412-61c2a3083791?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1590490360182-c33d57733427?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1618773928121-c32242e63f39?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1596394516093-501ba68a0ba6?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1578683010236-d716f9a3f461?auto=format&fit=crop&w=1200&q=80",
        "https://images.unsplash.com/photo-1611892440504-42a792e24d32?auto=format&fit=crop&w=1200&q=80"
    ];

    private static readonly DestinationSeed[] DestinationSeeds =
    [
        new("Istanbul", "Turkey", "TR", "istanbul", 41.0082, 28.9784,
            "Transcontinental metropolis bridging Europe and Asia with historic palaces, vibrant bazaars, and Bosphorus views.",
            "https://images.unsplash.com/photo-1524231757912-21f4fe3a7200?auto=format&fit=crop&w=1200&q=80", true),
        new("Rome", "Italy", "IT", "rome", 41.9028, 12.4964,
            "The Eternal City offering ancient landmarks, Renaissance art, lively piazzas, and timeless Italian hospitality.",
            "https://images.unsplash.com/photo-1552832230-c0197dd311b5?auto=format&fit=crop&w=1200&q=80", true),
        new("Paris", "France", "FR", "paris", 48.8566, 2.3522,
            "Iconic boulevards, world-class museums, riverside cafes, and refined boutique stays in the City of Light.",
            "https://images.unsplash.com/photo-1502602898657-3e91760cbb34?auto=format&fit=crop&w=1200&q=80", true),
        new("London", "United Kingdom", "GB", "london", 51.5074, -0.1278,
            "Cosmopolitan capital blending royal heritage, West End theatre, leafy parks, and contemporary luxury.",
            "https://images.unsplash.com/photo-1513635269975-59663e0ac1ad?auto=format&fit=crop&w=1200&q=80", true),
        new("Barcelona", "Spain", "ES", "barcelona", 41.3874, 2.1686,
            "Mediterranean coastline, Gaudi architecture, tapas neighborhoods, and sun-soaked rooftop retreats.",
            "https://images.unsplash.com/photo-1583422409516-2895a77efded?auto=format&fit=crop&w=1200&q=80", true),
        new("Dubai", "United Arab Emirates", "AE", "dubai", 25.2048, 55.2708,
            "Futuristic skyline, desert resorts, private beaches, and luxury hospitality along the Arabian Gulf.",
            "https://images.unsplash.com/photo-1512453979798-5ea266f8880c?auto=format&fit=crop&w=1200&q=80", true),
        new("Tokyo", "Japan", "JP", "tokyo", 35.6762, 139.6503,
            "Neon-lit districts, serene temples, Michelin dining, and precision hospitality in Japan's capital.",
            "https://images.unsplash.com/photo-1540959733332-eab4deabeeaf?auto=format&fit=crop&w=1200&q=80", true),
        new("New York", "United States", "US", "new-york", 40.7128, -74.0060,
            "Energetic boroughs, Broadway shows, Central Park views, and iconic Manhattan skyline hotels.",
            "https://images.unsplash.com/photo-1496442226666-8d4d0e62e6e9?auto=format&fit=crop&w=1200&q=80", true),
        new("Amsterdam", "Netherlands", "NL", "amsterdam", 52.3676, 4.9041,
            "Canal-ring architecture, cycling culture, golden-age museums, and intimate canal house accommodations.",
            "https://images.unsplash.com/photo-1534351590666-13e3e96b5017?auto=format&fit=crop&w=1200&q=80", false),
        new("Bangkok", "Thailand", "TH", "bangkok", 13.7563, 100.5018,
            "Ornate shrines, riverside resorts, bustling street markets, and warm Thai hospitality.",
            "https://images.unsplash.com/photo-1508009603885-50cf7c579365?auto=format&fit=crop&w=1200&q=80", false),
        new("Antalya", "Turkey", "TR", "antalya", 36.8969, 30.7133,
            "Turquoise Coast beaches, Taurus Mountain backdrops, historic Kaleici, and all-inclusive resorts.",
            "https://images.unsplash.com/photo-1542051841857-5f90071e7989?auto=format&fit=crop&w=1200&q=80", false),
        new("Prague", "Czech Republic", "CZ", "prague", 50.0755, 14.4378,
            "Gothic spires, cobblestone squares, Vltava river bridges, and charming heritage hotels.",
            "https://images.unsplash.com/photo-1541849546-216549ae216d?auto=format&fit=crop&w=1200&q=80", false),
        new("Vienna", "Austria", "AT", "vienna", 48.2082, 16.3738,
            "Imperial palaces, classical concert halls, historic coffeehouses, and grand Ringstrasse stays.",
            "https://images.unsplash.com/photo-1516550893923-42d28e5677af?auto=format&fit=crop&w=1200&q=80", false),
        new("Lisbon", "Portugal", "PT", "lisbon", 38.7223, -9.1393,
            "Hilltop viewpoints, pastel facades, Atlantic breezes, and boutique coastal retreats.",
            "https://images.unsplash.com/photo-1555881400-74d7acaacd8b?auto=format&fit=crop&w=1200&q=80", false),
        new("Sydney", "Australia", "AU", "sydney", -33.8688, 151.2093,
            "Harbourfront icons, golden surf beaches, coastal walks, and modern waterfront stays.",
            "https://images.unsplash.com/photo-1506973035872-a4ec16b8e8d9?auto=format&fit=crop&w=1200&q=80", false),
        new("Singapore", "Singapore", "SG", "singapore", 1.3521, 103.8198,
            "Lush sky gardens, Marina Bay landmarks, multicultural cuisine, and contemporary urban sanctuaries.",
            "https://images.unsplash.com/photo-1525625293386-3f8f99389edd?auto=format&fit=crop&w=1200&q=80", false)
    ];

    public static IReadOnlyList<Amenity> CreateAmenities() =>
    [
        // Hotel scope (12)
        new("swimming-pool", "Swimming Pool", AmenityCategory.Wellness, AmenityScope.Hotel, "waves"),
        new("spa-wellness", "Spa & Wellness Center", AmenityCategory.Wellness, AmenityScope.Hotel, "sparkles"),
        new("fitness-center", "Fitness Center", AmenityCategory.Wellness, AmenityScope.Hotel, "dumbbell"),
        new("restaurant", "On-site Restaurant", AmenityCategory.FoodAndDrink, AmenityScope.Hotel, "utensils"),
        new("airport-shuttle", "Airport Shuttle", AmenityCategory.General, AmenityScope.Hotel, "plane"),
        new("free-parking", "Free Parking", AmenityCategory.General, AmenityScope.Hotel, "car"),
        new("24h-front-desk", "24-Hour Front Desk", AmenityCategory.General, AmenityScope.Hotel, "clock"),
        new("bar-lounge", "Bar & Lounge", AmenityCategory.FoodAndDrink, AmenityScope.Hotel, "wine"),
        new("pet-friendly", "Pet Friendly", AmenityCategory.Family, AmenityScope.Hotel, "paw-print"),
        new("business-center", "Business Center", AmenityCategory.Business, AmenityScope.Hotel, "briefcase"),
        new("beachfront", "Beachfront Access", AmenityCategory.Outdoor, AmenityScope.Hotel, "umbrella"),
        new("ev-charging", "EV Charging Station", AmenityCategory.Outdoor, AmenityScope.Hotel, "zap"),

        // Room scope (10)
        new("air-conditioning", "Air Conditioning", AmenityCategory.Room, AmenityScope.Room, "wind"),
        new("balcony", "Private Balcony", AmenityCategory.Outdoor, AmenityScope.Room, "sun"),
        new("minibar", "Minibar", AmenityCategory.FoodAndDrink, AmenityScope.Room, "cup-soda"),
        new("coffee-maker", "Coffee & Tea Maker", AmenityCategory.FoodAndDrink, AmenityScope.Room, "coffee"),
        new("in-room-safe", "In-Room Safe", AmenityCategory.Room, AmenityScope.Room, "lock"),
        new("workspace-desk", "Workspace Desk", AmenityCategory.Business, AmenityScope.Room, "laptop"),
        new("bathtub", "Deep Soaking Bathtub", AmenityCategory.Room, AmenityScope.Room, "bath"),
        new("kitchenette", "Kitchenette", AmenityCategory.FoodAndDrink, AmenityScope.Room, "cooking-pot"),
        new("sea-view", "Sea or Waterfront View", AmenityCategory.Outdoor, AmenityScope.Room, "eye"),
        new("soundproofing", "Soundproofed Rooms", AmenityCategory.Room, AmenityScope.Room, "volume-x"),

        // Both scope (2)
        new("free-wifi", "Free High-Speed Wi-Fi", AmenityCategory.General, AmenityScope.Both, "wifi"),
        new("wheelchair-accessible", "Wheelchair Accessible", AmenityCategory.Accessibility, AmenityScope.Both, "accessibility")
    ];

    public static IReadOnlyList<Destination> CreateDestinations() =>
        DestinationSeeds
            .Select(d => new Destination(
                d.Name,
                d.Country,
                d.CountryCode,
                d.Slug,
                GeoLocation.Create(d.Latitude, d.Longitude),
                d.Description,
                d.ImageUrl,
                d.IsFeatured))
            .ToList();

    public static IReadOnlyList<Hotel> CreateHotels(
        IReadOnlyDictionary<string, Destination> destinationsBySlug,
        IReadOnlyDictionary<string, Amenity> amenitiesByCode)
    {
        var hotelSeeds = BuildHotelSeeds();
        var hotels = new List<Hotel>(hotelSeeds.Count);

        for (var i = 0; i < hotelSeeds.Count; i++)
        {
            var seed = hotelSeeds[i];
            var destination = destinationsBySlug[seed.DestinationSlug];

            var hotel = new Hotel(
                destination.Id,
                seed.Name,
                seed.Slug,
                seed.Description,
                seed.PropertyType,
                seed.StarRating,
                Address.Create(destination.Country, destination.Name, seed.Street, seed.District, seed.PostalCode),
                GeoLocation.Create(
                    destination.Location.Latitude + seed.LatOffset,
                    destination.Location.Longitude + seed.LonOffset));

            hotel.UpdateRatingSummary(seed.AverageRating, seed.ReviewCount);

            foreach (var code in seed.HotelAmenityCodes)
            {
                if (amenitiesByCode.TryGetValue(code, out var amenity) && amenity.Scope != AmenityScope.Room)
                {
                    hotel.AddAmenity(amenity.Id);
                }
            }

            var standardRoom = hotel.AddRoomType(
                GetStandardRoomName(seed.PropertyType),
                $"Comfortable {GetStandardRoomName(seed.PropertyType).ToLowerInvariant()} designed for solo travelers or couples visiting {destination.Name}.",
                Occupancy.Create(maxAdults: 2, maxChildren: 1, maxTotalGuests: 2),
                seed.PropertyType == PropertyType.Hostel ? "2 Twin Beds" : "1 Queen Bed",
                Money.Create(seed.BasePriceUsd, "USD"),
                totalRoomCount: 8 + (i % 5),
                sizeSqm: seed.PropertyType == PropertyType.Hostel ? 20 : 28);

            var deluxeRoom = hotel.AddRoomType(
                GetDeluxeRoomName(seed.PropertyType),
                $"Spacious {GetDeluxeRoomName(seed.PropertyType).ToLowerInvariant()} with upgraded furnishings and extra seating space.",
                Occupancy.Create(maxAdults: 3, maxChildren: 1, maxTotalGuests: 3),
                "1 King Bed",
                Money.Create(decimal.Round(seed.BasePriceUsd * 1.38m, 2), "USD"),
                totalRoomCount: 5 + (i % 4),
                sizeSqm: 38);

            var suiteRoom = hotel.AddRoomType(
                GetSuiteRoomName(seed.PropertyType),
                $"Premium multi-guest accommodation ideal for families or extended stays in {destination.Name}.",
                Occupancy.Create(maxAdults: 4, maxChildren: 2, maxTotalGuests: 5),
                "1 King Bed & 2 Twin Beds",
                Money.Create(decimal.Round(seed.BasePriceUsd * 1.95m, 2), "USD"),
                totalRoomCount: 2 + (i % 3),
                sizeSqm: 58);

            AssignRoomAmenities(hotel, standardRoom, amenitiesByCode, isSuite: false, includeKitchen: seed.PropertyType is PropertyType.Apartment or PropertyType.Villa);
            AssignRoomAmenities(hotel, deluxeRoom, amenitiesByCode, isSuite: false, includeKitchen: seed.PropertyType is PropertyType.Apartment or PropertyType.Villa);
            AssignRoomAmenities(hotel, suiteRoom, amenitiesByCode, isSuite: true, includeKitchen: true);

            hotel.AddImage(seed.ImageUrls[0], $"{seed.Name} exterior and main view", 0, isPrimary: true);
            hotel.AddImage(seed.ImageUrls[1], $"{seed.Name} lobby and shared lounge", 1, isPrimary: false);
            hotel.AddImage(seed.ImageUrls[2], $"{seed.Name} guest room interior", 2, isPrimary: false, roomTypeId: standardRoom.Id);

            hotel.Publish();
            hotels.Add(hotel);
        }

        return hotels;
    }

    private static void AssignRoomAmenities(
        Hotel hotel,
        RoomType roomType,
        IReadOnlyDictionary<string, Amenity> amenitiesByCode,
        bool isSuite,
        bool includeKitchen)
    {
        string[] baseCodes = ["free-wifi", "air-conditioning", "coffee-maker", "in-room-safe", "soundproofing"];
        foreach (var code in baseCodes)
        {
            if (amenitiesByCode.TryGetValue(code, out var amenity))
                hotel.AddRoomTypeAmenity(roomType.Id, amenity.Id);
        }

        if (isSuite)
        {
            string[] suiteCodes = ["balcony", "minibar", "workspace-desk", "bathtub"];
            foreach (var code in suiteCodes)
            {
                if (amenitiesByCode.TryGetValue(code, out var amenity))
                    hotel.AddRoomTypeAmenity(roomType.Id, amenity.Id);
            }
        }

        if (includeKitchen && amenitiesByCode.TryGetValue("kitchenette", out var kitchen))
        {
            hotel.AddRoomTypeAmenity(roomType.Id, kitchen.Id);
        }
    }

    private static string GetStandardRoomName(PropertyType propertyType) => propertyType switch
    {
        PropertyType.Apartment => "Studio City Apartment",
        PropertyType.Villa => "Garden Courtyard Suite",
        PropertyType.Hostel => "Private Twin Room",
        _ => "Superior Queen Room"
    };

    private static string GetDeluxeRoomName(PropertyType propertyType) => propertyType switch
    {
        PropertyType.Apartment => "One-Bedroom Residence",
        PropertyType.Villa => "Panoramic Terrace Suite",
        PropertyType.Hostel => "Private Double Room",
        _ => "Deluxe King Room"
    };

    private static string GetSuiteRoomName(PropertyType propertyType) => propertyType switch
    {
        PropertyType.Apartment => "Two-Bedroom Family Loft",
        PropertyType.Villa => "Signature Private Villa",
        PropertyType.Hostel => "Family Quad Room",
        _ => "Executive Family Suite"
    };

    private static string[] ImgSet(int offset) =>
    [
        HotelGalleryPool[offset % HotelGalleryPool.Length],
        HotelGalleryPool[(offset + 4) % HotelGalleryPool.Length],
        HotelGalleryPool[(offset + 8) % HotelGalleryPool.Length]
    ];

    private static List<HotelSeed> BuildHotelSeeds()
    {
        var seeds = new List<HotelSeed>(54)
        {
            // Istanbul (4)
            new("istanbul", "Bosphorus Palace Hotel", "bosphorus-palace-hotel",
                "Waterfront Ottoman-inspired luxury property overlooking the Bosphorus strait with private spa rituals and rooftop dining.",
                PropertyType.Hotel, 5, "Besiktas", "Ciragan Caddesi No. 48", "34349", 0.032, 0.041, 285m, 4.86m, 642,
                ["free-wifi", "swimming-pool", "spa-wellness", "fitness-center", "restaurant", "airport-shuttle", "24h-front-desk", "bar-lounge"], ImgSet(0)),
            new("istanbul", "Karakoy Loft Boutique Hotel", "karakoy-loft-boutique-hotel",
                "Design-led boutique stay housed in a restored 19th-century stone building steps from Galata Bridge and ferry piers.",
                PropertyType.BoutiqueHotel, 4, "Beyoglu", "Kemankes Caddesi No. 22", "34425", 0.015, -0.004, 155m, 4.68m, 318,
                ["free-wifi", "restaurant", "24h-front-desk", "bar-lounge", "airport-shuttle"], ImgSet(1)),
            new("istanbul", "Sultanahmet Heritage Suites", "sultanahmet-heritage-suites",
                "Intimate historic residences within walking distance of Hagia Sophia, Blue Mosque, and Topkapi Palace.",
                PropertyType.Apartment, 4, "Fatih", "Kabasaakal Caddesi No. 14", "34122", -0.003, -0.001, 130m, 4.54m, 274,
                ["free-wifi", "24h-front-desk", "airport-shuttle", "wheelchair-accessible"], ImgSet(2)),
            new("istanbul", "Moda Pier Hostel & Social", "moda-pier-hostel-social",
                "Modern minimalist private-room hostel on the Anatolian side near artisan cafes and seaside promenades.",
                PropertyType.Hostel, 3, "Kadikoy", "Moda Caddesi No. 96", "34710", -0.024, 0.048, 68m, 4.35m, 189,
                ["free-wifi", "24h-front-desk", "bar-lounge", "pet-friendly"], ImgSet(3)),

            // Rome (4)
            new("rome", "Grand Hotel Via Veneto", "grand-hotel-via-veneto",
                "Refined Roman sanctuary featuring Travertine marble interiors, rooftop aperitivo lounge, and tranquil wellness suites.",
                PropertyType.Hotel, 5, "Ludovisi", "Via Vittorio Veneto 155", "00187", 0.006, -0.007, 320m, 4.82m, 512,
                ["free-wifi", "spa-wellness", "fitness-center", "restaurant", "24h-front-desk", "bar-lounge", "business-center"], ImgSet(4)),
            new("rome", "Trastevere Artisans Boutique", "trastevere-artisans-boutique",
                "Warm terracotta-toned boutique property tucked along ivy-draped cobblestone alleys in historic Trastevere.",
                PropertyType.BoutiqueHotel, 4, "Trastevere", "Via della Lungaretta 74", "00153", -0.014, -0.025, 195m, 4.71m, 389,
                ["free-wifi", "24h-front-desk", "bar-lounge", "airport-shuttle"], ImgSet(5)),
            new("rome", "Piazza Navona Residences", "piazza-navona-residences",
                "Restored baroque apartments overlooking quiet Roman courtyards just minutes from the Pantheon.",
                PropertyType.Apartment, 4, "Parione", "Via di Monte Giordano 31", "00186", -0.004, -0.024, 175m, 4.61m, 205,
                ["free-wifi", "airport-shuttle", "wheelchair-accessible"], ImgSet(6)),
            new("rome", "Villa Aurelia Gardens", "villa-aurelia-gardens",
                "Secluded private villa complex surrounded by Mediterranean cypress gardens overlooking the Vatican hill.",
                PropertyType.Villa, 5, "Aurelio", "Via Aurelia Antica 210", "00165", -0.015, -0.055, 390m, 4.91m, 94,
                ["free-wifi", "swimming-pool", "free-parking", "pet-friendly", "airport-shuttle"], ImgSet(7)),

            // Paris (4)
            new("paris", "Maison Saint-Germain Paris", "maison-saint-germain-paris",
                "Classic Haussmannian elegance in the Left Bank with Parisian courtyard breakfasts and bespoke concierge service.",
                PropertyType.BoutiqueHotel, 5, "Saint-Germain-des-Pres", "Boulevard Saint-Germain 142", "75006", -0.003, -0.017, 350m, 4.88m, 476,
                ["free-wifi", "spa-wellness", "restaurant", "24h-front-desk", "bar-lounge", "wheelchair-accessible"], ImgSet(8)),
            new("paris", "Hotel Le Marais Atelier", "hotel-le-marais-atelier",
                "Contemporary Parisian hotel near Place des Vosges surrounded by independent galleries and patisseries.",
                PropertyType.Hotel, 4, "Le Marais", "Rue de Turenne 68", "75003", 0.004, 0.014, 235m, 4.69m, 610,
                ["free-wifi", "24h-front-desk", "bar-lounge", "fitness-center"], ImgSet(9)),
            new("paris", "Montmartre Terrace Apartments", "montmartre-terrace-apartments",
                "Sunlit Parisian flats with wrought-iron balconies and panoramic rooftop views toward Sacre-Coeur.",
                PropertyType.Apartment, 4, "Montmartre", "Rue Lepic 52", "75018", 0.031, -0.016, 185m, 4.52m, 238,
                ["free-wifi", "pet-friendly", "airport-shuttle"], ImgSet(10)),
            new("paris", "Canal Saint-Martin Urban Stay", "canal-saint-martin-urban-stay",
                "Vibrant riverside boutique hostel offering private rooms, communal workspace, and evening wine tastings.",
                PropertyType.Hostel, 3, "10th Arrondissement", "Quai de Valmy 88", "75010", 0.018, 0.013, 98m, 4.38m, 340,
                ["free-wifi", "24h-front-desk", "bar-lounge", "business-center"], ImgSet(11)),

            // London (4)
            new("london", "The Kensington Sovereign", "the-kensington-sovereign",
                "Timeless British townhouse hotel steps from Hyde Park and South Kensington museums.",
                PropertyType.Hotel, 5, "Kensington", "Queen's Gate 92", "SW7 5AB", -0.012, -0.051, 340m, 4.84m, 530,
                ["free-wifi", "spa-wellness", "fitness-center", "restaurant", "24h-front-desk", "bar-lounge", "business-center"], ImgSet(0)),
            new("london", "Shoreditch Foundry Hotel", "shoreditch-foundry-hotel",
                "Industrial-chic East London hotel with rooftop terrace, craft cocktail lounge, and express coworking.",
                PropertyType.BoutiqueHotel, 4, "Hackney", "Redchurch Street 41", "E2 7DJ", 0.018, 0.052, 220m, 4.67m, 445,
                ["free-wifi", "fitness-center", "restaurant", "24h-front-desk", "bar-lounge", "pet-friendly"], ImgSet(1)),
            new("london", "Covent Garden Townhouse Suites", "covent-garden-townhouse-suites",
                "Serviced West End apartments offering full kitchens and quiet residential comfort steps from Theatreland.",
                PropertyType.Apartment, 4, "Westminster", "Henrietta Street 19", "WC2E 8PW", 0.004, 0.004, 245m, 4.59m, 198,
                ["free-wifi", "24h-front-desk", "wheelchair-accessible"], ImgSet(2)),
            new("london", "Thames Southbank Lodge", "thames-southbank-lodge",
                "Contemporary budget-friendly stay near Tate Modern and Borough Market with 24-hour reception.",
                PropertyType.Hostel, 3, "Southwark", "Southwark Street 112", "SE1 0SW", -0.002, 0.032, 115m, 4.29m, 412,
                ["free-wifi", "24h-front-desk", "bar-lounge"], ImgSet(3)),

            // Barcelona (4)
            new("barcelona", "Barceloneta Azure Resort", "barceloneta-azure-resort",
                "Mediterranean beachfront resort featuring infinity pools, seafront dining, and direct promenade access.",
                PropertyType.Resort, 5, "Ciutat Vella", "Passeig Maritim 34", "08003", -0.011, 0.025, 295m, 4.81m, 710,
                ["free-wifi", "swimming-pool", "spa-wellness", "fitness-center", "restaurant", "bar-lounge", "beachfront", "24h-front-desk"], ImgSet(4)),
            new("barcelona", "Eixample Modernista Hotel", "eixample-modernista-hotel",
                "Elegant Catalan modernist hotel near Passeig de Gracia with sunlit atrium and plunge pool.",
                PropertyType.Hotel, 4, "Eixample", "Carrer de Mallorca 265", "08008", 0.006, -0.004, 210m, 4.73m, 488,
                ["free-wifi", "swimming-pool", "restaurant", "24h-front-desk", "bar-lounge", "ev-charging"], ImgSet(5)),
            new("barcelona", "El Born Courtyard Lofts", "el-born-courtyard-lofts",
                "Stylish Catalan apartments with exposed timber beams near Picasso Museum and Ciutadella Park.",
                PropertyType.Apartment, 4, "El Born", "Carrer del Rec 44", "08003", -0.003, 0.014, 165m, 4.56m, 260,
                ["free-wifi", "airport-shuttle", "pet-friendly"], ImgSet(6)),
            new("barcelona", "Sitges Hillside Villa Retreat", "sitges-hillside-villa-retreat",
                "Private Mediterranean villa sanctuary with saltwater pool and sweeping coastal views.",
                PropertyType.Villa, 5, "Pedralbes", "Avinguda d'Esplugues 78", "08034", 0.005, -0.055, 410m, 4.92m, 84,
                ["free-wifi", "swimming-pool", "free-parking", "ev-charging", "pet-friendly"], ImgSet(7)),

            // Dubai (4)
            new("dubai", "Palm Jumeirah Crescent Resort", "palm-jumeirah-crescent-resort",
                "Ultra-luxury waterfront resort on the Palm crescent with private white-sand beach, lagoons, and fine dining.",
                PropertyType.Resort, 5, "Palm Jumeirah", "Crescent Road West 18", "00000", -0.088, -0.145, 430m, 4.93m, 1120,
                ["free-wifi", "swimming-pool", "spa-wellness", "fitness-center", "restaurant", "airport-shuttle", "free-parking", "24h-front-desk", "bar-lounge", "beachfront"], ImgSet(8)),
            new("dubai", "Downtown Boulevard Tower Hotel", "downtown-boulevard-tower-hotel",
                "Sleek skyscraper hotel minutes from Burj Khalifa and Dubai Mall featuring sky-high infinity pool.",
                PropertyType.Hotel, 5, "Downtown Dubai", "Sheikh Mohammed bin Rashid Blvd 88", "00000", -0.007, 0.004, 310m, 4.79m, 865,
                ["free-wifi", "swimming-pool", "spa-wellness", "fitness-center", "restaurant", "free-parking", "24h-front-desk", "business-center", "ev-charging"], ImgSet(9)),
            new("dubai", "Marina Waterfront Residences", "marina-waterfront-residences",
                "High-rise serviced residences overlooking Dubai Marina yachts with direct tram and beach access.",
                PropertyType.Apartment, 4, "Dubai Marina", "Al Marsa Street 45", "00000", -0.125, -0.130, 190m, 4.58m, 420,
                ["free-wifi", "swimming-pool", "fitness-center", "free-parking", "24h-front-desk", "wheelchair-accessible"], ImgSet(10)),
            new("dubai", "Al Seef Heritage Boutique", "al-seef-heritage-boutique",
                "Wind-tower inspired boutique stay along historic Dubai Creek blending traditional craft with modern luxury.",
                PropertyType.BoutiqueHotel, 4, "Bur Dubai", "Al Seef Street 12", "00000", 0.056, 0.038, 165m, 4.64m, 295,
                ["free-wifi", "restaurant", "airport-shuttle", "24h-front-desk"], ImgSet(11)),

            // Tokyo (3)
            new("tokyo", "Shinjuku Skyline Sanctuary", "shinjuku-skyline-sanctuary",
                "High-floor contemporary hotel offering Mount Fuji vistas, Japanese onsen spa, and seamless station access.",
                PropertyType.Hotel, 5, "Shinjuku", "Nishi-Shinjuku 3-7-1", "163-1055", 0.014, 0.041, 290m, 4.89m, 790,
                ["free-wifi", "spa-wellness", "fitness-center", "restaurant", "24h-front-desk", "bar-lounge", "business-center"], ImgSet(0)),
            new("tokyo", "Yanaka Cedar Ryokan Boutique", "yanaka-cedar-ryokan-boutique",
                "Serene timber-and-tatami boutique hotel in quiet Yanaka neighborhood with private garden tea room.",
                PropertyType.BoutiqueHotel, 4, "Taito", "Yanaka 3-14-8", "110-0001", 0.048, 0.115, 195m, 4.77m, 315,
                ["free-wifi", "24h-front-desk", "wheelchair-accessible"], ImgSet(1)),
            new("tokyo", "Shibuya Minimalist Pods & Rooms", "shibuya-minimalist-pods-rooms",
                "Smart urban hostel steps from Shibuya Crossing featuring private compact rooms and social lounge.",
                PropertyType.Hostel, 3, "Shibuya", "Udagawacho 29-4", "150-0042", -0.015, 0.048, 92m, 4.44m, 540,
                ["free-wifi", "24h-front-desk", "bar-lounge"], ImgSet(2)),

            // New York (3)
            new("new-york", "Central Park West Grand", "central-park-west-grand",
                "Landmark Manhattan hotel overlooking Central Park with brasseries, fitness club, and concierge service.",
                PropertyType.Hotel, 5, "Midtown West", "Central Park South 160", "10019", 0.054, 0.028, 395m, 4.83m, 920,
                ["free-wifi", "spa-wellness", "fitness-center", "restaurant", "24h-front-desk", "bar-lounge", "business-center"], ImgSet(3)),
            new("new-york", "SoHo Cast-Iron Boutique", "soho-cast-iron-boutique",
                "Art-filled boutique hotel in a historic SoHo loft building near designer ateliers and galleries.",
                PropertyType.BoutiqueHotel, 4, "SoHo", "Mercer Street 104", "10012", 0.012, 0.006, 275m, 4.72m, 468,
                ["free-wifi", "fitness-center", "restaurant", "24h-front-desk", "bar-lounge", "pet-friendly"], ImgSet(4)),
            new("new-york", "Brooklyn Heights Brownstone Suites", "brooklyn-heights-brownstone-suites",
                "Spacious residential suites along tree-lined Brooklyn streets with quick subway links to Lower Manhattan.",
                PropertyType.Apartment, 4, "Brooklyn Heights", "Montague Street 75", "11201", -0.018, 0.011, 215m, 4.62m, 234,
                ["free-wifi", "pet-friendly", "wheelchair-accessible"], ImgSet(5)),

            // Amsterdam (3)
            new("amsterdam", "Keizersgracht Canal House", "keizersgracht-canal-house",
                "17th-century golden-age merchant townhouse hotel perched directly on the UNESCO Keizersgracht canal.",
                PropertyType.BoutiqueHotel, 5, "Centrum", "Keizersgracht 384", "1016 EK", 0.002, -0.018, 270m, 4.85m, 412,
                ["free-wifi", "restaurant", "24h-front-desk", "bar-lounge"], ImgSet(6)),
            new("amsterdam", "Jordaan Courtyard Apartments", "jordaan-courtyard-apartments",
                "Bright Dutch apartments with private garden terraces nestled among Jordaan bakeries and boutiques.",
                PropertyType.Apartment, 4, "Jordaan", "Prinsengracht 218", "1016 HD", 0.005, -0.022, 195m, 4.65m, 188,
                ["free-wifi", "pet-friendly"], ImgSet(7)),
            new("amsterdam", "Vondelpark Cycle Hotel", "vondelpark-cycle-hotel",
                "Contemporary eco-certified hotel adjacent to Vondelpark and Museumplein with EV charging.",
                PropertyType.Hotel, 4, "Oud-Zuid", "Overtoom 142", "1054 HN", -0.008, -0.031, 175m, 4.49m, 355,
                ["free-wifi", "fitness-center", "24h-front-desk", "ev-charging", "bar-lounge"], ImgSet(8)),

            // Bangkok (3)
            new("bangkok", "Chao Phraya Riverside Resort", "chao-phraya-riverside-resort",
                "Lush tropical urban resort along the River of Kings featuring teakwood pavilions and river shuttle boats.",
                PropertyType.Resort, 5, "Bang Rak", "Charoen Krung Road 48", "10500", -0.035, 0.012, 240m, 4.90m, 1280,
                ["free-wifi", "swimming-pool", "spa-wellness", "fitness-center", "restaurant", "airport-shuttle", "24h-front-desk", "bar-lounge"], ImgSet(9)),
            new("bangkok", "Sukhumvit Sky Tower Hotel", "sukhumvit-sky-tower-hotel",
                "Modern high-rise hotel connected to BTS Skytrain with rooftop infinity pool and pan-Asian dining.",
                PropertyType.Hotel, 4, "Watthana", "Sukhumvit Soi 24, 99", "10110", -0.029, 0.066, 135m, 4.66m, 645,
                ["free-wifi", "swimming-pool", "fitness-center", "restaurant", "24h-front-desk", "business-center"], ImgSet(10)),
            new("bangkok", "Ari Garden Boutique Stay", "ari-garden-boutique-stay",
                "Peaceful green sanctuary in trendy Ari district close to artisan coffee shops and weekend markets.",
                PropertyType.BoutiqueHotel, 3, "Phaya Thai", "Phahonyothin Soi 7, 32", "10400", 0.023, 0.043, 82m, 4.53m, 278,
                ["free-wifi", "24h-front-desk", "airport-shuttle"], ImgSet(11)),

            // Antalya (3)
            new("antalya", "Lara Turquoise Coast Resort", "lara-turquoise-coast-resort",
                "Expansive Mediterranean beachfront resort with lagoon pools, Turkish hammam spa, and family waterpark.",
                PropertyType.Resort, 5, "Lara", "Kemeragzi Tesisler Caddesi 110", "07112", -0.041, 0.142, 260m, 4.84m, 1410,
                ["free-wifi", "swimming-pool", "spa-wellness", "fitness-center", "restaurant", "airport-shuttle", "free-parking", "24h-front-desk", "beachfront"], ImgSet(0)),
            new("antalya", "Kaleici Ottoman Mansion", "kaleici-ottoman-mansion",
                "Restored citrus-garden Ottoman mansion inside historic Kaleici old town above the Roman harbour.",
                PropertyType.BoutiqueHotel, 4, "Muratpasa", "Hesapci Sokak 26", "07100", -0.013, -0.008, 128m, 4.74m, 342,
                ["free-wifi", "swimming-pool", "restaurant", "24h-front-desk", "airport-shuttle"], ImgSet(1)),
            new("antalya", "Konyaalti Cliffside Villas", "konyaalti-cliffside-villas",
                "Private modern villas overlooking Konyaalti Beach and the Taurus Mountains with heated plunge pools.",
                PropertyType.Villa, 5, "Konyaalti", "Akdeniz Bulvari 214", "07070", -0.018, -0.068, 340m, 4.88m, 118,
                ["free-wifi", "swimming-pool", "free-parking", "beachfront", "pet-friendly"], ImgSet(2)),

            // Prague (3)
            new("prague", "Old Town Astronomical Hotel", "old-town-astronomical-hotel",
                "Historic baroque hotel moments from Old Town Square and Charles Bridge with vaulted cellar dining.",
                PropertyType.Hotel, 5, "Stare Mesto", "Celetna 595", "110 00", 0.012, -0.014, 215m, 4.80m, 590,
                ["free-wifi", "spa-wellness", "restaurant", "24h-front-desk", "bar-lounge", "airport-shuttle"], ImgSet(3)),
            new("prague", "Mala Strana Castle Boutique", "mala-strana-castle-boutique",
                "Romantic boutique property tucked below Prague Castle gardens with classical Bohemiam charm.",
                PropertyType.BoutiqueHotel, 4, "Mala Strana", "Nerudova 212", "118 00", 0.013, -0.038, 150m, 4.71m, 366,
                ["free-wifi", "24h-front-desk", "bar-lounge"], ImgSet(4)),
            new("prague", "Vinohrady Park Suites", "vinohrady-park-suites",
                "Art Nouveau apartments facing Riegrovy Sady park with generous living spaces for longer stays.",
                PropertyType.Apartment, 4, "Vinohrady", "Polska 42", "120 00", 0.002, 0.006, 118m, 4.55m, 164,
                ["free-wifi", "pet-friendly", "free-parking"], ImgSet(5)),

            // Vienna (3)
            new("vienna", "Ringstrasse Imperial Grand", "ringstrasse-imperial-grand",
                "Palatial Viennese hotel adjacent to the State Opera featuring crystal chandeliers and pastry salon.",
                PropertyType.Hotel, 5, "Innere Stadt", "Karntner Ring 16", "1010", -0.005, -0.002, 315m, 4.87m, 680,
                ["free-wifi", "spa-wellness", "fitness-center", "restaurant", "24h-front-desk", "bar-lounge", "business-center"], ImgSet(6)),
            new("vienna", "MuseumsQuartier Design Hotel", "museumsquartier-design-hotel",
                "Contemporary boutique stay near Vienna's cultural quarter with minimalist rooms and sunlit courtyard.",
                PropertyType.BoutiqueHotel, 4, "Neubau", "Siebensterngasse 27", "1070", -0.005, -0.019, 178m, 4.66m, 398,
                ["free-wifi", "fitness-center", "24h-front-desk", "bar-lounge", "wheelchair-accessible"], ImgSet(7)),
            new("vienna", "Belvedere Garden Residences", "belvedere-garden-residences",
                "Refined serviced apartments near Belvedere Palace with direct rail connection to Vienna Airport.",
                PropertyType.Apartment, 4, "Landstrasse", "Prinz-Eugen-Strasse 58", "1040", -0.016, 0.006, 148m, 4.52m, 210,
                ["free-wifi", "free-parking", "ev-charging"], ImgSet(8)),

            // Lisbon (3)
            new("lisbon", "Chiado Miradouro Boutique", "chiado-miradouro-boutique",
                "Azulejo-tiled heritage townhouse hotel in Chiado offering panoramic Tagus River sunset views.",
                PropertyType.BoutiqueHotel, 5, "Chiado", "Rua Garrett 84", "1200-204", -0.011, -0.003, 245m, 4.86m, 515,
                ["free-wifi", "restaurant", "24h-front-desk", "bar-lounge", "airport-shuttle"], ImgSet(9)),
            new("lisbon", "Avenida da Liberdade Hotel", "avenida-da-liberdade-hotel",
                "Tree-lined boulevard hotel with rooftop plunge pool, Portuguese seafood bistro, and spa.",
                PropertyType.Hotel, 4, "Santo Antonio", "Avenida da Liberdade 185", "1269-050", 0.001, -0.008, 190m, 4.69m, 472,
                ["free-wifi", "swimming-pool", "fitness-center", "restaurant", "24h-front-desk", "ev-charging"], ImgSet(10)),
            new("lisbon", "Alfama Steps Apartments", "alfama-steps-apartments",
                "Sun-drenched historic apartments along Tram 28 route with terracotta rooftops and river glimpses.",
                PropertyType.Apartment, 3, "Alfama", "Rua de Sao Miguel 18", "1100-544", -0.012, 0.009, 132m, 4.51m, 289,
                ["free-wifi", "airport-shuttle"], ImgSet(11)),

            // Sydney (3)
            new("sydney", "Circular Quay Harbour Hotel", "circular-quay-harbour-hotel",
                "Iconic waterfront luxury hotel framing views of Sydney Opera House and Harbour Bridge.",
                PropertyType.Hotel, 5, "The Rocks", "George Street 199", "2000", 0.010, -0.001, 330m, 4.88m, 745,
                ["free-wifi", "swimming-pool", "spa-wellness", "fitness-center", "restaurant", "24h-front-desk", "bar-lounge", "business-center"], ImgSet(0)),
            new("sydney", "Bondi Pacific Beach Resort", "bondi-pacific-beach-resort",
                "Laid-back coastal resort overlooking Bondi Beach waves with surf concierge and oceanfront deck.",
                PropertyType.Resort, 4, "Bondi Beach", "Campbell Parade 148", "2026", -0.022, 0.065, 255m, 4.71m, 530,
                ["free-wifi", "swimming-pool", "restaurant", "bar-lounge", "beachfront", "24h-front-desk"], ImgSet(1)),
            new("sydney", "Surry Hills Terrace Stay", "surry-hills-terrace-stay",
                "Stylish urban boutique hotel nestled in Sydney's dining and creative hub near Central Station.",
                PropertyType.BoutiqueHotel, 4, "Surry Hills", "Crown Street 260", "2010", -0.016, 0.005, 185m, 4.59m, 268,
                ["free-wifi", "24h-front-desk", "bar-lounge", "pet-friendly"], ImgSet(2)),

            // Singapore (3)
            new("singapore", "Marina Bay Sky Sanctuary", "marina-bay-sky-sanctuary",
                "Architectural marvel featuring biophilic sky terraces, rooftop lap pool, and Michelin-starred dining.",
                PropertyType.Hotel, 5, "Marina Bay", "Bayfront Avenue 12", "018956", -0.069, 0.039, 365m, 4.94m, 1050,
                ["free-wifi", "swimming-pool", "spa-wellness", "fitness-center", "restaurant", "24h-front-desk", "bar-lounge", "business-center", "wheelchair-accessible"], ImgSet(3)),
            new("singapore", "Sentosa Cove Island Resort", "sentosa-cove-island-resort",
                "Tropical marina and beachfront sanctuary on Sentosa Island surrounded by rainforest trails.",
                PropertyType.Resort, 5, "Sentosa", "Ocean Way 21", "098374", -0.104, 0.022, 340m, 4.82m, 620,
                ["free-wifi", "swimming-pool", "spa-wellness", "fitness-center", "restaurant", "free-parking", "beachfront", "24h-front-desk"], ImgSet(4)),
            new("singapore", "Tiong Bahru Heritage Lofts", "tiong-bahru-heritage-lofts",
                "Art Deco shophouse boutique residences in Singapore's hippest heritage neighborhood.",
                PropertyType.BoutiqueHotel, 4, "Bukit Merah", "Yong Siak Street 55", "168663", -0.067, 0.011, 188m, 4.68m, 310,
                ["free-wifi", "24h-front-desk", "airport-shuttle"], ImgSet(5))
        };

        return seeds;
    }
}
