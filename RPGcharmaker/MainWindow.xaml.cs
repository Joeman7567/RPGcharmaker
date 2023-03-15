using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPGcharmaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random _rpg = new Random();
        private RPGcharacter _character;
        public MainWindow()
        {
            InitializeComponent();
            _character = new RPGcharacter(_rpg);
            updateStats();
            string Junk = "";
            for(int i = 0; i < 10; i++)
            {
                Junk += $"{RPGcharacter.RollDice(5, 20, _rpg).ToString()}\n";
            }
            MessageBox.Show(Junk);
        }

        private void buttonUpdateName_Click(object sender, RoutedEventArgs e)
        {
            _character.Name = nameInput.Text;
        }

        private void re_rolls_Click(object sender, RoutedEventArgs e)
        {
            _character.Roll();
            updateStats();

            double odds = .5;
            _character.PartyMembers.Clear();

            foreach (ListBoxItem i in listPotentialMembers.Items)
            {
                if (_rpg.NextDouble() > odds)
                {
                    RPGcharacter c = new RPGcharacter(_rpg)
                    {
                        Name = i.Content.ToString()
                    };
                    _character.PartyMembers.Add(c);
                }
                //junk
                if(_character.PartyMembers.Count > 0)
                {
                     _character.PartyMembers[0].FavoriteColor = Brushes.BlanchedAlmond;
                }
               
            }
            Brush color1 = Brushes.Tomato;
            Brush color2 = Brushes.Honeydew;
            listPartyMembers.Items.Clear();
            foreach(RPGcharacter c in _character.PartyMembers)
            {
                ListBoxItem i = new ListBoxItem();
                if(c.FavoriteColor != null)
                {
                    i.Background= c.FavoriteColor;
                }
               else if (listPartyMembers.Items.Count % 2 == 0)
                {
                    i.Background = color1; 
                }
                else
                {
                    i.Background = color2;
                }
                i.Content = $"{c.Name} STR: {c.Strength} INT: {c.Intelligence} STA: {c.Stamina} DEX: {c.Dexterity} WIS: {c.Wisdom} CHA: {c.Charisma}";
                listPartyMembers.Items.Add(i);
            }
        }

        private void updateStats()
        {
            strengthText.Text = _character.Strength.ToString();
            wisdomText.Text = _character.Wisdom.ToString();
            dexterityText.Text = _character.Dexterity.ToString();
            staminaText.Text = _character.Stamina.ToString();
            intelligenceText.Text = _character.Intelligence.ToString();
            charismaText.Text = _character.Charisma.ToString();
        }
    }
}
