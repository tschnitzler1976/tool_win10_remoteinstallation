public class c15checkstringempty
{
    public bool checkstringemptysuccess;
    public bool stringnotempty;
    public bool stringempty;

    public c15checkstringempty()
    {
        this.stringnotempty = false;
        this.stringempty = false;
        this.checkstringemptysuccess = false;
    }

    public void checkstringempty(string text, bool durchfuehren, int msgboxjaneinresult)
    {
        this.checkstringemptysuccess = false;
        this.stringnotempty = false;
        this.stringempty = false;
        if (durchfuehren&&msgboxjaneinresult!=3)
        {
            if (text.Length != 0)
            {
                this.stringnotempty = true;
            }
            else
            {
                this.stringempty = true;
            }
            this.checkstringemptysuccess = true;
        }
    }

}