using BusinessLogicLayer.DataClasses;

namespace BusinessLogicLayer.Interfaces;
public interface ICodingSessionRepository
{
    bool AddCodingSession(CodingSession session);
    List<CodingSession> GetAllCodingSessions();
    bool UpdateCodingSession(CodingSession session);
    bool DeleteCodingSession(int? id);
}
