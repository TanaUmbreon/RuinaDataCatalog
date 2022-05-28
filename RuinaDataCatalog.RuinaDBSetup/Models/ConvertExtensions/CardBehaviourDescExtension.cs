using LOR_XML;

namespace RuinaDataCatalog.RuinaDBSetup.Models.ConvertExtensions;

/// <summary>
/// <see cref="CardBehaviourDesc"/> の拡張メソッドを提供します。
/// </summary>
public static class CardBehaviourDescExtension
{
    /// <summary>
    /// このインスタンスを Libray of Ruina データベースで使用するデータ型に変換します。
    /// </summary>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static CardBehaviourDescriptionInfo ToCardBehaviourDescriptionInfo(this CardBehaviourDesc xml)
        => new()
        {
            Id = xml.behaviourID,
            BehaviourDesc = xml.behaviourDesc ?? "",
        };
}
