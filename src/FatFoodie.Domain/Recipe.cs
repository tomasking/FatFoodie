namespace FatFoodie.Domain
{
    public class Recipe
    {
        protected bool Equals(Recipe other)
        {
            return RecipeId == other.RecipeId && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((Recipe)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (RecipeId.GetHashCode() * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        public int? RecipeId { get; set; }

        public string Name { get; set; }
    }
}
