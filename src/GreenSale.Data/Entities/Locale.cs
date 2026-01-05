using System.ComponentModel.DataAnnotations;

namespace GreenSale.Data.Entities;

/// <summary>
/// Languages, Key is unique: uz, ru, en, uzc ...
/// </summary>
public class Locale
{
    [Key]
    [StringLength(10)]
    public string Key { get; set; } = string.Empty;

    [StringLength(32)]
    public string Title { get; set; } = string.Empty;

    [StringLength(15)]
    public string Code { get; set; } = string.Empty;
}

public interface ILocalization
{
    string LocaleKey { get; }
}

public interface ILocalized<T> where T : ILocalization
{
    List<T> Locales { get; set; }
}

public class EntityLocale : IEntity, ILocalization
{
    public required string LocaleKey { get; set; }
    public Locale Locale { get; set; } = default!;
}