using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntitiesLayer;
using BusinessLogicLayer;

namespace UserInterfaceLayer
{
    public partial class RouteSeatSelectionForm : Form
    {
        public RouteSeatSelectionForm()
        {
            InitializeComponent();
        }

        private void btnRouteSearch_Click(object sender, EventArgs e)
        {
            //Tablodan 2+1 mi 2+2 mi yani otobusun enindeki koltuk sayısı
            int tablodanyataykoltuksayısı = 3;
            //Tablodan gelen otobusun koltuk sayısı bölü yukardaki "tablodanyataykoltuksayısı" bu sonucu verecek
            int tablodandikeykoltuksayısı = 10;
            int seatNumber = 1;
            for (int i = 0; i < tablodanyataykoltuksayısı; i++)
            {
                for (int j = 0; j < tablodandikeykoltuksayısı; j++)
                {
                    Button button = new Button();
                    button.Size = new Size(40, 40);
                    button.Text = seatNumber.ToString();
                    button.Tag = seatNumber;
                    button.Location = new Point(20 + (50 * i), 20 + (50 * j));
                    button.BringToFront();
                    this.Controls.Add(button);
                    grpboxSeatSelection.Controls.Add(button);
                    button.Click += Button_Click;
                    button.BackgroundImage = Image.FromFile("..\\..\\Seats\\EmptySeat.png");
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    seatNumber++;
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button senderButton = new Button();
            senderButton.BackgroundImage = Image.FromFile("..\\..\\Seats\\EmptySeat.png");
            senderButton.BackgroundImageLayout = ImageLayout.Stretch;
          
        }

        private void RouteSeatSelectionForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            TicketForm useTicket = new TicketForm();
            useTicket.Show();
            this.Hide();

        }
    }
}
