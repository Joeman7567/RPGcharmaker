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
        private RPGcharacter _character = new RPGcharacter();
        public MainWindow()
        {
            InitializeComponent();
            updateStats();

        }

        private void buttonUpdateName_Click(object sender, RoutedEventArgs e)
        {
            _character.Name = nameInput.Text;
        }

        private void re_rolls_Click(object sender, RoutedEventArgs e)
        {  
            _character.Roll();
            updateStats();
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
