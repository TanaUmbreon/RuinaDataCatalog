using RuinaDataCatalog.RuinaDBSetup.Models;

namespace RuinaDataCatalog.RuinaDBSetup.Repositries;

/// <summary>
/// Ruina カタログ データベースをセットアップするための論理的な操作を提供します。
/// </summary>
public interface ICatalogSetupRepository
{
    /// <summary>
    /// 列挙値の説明テーブル群を再構築し、固定のレコードを追加します。
    /// </summary>
    void RebuildAndInsertEnumDescriptions();

    void SetupCards(IEnumerable<CardInfo> cards);

    void SetupCardDescriptions(IEnumerable<CardDescriptionInfo> cardDescriptions);
}
