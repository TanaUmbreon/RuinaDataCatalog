using RuinaDataCatalog.RuinaDBSetup.Models;

namespace RuinaDataCatalog.RuinaDBSetup.Repositries;

public interface ICatalogSetupRepository
{
    void SetupEnumDescriptions();

    void SetupCards(IEnumerable<CardInfo> cards);

    void SetupCardDescriptions(IEnumerable<CardDescriptionInfo> cardDescriptions);
}
