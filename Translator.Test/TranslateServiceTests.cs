namespace Translator.Test
{
    public class TranslateServiceTests
    {
        [Fact]
        public void GetTranslationMustReturnCorrectValue()
        {
            // 1 шаг пишем зная что еще нету сервисов
            var translationService = new TranslationService();
            translationService.AddTranslation("orange", "апельсин");

            Assert.Equal("апельсин", translationService.GetTranslation("orange"));
        }
    }
}