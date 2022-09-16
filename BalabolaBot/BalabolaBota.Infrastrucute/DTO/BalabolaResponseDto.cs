namespace BalabolaBot.Infrastrucute.DTO;

public record BalabolaResponseDto(int BadQuery, int Error, int Intro, int IsCached, string Query, string Signature,
    string Text);