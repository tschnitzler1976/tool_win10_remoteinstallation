public class c02readalllinesfromtextfile{
    public string [] readalllinesfromtextfile;
    public bool runreadalllinesfromtextfilesuccess;

    public c02readalllinesfromtextfile(){
    }
    public void runreadalllinesfromfile(string path, bool durchfuehren, int msgboxjaneinvalue){
        this.runreadalllinesfromtextfilesuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3)
        {
            readalllinesfromtextfile = System.IO.File.ReadAllLines(path);
            this.runreadalllinesfromtextfilesuccess = true;
        }
    }
}