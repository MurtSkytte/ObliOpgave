namespace ObliOpgave1
{
    public class Trophy
    {
        public int Id { get; set; }
        public string Competition { get; set; }
        public int Year { get; set; }

        public Trophy(int id, string competition, int year)
        {
            Id = id;
            Competition = competition;
            Year = year;
        }

        public Trophy()
        {
        }

        public override string ToString()
        {
            return $"{Id} {Competition} {Year}";
        }

        public void ValidateCompition()
        {
            if (Competition == null)
            {
                throw new ArgumentNullException(nameof(Competition), "Competition cannot be null");
            }
            if (Competition.Length < 3)
            {
                throw new ArgumentException(nameof(Competition), "Competition cannot be shorter than 3");
            }
        }

        public void ValidateYear()
        {
            if (Year > 2024 || Year < 1970)
            {
                throw new ArgumentOutOfRangeException(nameof(Year), "Year must be between 1970 and 2024");
            }
        }

        public void Validate()
        {
            ValidateCompition();
            ValidateYear();
        }
    }
}
