/*
Arisa Takenaka Trombley
2375446
trombley@chapman.edu
CPSC-340-02
Type Type Revolution
*/

/* DESCRIPTION
Contains Lists of configurations and word data for game settings
*/
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStuff : MonoBehaviour
{
    public List<List<List<string>>> themedWords = new List<List<List<string>>>(5);
    public List<List<string>> levelArrows = new List<List<string>>(3);
    
    // Tempo Config
    public List<int> tempos = new List<int>()
    {
        100, 140, 180, 200
    };

    // Speed of Spawning Config
    public List<float> spawnTimes = new List<float>()
    {
        2.5f, 2, 1.5f, 1f
    };
    
    private List<List<string>> defaultWords = new List<List<string>>(4);
    private List<List<string>> oceanWords = new List<List<string>>(4);
    private List<List<string>> farmWords = new List<List<string>>(4);
    private List<List<string>> winterWords = new List<List<string>>(4);
    private List<List<string>> evilWords = new List<List<string>>(4);

    // Default Words
    private List<string> threeFour_default = new List<string>()
    {
        "tea", "tin", "toe", "cat", "dog", "bat", "lie", "log", "lag", "jet", "lax", "leg", "jot",
        "nyx", "bun", "sun", "fun", "sub", "mod", "fog", "rod", "sue", "nod", "fig", "tug", "tag",
        "rat", "tar", "thin", "four", "tree", "flee", "grey", "free", "flea", "meat", "wood", "root",
        "corn", "coal", "bowl", "mold", "lynx", "bonk", "honk", "lake", "peck", "lick", "rose", "tech",
        "chat", "clap", "math", "cola", "make", "take", "fake", "life", "boil", "foil", "coil"
    };
    private List<string> fourFive_default = new List<string>()
    {
        "thin", "four", "tree", "flee", "grey", "free", "flea", "meat", "wood", "root",
        "corn", "coal", "bowl", "mold", "lynx", "bonk", "honk", "lake", "peck", "lick", "rose", "tech",
        "chat", "clap", "math", "cola", "make", "take", "fake", "life", "boil", "foil", "coil",
        "petty", "world", "penny", "grass", "space", "spade", "stale", "peach", "shoes", "pinto", "black",
        "speed", "white", "study", "frail", "grail", "paper", "happy", "green", "audio", "whack", "robot", "books",
        "photo", "clock", "timer", "music", "video", "games", "train", "crops", "swing", "stick", "leave",
        "glass", "crass", "front", "never", "daily", "dairy", "earth", "pipes", "tower", "pique", "crown", 
        "adieu", "storm", "dream", "freak"
    };
    private List<string> fiveSix_default = new List<string>()
    {
        "petty", "world", "penny", "grass", "space", "spade", "stale", "peach", "shoes", "pinto", "black",
        "speed", "white", "study", "frail", "grail", "paper", "happy", "green", "audio", "whack", "robot", "books",
        "photo", "clock", "timer", "music", "video", "games", "train", "crops", "swing", "stick", "leave", "power",
        "glass", "crass", "front", "never", "daily", "dairy", "earth", "pipes", "tower", "pique", "crown", 
        "adieu", "storm", "dream", "freak", "create", "lentil", "crouch", "legacy", "impact", "visual",
        "planet", "rocket", "socket", "jacket", "shovel", "ground", "tomato", "potato", "charge", "pocket", "locket",
        "public", "safety", "please", "humble", "bumble", "purple", "orange", "yellow", "antics", "ticket", "widget",
        "fidget", "poster", "pencil"
    };
    private List<string> sixPlus_default = new List<string>()
    {
        "create", "lentil", "crouch", "legacy", "impact", "visual",
        "planet", "rocket", "socket", "jacket", "shovel", "ground", "tomato", "potato", "charge", "pocket", "locket",
        "public", "safety", "please", "humble", "bumble", "purple", "orange", "yellow", "antics", "ticket", "widget",
        "fidget", "poster", "pencil", "program", "physics", "frantic", "america", "panther", "leather", "computer", "backpack",
        "asparagus", "burrito", "churros", "buttery", "adventure", 
    };
    
    // Winter Words
    private List<string> threeFour_winter = new List<string>()
    {
        "ice", "cap", "ski", "fir", "fur", "log", "hut", "yew", "oak", "joy", "fox", "mug", "hot", "elk", "dog", "elf",
        "yule", "snow", "cold", "sled", "warm", "tree", "boot", "mitt", "glee", "wool", "deer", "bear", "coat", "wind",
        "cool", "fire", "hail", "melt"
    };
    private List<string> fourFive_winter = new List<string>()
    {
        "yule", "snow", "cold", "sled", "warm", "tree", "boot", "mitt", "glee", "wool", "deer", "bear", "coat", "wind",
        "cool", "fire", "hail", "melt", "carol", "chill", "frost", "flake", "cheer", "white", "slush", "polar", "north", "comet",
        "scarf", "igloo", "sleet", "glove", "quiet", "storm", "angel", "holly", "santa", "merry", "gifts", "poles", "bells" , "vixen"
    };
    private List<string> fiveSix_winter = new List<string>()
    {
        "bells", "poles", "white", "slush", "polar", "north", "scarf", "igloo", "sleet", "glove", "quiet", "storm", "angel", "gifts",
        "merry", "holly", "feast", "santa", "freeze", "tundra", "frigid", "gloves", "sleigh", "frosty", "chilly", "ribbon", "comet",
        "jingle", "vixen", "frosty","wreath", "silent", "warmth", "nutmeg", "cheery", "joyful", "candle", "season", "winter"
    };
    private List<string> sixPlus_winter = new List<string>()
    {
        "chilled", "icicle", "blizzard", "reindeer", "yuletide", "reindeer", "snowman", "mistletoe", "caroling", 
        "festivity", "christmas", "winter", "snowfall", "snowflake", "wonderland", "snowboard", "fireplace", "chimney",
        "mammoth", "rudolph", "prancer", "partridge", "donner", "dancer", "dasher", "blitzen"
    };

    // Ocean Words
    private List<string> threeFour_ocean = new List<string>()
    {
        "sea", "fin", "bay", "sub", "net", "dew", "cod", "sun", "oar", "sky","fog","ray","mud","oil","rip",
        "spa", "ice", "eel", "flo", "wave", "tide", "reef", "ship", "sand", "sail", "fish", "dock", "cove",
        "surf", "clam", "dive", "rock", "knot", "buoy", "pool", "hump", "surf",
        "weed", "boat", "gull", "oars", "pier", "gull", "foam", "kelp"
    };
    private List<string> fourFive_ocean = new List<string>()
    {
        "goby", "wave", "tide", "reef", "ship", "sand", "sail", "fish", "dock", "cove", 
        "surf", "clam", "dive", "rock", "knot", "buoy", "pool", "hump", "weed", "boat", 
        "gull", "coral", "shell", "whale", "coast", "float", "seal", "pearl", "kelp", 
        "foam", "pier", "oars", "wake", "beach", "ocean", "stern", "lures", 
        "crabs", "inlet", "abyss", "shoal", "wreck", "buoys", "fluke", "surge",
        "isles", "wharf", "spray", "sound", "ferry", "spray", "yacht", "shark"
    };
    private List<string> fiveSix_ocean = new List<string>()
    {
        "coral", "shell", "whale", "coast", "float", "seal", "pearl", "kelp", 
        "foam", "pier", "oars", "wake", "beach", "ocean", "stern",
        "crabs", "inlet", "abyss", "shoal", "wreck", "fluke", "surge",
        "isles", "wharf", "spray", "sound", "ferry", "corals", "wharfs", "shells",
        "whales", "tides", "oceans", "sterns", "lures", 
        "seabed", "inlets", "shoals", "wrecks", "buoys", "flukes", "surges", "islets",
        "sprays", "crusts", "bucket", "yachts", "sharks", "mantis", "trench",
        "hermit", "mussel", "turtle", "oyster", "marina",
        "sponge", "reefer", "urchin", "angler", "tropic", "sailor",
        "splash", "marlin", "shrimp", "skates",  "squids", "island",
        "anchor", "harbor"
    };
    private List<string> sixPlus_ocean = new List<string>()
    {
        "corals", "wharfs", "shells", "whales", "tides", "oceans", "sterns", "lures", 
        "seabed", "inlets", "shoals", "wrecks", "buoys", "flukes", "surges", "islets",
        "sprays", "crusts", "yachts", "sharks", "mantis", "trench", "hermit", "mussel", 
        "turtle", "oyster", "marina", "sponge", "reefer", "urchin", "angler", "flukes", 
        "tropic", "sailor", "splash", "marlin", "shrimp", "skates",  "squids", "island",
        "anchor", "harbor", "ferries", "anchors", "lobster","mussels", "galleon", "seaweed", 
        "mackerel", "dolphin", "narwhal", "seashell"
    };
    
    // Farm Words
    private List<string> threeFour_farm = new List<string>()
    {
        "cow", "pig", "hen", "hay", "dog", "cat", "pen", "hog" , "egg", "ram", "axe", "web",
        "moo", "rat", "mud", "fox", "hut", "ewe","ant","bee", "caw", "owl", "kak", "kid", "hoe", "bell", "feed",
        "doe","calf", "farm", "barn", "roam", "goat", "lamb", "corn", "mule", "wool", "duck", "grow", "herd",
        "soil", "dirt", "bull", "rake", "seed", "silo", "crop", "pond", "mare", "colt", "wood", "yard", "plow"
    };
    private List<string> fourFive_farm = new List<string>()
    {
        "calf", "farm", "barn", "roam", "goat", "lamb", "corn", "mule", "wool", "duck", "yard", "plow",
        "soil", "dirt", "bull", "rake", "seed", "silo", "crop", "pond", "mare", "colt", "grow","mill", 
        "chick", "truck", "raise", "field", "grain", "tools", "wheel", "horse", "stable", "fence",
        "quail", "water", "plant", "sheep", "dairy", "churn", "ranch", "wheat", "acres", "maize", "feral",
        "swine", "ducks", "flock", "jeans", "denim", "herds", "shuck"
    };
    private List<string> fiveSix_farm = new List<string>()
    {
        "chick", "truck", "raise", "field", "grain", "tools", "wheel", "horse", "stable", "fence", "herds",
        "quail", "water", "plant", "sheep", "dairy", "churn", "ranch", "wheat", "acres", "maize", "feral", "neigh",
        "ducks", "flock", "jeans", "denim", "shovel", "animal", "engine", "trough", "barrel", "butter",
        "farmer", "grapes", "barley", "kennel", "pastor", "tomato", "potato", "donkey", "plough", "milker", "stalls"
    };
    private List<string> sixPlus_farm = new List<string>()
    {
        "shovel", "animal", "engine", "trough", "barrel", "butter", "milker", "stalls",
        "farmer", "grapes", "barley", "kennel", "pastor", "tomato", "potato", "donkey", "plough",
        "tractor", "flannel", "orchard", "cattle", "garden", "weeder", "manure", "rooster", "poultry",
        "stallion", "harvest", "piglet", "spider", "cowbell", "pasture", "grazed"
    };
    
    // Evil Words
    private List<string> threeFour_evil = new List<string>()
    {
        "eye", "leg", "gut", "lie", "rot", "lug", "sad", "mad", "not", "ill", "bad", "cry",
        "hex", "sin", "war", "pit", "spy", "cut", "woe", "ash", "con", "tar", "off", "dark", "kill", 
        "end", "rip", "bane", "cold", "hate", "fail", "quit", "grim", "vice", "gore", "dirt", "evil",
        "fear", "pain", "rude", "fist", "lurk", "hurt", "doom", "hell", "hang", "cash", "body",
        "rash", "bugs", "slay", "foul", "gory", "liar", "narc", "sins", "skin", "feed", "stab"
    };
    private List<string> fourFive_evil = new List<string>()
    {
        "dark", "kill", "bane", "cold", "hate", "fail", "quit", "grim", "vice", "gore", "dirt", "evil",
        "fear", "pain", "rude", "fist", "lurk", "hurt", "doom", "hell", "hang", "cash", "drug", "skin", 
        "rash", "bugs", "slay", "foul", "gory", "liar", "narc", "sins", "death", "witch", "curse",
        "fiend", "blood", "devil", "demon", "magic", "depth", "dread", "skull", "sword", "hoard", "spike",
        "drugs", "crack", "broke", "break", "freak", "chaos", "cruel", "venom", "denim", "stink", "stale", "stake",
        "dirty", "gross", "mummy", "grave", "haunt", "crime"
    };
    private List<string> fiveSix_evil = new List<string>()
    {
        "haunt", "death", "witch", "curse", "fiend", "blood", "devil", "demon", "magic", "depth", "dread", "skull", "sword", "hoard", "spike",
        "drugs", "crack", "broke", "break", "freak", "chaos", "cruel", "venom", "denim", "stink", "stale", "stake", "flesh",
        "dirty", "gross", "mummy", "grave", "enemy", "wicked", "afraid", "broken", "terror", "horror", "cursed", "famine", "hatred", "betray",
        "poison", "unjust", "menace", "shadow", "stench", "tyrant", "vulgar", "fringe", "infect", "vandal",
        "grieve", "hexing", "luring", "damage", "scream", "murder"
    };
    private List<string> sixPlus_evil = new List<string>()
    {
        "wicked", "afraid", "broken", "terror", "horror", "cursed", "famine", "hatred", "betray",
        "poison", "unjust", "menace", "shadow", "stench", "tyrant", "vulgar", "fringe", "infect", "vandal",
        "grieve", "hexing", "luring", "damage", "cremate", "sinister", "heinous", "monster", "torture", "calamity",
        "haunted", "murder", "killing", "stabber", "kidnap", "malice", "deform", "destroy", "corrupt",
        "demonic", "demons", "eyeball"
    };
    
    // Song Arrows: Left = 1, Up = 2, Down = 3, Right = 4
    private List<string> songOne = new List<string>(24)
    {
        "Left", "Left", "Right", "Right", "Up", "Down", "Left", "Right",
        "Up", "Down", "Up", "Down", "Left", "Right", "Left", "Right",
        "Up", "Left", "Down", "Right", "Up", "Right", "Down", "Left"
    };
    private List<string> songTwo = new List<string>(24)
    {
        "Left", "Left", "Right", "Right", "Up", "Down", "Left", "Right",
        "Up", "Down", "Up", "Down", "Left", "Right", "Left", "Right",
        "Up", "Left", "Down", "Right", "Up", "Right", "Down", "Left"
    };
    private List<string> songThree = new List<string>(24)
    {
        "Left", "Left", "Right", "Right", "Up", "Down", "Left", "Right",
        "Up", "Down", "Up", "Down", "Left", "Right", "Left", "Right",
        "Up", "Left", "Down", "Right", "Up", "Right", "Down", "Left"
    };

    private void Awake()
    {
        defaultWords.Add(threeFour_default);
        defaultWords.Add(fourFive_default);
        defaultWords.Add(fiveSix_default);
        defaultWords.Add(sixPlus_default);
        
        oceanWords.Add(threeFour_ocean);
        oceanWords.Add(fourFive_ocean);
        oceanWords.Add(fiveSix_ocean);
        oceanWords.Add(sixPlus_ocean);

        farmWords.Add(threeFour_farm);
        farmWords.Add(fourFive_farm);
        farmWords.Add(fiveSix_farm);
        farmWords.Add(sixPlus_farm);

        winterWords.Add(threeFour_winter);
        winterWords.Add(fourFive_winter);
        winterWords.Add(fiveSix_winter);
        winterWords.Add(sixPlus_winter);

        evilWords.Add(threeFour_evil);
        evilWords.Add(fourFive_evil);
        evilWords.Add(fiveSix_evil);
        evilWords.Add(sixPlus_evil);

        levelArrows.Add(songOne);
        levelArrows.Add(songTwo);
        levelArrows.Add(songThree);

        themedWords.Add(defaultWords);
        themedWords.Add(oceanWords);
        themedWords.Add(winterWords);
        themedWords.Add(farmWords);
        themedWords.Add(evilWords);
    }
}
