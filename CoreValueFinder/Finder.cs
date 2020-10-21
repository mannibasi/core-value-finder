using System;

namespace CoreValueFinder
{
    public class Finder
    {
        private const int CORE_VALUE_UPPER_BOUND = 10;
        private int parsedRatingInput;
        private readonly CoreValueEngine engine;

        public Finder()
        {
            this.engine = DefaultCoreValueEngine();
        }

        internal void Find()
        {
            CaptureValueRatings(engine);
            engine.RoundOneValueElimination();
            engine.PrepareForValueRating();
            CaptureValueRatings(engine);
            engine.RoundTwoValueElimination();
            PrintCoreValues(engine);
        }

        public bool RatingIsValid(string ratingInput)
        {
            return int.TryParse(ratingInput, out parsedRatingInput);
        }

        private void CaptureValueRatings(CoreValueEngine engine)
        {
            Console.Clear();
            Console.WriteLine("Please (re-)rate remaining values on a scale of zero to ten:");
            foreach (var cv in engine.GetCoreValues())
            {
                bool validRating = false;
                while(!validRating)
                {
                    Console.WriteLine(cv.GetDescription());
                    string input = Console.ReadLine();
                    if (RatingIsValid(input))
                    {
                        cv.Rate(parsedRatingInput);
                        validRating = true;
                    }
                }
            }
        }

        private void PrintCoreValues(CoreValueEngine engine)
        {
            Console.Clear();
            Console.WriteLine("The following constitutes your list of personal core values:");
            PrintCoreValueDescriptions(engine);
            if (engine.GetCoreValues().Count < CORE_VALUE_UPPER_BOUND)
            {
                Console.WriteLine("If your personal core values list is still too long and bulky, " +
                    "chip away at it some more until you only have about 10 values on your list. " +
                    "Make that part of who you are and know that this is your code (or map) to your best life.");
            }
        }

        private void PrintCoreValueDescriptions(CoreValueEngine engine)
        {
            foreach (var cv in engine.GetCoreValues())
            {
                Console.WriteLine(cv.GetDescription());
            }
        }

        public static CoreValueEngine DefaultCoreValueEngine()
        {
            var cve = new CoreValueEngine();
            cve.Add(new CoreValue("Abundance"));
            cve.Add(new CoreValue("Acceptance"));
            cve.Add(new CoreValue("Accessibility"));
            cve.Add(new CoreValue("Accomplishment"));
            cve.Add(new CoreValue("Accuracy"));
            cve.Add(new CoreValue("Achievement"));
            cve.Add(new CoreValue("Acknowledgement"));
            cve.Add(new CoreValue("Activeness"));
            cve.Add(new CoreValue("Adaptability"));
            cve.Add(new CoreValue("Adoration"));
            cve.Add(new CoreValue("Adroitness"));
            cve.Add(new CoreValue("Adventure"));
            cve.Add(new CoreValue("Affection"));
            cve.Add(new CoreValue("Affluence"));
            cve.Add(new CoreValue("Aggressiveness"));
            cve.Add(new CoreValue("Agility"));
            cve.Add(new CoreValue("Alertness"));
            cve.Add(new CoreValue("Altruism"));
            cve.Add(new CoreValue("Ambition"));
            cve.Add(new CoreValue("Amusement"));
            cve.Add(new CoreValue("Anticipation"));
            cve.Add(new CoreValue("Appreciation"));
            cve.Add(new CoreValue("Approachability"));
            cve.Add(new CoreValue("Articulateness"));
            cve.Add(new CoreValue("Assertiveness"));
            cve.Add(new CoreValue("Assurance"));
            cve.Add(new CoreValue("Attentiveness"));
            cve.Add(new CoreValue("Attractiveness"));
            cve.Add(new CoreValue("Audacity"));
            cve.Add(new CoreValue("Availability"));
            cve.Add(new CoreValue("Awareness"));
            cve.Add(new CoreValue("Awe"));
            cve.Add(new CoreValue("Balance"));
            cve.Add(new CoreValue("Beauty"));
            cve.Add(new CoreValue("Being the best"));
            cve.Add(new CoreValue("Belonging"));
            cve.Add(new CoreValue("Benevolence"));
            cve.Add(new CoreValue("Bliss"));
            cve.Add(new CoreValue("Boldness"));
            cve.Add(new CoreValue("Bravery"));
            cve.Add(new CoreValue("Brilliance"));
            cve.Add(new CoreValue("Buoyancy"));
            cve.Add(new CoreValue("Calmness"));
            cve.Add(new CoreValue("Camaraderie"));
            cve.Add(new CoreValue("Candour"));
            cve.Add(new CoreValue("Capability"));
            cve.Add(new CoreValue("Care"));
            cve.Add(new CoreValue("Carefulness"));
            cve.Add(new CoreValue("Celebrity"));
            cve.Add(new CoreValue("Certainty"));
            cve.Add(new CoreValue("Challenge"));
            cve.Add(new CoreValue("Charity"));
            cve.Add(new CoreValue("Charm"));
            cve.Add(new CoreValue("Chastity"));
            cve.Add(new CoreValue("Cheerfulness"));
            cve.Add(new CoreValue("Clarity"));
            cve.Add(new CoreValue("Cleanliness"));
            cve.Add(new CoreValue("Clear-mindedness"));
            cve.Add(new CoreValue("Cleverness"));
            cve.Add(new CoreValue("Closeness"));
            cve.Add(new CoreValue("Comfort"));
            cve.Add(new CoreValue("Commitment"));
            cve.Add(new CoreValue("Compassion"));
            cve.Add(new CoreValue("Completion"));
            cve.Add(new CoreValue("Composure"));
            cve.Add(new CoreValue("Concentration"));
            cve.Add(new CoreValue("Confidence"));
            cve.Add(new CoreValue("Conformity"));
            cve.Add(new CoreValue("Congruency"));
            cve.Add(new CoreValue("Connection"));
            cve.Add(new CoreValue("Consciousness"));
            cve.Add(new CoreValue("Consistency"));
            cve.Add(new CoreValue("Contentment"));
            cve.Add(new CoreValue("Continuity"));
            cve.Add(new CoreValue("Contribution"));
            cve.Add(new CoreValue("Control"));
            cve.Add(new CoreValue("Conviction"));
            cve.Add(new CoreValue("Conviviality"));
            cve.Add(new CoreValue("Coolness"));
            cve.Add(new CoreValue("Cooperation"));
            cve.Add(new CoreValue("Cordiality"));
            cve.Add(new CoreValue("Correctness"));
            cve.Add(new CoreValue("Courage"));
            cve.Add(new CoreValue("Courtesy"));
            cve.Add(new CoreValue("Craftiness"));
            cve.Add(new CoreValue("Creativity"));
            cve.Add(new CoreValue("Credibility"));
            cve.Add(new CoreValue("Cunning"));
            cve.Add(new CoreValue("Curiosity"));
            cve.Add(new CoreValue("Daring"));
            cve.Add(new CoreValue("Decisiveness"));
            cve.Add(new CoreValue("Decorum"));
            cve.Add(new CoreValue("Deference"));
            cve.Add(new CoreValue("Delight"));
            cve.Add(new CoreValue("Dependability"));
            cve.Add(new CoreValue("Depth"));
            cve.Add(new CoreValue("Desire"));
            cve.Add(new CoreValue("Determination"));
            cve.Add(new CoreValue("Devotion"));
            cve.Add(new CoreValue("Devoutness"));
            cve.Add(new CoreValue("Dexterity"));
            cve.Add(new CoreValue("Dignity"));
            cve.Add(new CoreValue("Diligence"));
            cve.Add(new CoreValue("Direction"));
            cve.Add(new CoreValue("Directness"));
            cve.Add(new CoreValue("Discipline"));
            cve.Add(new CoreValue("Discovery"));
            cve.Add(new CoreValue("Discretion"));
            cve.Add(new CoreValue("Diversity"));
            cve.Add(new CoreValue("Dominance"));
            cve.Add(new CoreValue("Dreaming"));
            cve.Add(new CoreValue("Drive"));
            cve.Add(new CoreValue("Duty"));
            cve.Add(new CoreValue("Dynamism"));
            cve.Add(new CoreValue("Eagerness"));
            cve.Add(new CoreValue("Economy"));
            cve.Add(new CoreValue("Ecstasy"));
            cve.Add(new CoreValue("Education"));
            cve.Add(new CoreValue("Effectiveness"));
            cve.Add(new CoreValue("Efficiency"));
            cve.Add(new CoreValue("Elation"));
            cve.Add(new CoreValue("Elegance"));
            cve.Add(new CoreValue("Empathy"));
            cve.Add(new CoreValue("Encouragement"));
            cve.Add(new CoreValue("Endurance"));
            cve.Add(new CoreValue("Energy"));
            cve.Add(new CoreValue("Enjoyment"));
            cve.Add(new CoreValue("Entertainment"));
            cve.Add(new CoreValue("Enthusiasm"));
            cve.Add(new CoreValue("Excellence"));
            cve.Add(new CoreValue("Excitement"));
            cve.Add(new CoreValue("Exhilaration"));
            cve.Add(new CoreValue("Expectancy"));
            cve.Add(new CoreValue("Expediency"));
            cve.Add(new CoreValue("Experience"));
            cve.Add(new CoreValue("Expertise"));
            cve.Add(new CoreValue("Exploration"));
            cve.Add(new CoreValue("Expressiveness"));
            cve.Add(new CoreValue("Extravagance"));
            cve.Add(new CoreValue("Extroversion"));
            cve.Add(new CoreValue("Exuberance"));
            cve.Add(new CoreValue("Fairness"));
            cve.Add(new CoreValue("Faith"));
            cve.Add(new CoreValue("Fame"));
            cve.Add(new CoreValue("Family"));
            cve.Add(new CoreValue("Fascination"));
            cve.Add(new CoreValue("Fashion"));
            cve.Add(new CoreValue("Fearlessness"));
            cve.Add(new CoreValue("Ferocity"));
            cve.Add(new CoreValue("Fidelity"));
            cve.Add(new CoreValue("Fierceness"));
            cve.Add(new CoreValue("Financial independence"));
            cve.Add(new CoreValue("Firmness"));
            cve.Add(new CoreValue("Fitness"));
            cve.Add(new CoreValue("Flexibility"));
            cve.Add(new CoreValue("Flow"));
            cve.Add(new CoreValue("Fluency"));
            cve.Add(new CoreValue("Focus"));
            cve.Add(new CoreValue("Fortitude"));
            cve.Add(new CoreValue("Frankness"));
            cve.Add(new CoreValue("Freedom"));
            cve.Add(new CoreValue("Friendliness"));
            cve.Add(new CoreValue("Frugality"));
            cve.Add(new CoreValue("Fun"));
            cve.Add(new CoreValue("Gallantry"));
            cve.Add(new CoreValue("Generosity"));
            cve.Add(new CoreValue("Gentility"));
            cve.Add(new CoreValue("Giving"));
            cve.Add(new CoreValue("Grace"));
            cve.Add(new CoreValue("Gratitude"));
            cve.Add(new CoreValue("Gregariousness"));
            cve.Add(new CoreValue("Growth"));
            cve.Add(new CoreValue("Guidance"));
            cve.Add(new CoreValue("Happiness"));
            cve.Add(new CoreValue("Harmony"));
            cve.Add(new CoreValue("Health"));
            cve.Add(new CoreValue("Heart"));
            cve.Add(new CoreValue("Helpfulness"));
            cve.Add(new CoreValue("Heroism"));
            cve.Add(new CoreValue("Holiness"));
            cve.Add(new CoreValue("Honesty"));
            cve.Add(new CoreValue("Honour"));
            cve.Add(new CoreValue("Hopefulness"));
            cve.Add(new CoreValue("Hospitality"));
            cve.Add(new CoreValue("Humility"));
            cve.Add(new CoreValue("Humour"));
            cve.Add(new CoreValue("Hygiene"));
            cve.Add(new CoreValue("Imagination"));
            cve.Add(new CoreValue("Impact"));
            cve.Add(new CoreValue("Impartiality"));
            cve.Add(new CoreValue("Independence"));
            cve.Add(new CoreValue("Industry"));
            cve.Add(new CoreValue("Ingenuity"));
            cve.Add(new CoreValue("Inquisitiveness"));
            cve.Add(new CoreValue("Insightfulness"));
            cve.Add(new CoreValue("Inspiration"));
            cve.Add(new CoreValue("Integrity"));
            cve.Add(new CoreValue("Intelligence"));
            cve.Add(new CoreValue("Intensity"));
            cve.Add(new CoreValue("Intimacy"));
            cve.Add(new CoreValue("Intrepidness"));
            cve.Add(new CoreValue("Introversion"));
            cve.Add(new CoreValue("Intuition"));
            cve.Add(new CoreValue("Intuitiveness"));
            cve.Add(new CoreValue("Inventiveness"));
            cve.Add(new CoreValue("Investing"));
            cve.Add(new CoreValue("Joy"));
            cve.Add(new CoreValue("Judiciousness"));
            cve.Add(new CoreValue("Justice"));
            cve.Add(new CoreValue("Keenness"));
            cve.Add(new CoreValue("Kindness"));
            cve.Add(new CoreValue("Knowledge"));
            cve.Add(new CoreValue("Leadership"));
            cve.Add(new CoreValue("Learning"));
            cve.Add(new CoreValue("Liberation"));
            cve.Add(new CoreValue("Liberty"));
            cve.Add(new CoreValue("Liveliness"));
            cve.Add(new CoreValue("Logic"));
            cve.Add(new CoreValue("Longevity"));
            cve.Add(new CoreValue("Love"));
            cve.Add(new CoreValue("Loyalty"));
            cve.Add(new CoreValue("Majesty"));
            cve.Add(new CoreValue("Making a difference"));
            cve.Add(new CoreValue("Mastery"));
            cve.Add(new CoreValue("Maturity"));
            cve.Add(new CoreValue("Meekness"));
            cve.Add(new CoreValue("Mellowness"));
            cve.Add(new CoreValue("Meticulousness"));
            cve.Add(new CoreValue("Mindfulness"));
            cve.Add(new CoreValue("Modesty"));
            cve.Add(new CoreValue("Motivation"));
            cve.Add(new CoreValue("Mysteriousness"));
            cve.Add(new CoreValue("Neatness"));
            cve.Add(new CoreValue("Nerve"));
            cve.Add(new CoreValue("Obedience"));
            cve.Add(new CoreValue("Open-mindedness"));
            cve.Add(new CoreValue("Openness"));
            cve.Add(new CoreValue("Optimism"));
            cve.Add(new CoreValue("Order"));
            cve.Add(new CoreValue("Organization"));
            cve.Add(new CoreValue("Originality"));
            cve.Add(new CoreValue("Outlandishness"));
            cve.Add(new CoreValue("Outrageousness"));
            cve.Add(new CoreValue("Passion"));
            cve.Add(new CoreValue("Peace"));
            cve.Add(new CoreValue("Perceptiveness"));
            cve.Add(new CoreValue("Perfection"));
            cve.Add(new CoreValue("Perkiness"));
            cve.Add(new CoreValue("Perseverance"));
            cve.Add(new CoreValue("Persistence"));
            cve.Add(new CoreValue("Persuasiveness"));
            cve.Add(new CoreValue("Philanthropy"));
            cve.Add(new CoreValue("Piety"));
            cve.Add(new CoreValue("Playfulness"));
            cve.Add(new CoreValue("Pleasantness"));
            cve.Add(new CoreValue("Pleasure"));
            cve.Add(new CoreValue("Poise"));
            cve.Add(new CoreValue("Polish"));
            cve.Add(new CoreValue("Popularity"));
            cve.Add(new CoreValue("Potency"));
            cve.Add(new CoreValue("Power"));
            cve.Add(new CoreValue("Practicality"));
            cve.Add(new CoreValue("Pragmatism"));
            cve.Add(new CoreValue("Precision"));
            cve.Add(new CoreValue("Preparedness"));
            cve.Add(new CoreValue("Presence"));
            cve.Add(new CoreValue("Privacy"));
            cve.Add(new CoreValue("Proactivity"));
            cve.Add(new CoreValue("Professionalism"));
            cve.Add(new CoreValue("Prosperity"));
            cve.Add(new CoreValue("Prudence"));
            cve.Add(new CoreValue("Punctuality"));
            cve.Add(new CoreValue("Purity"));
            cve.Add(new CoreValue("Realism"));
            cve.Add(new CoreValue("Reason"));
            cve.Add(new CoreValue("Reasonableness"));
            cve.Add(new CoreValue("Recognition"));
            cve.Add(new CoreValue("Recreation"));
            cve.Add(new CoreValue("Refinement"));
            cve.Add(new CoreValue("Reflection"));
            cve.Add(new CoreValue("Relaxation"));
            cve.Add(new CoreValue("Reliability"));
            cve.Add(new CoreValue("Religiousness"));
            cve.Add(new CoreValue("Resilience"));
            cve.Add(new CoreValue("Resolution"));
            cve.Add(new CoreValue("Resolve"));
            cve.Add(new CoreValue("Resourcefulness"));
            cve.Add(new CoreValue("Respect"));
            cve.Add(new CoreValue("Rest"));
            cve.Add(new CoreValue("Restraint"));
            cve.Add(new CoreValue("Reverence"));
            cve.Add(new CoreValue("Richness"));
            cve.Add(new CoreValue("Rigor"));
            cve.Add(new CoreValue("Sacredness"));
            cve.Add(new CoreValue("Sacrifice"));
            cve.Add(new CoreValue("Sagacity"));
            cve.Add(new CoreValue("Saintliness"));
            cve.Add(new CoreValue("Sanguinity"));
            cve.Add(new CoreValue("Satisfaction"));
            cve.Add(new CoreValue("Security"));
            cve.Add(new CoreValue("Self-control"));
            cve.Add(new CoreValue("Self-reliance"));
            cve.Add(new CoreValue("Selflessness"));
            cve.Add(new CoreValue("Sensitivity"));
            cve.Add(new CoreValue("Sensuality"));
            cve.Add(new CoreValue("Serenity"));
            cve.Add(new CoreValue("Service"));
            cve.Add(new CoreValue("Sexuality"));
            cve.Add(new CoreValue("Sharing"));
            cve.Add(new CoreValue("Shrewdness"));
            cve.Add(new CoreValue("Significance"));
            cve.Add(new CoreValue("Silence"));
            cve.Add(new CoreValue("Silliness"));
            cve.Add(new CoreValue("Simplicity"));
            cve.Add(new CoreValue("Sincerity"));
            cve.Add(new CoreValue("Skilfulness"));
            cve.Add(new CoreValue("Solidarity"));
            cve.Add(new CoreValue("Solitude"));
            cve.Add(new CoreValue("Soundness"));
            cve.Add(new CoreValue("Speed"));
            cve.Add(new CoreValue("Spirit"));
            cve.Add(new CoreValue("Spirituality"));
            cve.Add(new CoreValue("Spontaneity"));
            cve.Add(new CoreValue("Spunk"));
            cve.Add(new CoreValue("Stability"));
            cve.Add(new CoreValue("Stealth"));
            cve.Add(new CoreValue("Stillness"));
            cve.Add(new CoreValue("Strength"));
            cve.Add(new CoreValue("Structure"));
            cve.Add(new CoreValue("Success"));
            cve.Add(new CoreValue("Support"));
            cve.Add(new CoreValue("Supremacy"));
            cve.Add(new CoreValue("Surprise"));
            cve.Add(new CoreValue("Sympathy"));
            cve.Add(new CoreValue("Synergy"));
            cve.Add(new CoreValue("Teamwork"));
            cve.Add(new CoreValue("Temperance"));
            cve.Add(new CoreValue("Thankfulness"));
            cve.Add(new CoreValue("Thoroughness"));
            cve.Add(new CoreValue("Thoughtfulness"));
            cve.Add(new CoreValue("Thrift"));
            cve.Add(new CoreValue("Tidiness"));
            cve.Add(new CoreValue("Timeliness"));
            cve.Add(new CoreValue("Traditionalism"));
            cve.Add(new CoreValue("Tranquillity"));
            cve.Add(new CoreValue("Transcendence"));
            cve.Add(new CoreValue("Trust"));
            cve.Add(new CoreValue("Trustworthiness"));
            cve.Add(new CoreValue("Truth"));
            cve.Add(new CoreValue("Understanding"));
            cve.Add(new CoreValue("Unflappability"));
            cve.Add(new CoreValue("Uniqueness"));
            cve.Add(new CoreValue("Unity"));
            cve.Add(new CoreValue("Usefulness"));
            cve.Add(new CoreValue("Utility"));
            cve.Add(new CoreValue("Valour"));
            cve.Add(new CoreValue("Variety"));
            cve.Add(new CoreValue("Victory"));
            cve.Add(new CoreValue("Vigour"));
            cve.Add(new CoreValue("Virtue"));
            cve.Add(new CoreValue("Vision"));
            cve.Add(new CoreValue("Vitality"));
            cve.Add(new CoreValue("Vivacity"));
            cve.Add(new CoreValue("Warmth"));
            cve.Add(new CoreValue("Watchfulness"));
            cve.Add(new CoreValue("Wealth"));
            cve.Add(new CoreValue("Wilfulness"));
            cve.Add(new CoreValue("Willingness"));
            cve.Add(new CoreValue("Winning"));
            cve.Add(new CoreValue("Wisdom"));
            cve.Add(new CoreValue("Wittiness"));
            cve.Add(new CoreValue("Wonder"));
            cve.Add(new CoreValue("Youthfulness"));
            cve.Add(new CoreValue("Zeal"));
            return cve;
        }
    }
}