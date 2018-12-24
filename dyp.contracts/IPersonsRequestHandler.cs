using dyp.contracts.dto;
using System;

namespace dyp.contracts
{
    public interface IPersonsRequestHandler
    {
        PersonsResponseDto Load_persons();
        string Load_person(Guid personId);
    }
}
