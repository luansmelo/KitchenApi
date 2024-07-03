namespace Kitchen.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; private set; } = String.Empty;
        public string Email { get; private set; } = String.Empty;
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt {  get; private set; }

    }
}
