using LOR_XML;
using RuinaDataCatalog.Core.Models;

namespace RuinaDataCatalog.RuinaDBSetup.Services;

/// <summary>
/// <see cref="BattleCardDesc"/> の拡張メソッドを提供します。
/// </summary>
public static class BattleCardDescExtension
{
    /// <summary>
    /// このインスタンスを Ruina カタログ データベースで使用するデータ型に変換します。
    /// </summary>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static CardDescriptionInfo ToCardDescriptionInfo(this BattleCardDesc xml)
        => new()
        {
            Id = xml.cardID,
            LocalizedName = xml.cardName ?? "",
            Ability = xml.ability ?? "",
            Behaviour = xml.behaviourDescList.Select(b => b.ToCardBehaviourDescriptionInfo()).ToArray(),
        };
}
