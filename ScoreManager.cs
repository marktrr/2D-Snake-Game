/* FINAL GAME PROJECT
 * 
 * File: ScoreManager.cs 
 * Full Name: Hy Minh Tran 
 * Student #: 7910276 
 * Date created: 12/5/2018 
 * Finished: 9:00 AM December 10, 2018.
 */

using HMFinal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HMFinal
{
    public class ScoreManager
    {
        private static string _fileName = "scores.xml";

        public List<Score> Highscores { get; private set; }

        public List<Score> Scores { get; private set; }

        /// <summary>
        /// Default method, generate the List<Score> which 5 default value.
        /// </summary>
        public ScoreManager()
          : this(new List<Score>())
        {
            Add(new Score()
            {
                Value = 4,
            }
            );
            Add(new Score()
            {
                Value = 3,
            }
               );
            Add(new Score()
            {
                Value = 2,
            }
            );
            Add(new Score()
            {
                Value = 1,
            }
            );
            Add(new Score()
            {
                Value = 0,
            }
            );
        }

        public ScoreManager(List<Score> scores)
        {
            Scores = scores;

            UpdateHighscores();
        }

        /// <summary>
        /// Add new Score to List<Score>, then update the highscore list.
        /// </summary>
        public void Add(Score score)
        {
            Scores.Add(score);

            Scores = Scores.OrderByDescending(c => c.Value).ToList(); // Orders the list so that the higher scores are first

            UpdateHighscores();
        }


        /// <summary>
        /// Load method. 
        /// This will read the data from the xml file.
        /// </summary>
        public static ScoreManager Load()
        {
            // Create a new file if the file is not exist
            if (!File.Exists(_fileName))
                return new ScoreManager();

            using (var reader = new StreamReader(new FileStream(_fileName, FileMode.Open)))
            {
                var serilizer = new XmlSerializer(typeof(List<Score>));

                var scores = (List<Score>)serilizer.Deserialize(reader);

                return new ScoreManager(scores);
            }
        }

        /// <summary>
        /// This method will take top 5 elements from xml file.
        /// </summary>
        public void UpdateHighscores()
        {
            Highscores = Scores.Take(5).ToList(); 
        }


        /// <summary>
        /// Save the new score to the list.
        /// </summary>
        public static void Save(ScoreManager scoreManager)
        {
            using (var writer = new StreamWriter(new FileStream(_fileName, FileMode.Create)))
            {
                var serilizer = new XmlSerializer(typeof(List<Score>));

                serilizer.Serialize(writer, scoreManager.Scores);
            }
        }
    }
}