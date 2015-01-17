public class Config
{

	public String fileExtList;
	public String storePath;
	public String logFile;
	public String authUser;
	public String authCode;
	public Queue parseDirs;
	public String[] skipDirs;
	public boolean scanAllDirs;
	public boolean scanOnly;
	public boolean showUI;
	public long minSizeKb;
	public int bufferSize;
	
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
		configData.parseDirs = new Queue();
		
		configData.fileExtList = "jpg;png";
		configData.storePath = ".\\store\\";
		configData.logFile = "this.log";
		configData.authUser = "sans";
		configData.authCode = "sans";
		configData.scanAllDirs = true;
		configData.scanOnly = false;
		configData.minSizeKb = 150;
		configData.bufferSize = 8192;
		
	}
	
	
}