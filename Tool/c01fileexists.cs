public class c01fileexists{

    public bool fileexists;
    public bool filedoesnotexist;

    public c01fileexists(){
        this.fileexists = false;
        this.filedoesnotexist = true;
    }

    public void runopenfile(string path, bool durchfuehren, int msgboxjaneinvalue){
        this.fileexists = false;
        this.filedoesnotexist = true;
        if (durchfuehren&&msgboxjaneinvalue!=3) { 
            if (System.IO.File.Exists(path)){
                this.fileexists=true;
                this.filedoesnotexist = false;
            }
        }
    }
}