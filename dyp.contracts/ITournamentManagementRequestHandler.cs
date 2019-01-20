using dyp.contracts.dto;

namespace dyp.contracts
{
    public interface ITournamentManagementRequestHandler
    {
        TournamentCreatedResponseDto Create_tournament(CreateTournamentRequestDto create_Request);
    }
}
