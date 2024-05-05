namespace Models.Data
{
    using Constants;
    using Localization;

    public static class CharacterDataDictionary
    {
        public static readonly IReadOnlyDictionary<string, string[]> Pronouns = new Dictionary<string, string[]>
        {
            [CharacterSheet.He] = [CharacterSheetLocale.He, CharacterSheetLocale.Him, CharacterSheetLocale.His],
            [CharacterSheet.She] = [CharacterSheetLocale.She, CharacterSheetLocale.Her, CharacterSheetLocale.Hers],
            [CharacterSheet.They] = [CharacterSheetLocale.They, CharacterSheetLocale.Them, CharacterSheetLocale.Theirs]
        };

        public static readonly IReadOnlyDictionary<string, object> Origins = new Dictionary<string, object>
        {
            ["Skyborn"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.SkybornDescription,
                [CharacterSheet.Traits] = CharacterCreatorLocale.SkybornTraits,
                [CharacterSheet.Drawbacks] = CharacterCreatorLocale.SkybornDrawbacks,
                [CharacterSheet.TotalStatChanges] = new Dictionary<string, int>
                {
                    [CharacterSheet.Strength] = -1,
                    [CharacterSheet.Dexterity] = 1,
                    [CharacterSheet.Constitution] = -1,
                    [CharacterSheet.Intelligence] = 1,
                    [CharacterSheet.Wisdom] = 0,
                    [CharacterSheet.Charisma] = 0
                }
            },
            ["Wastelander"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.WastelanderDescription,
                [CharacterSheet.Traits] = CharacterCreatorLocale.WastelanderTraits,
                [CharacterSheet.Drawbacks] = CharacterCreatorLocale.WastelanderDrawbacks,
                [CharacterSheet.TotalStatChanges] = new Dictionary<string, int>
                {
                    [CharacterSheet.Strength] = 0,
                    [CharacterSheet.Dexterity] = -1,
                    [CharacterSheet.Constitution] = 1,
                    [CharacterSheet.Intelligence] = 0,
                    [CharacterSheet.Wisdom] = 1,
                    [CharacterSheet.Charisma] = -1
                }
            },
            ["Nomad"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.NomadDescription,
                [CharacterSheet.Traits] = CharacterCreatorLocale.NomadTraits,
                [CharacterSheet.Drawbacks] = CharacterCreatorLocale.NomadDrawbacks,
                [CharacterSheet.TotalStatChanges] = new Dictionary<string, int>
                {
                    [CharacterSheet.Strength] = 0,
                    [CharacterSheet.Dexterity] = 1,
                    [CharacterSheet.Constitution] = 0,
                    [CharacterSheet.Intelligence] = -1,
                    [CharacterSheet.Wisdom] = 1,
                    [CharacterSheet.Charisma] = -1
                }
            },
            ["Tech Savant"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.TechSavantDescription,
                [CharacterSheet.Traits] = CharacterCreatorLocale.TechSavantTraits,
                [CharacterSheet.Drawbacks] = CharacterCreatorLocale.TechSavantDrawbacks,
                [CharacterSheet.TotalStatChanges] = new Dictionary<string, int>
                {
                    [CharacterSheet.Strength] = -1,
                    [CharacterSheet.Dexterity] = 1,
                    [CharacterSheet.Constitution] = 0,
                    [CharacterSheet.Intelligence] = 1,
                    [CharacterSheet.Wisdom] = -1,
                    [CharacterSheet.Charisma] = 0
                }
            },
            ["Shadowborn"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.ShadowbornDescription,
                [CharacterSheet.Traits] = CharacterCreatorLocale.ShadowbornTraits,
                [CharacterSheet.Drawbacks] = CharacterCreatorLocale.ShadowbornDrawbacks,
                [CharacterSheet.TotalStatChanges] = new Dictionary<string, int>
                {
                    [CharacterSheet.Strength] = -2,
                    [CharacterSheet.Dexterity] = 1,
                    [CharacterSheet.Constitution] = -1,
                    [CharacterSheet.Intelligence] = 0,
                    [CharacterSheet.Wisdom] = 0,
                    [CharacterSheet.Charisma] = 2
                }
            }
            // Add more origins here
        };

        public static readonly IReadOnlyDictionary<string, object> Races = new Dictionary<string, object>
        {
            ["Human"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.HumanDescription,
                [CharacterSheet.Traits] = CharacterCreatorLocale.HumanTraits,
                [CharacterSheet.Drawbacks] = CharacterCreatorLocale.HumanDrawbacks,
                [CharacterSheet.TotalStatChanges] = new Dictionary<string, int>
                {
                    [CharacterSheet.Strength] = 0,
                    [CharacterSheet.Dexterity] = 0,
                    [CharacterSheet.Constitution] = 0,
                    [CharacterSheet.Intelligence] = 0,
                    [CharacterSheet.Wisdom] = 0,
                    [CharacterSheet.Charisma] = 0
                }
            },
            ["Mutant"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.MutantDescription,
                [CharacterSheet.Traits] = CharacterCreatorLocale.MutantTraits,
                [CharacterSheet.Drawbacks] = CharacterCreatorLocale.MutantDrawbacks,
                [CharacterSheet.TotalStatChanges] = new Dictionary<string, int>
                {
                    [CharacterSheet.Strength] = 1,
                    [CharacterSheet.Dexterity] = 0,
                    [CharacterSheet.Constitution] = 2,
                    [CharacterSheet.Intelligence] = -2,
                    [CharacterSheet.Wisdom] = 0,
                    [CharacterSheet.Charisma] = -1
                }
            },
            ["Scavenger"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.ScavengerDescription,
                [CharacterSheet.Traits] = CharacterCreatorLocale.ScavengerTraits,
                [CharacterSheet.Drawbacks] = CharacterCreatorLocale.ScavengerDrawbacks,
                [CharacterSheet.TotalStatChanges] = new Dictionary<string, int>
                {
                    [CharacterSheet.Strength] = -1,
                    [CharacterSheet.Dexterity] = 1,
                    [CharacterSheet.Constitution] = -1,
                    [CharacterSheet.Intelligence] = 0,
                    [CharacterSheet.Wisdom] = 1,
                    [CharacterSheet.Charisma] = 0
                }
            },
            ["Cybernetic"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.CyberneticDescription,
                [CharacterSheet.Traits] = CharacterCreatorLocale.CyberneticTraits,
                [CharacterSheet.Drawbacks] = CharacterCreatorLocale.CyberneticDrawbacks,
                [CharacterSheet.TotalStatChanges] = new Dictionary<string, int>
                {
                    [CharacterSheet.Strength] = 2,
                    [CharacterSheet.Dexterity] = -2,
                    [CharacterSheet.Constitution] = 0,
                    [CharacterSheet.Intelligence] = 1,
                    [CharacterSheet.Wisdom] = 0,
                    [CharacterSheet.Charisma] = -1
                }
            },
            ["Marauder"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.MarauderDescription,
                [CharacterSheet.Traits] = CharacterCreatorLocale.MarauderTraits,
                [CharacterSheet.Drawbacks] = CharacterCreatorLocale.MarauderDrawbacks,
                [CharacterSheet.TotalStatChanges] = new Dictionary<string, int>
                {
                    [CharacterSheet.Strength] = 1,
                    [CharacterSheet.Dexterity] = 0,
                    [CharacterSheet.Constitution] = 0,
                    [CharacterSheet.Intelligence] = -1,
                    [CharacterSheet.Wisdom] = 2,
                    [CharacterSheet.Charisma] = -2
                }
            }
            // Add more races here
        };

        public static readonly IReadOnlyDictionary<string, object> Motivations = new Dictionary<string, object>
        {
            ["The Pathfinder"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.PathfinderDescription,
                [CharacterSheet.Goal] = CharacterCreatorLocale.PathfinderGoal
            },
            ["The Vengeful"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.VengefulDescription,
                [CharacterSheet.Goal] = CharacterCreatorLocale.VengefulGoal
            },
            ["The Redeemer"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.RedeemerDescription,
                [CharacterSheet.Goal] = CharacterCreatorLocale.RedeemerGoal
            },
            ["The Survivor"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.SurvivorDescription,
                [CharacterSheet.Goal] = CharacterCreatorLocale.SurvivorGoal
            },
            ["The Opportunist"] = new Dictionary<string, object>
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.OpportunistDescription,
                [CharacterSheet.Goal] = CharacterCreatorLocale.OpportunistGoal
            }
            // Add more motivations here
        };

        public static readonly IReadOnlyDictionary<string, object> Stats = new Dictionary<string, object>()
        {
            ["Strength"] = new Dictionary<string, object>()
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.StrengthDescription
            },
            ["Dexterity"] = new Dictionary<string, object>()
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.DexterityDescription
            },
            ["Constitution"] = new Dictionary<string, object>()
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.ConstitutionDescription
            },
            ["Intelligence"] = new Dictionary<string, object>()
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.IntelligenceDescription
            },
            ["Wisdom"] = new Dictionary<string, object>()
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.WisdomDescription,
            },
            ["Charisma"] = new Dictionary<string, object>()
            {
                [CharacterSheet.Description] = CharacterCreatorLocale.CharismaDescription,
            },
        };
    }
}