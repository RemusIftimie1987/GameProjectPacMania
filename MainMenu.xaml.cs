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
using System.Windows.Shapes;

namespace GameProject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainMenuForm : Window
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void myClickHandler(object sender)
        {
        }

        private void HighScoreBtnClick(object sender, EventArgs e)
        {
            HighScoresForm form = new HighScoresForm();
            form.Show();
        }

        private void PlayBtnClick(object sender, EventArgs e)
        {
            GameAreaForm form = new GameAreaForm();
            form.Show();
        }
    }
}
