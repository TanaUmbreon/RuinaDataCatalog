using RuinaDataCatalog.Core.Models;

namespace RuinaDataCatalog.Core.Repositories;

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

    /// <summary>
    /// バトル ページ説明テーブル群を再構築し、指定したバトル ページ説明のコレクションでレコードを追加します。
    /// </summary>
    /// <param name="cardDescriptions">テーブルに追加するバトル ページ説明のコレクション。</param>
    void RebuildAndInsertCardDescriptions(IEnumerable<CardDescriptionInfo> cardDescriptions);
}
