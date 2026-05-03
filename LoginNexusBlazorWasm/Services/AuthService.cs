using LoginNexusBlazorWasm.Models;

namespace LoginNexusBlazorWasm.Services
{
    public class AuthService
    {
        private readonly List<User> _users = new()
    {
        new User { Email = "professor@nexus.edu", Password = "123", Role = "Professor", Name = "Dr. Arnaldo" },
        new User { Email = "aluno@nexus.edu", Password = "123", Role = "Student", Name = "Estudante 01" }
    };

        public User? Authenticate(string email, string password)
        {
            return _users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}