// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

namespace UnityEngine.Experimental.UIElements
{
    public class PopupWindow : BaseTextElement
    {
        private VisualElement m_ContentContainer;

        public PopupWindow()
        {
            m_ContentContainer = new VisualElement() { name = "ContentContainer" };
            shadow.Add(m_ContentContainer);
        }

        public override VisualElement contentContainer // Contains full content, potentially partially visible
        {
            get { return m_ContentContainer; }
        }
    }
}
