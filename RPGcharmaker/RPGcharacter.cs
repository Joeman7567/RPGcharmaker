using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Navigation;

namespace RPGcharmaker
{
    internal class RPGcharacter
    {
        private int _strength;
        private int _charisma;
        private int _stamina;
        private int _intelligence;
        private int _dexterity;
        private int _wisdom;
        private int _maxWisdom = 20;
        private int _maxCharisma = 20;
        private int _maxStrength = 20;
        private int _maxIntelligence = 20;
        private int _maxDexterity = 20;
        private int _maxStamina = 20;
        private Brush _favoriteColor;
        private List<RPGcharacter> _partyMembers = new List<RPGcharacter>();

        private CharacterClasses _characterClass = CharacterClasses.None;
        private Random _rng = new Random();

        #region Properties
        public string Name { get; set; }
        public long XP { get; set; }
        public int level { get; set; }

        public CharacterClasses CharacterClass
        { get { return _characterClass; }
            set { _characterClass = value; }
        }
        public int Strength { get { return _strength; } }
        public int Charisma { get { return _charisma; } }
        public int Stamina { get { return _stamina; } }
        public int Intelligence { get { return _intelligence; } }
        public int Dexterity { get { return _dexterity; } }
        public int Wisdom { get { return _wisdom; } }
        public Brush FavoriteColor
        {
            get { return _favoriteColor; }
            set { _favoriteColor = value; }
        }

        public List<RPGcharacter> PartyMembers
        {
            get { return _partyMembers; }
            set { _partyMembers = value; }
        }

        #endregion Properties
        public RPGcharacter(Random rng)
        {
            _rng = rng;
            Roll();
        }

        public void Roll()
        {
            _charisma = _rng.Next(1, _maxCharisma + 1);
            _wisdom = _rng.Next(1, _maxWisdom + 1);
            _strength = _rng.Next(1, _maxStrength + 1);
            _intelligence = _rng.Next(1, _maxIntelligence + 1);
            _stamina = _rng.Next(1, _maxStamina + 1);
            _dexterity = _rng.Next(1, _maxDexterity + 1);
        }
        public static int RollDice (int numberOfDice, int sidesPerdice, Random r)
        {
        int total = 0;

            for (int i = 0; i < numberOfDice; i++)
            {
                total = total + r.Next(1, sidesPerdice + 1);
            }

            return total;
        }

    }
    public enum CharacterClasses
    {
        None = 0,
        Ranger,
        Mage,
        Melee,
        Rouge,
        Bard,
        Goliath,
        Palidian
    }
}
