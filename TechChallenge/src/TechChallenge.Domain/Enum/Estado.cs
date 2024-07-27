namespace TechChallenge.Domain.Enum
{
    public enum Estado
    {
        DF,
        GO,
        MT,
        MS,
        AL,
        BA,
        CE,
        MA,
        PB,
        PE,
        PI,
        RN,
        SE,
        AC,
        AP,
        AM,
        PA,
        RO,
        RR,
        TO,
        ES,
        MG,
        RJ,
        SP,
        PR,
        RS,
        SC
    }

    public static class EstadoExtension
    {
        public static bool DDDEstaValido(this Estado estado, int DDD)
        {
            switch (estado)
            {
                case Estado.DF: return new[] { 61 }.Contains(DDD);
                case Estado.GO: return new[] { 62, 64 }.Contains(DDD);
                case Estado.MT: return new[] { 65, 66 }.Contains(DDD);
                case Estado.MS: return new[] { 67 }.Contains(DDD);
                case Estado.AL: return new[] { 82 }.Contains(DDD);
                case Estado.BA: return new[] { 71, 73, 74, 75, 77 }.Contains(DDD);
                case Estado.CE: return new[] { 85, 88 }.Contains(DDD);
                case Estado.MA: return new[] { 98, 99 }.Contains(DDD);
                case Estado.PB: return new[] { 83 }.Contains(DDD);
                case Estado.PE: return new[] { 81, 87 }.Contains(DDD);
                case Estado.PI: return new[] { 86, 89 }.Contains(DDD);
                case Estado.RN: return new[] { 84 }.Contains(DDD);
                case Estado.SE: return new[] { 79 }.Contains(DDD);
                case Estado.AC: return new[] { 68 }.Contains(DDD);
                case Estado.AP: return new[] { 96 }.Contains(DDD);
                case Estado.AM: return new[] { 92, 97 }.Contains(DDD);
                case Estado.PA: return new[] { 91, 93, 94 }.Contains(DDD);
                case Estado.RO: return new[] { 69 }.Contains(DDD);
                case Estado.RR: return new[] { 95 }.Contains(DDD);
                case Estado.TO: return new[] { 63 }.Contains(DDD);
                case Estado.ES: return new[] { 27, 28 }.Contains(DDD);
                case Estado.MG: return new[] { 31, 32, 33, 34, 35, 37, 38 }.Contains(DDD);
                case Estado.RJ: return new[] { 21, 22, 24 }.Contains(DDD);
                case Estado.SP: return new[] { 11, 12, 13, 14, 15, 16, 17, 18, 19 }.Contains(DDD);
                case Estado.PR: return new[] { 41, 42, 43, 44, 45, 46 }.Contains(DDD);
                case Estado.RS: return new[] { 51, 53, 54, 55 }.Contains(DDD);
                case Estado.SC: return new[] { 47, 48, 49 }.Contains(DDD);
                default: return false;
            }
        }
    }
}
