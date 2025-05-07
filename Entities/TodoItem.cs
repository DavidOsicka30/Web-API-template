// Author: David Osička
// Licence: https://buymeacoffee.com/davidosicka
using System.ComponentModel.DataAnnotations;

namespace DavidOsicka30.CSharp.WebApiTemplate.Entities;


/// <summary>
/// Simple POCO object
/// </summary>
public class TodoItem
{
    [Key]
    public int Id { get; init; }
    // ReSharper disable once EntityFramework.ModelValidation.UnlimitedStringLength
    public string? Name { get; init; } = null!;
    public bool IsCompleted { get; init; }
}