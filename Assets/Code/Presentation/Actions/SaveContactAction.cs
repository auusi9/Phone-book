using Code.Data.Vo;

namespace Code.Presentation.Actions
{
    public class SaveContactAction
    {
        public ContactVo ContactVo { get; }

        public SaveContactAction(ContactVo contactVo)
        {
            ContactVo = contactVo;
        }
    }
}