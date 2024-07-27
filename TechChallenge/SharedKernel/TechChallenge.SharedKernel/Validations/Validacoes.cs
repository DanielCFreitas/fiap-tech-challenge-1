using System.Text.RegularExpressions;

namespace TechChallenge.SharedKernel.Validations
{
    public static class Validacoes
    {
        public static void ExcecaoSeVazioOuNulo(string valor, string mensagem)
        {
            if (string.IsNullOrEmpty(valor)) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeVazioOuNulo(DateTime valor, string mensagem)
        {
            if (DateTime.MinValue == valor) throw new DomainException(mensagem);
        }

        public static void ExcesaoSeNaoForIgualA(int valor, int comparador, string mensagem)
        {
            if (valor != comparador) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeMaiorQue(decimal valor, decimal comparador, string mensagem)
        {
            if (valor > comparador) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeVazio(Guid valor, string mensagem)
        {
            if (Guid.Empty == valor) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeIgualA(int valor, int comparador, string mensagem)
        {
            if (valor == comparador) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeNaoSeguirPadraoDaExpressaoRegular(string valor, string padrao, string mensagem)
        {
            if (!Regex.IsMatch(valor, padrao)) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeNaoForVazioENaoSeguirPadraoDaExpressaoRegular(string valor, string padrao, string mensagem)
        {
            if (!string.IsNullOrEmpty(valor)) ExcecaoSeNaoSeguirPadraoDaExpressaoRegular(valor, padrao, mensagem);
        }

        public static void ExcecaoSeNulo(object valor, string mensagem)
        {
            if (valor == null) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeVerdadeiro(bool valor, string mensagem)
        {
            if (valor) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeMaiorQue(DateTime valor, DateTime comparador, string mensagem)
        {
            if (valor > comparador) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeMenorQue(decimal valor, decimal comparador, string mensagem)
        {
            if (valor < comparador) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeMaiorQue(int valor, int comparador, string mensagem)
        {
            if (valor > comparador) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeMenorQue(DateTime valor, DateTime comparador, string mensagem)
        {
            if (valor < comparador) throw new DomainException(mensagem);
        }

        public static void ExcesaoSeEnumIncorreto(int valor, Type type, string mensagem)
        {
            if (!Enum.IsDefined(type, valor)) throw new DomainException(mensagem);
        }

        public static void ExcecaoSeFalso(bool valor, string mensagem)
        {
            if (!valor) throw new DomainException(mensagem);
        }

    }
}
