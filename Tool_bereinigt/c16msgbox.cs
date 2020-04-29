public class c16msgbox
{
    public c16msgbox(){
        this.runmsgboxnegativesuccess = false;
        this.runmsgboxpositiveesuccess = false;
    }

    public bool runmsgboxnegativesuccess;
    public bool runmsgboxpositiveesuccess;

    public void setrunmsgboxpositiveesuccess(bool wahrheitswert, int msgboxjaneinvalue)
    {
        if(msgboxjaneinvalue!=3)
            this.runmsgboxpositiveesuccess = wahrheitswert;
    }

    public void setrunmsgboxnegativeesuccess(bool wahrheitswert, int msgboxjaneinvlue)
    {
        if(msgboxjaneinvlue!=3)
        this.runmsgboxnegativesuccess = wahrheitswert;
    }

    public void runmsgboxpositive(string text, bool durchfuehren, int msgboxjaneinvalue)
    {
        this.runmsgboxpositiveesuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3)
        {
            System.Windows.Forms.MessageBox.Show(text);
            this.runmsgboxpositiveesuccess = true;
        }
    }

    public void runmsgboxnegative(string text, bool durchfuehren, int runmsgboxvalue)
    {
        this.runmsgboxnegativesuccess = false;
        if (durchfuehren&&runmsgboxvalue!=3)
        {
            System.Windows.Forms.MessageBox.Show(text);
            this.runmsgboxnegativesuccess = true;
        }
    }
}