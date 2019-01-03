using dyp.contracts.dto;

namespace dyp.contracts
{
    public interface IPersonsRequestHandler
    {
        PersonResponseDto[] Load_persons();
        PersonResponseDto Create_person(CreatePersonRequestDto createRequest);
        PersonResponseDto Update_person(UpdatePersonRequestDto updateRequest);
    }
}
