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

    /// <summary>
    /// バトル ページ情報テーブル群を再構築し、指定したバトル ページ情報のコレクションでレコードを追加します。
    /// </summary>
    /// <param name="cards">テーブルに追加するバトル ページ情報のコレクション。</param>
    void RebuildAndInsertCards(IEnumerable<CardInfo> cards);

    void SetupCardDescriptions(IEnumerable<CardDescriptionInfo> cardDescriptions);
}
