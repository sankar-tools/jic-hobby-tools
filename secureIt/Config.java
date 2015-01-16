

public class Config
{

	public String FileExtList;
	public String StorePath;
	public String LogFile;
	public String authUser;
	public String authCode;
	public String[] ParseDirs;
	public String[] SkipDirs;
	public boolean ScanAllDirs;
	public boolean ScanOnly;
	public boolean ShowUI;
	public long MinSizeKb;
	
	private static Config configData = null;
	
	private Config()
	{}
	
	public static Config Instance()
	{
		if (configData == null)
		{
			configData = new Config();
			configData.loadConfig();
		}

		return configData;
	}
	
	
	private void loadConfig()
	{
		configData.FileExtList = "jpg;png";
		configData.StorePath = ".\\store\\";
		configData.LogFile = "this.log";
		configData.authUser = "sans";
		configData.authCode = "sans";
		configData.ScanAllDirs = true;
		configData.ScanOnly = false;
		configData.MinSizeKb = 150;
		
	}
	
	
}