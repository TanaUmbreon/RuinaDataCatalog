using LOR_DiceSystem;
using static System.Convert;

namespace RuinaDataCatalog.RuinaDBSetup.Models.ConvertExtensions;

/// <summary>
/// <see cref="DiceBehaviour"/> の拡張メソッドを提供します。
/// </summary>
public static class DiceBehaviourExtension
{
    /// <summary>
    /// このインスタンスを Ruina カタログ データベースで使用するデータ型に変換します。
    /// </summary>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static CardBehaviourInfo ToCardBehaviourInfo(this DiceBehaviour xml)
        => new()
        {
            Min = xml.Min,
            Dice = xml.Dice,
            Type = ToInt32(xml.Type),
            Detail = ToInt32(xml.Detail),
            Motion = ToInt32(xml.MotionDetail),
            MotionDefault = ToInt32(xml.MotionDetailDefault),
            EffectRes = xml.EffectRes,
            Script = xml.Script,
            ActionScript = xml.ActionScript,
            Desc = xml.Desc,
        };
}
