using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Scala.Gezelschapsspelen.Core.Entities
{
    [Table("Spelen")]
    public class Spel
    {
        private string titel;
        private int minimulLeeftijd;
        private int maximumSpelers;
        private int spelDuur;

        [ExplicitKey]
        public string Id { get; private set; }
        public string Titel 
        {
            get { return titel; } 
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Titel kan niet leeg zijn !");
                titel = value.Trim();
            }
        }
        public int MinimumLeeftijd 
        { 
            get { return minimulLeeftijd; }
            set
            {
                if (value < 0) value = 0;
                minimulLeeftijd = value;
            }
        }
        public int MaximumSpelers 
        { 
            get { return maximumSpelers; }
            set
            {
                if (value < 0) value = 0;
                if (value > 500) value = 500;
                maximumSpelers = value;
            }
        }
        public int Spelduur 
        { 
            get { return spelDuur; }
            set
            {
                if (value < 0) value = 0;
                if (value > 600) value = 600;
                spelDuur = value;
            }
        }
        public string CatId { get; set; }

        public Spel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Spel(string titel, int minimumLeeftijd,
            int maximumSpelers, int spelduur, string catId)
        {
            Id = Guid.NewGuid().ToString();
            Titel = titel;
            MinimumLeeftijd = minimumLeeftijd;
            MaximumSpelers = maximumSpelers;
            Spelduur = spelduur;
            CatId = catId;

        }
        internal Spel(string id, string titel, int minimumLeeftijd,
            int maximumSpelers, int spelduur, string catId)
        {
            Id = id;
            Titel = titel;
            MinimumLeeftijd = minimumLeeftijd;
            MaximumSpelers = maximumSpelers;
            Spelduur = spelduur;
            CatId = catId;
        }
        public override string ToString()
        {
            return $"{Titel}";
        }

    }
}
