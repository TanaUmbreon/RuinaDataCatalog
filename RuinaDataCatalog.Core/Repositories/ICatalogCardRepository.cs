using RuinaDataCatalog.Core.Models;

namespace RuinaDataCatalog.Core.Repositories;

/// <summary>
/// Ruina カタログ データベースのバトル ページ情報を取得するための論理的な操作を提供します。
/// </summary>
public interface ICatalogCardRepository
{
    /// <summary>
    /// バトル ページ情報のコレクションを取得します。
    /// </summary>
    public IEnumerable<CardInfo> GetCards();
}
