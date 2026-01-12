public class Submit
{
    public int[] Answer;

    private Ractangle _outLine;

    public Submit() => Init();
    public void Init()
    {
        Answer = new int[4];
        _outLine = new Ractangle(width: 40, height:15);
    }
    //팝업 창
    public void Render()
    {
        _outLine.Draw();
    }
    // 다이얼 식 정답
    // 위아래 입력하면 숫자변경
    // 왼쪽 오른쪽으로 칸 변경

}
