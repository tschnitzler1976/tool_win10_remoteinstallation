public class c04createnameoffilename{

    public c04createnameoffilename(){
        this.initializelistforfilenamessuccess = false;
        this.runcreatepartoffilenamesuccess = false;
    }
  
    public System.Collections.Generic.List<string> listwithfilenames;
    public string filename;
    public bool initializelistforfilenamessuccess;
    public bool runcreatepartoffilenamesuccess;

    public void initializelistforfilenames(bool durchfuehren, int msgboxjaneinvalue){
        this.initializelistforfilenamessuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3) { 
            this.listwithfilenames=new System.Collections.Generic.List<string>();
            this.initializelistforfilenamessuccess = true;
        }
    }

    public void runcreatepartoffilename(string pathtofile,string prefix, string postfix, bool durchfuehren,int msgboxjaneinvalue){

        this.runcreatepartoffilenamesuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3)
        {
            System.TimeSpan t = System.DateTime.UtcNow - new System.DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            string secondsSinceEpochasstring = secondsSinceEpoch.ToString();
            this.filename = pathtofile + prefix + "_" + secondsSinceEpochasstring + postfix;
            this.listwithfilenames.Add(this.filename);
            this.runcreatepartoffilenamesuccess = true;
        }
    }
}