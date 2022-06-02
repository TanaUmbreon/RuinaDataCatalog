namespace RuinaDataCatalog.Core.Models;

/// <summary>
/// ローカライズされたバトル ページ情報を格納します。
/// </summary>
public class LocalizedCardInfo
{
    /// <summary>
    /// バトル ページの数値 ID を取得または設定します。
    /// </summary>
    public int Id { get; set; } = 0;

    /// <summary>
    /// バトル ページ名を取得または設定します。
    /// </summary>
    public string Name { get; set; } = "";

    /// <summary>
    /// アートワーク名を取得または設定します。
    /// </summary>
    public string Artwork { get; set; } = "";

    /// <summary>
    /// レアリティを取得または設定します。
    /// </summary>
    public int Rarity { get; set; } = 0;

    /// <summary>
    /// レアリティ名を取得または設定します。
    /// </summary>
    public string RarityName { get; set; } = "";

    /// <summary>
    /// 攻撃範囲を取得または設定します。
    /// </summary>
    public int Range { get; set; } = 0;

    /// <summary>
    /// 攻撃範囲名を取得または設定します。
    /// </summary>
    public string RangeName { get; set; } = "";

    /// <summary>
    /// コストを取得または設定します。
    /// </summary>
    public int Cost { get; set; } = 0;

    /// <summary>
    /// 所属するチャプターを取得または設定します。
    /// </summary>
    public int Chapter { get; set; } = 0;
}
