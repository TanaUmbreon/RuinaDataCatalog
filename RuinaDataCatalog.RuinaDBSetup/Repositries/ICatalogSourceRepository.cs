using LOR_DiceSystem;
using LOR_XML;

namespace RuinaDataCatalog.RuinaDBSetup.Repositries;

/// <summary>
/// Ruina カタログ データの元データに対する論理的な操作を提供します。
/// </summary>
public interface ICatalogSourceRepository
{
    /// <summary>
    /// バトル ページ情報のコレクションを取得します。
    /// </summary>
    IEnumerable<DiceCardXmlInfo> Cards { get; }

    /// <summary>
    /// バトル ページ説明のコレクションを取得します。
    /// </summary>
    IEnumerable<BattleCardDesc> CardDescriptions { get; }
}
