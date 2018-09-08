using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;


namespace TwilightImperium4Pregame
{
    public partial class TwilightImperium4Pregame : Form
    {
        public TwilightImperium4Pregame()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StatusLabel.Visible = false;
            try
            {
                var players = new List<Tuple<string,string>>();
                if (Player1TB.Text.Trim() != "")
                {
                    if (Player1RaceGroups.Text.Trim() == "") throw new NoRaceGroupsException();
                    players.Add(new Tuple<string,string>(Player1TB.Text.Trim(), Player1RaceGroups.Text.Trim()));
                }
                if (Player2TB.Text.Trim() != "")
                {
                    if (Player2RaceGroups.Text.Trim() == "") throw new NoRaceGroupsException();
                    players.Add(new Tuple<string, string>(Player2TB.Text.Trim(), Player2RaceGroups.Text.Trim()));
                }
                if (Player3TB.Text.Trim() != "")
                {
                    if (Player3RaceGroups.Text.Trim() == "") throw new NoRaceGroupsException();
                    players.Add(new Tuple<string, string>(Player3TB.Text.Trim(), Player3RaceGroups.Text.Trim()));
                }
                if (Player4TB.Text.Trim() != "")
                {
                    if (Player4RaceGroups.Text.Trim() == "") throw new NoRaceGroupsException();
                    players.Add(new Tuple<string, string>(Player4TB.Text.Trim(), Player4RaceGroups.Text.Trim()));
                }
                if (Player5TB.Text.Trim() != "")
                {
                    if (Player5RaceGroups.Text.Trim() == "") throw new NoRaceGroupsException();
                    players.Add(new Tuple<string, string>(Player5TB.Text.Trim(), Player5RaceGroups.Text.Trim()));
                }
                if (Player6TB.Text.Trim() != "")
                {
                    if (Player6RaceGroups.Text.Trim() == "") throw new NoRaceGroupsException();
                    players.Add(new Tuple<string, string>(Player6TB.Text.Trim(), Player6RaceGroups.Text.Trim()));
                }

                var reader = new StreamReader("racepick.json");
                var json = reader.ReadToEnd();
                Races availableRaces = new JavaScriptSerializer().Deserialize<Races>(json);
                Random rnd = new Random();
   
                foreach (Tuple<string,string> player in players)
                {
                    
                    string text = "";
                    foreach (string raceGroup in player.Item2.Split(','))
                    {
                        var availableRacesInRaceGroup = availableRaces.RaceList.Where(r => r.RaceGroup == raceGroup.Trim()).ToList();
                        if (availableRacesInRaceGroup.Count() == 0) throw new NoRaceInRaceGroupException();
                        var chosenRace = availableRacesInRaceGroup[rnd.Next(availableRacesInRaceGroup.Count)];
                        availableRaces.RaceList.Remove(chosenRace);
                        text += chosenRace.Name + "<br /><br />" + chosenRace.Description + "<br /><br /><br />";
                    }
                    System.IO.File.WriteAllText(player.Item1 + ".html", text);
                }
           


                StatusLabel.Text = "Player Information Files Successfully Generated";
                StatusLabel.Visible = true;
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Player Information Files Generation Failure";
                MessageBox.Show("Player Information Files Generation Failure:\r\n" + ex.Message);
                StatusLabel.Visible = true;
            }
        }


    }
}
