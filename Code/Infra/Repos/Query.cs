using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Infra
{
    public sealed class GetPersonsQuery
    {
        private readonly IPersonsRepo _repo;

        public GetPersonsQuery(IPersonsRepo repo)
        {
            _repo = repo;
        }

        public async Task<List<Person>> GetAsync()
        {
            return await _repo.GetAllAsync();
        }
    }
}
