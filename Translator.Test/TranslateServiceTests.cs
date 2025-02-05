namespace Translator.Test
{
    public class TranslateServiceTests
    {
        [Fact]
        public void GetTranslationMustReturnCorrectValue()
        {
            // 1 ��� ����� ���� ��� ��� ���� ��������
            var translationService = new TranslationService();
            translationService.AddTranslation("orange", "��������");

            Assert.Equal("��������", translationService.GetTranslation("orange"));
        }
    }
}