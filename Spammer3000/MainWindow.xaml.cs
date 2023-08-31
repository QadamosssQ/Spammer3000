using System.Windows;
using System.Windows.Forms;
using WindowsInput;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Spammer3000
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void StartSpam(object sender, RoutedEventArgs e)
        {
            

            string contentToSpam = ContentToSpam.Text;

            int countClicks = 0;

            int delay = 0;

            if(contentToSpam == null)
            {
                err();
            }

            if (int.TryParse(repeatCountInput.Text, out int inputValue))
            {
                countClicks = inputValue; 
            }
            else
            {
                err();
            }

            if (int.TryParse(DelayCount.Text, out int inputValue2))
            {
                delay = inputValue2;
            }
            else
            {
                err();
            }

            StartSpam(contentToSpam, countClicks, delay);


        }

        public void StartSpam(string content, int clicks, int delay)
        {
            InputSimulator inputSimulator = new InputSimulator();

            MessageBox.Show("Za 5s zacznie spamić", "Start");

            System.Threading.Thread.Sleep(1000);

            for (int i = 0; i < clicks; i++)
            {
                inputSimulator.Keyboard.TextEntry(content);

                inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);

                System.Threading.Thread.Sleep(delay);
            }

        }

        public void err()
        {
            MessageBox.Show("Brak danych", "Błąd");

            return;
        }

    }
}
