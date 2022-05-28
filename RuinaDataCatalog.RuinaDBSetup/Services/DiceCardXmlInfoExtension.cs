using LOR_DiceSystem;
using RuinaDataCatalog.Core.Models;
using static System.Convert;

namespace RuinaDataCatalog.RuinaDBSetup.Services;

/// <summary>
/// <see cref="DiceCardXmlInfo"/> の拡張メソッドを提供します。
/// </summary>
public static class DiceCardXmlInfoExtension
{
    /// <summary>
    /// このインスタンスを Ruina カタログ データベースで使用するデータ型に変換します。
    /// </summary>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static CardInfo ToCardInfo(this DiceCardXmlInfo xml)
        => new()
        {
            Id = xml._id,
            Name = xml.workshopName ?? "",
            TextId = xml._textId,
            Artwork = xml.Artwork ?? "",
            Rarity = ToInt32(xml.Rarity),
            Range = ToInt32(xml.Spec.Ranged),
            Cost = xml.Spec.Cost,
            Affection = ToInt32(xml.Spec.affection),
            EmotionLimit = xml.Spec.emotionLimit,
            Script = xml.Script ?? "",
            ScriptDesc = xml.ScriptDesc ?? "",
            Chapter = xml.Chapter,
            SpecialEffect = xml.SpecialEffect ?? "",
            SkinChange = xml.SkinChange ?? "",
            SkinChangeType = ToInt32(xml.SkinChangeType),
            SkinHeight = xml.SkinHeight,
            MapChange = xml.MapChange ?? "",
            Priority = xml.Priority,
            PriorityScript = xml.PriorityScript ?? "",
            Category = ToInt32(xml.category),
            MaxCooltimeForEgo = xml.EgoMaxCooltimeValue,
            MaxNum = xml.MaxNum,
            Option = xml.optionList.Select(o => ToInt32(o)).ToArray(),
            Keyword = xml.Keywords,
            Behaviour = xml.DiceBehaviourList.Select(b => b.ToCardBehaviourInfo()).ToArray(),
        };
}
