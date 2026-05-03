using LoginNexusBlazorWasm.Models;

namespace LoginNexusBlazorWasm.Services
{
    public class AuthService
    {
        // Propriedade para armazenar o usuário atual
        public User? CurrentUser { get; private set; }

        // Evento para notificar outros componentes (como o Header) que o usuário mudou
        public event Action? OnAuthStateChanged;

        private readonly List<User> _users = new()
        {
            new User { Email = "danielpaiva@nexus.edu", Password = "123", Role = "Professor", Name = "Dr. Daniel Paiva" },
            new User { Email = "aluno@nexus.edu", Password = "123", Role = "Student", Name = "Estudante 01" }
        };

        public User? Authenticate(string email, string password)
        {
            var user = _users.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                CurrentUser = user;
                // Dispara o evento avisando: "Ei, alguém logou!"
                OnAuthStateChanged?.Invoke();
            }

            return user;
        }

        public void Logout()
        {
            CurrentUser = null;
            OnAuthStateChanged?.Invoke();
        }
    }
}