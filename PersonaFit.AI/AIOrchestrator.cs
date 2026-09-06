using PersonaFit.AI.Models;

namespace PersonaFit.AI
{
    public class AIOrchestrator
    {
        public async Task<Persona> GetPersonaAsync(string name)
        {
            return await Task.FromResult(new Persona(1, "TestPersona", "Test Description"));
        }
    }
}
