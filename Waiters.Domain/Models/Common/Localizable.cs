namespace DefaultTemplate.Domain.Common;

public class Localizable
{
    public Localizable()
    {}
    
    public Localizable(string? en, string? ru, string? kk)
    {
        Ru = ru;
        En = en;
        Kk = kk;
    }
    
    public string? Kk { get; set; }
    public string? En { get; set; }
    public string? Ru { get; set; }
}