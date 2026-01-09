using System;

public struct GuideText
{
    public string[] Text;
    public ConsoleColor Color;
   
    public GuideText(ConsoleColor color)
    {
        Text = new string[]
        {
            "    조작키 안내",
            "        위",
            "        ↑",
            "  ←     ↓     →",
            "왼 쪽 아 래 오른쪽",
            "Enter : 선택 / 입력 완료",
            "Tab : 가방 열기",
            "ESC : 닫기"
        };
        Color = color;
    }
}