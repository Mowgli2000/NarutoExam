namespace narutoAPI.Data
{
	public class CharResponse
    {
        public List<Character> Characters { get; set; }
    }

	public class Character
	{
		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			
			Character other = (Character)obj;
			return this.id == other.id;
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}
		public int id { get; set; }
		public string name { get; set; }
		public List<string> jutsu { get; set; }
        public List<string> images { get; set; }
        public int rating { get; set; } = 0;
	}
}
